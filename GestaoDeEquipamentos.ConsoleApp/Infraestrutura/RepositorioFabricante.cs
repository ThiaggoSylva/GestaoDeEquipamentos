using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioFabricante : RepositorioBase<Fabricante>
{
    public bool Editar(string idSelecionado, Fabricante fabricanteEditado)
    {
        Fabricante? fabricanteSelecionado = SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
            return false;

        fabricanteSelecionado.nome = fabricanteEditado.nome;
        fabricanteSelecionado.email = fabricanteEditado.email;
        fabricanteSelecionado.telefone = fabricanteEditado.telefone;

        return true;
    }
}