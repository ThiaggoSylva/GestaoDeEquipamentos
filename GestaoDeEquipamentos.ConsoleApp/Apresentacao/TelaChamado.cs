using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaChamado : TelaBase
{
    public RepositorioChamado repositorioChamado = null!;
    public RepositorioEquipamento repositorioEquipamento = null!;

    public string? ObterEscolhaMenuPrincipal()
    {
        ExibirCabecalho("Gestão de Chamados", "Menu Principal");
        Console.WriteLine("1 - Cadastrar chamado");
        Console.WriteLine("2 - Editar chamado");
        Console.WriteLine("3 - Excluir chamado");
        Console.WriteLine("4 - Visualizar chamados");
        Console.WriteLine("S - Sair");
        ExibirSeparador();
        Console.Write("> ");

        return Console.ReadLine()?.ToUpper();
    }

    public void Cadastrar()
    {
        ExibirCabecalho("Gestão de Chamados", "Cadastro de Chamado");

        Equipamento? equipamentoSelecionado = SelecionarEquipamento("Digite o id do equipamento que deseja selecionar: ");

        if (equipamentoSelecionado == null)
        {
            ExibirMensagem("Não foi possível encontrar o equipamento informado.");
            return;
        }

        Chamado novoChamado = ObterDadosChamado(equipamentoSelecionado, DateTime.Now);

        repositorioChamado.Cadastrar(novoChamado);

        ExibirMensagem($"O registro \"{novoChamado.id}\" foi cadastrado com sucesso.");
    }

    public void Editar()
    {
        ExibirCabecalho("Gestão de Chamados", "Edição de Chamado");

        ExibirTabelaChamados();
        ExibirSeparador();

        string idSelecionado = LerId("Digite o id do chamado que deseja editar: ");

        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(idSelecionado);

        if (chamadoSelecionado == null)
        {
            ExibirMensagem("Não foi possível encontrar o chamado informado.");
            return;
        }

        Equipamento? equipamentoSelecionado = SelecionarEquipamento("Digite o id do equipamento do chamado: ");

        if (equipamentoSelecionado == null)
        {
            ExibirMensagem("Não foi possível encontrar o equipamento informado.");
            return;
        }

        Chamado chamadoEditado = ObterDadosChamado(equipamentoSelecionado, chamadoSelecionado.dataAbertura);

        repositorioChamado.Editar(idSelecionado, chamadoEditado);

        ExibirMensagem($"O registro \"{idSelecionado}\" foi editado com sucesso.");
    }

    public void Excluir()
    {
        ExibirCabecalho("Gestão de Chamados", "Exclusão de Chamado");

        ExibirTabelaChamados();
        ExibirSeparador();

        string idSelecionado = LerId("Digite o id do chamado que deseja excluir: ");

        bool conseguiuExcluir = repositorioChamado.Excluir(idSelecionado);

        if (conseguiuExcluir)
            ExibirMensagem($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
        else
            ExibirMensagem($"Não foi possível encontrar o registro \"{idSelecionado}\".");
    }

    public void VisualizarTodos()
    {
        ExibirCabecalho("Gestão de Chamados", "Visualização de Chamados");

        ExibirTabelaChamados();
        ExibirSeparador();
        Pausar();
    }

    private Chamado ObterDadosChamado(Equipamento equipamentoSelecionado, DateTime dataAbertura)
    {
        return new Chamado
        {
            equipamento = equipamentoSelecionado,
            titulo = LerTextoObrigatorio("Digite o título do chamado: ", 3),
            descricao = LerDescricao(),
            dataAbertura = dataAbertura
        };
    }

    private string? LerDescricao()
    {
        Console.Write("Digite a descrição do chamado: ");
        return Console.ReadLine();
    }

    private Equipamento? SelecionarEquipamento(string mensagem)
    {
        ExibirTabelaEquipamentos();
        ExibirSeparador();

        string idSelecionado = LerId(mensagem);

        return repositorioEquipamento.SelecionarPorId(idSelecionado);
    }

    private void ExibirTabelaEquipamentos()
    {
        Console.WriteLine(
            "{0, -7} | {1, -18} | {2, -20} | {3, -18} | {4, -12}",
            "Id", "Nome", "Fabricante", "Preço", "Fabricação"
        );

        Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? equipamento = equipamentos[i];

            if (equipamento == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -18} | {2, -20} | {3, -18} | {4, -12}",
                equipamento.id,
                equipamento.nome,
                equipamento.fabricante.nome,
                equipamento.precoAquisicao.ToString("C2"),
                equipamento.dataFabricacao.ToShortDateString()
            );
        }
    }

    private void ExibirTabelaChamados()
    {
        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -18} | {3, -15} | {4, -10}",
            "Id", "Título", "Equipamento", "Abertura", "Dias"
        );

        Chamado?[] chamados = repositorioChamado.SelecionarTodos();

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? chamado = chamados[i];

            if (chamado == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -18} | {3, -15} | {4, -10}",
                chamado.id,
                chamado.titulo,
                chamado.equipamento.nome,
                chamado.dataAbertura.ToShortDateString(),
                chamado.ObterDiasDecorridos()
            );
        }
    }
}