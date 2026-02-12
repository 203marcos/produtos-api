using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Produtos.Api.Controllers;
using Produtos.Api.DTOs;
using Produtos.Api.Interfaces;
using Xunit;

namespace Produtos.Api.Tests
{
  public class ProdutoControllerTests
  {
    [Fact]
    public async Task GetAll_ReturnsOkResult()
    {
      // Arrange
      var mockService = new Mock<IProdutoService>();
      mockService.Setup(s => s.GetAllAsync(null, null, null)).ReturnsAsync(new List<ProdutoDto>());
      var controller = new ProdutoController(mockService.Object);

      // Act
      var result = await controller.GetAll(null);

      // Assert
      Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenNotExists()
    {
      var mockService = new Mock<IProdutoService>();
      mockService.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((ProdutoDto?)null);
      var controller = new ProdutoController(mockService.Object);

      var result = await controller.GetById(Guid.NewGuid());

      Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenExists()
    {
      var mockService = new Mock<IProdutoService>();
      mockService.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new ProdutoDto { Id = Guid.NewGuid(), Nome = "Teste", Categoria = "Cat", Preco = 1, Estoque = 1, Ativo = true, DataCadastro = DateTime.Now });
      var controller = new ProdutoController(mockService.Object);

      var result = await controller.GetById(Guid.NewGuid());

      Assert.IsType<OkObjectResult>(result);
    }
  }
}
