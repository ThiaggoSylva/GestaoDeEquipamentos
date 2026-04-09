using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

// Arquitetura de 3 Camadas
// Apresentação / Interface
// Infraestrutura
// Domínio / Regra de Negócio

Equipamento?[] equipamentos = new Equipamento[100];
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
        telaEquipamento.Cadastrar(equipamentos);

    else if (opcaoMenu == "2")
        telaEquipamento.Editar(equipamentos);

    else if (opcaoMenu == "3")
        telaEquipamento.Excluir(equipamentos);

    else if (opcaoMenu == "4")
        telaEquipamento.VisualizarTodos(equipamentos);
}