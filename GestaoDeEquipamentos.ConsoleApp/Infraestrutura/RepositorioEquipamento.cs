using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioEquipamento : RepositorioBase<Equipamento>
{
    public bool Editar(string idSelecionado, Equipamento equipamentoEditado)
    {
        Equipamento? equipamentoSelecionado = SelecionarPorId(idSelecionado);

        if (equipamentoSelecionado == null)
            return false;

        equipamentoSelecionado.nome = equipamentoEditado.nome;
        equipamentoSelecionado.fabricante = equipamentoEditado.fabricante;
        equipamentoSelecionado.precoAquisicao = equipamentoEditado.precoAquisicao;
        equipamentoSelecionado.dataFabricacao = equipamentoEditado.dataFabricacao;

        return true;
    }
}