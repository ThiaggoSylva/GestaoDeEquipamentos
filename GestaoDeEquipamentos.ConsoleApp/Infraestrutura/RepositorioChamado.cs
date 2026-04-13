using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado : RepositorioBase<Chamado>
{
    public bool Editar(string idSelecionado, Chamado chamadoEditado)
    {
        Chamado? chamadoSelecionado = SelecionarPorId(idSelecionado);

        if (chamadoSelecionado == null)
            return false;

        chamadoSelecionado.titulo = chamadoEditado.titulo;
        chamadoSelecionado.descricao = chamadoEditado.descricao;
        chamadoSelecionado.dataAbertura = chamadoEditado.dataAbertura;
        chamadoSelecionado.equipamento = chamadoEditado.equipamento;

        return true;
    }
}