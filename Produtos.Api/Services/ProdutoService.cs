using Produtos.Api.Data;
using Produtos.Api.DTOs;
using Produtos.Api.Interfaces;
using Produtos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Produtos.Api.Services;

public class ProdutoService : IProdutoService
{
  private readonly AppDbContext _context;

  public ProdutoService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<ProdutoDto>> GetAllAsync(string? categoria = null)
  {
    var query = _context.Produtos.AsQueryable();
    if (!string.IsNullOrEmpty(categoria))
      query = query.Where(p => p.Categoria == categoria);

    // Paginação opcional
    if (page.HasValue && pageSize.HasValue && page > 0 && pageSize > 0)
    {
        query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
    }

    return await query
        .Select(p => new ProdutoDto
        {
          Id = p.Id,
          Nome = p.Nome,
          Descricao = p.Descricao,
          Preco = p.Preco,
          Estoque = p.Estoque,
          Categoria = p.Categoria,
          ImagemUrl = p.ImagemUrl,
          Ativo = p.Ativo,
          DataCadastro = p.DataCadastro
        })
        .ToListAsync();
  }

  public async Task<ProdutoDto?> GetByIdAsync(Guid id)
  {
    var p = await _context.Produtos.FindAsync(id);
    if (p == null) return null;
    return new ProdutoDto
    {
      Id = p.Id,
      Nome = p.Nome,
      Descricao = p.Descricao,
      Preco = p.Preco,
      Estoque = p.Estoque,
      Categoria = p.Categoria,
      ImagemUrl = p.ImagemUrl,
      Ativo = p.Ativo,
      DataCadastro = p.DataCadastro
    };
  }

  public async Task<ProdutoDto> CreateAsync(CreateProdutoDto dto)
  {
    var produto = new Produto
    {
      Id = Guid.NewGuid(),
      Nome = dto.Nome,
      Descricao = dto.Descricao,
      Preco = dto.Preco,
      Estoque = dto.Estoque,
      Categoria = dto.Categoria,
      ImagemUrl = dto.ImagemUrl,
      Ativo = true,
      DataCadastro = DateTime.UtcNow
    };
    _context.Produtos.Add(produto);
    await _context.SaveChangesAsync();

    return await GetByIdAsync(produto.Id) ?? throw new Exception("Erro ao criar produto");
  }

  public async Task<bool> UpdateAsync(Guid id, UpdateProdutoDto dto)
  {
    var produto = await _context.Produtos.FindAsync(id);
    if (produto == null) return false;

    produto.Nome = dto.Nome;
    produto.Descricao = dto.Descricao;
    produto.Preco = dto.Preco;
    produto.Estoque = dto.Estoque;
    produto.Categoria = dto.Categoria;
    produto.ImagemUrl = dto.ImagemUrl;
    produto.Ativo = dto.Ativo;

    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> DeleteAsync(Guid id)
  {
    var produto = await _context.Produtos.FindAsync(id);
    if (produto == null) return false;
    _context.Produtos.Remove(produto);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<IEnumerable<string>> GetCategoriasAsync()
  {
    return await _context.Produtos
        .Select(p => p.Categoria)
        .Distinct()
        .ToListAsync();
  }
}