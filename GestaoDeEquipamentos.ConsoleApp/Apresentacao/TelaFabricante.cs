using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaFabricante : TelaBase
{
    public RepositorioFabricante repositorioFabricante = null!;
    public RepositorioEquipamento repositorioEquipamento = null!;

    public string? ObterEscolhaMenuPrincipal()
    {
        ExibirCabecalho("Gestão de Fabricantes", "Menu Principal");
        Console.WriteLine("1 - Cadastrar fabricante");
        Console.WriteLine("2 - Editar fabricante");
        Console.WriteLine("3 - Excluir fabricante");
        Console.WriteLine("4 - Visualizar fabricantes");
        Console.WriteLine("S - Sair");
        ExibirSeparador();
        Console.Write("> ");

        return Console.ReadLine()?.ToUpper();
    }

    public void Cadastrar()
    {
        ExibirCabecalho("Gestão de Fabricantes", "Cadastro de Fabricante");

        Fabricante novoFabricante = ObterDadosFabricante();

        repositorioFabricante.Cadastrar(novoFabricante);

        ExibirMensagem($"O fabricante \"{novoFabricante.id}\" foi cadastrado com sucesso.");
    }

    public void Editar()
    {
        ExibirCabecalho("Gestão de Fabricantes", "Edição de Fabricante");

        ExibirTabelaFabricantes();
        ExibirSeparador();

        string idSelecionado = LerId("Digite o id do fabricante que deseja editar: ");

        Fabricante? fabricanteSelecionado = repositorioFabricante.SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
        {
            ExibirMensagem("Não foi possível encontrar o fabricante informado.");
            return;
        }

        Fabricante fabricanteEditado = ObterDadosFabricante();

        repositorioFabricante.Editar(idSelecionado, fabricanteEditado);

        ExibirMensagem($"O fabricante \"{idSelecionado}\" foi editado com sucesso.");
    }

    public void Excluir()
    {
        ExibirCabecalho("Gestão de Fabricantes", "Exclusão de Fabricante");

        ExibirTabelaFabricantes();
        ExibirSeparador();

        string idSelecionado = LerId("Digite o id do fabricante que deseja excluir: ");

        if (ObterQuantidadeEquipamentosDoFabricante(idSelecionado) > 0)
        {
            ExibirMensagem("Não é possível excluir este fabricante, pois existem equipamentos vinculados a ele.");
            return;
        }

        bool conseguiuExcluir = repositorioFabricante.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            ExibirMensagem("Não foi possível encontrar o fabricante informado.");
            return;
        }

        ExibirMensagem($"O fabricante \"{idSelecionado}\" foi excluído com sucesso.");
    }

    public void VisualizarTodos()
    {
        ExibirCabecalho("Gestão de Fabricantes", "Visualização de Fabricantes");

        ExibirTabelaFabricantes();
        ExibirSeparador();
        Pausar();
    }

    private Fabricante ObterDadosFabricante()
    {
        return new Fabricante
        {
            nome = LerTextoObrigatorio("Digite o nome do fabricante: ", 2),
            email = LerEmail("Digite o email do fabricante: "),
            telefone = LerTextoObrigatorio("Digite o telefone do fabricante: ")
        };
    }

    private void ExibirTabelaFabricantes()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -25} | {3, -15} | {4, -10}",
            "Id", "Nome", "Email", "Telefone", "Qtd Equip."
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? fabricante = fabricantes[i];

            if (fabricante == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -25} | {3, -15} | {4, -10}",
                fabricante.id,
                fabricante.nome,
                fabricante.email,
                fabricante.telefone,
                ObterQuantidadeEquipamentosDoFabricante(fabricante.id)
            );
        }
    }

    private int ObterQuantidadeEquipamentosDoFabricante(string idFabricante)
    {
        int quantidade = 0;

        Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? equipamento = equipamentos[i];

            if (equipamento == null)
                continue;

            if (equipamento.fabricante.id == idFabricante)
                quantidade++;
        }

        return quantidade;
    }
}