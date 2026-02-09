using System.ComponentModel.DataAnnotations;

namespace Produtos.Api.DTOs;

public class CreateProdutoDto
{
  [Required]
  [MaxLength(100)]
  public string Nome { get; set; } = string.Empty;

  [MaxLength(500)]
  public string? Descricao { get; set; }

  [Required]
  [Range(0.01, double.MaxValue)]
  public decimal Preco { get; set; }

  [Required]
  [Range(0, int.MaxValue)]
  public int Estoque { get; set; }

  [Required]
  public string Categoria { get; set; } = string.Empty;

  [Url]
  public string? ImagemUrl { get; set; }
}