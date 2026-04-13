using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public abstract class RepositorioBase<T> where T : EntidadeBase
{
    protected T?[] registros = new T[100];

    public virtual void Cadastrar(T novoRegistro)
    {
        novoRegistro.id = GerarId();

        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novoRegistro;
                break;
            }
        }
    }

    public virtual bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            T? registro = registros[i];

            if (registro == null)
                continue;

            if (registro.id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }

    public virtual T? SelecionarPorId(string idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            T? registro = registros[i];

            if (registro == null)
                continue;

            if (registro.id == idSelecionado)
                return registro;
        }

        return null;
    }

    public virtual T?[] SelecionarTodos()
    {
        return registros;
    }

    private string GerarId()
    {
        return Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);
    }
}