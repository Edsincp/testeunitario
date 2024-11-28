using Microsoft.AspNetCore.Mvc;
using TodoApi.Controllers;
using TodoApi.Models;
using Xunit;

namespace TodoApi.Tests
{
	public class TodoControllerTests
	{
		[Fact]
		public void Adicionar_DeveAdicionarItemNaLista()
		{
			// Arrange
			var controller = new TodoController();
			var todoItem = new TodoItem { Nome = "Tarefa de Teste", Concluido = false };

			// Act
			var resultado = controller.Adicionar(todoItem) as CreatedAtActionResult;

			// Assert
			Assert.NotNull(resultado);
			Assert.Equal("ObterTodos", resultado?.ActionName);

			var itemAdicionado = resultado?.Value as TodoItem;
			Assert.NotNull(itemAdicionado);
			Assert.Equal(todoItem.Nome, itemAdicionado?.Nome);
			Assert.False(itemAdicionado?.Concluido);
		}
	}
}
