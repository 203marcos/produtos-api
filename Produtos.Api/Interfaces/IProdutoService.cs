using Produtos.Api.DTOs;

namespace Produtos.Api.Interfaces;

public interface IProdutoService
{
  Task<IEnumerable<ProdutoDto>> GetAllAsync(string? categoria = null, int? page = null, int? pageSize = null);
  Task<ProdutoDto?> GetByIdAsync(Guid id);
  Task<ProdutoDto> CreateAsync(CreateProdutoDto dto);
  Task<bool> UpdateAsync(Guid id, UpdateProdutoDto dto);
  Task<bool> DeleteAsync(Guid id);
  Task<IEnumerable<string>> GetCategoriasAsync();
}