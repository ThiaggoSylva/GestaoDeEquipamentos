using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();
RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

TelaEquipamento telaEquipamento = new TelaEquipamento
{
    repositorioEquipamento = repositorioEquipamento,
    repositorioFabricante = repositorioFabricante
};

TelaChamado telaChamado = new TelaChamado
{
    repositorioChamado = repositorioChamado,
    repositorioEquipamento = repositorioEquipamento
};

TelaFabricante telaFabricante = new TelaFabricante
{
    repositorioFabricante = repositorioFabricante,
    repositorioEquipamento = repositorioEquipamento
};

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar equipamentos");
    Console.WriteLine("2 - Gerenciar chamados");
    Console.WriteLine("3 - Gerenciar fabricantes");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");

    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    ExecutarModulo(opcaoMenuPrincipal, telaEquipamento, telaChamado, telaFabricante);
}

static void ExecutarModulo(
    string? opcaoMenuPrincipal,
    TelaEquipamento telaEquipamento,
    TelaChamado telaChamado,
    TelaFabricante telaFabricante)
{
    while (true)
    {
        string? opcaoMenu = null;

        if (opcaoMenuPrincipal == "1")
            opcaoMenu = telaEquipamento.ObterEscolhaMenuPrincipal();
        else if (opcaoMenuPrincipal == "2")
            opcaoMenu = telaChamado.ObterEscolhaMenuPrincipal();
        else if (opcaoMenuPrincipal == "3")
            opcaoMenu = telaFabricante.ObterEscolhaMenuPrincipal();
        else
            break;

        if (opcaoMenu == "S")
        {
            Console.Clear();
            break;
        }

        ExecutarAcao(opcaoMenuPrincipal, opcaoMenu, telaEquipamento, telaChamado, telaFabricante);
    }
}

static void ExecutarAcao(
    string? opcaoMenuPrincipal,
    string? opcaoMenu,
    TelaEquipamento telaEquipamento,
    TelaChamado telaChamado,
    TelaFabricante telaFabricante)
{
    if (opcaoMenuPrincipal == "1")
    {
        if (opcaoMenu == "1") telaEquipamento.Cadastrar();
        else if (opcaoMenu == "2") telaEquipamento.Editar();
        else if (opcaoMenu == "3") telaEquipamento.Excluir();
        else if (opcaoMenu == "4") telaEquipamento.VisualizarTodos();
    }
    else if (opcaoMenuPrincipal == "2")
    {
        if (opcaoMenu == "1") telaChamado.Cadastrar();
        else if (opcaoMenu == "2") telaChamado.Editar();
        else if (opcaoMenu == "3") telaChamado.Excluir();
        else if (opcaoMenu == "4") telaChamado.VisualizarTodos();
    }
    else if (opcaoMenuPrincipal == "3")
    {
        if (opcaoMenu == "1") telaFabricante.Cadastrar();
        else if (opcaoMenu == "2") telaFabricante.Editar();
        else if (opcaoMenu == "3") telaFabricante.Excluir();
        else if (opcaoMenu == "4") telaFabricante.VisualizarTodos();
    }
}