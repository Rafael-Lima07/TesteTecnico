namespace TesteTecnico.Models;

public class Produto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string CodBarras { get; set; }
    public decimal ValorVenda { get; set; }
    public float PesoBruto { get; set; }
    public float PeloLiquido { get; set; }

}
