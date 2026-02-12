using Microsoft.AspNetCore.Mvc;
using Produtos.Api.DTOs;
using Produtos.Api.Interfaces;

namespace Produtos.Api.Controllers;

// Controller responsavel por expor os endpoints da API de produtos
[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
  // Injecao de dependencia do servico de produtos
  private readonly IProdutoService _service;

  public ProdutoController(IProdutoService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll([FromQuery] string? categoria)
  {
    // Paginação opcional
    int? page = null;
    int? pageSize = null;
    if (Request.Query.ContainsKey("page"))
    {
      int p;
      if (int.TryParse(Request.Query["page"], out p)) page = p;
    }
    if (Request.Query.ContainsKey("pageSize"))
    {
      int ps;
      if (int.TryParse(Request.Query["pageSize"], out ps)) pageSize = ps;
    }

    var produtos = await _service.GetAllAsync(categoria, page, pageSize);
    return Ok(produtos);
  }

  // GET /api/produtos/{id}
  // Busca um produto pelo id
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var produto = await _service.GetByIdAsync(id);
    if (produto == null) return NotFound();
    return Ok(produto);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateProdutoDto dto)
  {
    var produto = await _service.CreateAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProdutoDto dto)
  {
    var updated = await _service.UpdateAsync(id, dto);
    if (!updated) return NotFound();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    var deleted = await _service.DeleteAsync(id);
    if (!deleted) return NotFound();
    return NoContent();
  }

  [HttpGet("categorias")]
  public async Task<IActionResult> GetCategorias()
  {
    var categorias = await _service.GetCategoriasAsync();
    return Ok(categorias);
  }
}