namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Equipamento : EntidadeBase
{
    public string nome = string.Empty;
    public Fabricante fabricante = new Fabricante();
    public decimal precoAquisicao;
    public DateTime dataFabricacao;
}