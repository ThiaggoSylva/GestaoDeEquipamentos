using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaEquipamento : TelaBase
{
    public RepositorioEquipamento repositorioEquipamento = null!;
    public RepositorioFabricante repositorioFabricante = null!;

    public string? ObterEscolhaMenuPrincipal()
    {
        ExibirCabecalho("Gestão de Equipamentos", "Menu Principal");
        Console.WriteLine("1 - Cadastrar equipamento");
        Console.WriteLine("2 - Editar equipamento");
        Console.WriteLine("3 - Excluir equipamento");
        Console.WriteLine("4 - Visualizar equipamentos");
        Console.WriteLine("S - Sair");
        ExibirSeparador();
        Console.Write("> ");

        return Console.ReadLine()?.ToUpper();
    }

    public void Cadastrar()
    {
        ExibirCabecalho("Gestão de Equipamentos", "Cadastro de Equipamento");

        if (!ExisteFabricanteCadastrado())
        {
            ExibirMensagem("Cadastre ao menos um fabricante antes de cadastrar um equipamento.");
            return;
        }

        Equipamento novoEquipamento = ObterDadosEquipamento();

        repositorioEquipamento.Cadastrar(novoEquipamento);

        ExibirMensagem($"O registro \"{novoEquipamento.id}\" foi cadastrado com sucesso.");
    }

    public void Editar()
    {
        ExibirCabecalho("Gestão de Equipamentos", "Edição de Equipamento");

        ExibirTabelaEquipamentos();
        ExibirSeparador();

        string idSelecionado = LerId("Digite o id do equipamento que deseja editar: ");

        Equipamento? equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(idSelecionado);

        if (equipamentoSelecionado == null)
        {
            ExibirMensagem("Não foi possível encontrar o equipamento informado.");
            return;
        }

        Equipamento equipamentoEditado = ObterDadosEquipamento();

        repositorioEquipamento.Editar(idSelecionado, equipamentoEditado);

        ExibirMensagem($"O registro \"{idSelecionado}\" foi editado com sucesso.");
    }

    public void Excluir()
    {
        ExibirCabecalho("Gestão de Equipamentos", "Exclusão de Equipamento");

        ExibirTabelaEquipamentos();
        ExibirSeparador();

        string idSelecionado = LerId("Digite o id do equipamento que deseja excluir: ");

        bool conseguiuExcluir = repositorioEquipamento.Excluir(idSelecionado);

        if (conseguiuExcluir)
            ExibirMensagem($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
        else
            ExibirMensagem($"Não foi possível encontrar o registro \"{idSelecionado}\".");
    }

    public void VisualizarTodos()
    {
        ExibirCabecalho("Gestão de Equipamentos", "Visualização de Equipamentos");

        ExibirTabelaEquipamentos();
        ExibirSeparador();
        Pausar();
    }

    private Equipamento ObterDadosEquipamento()
    {
        return new Equipamento
        {
            nome = LerTextoObrigatorio("Digite o nome do equipamento: ", 6),
            fabricante = SelecionarFabricante(),
            precoAquisicao = LerDecimal("Digite o preço de aquisição do equipamento: "),
            dataFabricacao = LerData("Digite a data de fabricação do equipamento: ")
        };
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

    private bool ExisteFabricanteCadastrado()
    {
        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] != null)
                return true;
        }

        return false;
    }

    private Fabricante SelecionarFabricante()
    {
        ExibirSeparador();
        Console.WriteLine("Fabricantes disponíveis");
        ExibirSeparador();

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -25} | {3, -15}",
            "Id", "Nome", "Email", "Telefone"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? fabricante = fabricantes[i];

            if (fabricante == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -25} | {3, -15}",
                fabricante.id,
                fabricante.nome,
                fabricante.email,
                fabricante.telefone
            );
        }

        ExibirSeparador();

        while (true)
        {
            string idFabricanteSelecionado = LerId("Digite o id do fabricante: ");
            Fabricante? fabricanteSelecionado = repositorioFabricante.SelecionarPorId(idFabricanteSelecionado);

            if (fabricanteSelecionado != null)
                return fabricanteSelecionado;

            Console.WriteLine("Não foi possível encontrar o fabricante informado.");
        }
    }
}