namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Chamado
{
    public string id;
    public string titulo;
    public string? descricao;
    public DateTime dataAbertura;
    public Equipamento equipamento;

    public int ObterDiasDecorridos()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(dataAbertura);

        return diferencaTempo.Days;
    }
}