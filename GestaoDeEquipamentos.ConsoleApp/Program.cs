using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp;

Equipamento?[] equipamentos = new Equipamento[100];

Equipamento equipamentoTeste = new Equipamento();

equipamentoTeste.id = Convert
    .ToHexString(RandomNumberGenerator.GetBytes(20))
    .ToLower()
    .Substring(0, 7); // 0-255


equipamentoTeste.nome = "Notebook";
equipamentoTeste.fabricante = "Acer";
equipamentoTeste.precoAquisicao = 4000;
equipamentoTeste.dataFabricacao = DateTime.Now;

equipamentos[0] = equipamentoTeste;

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Cadastrar equipamento");
    Console.WriteLine("2 - Editar equipamento");
    Console.WriteLine("3 - Excluir equipamento");
    Console.WriteLine("4 - Visualizar equipamentos");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenu = Console.ReadLine()?.ToUpper();

    if (opcaoMenu == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenu == "1")
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro de Equipamento");
        Console.WriteLine("---------------------------------");

        Equipamento novoEquipamento = new Equipamento();

        do
        {
            Console.Write("Digite o nome do equipamento: ");
            novoEquipamento.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) &&
                novoEquipamento.nome.Length > 3)
            {
                break;
            }

        } while (true);

        do
        {
            Console.Write("Digite o fabricante do equipamento: ");
            novoEquipamento.fabricante = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.fabricante) &&
                novoEquipamento.fabricante.Length > 2)
            {
                break;
            }

        } while (true);

        Console.Write("Digite o preço de aquisição do equipamento: ");
        novoEquipamento.precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento: ");
        novoEquipamento.dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        novoEquipamento.id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7); // 0-255

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                equipamentos[i] = novoEquipamento;
                break;
            }
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoEquipamento.nome}\" foi cadastrado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    else if (opcaoMenu == "2")
    {
        /*
            Requisito 1.2: Como funcionário, Junior quer ter a possibilidade de editar um equipamento, sendo que ele
            possa editar todos os campos.
                • Deve ter os mesmos critérios que o Requisito 1.
        */
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Equipamento");
        Console.WriteLine("---------------------------------");

        // 1. Perguntar qual equipamento o usuário quer editar

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null) // null guard/check
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString()
            );
        }

        Console.Write("Digite o id do equipamento que deseja editar: ");

        // 2. Buscar/Validar o equipamento

        // 3. Substitui as informações dos campos do equipamento pelas novas
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    else if (opcaoMenu == "3")
    {

    }

    else if (opcaoMenu == "4")
    {

    }
}