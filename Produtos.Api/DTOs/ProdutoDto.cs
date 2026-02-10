namespace Produtos.Api.DTOs;

public class ProdutoDto
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public string? Descricao { get; set; }
  public decimal Preco { get; set; }
  public int Estoque { get; set; }
  public string Categoria { get; set; } = string.Empty;
  public string? ImagemUrl { get; set; }
  public bool Ativo { get; set; }
  public DateTime DataCadastro { get; set; }
}