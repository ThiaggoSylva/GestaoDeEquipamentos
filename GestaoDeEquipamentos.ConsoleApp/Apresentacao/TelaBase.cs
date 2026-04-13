namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public abstract class TelaBase
{
    protected void ExibirCabecalho(string titulo, string subtitulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
        Console.WriteLine(subtitulo);
        Console.WriteLine("---------------------------------");
    }

    protected void ExibirMensagem(string mensagem)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine(mensagem);
        Console.WriteLine("---------------------------------");
        Pausar();
    }

    protected void Pausar()
    {
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    protected string LerTextoObrigatorio(string mensagem, int tamanhoMinimo = 1)
    {
        while (true)
        {
            Console.Write(mensagem);
            string texto = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(texto) && texto.Length >= tamanhoMinimo)
                return texto;
        }
    }

    protected string LerId(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string id = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(id) && id.Length == 7)
                return id;
        }
    }

    protected decimal LerDecimal(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            bool conseguiuConverter = decimal.TryParse(Console.ReadLine(), out decimal valor);

            if (conseguiuConverter)
                return valor;
        }
    }

    protected DateTime LerData(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            bool conseguiuConverter = DateTime.TryParse(Console.ReadLine(), out DateTime data);

            if (conseguiuConverter)
                return data;
        }
    }

    protected string LerEmail(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string email = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(email) &&
                email.Contains('@') &&
                email.Contains('.'))
                return email;
        }
    }

    protected void ExibirSeparador()
    {
        Console.WriteLine("---------------------------------");
    }
}