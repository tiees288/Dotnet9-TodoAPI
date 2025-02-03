using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Extensions;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
     private readonly ITodoService _todoService;

     public TodoController(ITodoService todoService)
     {
          _todoService = todoService;
     }

     [HttpGet()]
     public ActionResult<BaseResponse<TodoItemModel>> GetTodos([FromQuery] int page, [FromQuery] int pageSize)
     {
          BaseResponse<TodoItemModel> todos = _todoService.GetTodos(page, pageSize);
          return this.CreateResponse(todos, ResponseType.Get);
     }

     [HttpPost("create")]
     public async Task<ActionResult<BaseResponse<TodoItemModel>>> CreateTodoItem([FromForm] TodoItemModel todoItemDTO)
     {
          if (!ModelState.IsValid) return BadRequest(ModelState);
          var result = await _todoService.AddTodoAsync(todoItemDTO);
          return this.CreateResponse(result, ResponseType.Create);
     }

     /// <summary>
     /// Deletes a Todo item by its ID.
     /// </summary>
     /// <param name="id">The ID of the Todo item to delete.</param>
     /// <returns>An ActionResult containing a message indicating the Todo item has been deleted.</returns>
     [HttpDelete("{id}")]
     public async Task<ActionResult<BaseResponse<TodoItemModel>>> DeleteTodoItem(int id)
     {
          var result = await _todoService.DeleteTodoAsync(id);
          return this.CreateResponse(result, ResponseType.Delete);


     }
}