namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Chamado : EntidadeBase
{
    public string titulo = string.Empty;
    public string? descricao;
    public DateTime dataAbertura;
    public Equipamento equipamento = new Equipamento();

    public int ObterDiasDecorridos()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(dataAbertura);
        return diferencaTempo.Days;
    }
}