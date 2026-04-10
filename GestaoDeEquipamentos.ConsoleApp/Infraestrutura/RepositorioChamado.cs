using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    public Chamado?[] chamados = new Chamado[100];

    public void Cadastrar(Chamado novoChamado)
    {
        novoChamado.id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
            {
                chamados[i] = novoChamado;
                break;
            }
        }
    }

    public Chamado?[] SelecionarTodos()
    {
        return chamados;
    }
}
