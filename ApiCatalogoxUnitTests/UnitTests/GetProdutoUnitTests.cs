using APICatalogo.Controllers;
using APICatalogo.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoMapper;
using APICatalogo.Repositories;

namespace ApiCatalogoxUnitTests.UnitTests;

public class GetProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
{
    private readonly ProdutosController _controller;

    public GetProdutoUnitTests(ProdutosUnitTestController controller)
    {
        _controller = new ProdutosController(controller.repository, controller.mapper);
    }

    [Fact]
    public async Task GetProdutoById_OKResult()
    {
        //Arrange
        var prodId = 2;

        //Act
        var data = await _controller.Get(prodId);

        ////Assert (xunit)
        //var okResult = Assert.IsType<OkObjectResult>(data.Result);
        //Assert.Equal(200, okResult.StatusCode);

        //Assert (fluentassertions)
        data.Result.Should().BeOfType<OkObjectResult>()//verifica se o resultado é do tipo OkObjectResult.
                   .Which.StatusCode.Should().Be(200);//verifica se o código de status do OkObjectResult é 200.
    }

    [Fact]
    public async Task GetProdutoById_Return_NotFound()
    {
        //Arrange  
        var prodId = 999;

        // Act  
        var data = await _controller.Get(prodId);

        // Assert  
        data.Result.Should().BeOfType<NotFoundObjectResult>()
                    .Which.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task GetProdutoById_Return_BadRequest()
    {
        //Arrange  
        int prodId = -1;

        // Act  
        var data = await _controller.Get(prodId);

        // Assert  
        data.Result.Should().BeOfType<BadRequestObjectResult>()
                   .Which.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task GetProdutos_Return_ListOfProdutoDTO()
    {
        // Act  
        var data = await _controller.Get();

        // Assert
        data.Result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeAssignableTo<IEnumerable<ProdutoDTO>>() //Verifica se o valor do OkObjectResult é atribuível a IEnumerable<ProdutoDTO>.
            .And.NotBeNull();
    }

    [Fact]
    public async Task GetProdutos_Return_BadRequestResult()
    {
        // Arrange
        var mockRepo = new Mock<IUnitOfWork>();
        var mockMapper = new Mock<IMapper>();

        mockRepo.Setup(r => r.ProdutoRepository.GetAllAsync())
                .ThrowsAsync(new Exception()); // <- isso precisa existir!

        var controller = new ProdutosController(mockRepo.Object, mockMapper.Object);

        // Act
        var result = await controller.Get();

        // Assert
        result.Result.Should().BeOfType<BadRequestResult>();
    }
}
