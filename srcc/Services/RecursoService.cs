using Moq;
using SmartCitySecurity.Services;
using SmartCitySecurity.Data.Repository;
using SmartCitySecurity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class RecursoServiceTests
{
    private readonly RecursoService _service;
    private readonly Mock<IRecursoPolicialRepository> _repositoryMock;

    public RecursoServiceTests()
    {
        _repositoryMock = new Mock<IRecursoPolicialRepository>();
        _service = new RecursoService(_repositoryMock.Object);
    }

    [Fact]
    public async Task ListarRecursos_DeveRetornarTodosOsRecursos()
    {
        // Arrange
        var listaRecursos = new List<RecursosPoliciais> { new RecursosPoliciais(), new RecursosPoliciais() };
        _repositoryMock.Setup(r => r.GetAll()).ReturnsAsync(listaRecursos);

        // Act
        var result = await _service.ListarRecursos();

        // Assert
        Assert.Equal(2, result.Count());
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public async Task ObterRecursoPorId_DeveRetornarRecurso_QuandoIdValido()
    {
        // Arrange
        var recurso = new RecursosPoliciais { RecursoId = 1 };
        _repositoryMock.Setup(r => r.GetById(1)).ReturnsAsync(recurso);

        // Act
        var result = await _service.ObterRecursoPorId(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.RecursoId);
        _repositoryMock.Verify(r => r.GetById(1), Times.Once);
    }

    [Fact]
    public async Task ObterRecursoPorId_DeveLancarExcecao_QuandoRecursoNaoEncontrado()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetById(1)).ReturnsAsync((RecursosPoliciais)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(() => _service.ObterRecursoPorId(1));
        Assert.Equal("Recurso com ID 1 não encontrado.", exception.Message);
    }

    [Fact]
    public async Task CriarRecurso_DeveLancarExcecao_QuandoRecursoForNulo()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CriarRecurso(null));
    }

    [Fact]
    public async Task CriarRecurso_DeveAdicionarRecurso_QuandoValido()
    {
        // Arrange
        var recurso = new RecursosPoliciais { RecursoId = 1 };
        _repositoryMock.Setup(r => r.Add(recurso)).Returns(Task.CompletedTask);

        // Act
        await _service.CriarRecurso(recurso);

        // Assert
        _repositoryMock.Verify(r => r.Add(recurso), Times.Once);
    }

    [Fact]
    public async Task AtualizarRecurso_DeveAtualizarRecurso_QuandoExistente()
    {
        // Arrange
        var recurso = new RecursosPoliciais { RecursoId = 1 };
        _repositoryMock.Setup(r => r.GetById(1)).ReturnsAsync(recurso);

        // Act
        await _service.AtualizarRecurso(recurso);

        // Assert
        _repositoryMock.Verify(r => r.Update(recurso), Times.Once);
    }

    [Fact]
    public async Task DeletarRecurso_DeveLancarExcecao_QuandoNaoEncontrado()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetById(1)).ReturnsAsync((RecursosPoliciais)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(() => _service.DeletarRecurso(1));
        Assert.Equal("Recurso com ID 1 não encontrado para exclusão.", exception.Message);
    }

    [Fact]
    public async Task AtualizarStatusDisponibilidade_DeveAtualizarRecursoQuandoNecessario()
    {
        // Arrange
        var recurso = new RecursosPoliciais { RecursoId = 1, UltimaManutencao = DateTime.UtcNow.AddDays(-2), Disponibilidade = true };
        var recursos = new List<RecursosPoliciais> { recurso };
        _repositoryMock.Setup(r => r.GetAll()).ReturnsAsync(recursos);

        // Act
        await _service.AtualizarStatusDisponibilidade();

        // Assert
        Assert.False(recurso.Disponibilidade);
        _repositoryMock.Verify(r => r.Update(recurso), Times.Once);
    }
}

