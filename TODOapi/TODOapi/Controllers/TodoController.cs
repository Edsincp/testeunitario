using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TodoController : ControllerBase
	{
		private static readonly List<TodoItem> Itens = new();

		[HttpGet]
		public IActionResult ObterTodos()
		{
			return Ok(Itens);
		}

		[HttpPost]
		public IActionResult Adicionar(TodoItem item)
		{
			item.Id = Itens.Count + 1;
			Itens.Add(item);
			return CreatedAtAction(nameof(ObterTodos), new { id = item.Id }, item);
		}
	}
}
