using GestaoDeEquipamentos.ConsoleApp.Apresentacao;

TelaEquipamento telaEquipamento = new TelaEquipamento();

while (true)
{
    string? opcaoMenu = telaEquipamento.ObterEscolhaMenuPrincipal();

    if (opcaoMenu == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenu == "1")
        telaEquipamento.Cadastrar();

    else if (opcaoMenu == "2")
        telaEquipamento.Editar();

    else if (opcaoMenu == "3")
        telaEquipamento.Excluir();

    else if (opcaoMenu == "4")
        telaEquipamento.VisualizarTodos();
}