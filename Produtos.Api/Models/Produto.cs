using System.ComponentModel.DataAnnotations;

namespace Produtos.Api.Models;

// Entidade que representa o produto no banco de dados
public class Produto
{
  public Guid Id { get; set; }

  [Required(ErrorMessage = "O nome é obrigatório")]
  [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
  public string Nome { get; set; } = string.Empty;

  [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
  public string? Descricao { get; set; }

  [Required(ErrorMessage = "O preço é obrigatório")]
  [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
  public decimal Preco { get; set; }

  [Required(ErrorMessage = "O estoque é obrigatório")]
  [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo")]
  public int Estoque { get; set; }

  [Required(ErrorMessage = "A categoria é obrigatória")]
  public string Categoria { get; set; } = string.Empty;

  [Url(ErrorMessage = "A URL da imagem é inválida")]
  public string? ImagemUrl { get; set; }

  public bool Ativo { get; set; } = true;

  public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}
