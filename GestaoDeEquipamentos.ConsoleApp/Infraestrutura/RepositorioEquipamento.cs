using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioEquipamento
{
    public Equipamento?[] equipamentos = new Equipamento[100];

    public void Cadastrar(Equipamento novoEquipamento)
    {
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
    }

    public bool Editar(string idSelecionado, Equipamento novoEquipamento)
    {
        Equipamento? equipamentoSelecionado = SelecionarPorId(idSelecionado);

        if (equipamentoSelecionado == null)
            return false;

        equipamentoSelecionado.nome = novoEquipamento.nome;
        equipamentoSelecionado.fabricante = novoEquipamento.fabricante;
        equipamentoSelecionado.precoAquisicao = novoEquipamento.precoAquisicao;
        equipamentoSelecionado.dataFabricacao = novoEquipamento.dataFabricacao;

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            if (e.id == idSelecionado)
            {
                equipamentos[i] = null;
                return true;
            }
        }

        return false;
    }

    public Equipamento? SelecionarPorId(string idSelecionado)
    {
        Equipamento? equipamentoSelecionado = null;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            if (e.id == idSelecionado)
            {
                equipamentoSelecionado = e;
                break;
            }
        }

        return equipamentoSelecionado;
    }

    public Equipamento?[] SelecionarTodos()
    {
        return equipamentos;
    }
}