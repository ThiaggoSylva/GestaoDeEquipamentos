using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaChamado
{
    public RepositorioChamado repositorioChamado;
    public RepositorioEquipamento repositorioEquipamento;

    public string? ObterEscolhaMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar chamado");
        Console.WriteLine("2 - Editar chamado");
        Console.WriteLine("3 - Excluir chamado");
        Console.WriteLine("4 - Visualizar chamados");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro de Chamado");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );

        Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do equipamento que deseja selecionar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Equipamento? equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(idSelecionado);

        if (equipamentoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o equipamento informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Chamado novoChamado = new Chamado();

        novoChamado.equipamento = equipamentoSelecionado;

        do
        {
            Console.Write("Digite o título do chamado: ");
            novoChamado.titulo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoChamado.titulo) &&
                novoChamado.titulo.Length >= 3)
            {
                break;
            }

        } while (true);

        Console.Write("Digite o descrição do chamado: ");
        novoChamado.descricao = Console.ReadLine();

        novoChamado.dataAbertura = DateTime.Now.AddDays(-3);

        repositorioChamado.Cadastrar(novoChamado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoChamado.id}\" foi cadastrado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

   public void Editar()
{
    Console.Clear();

    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Chamados");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Edição de Chamado");
    Console.WriteLine("---------------------------------");

    Console.WriteLine(
        "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Título", "Equipamento", "Data de Abertura", "Dias desde abertura"
    );

    Chamado?[] chamados = repositorioChamado.SelecionarTodos();

    for (int i = 0; i < chamados.Length; i++)
    {
        Chamado? c = chamados[i];

        if (c == null)
            continue;

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}",
            c.id, c.titulo, c.equipamento.nome, c.dataAbertura.ToShortDateString(), c.ObterDiasDecorridos()
        );
    }

    Console.WriteLine("---------------------------------");

    string? idSelecionado;

    do
    {
        Console.Write("Digite o id do chamado que deseja editar: ");
        idSelecionado = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            break;

    } while (true);

    Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(idSelecionado);

    if (chamadoSelecionado == null)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Não foi possível encontrar o chamado informado.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
        return;
    }

    Console.WriteLine("---------------------------------");
    Console.WriteLine("Equipamentos disponíveis");
    Console.WriteLine("---------------------------------");

    Console.WriteLine(
        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
    );

    Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

    for (int i = 0; i < equipamentos.Length; i++)
    {
        Equipamento? e = equipamentos[i];

        if (e == null)
            continue;

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString()
        );
    }

    Console.WriteLine("---------------------------------");

    string? idEquipamentoSelecionado;

    do
    {
        Console.Write("Digite o id do equipamento do chamado: ");
        idEquipamentoSelecionado = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(idEquipamentoSelecionado) && idEquipamentoSelecionado.Length == 7)
            break;

    } while (true);

    Equipamento? equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(idEquipamentoSelecionado);

    if (equipamentoSelecionado == null)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Não foi possível encontrar o equipamento informado.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
        return;
    }

    Chamado chamadoEditado = new Chamado();
    chamadoEditado.equipamento = equipamentoSelecionado;

    do
    {
        Console.Write("Digite o título do chamado: ");
        chamadoEditado.titulo = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(chamadoEditado.titulo) && chamadoEditado.titulo.Length >= 3)
            break;

    } while (true);

    Console.Write("Digite a descrição do chamado: ");
    chamadoEditado.descricao = Console.ReadLine();

    chamadoEditado.dataAbertura = chamadoSelecionado.dataAbertura;

    bool conseguiuEditar = repositorioChamado.Editar(idSelecionado, chamadoEditado);

    if (!conseguiuEditar)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Não foi possível encontrar o chamado informado.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
        return;
    }

    Console.WriteLine("---------------------------------");
    Console.WriteLine($"O registro \"{idSelecionado}\" foi editado com sucesso.");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Digite ENTER para continuar...");
    Console.ReadLine();
}

public void Excluir()
{
    Console.Clear();

    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Chamados");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Exclusão de Chamado");
    Console.WriteLine("---------------------------------");

    Console.WriteLine(
        "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Título", "Equipamento", "Data de Abertura", "Dias desde abertura"
    );

    Chamado?[] chamados = repositorioChamado.SelecionarTodos();

    for (int i = 0; i < chamados.Length; i++)
    {
        Chamado? c = chamados[i];

        if (c == null)
            continue;

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}",
            c.id, c.titulo, c.equipamento.nome, c.dataAbertura.ToShortDateString(), c.ObterDiasDecorridos()
        );
    }

    Console.WriteLine("---------------------------------");

    string? idSelecionado;

    do
    {
        Console.Write("Digite o id do chamado que deseja excluir: ");
        idSelecionado = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            break;

    } while (true);

    bool conseguiuExcluir = repositorioChamado.Excluir(idSelecionado);

    if (conseguiuExcluir)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
        Console.WriteLine("---------------------------------");
    }
    else
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Não foi possível encontrar o registro \"{idSelecionado}\".");
        Console.WriteLine("---------------------------------");
    }

    Console.Write("Digite ENTER para continuar...");
    Console.ReadLine();
}

    public void VisualizarTodos()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Chamados");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}",
            "Id", "Título", "Equipamento", "Data de Abertura", "Dias desde abertura"
        );

        Chamado?[] chamados = repositorioChamado.SelecionarTodos();

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}",
                c.id, c.titulo, c.equipamento.nome, c.dataAbertura.ToShortDateString(), c.ObterDiasDecorridos()
            );
        }

        Console.WriteLine("---------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }
}