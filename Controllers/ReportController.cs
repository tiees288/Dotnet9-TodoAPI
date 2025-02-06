using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Extensions;

[ApiController]
[Route("api/report/todo")]
public class ReportController : ControllerBase
{
     private readonly ITodoService _todoService;

     public ReportController(ITodoService todoService)
     {
          _todoService = todoService;
     }

     [HttpGet()]
     public ActionResult<BaseResponse<TodoItemModel>> GetTodos([FromQuery] int page, [FromQuery] int pageSize)
     {
          BaseResponse<TodoItemModel> todos = _todoService.GetTodos(page, pageSize);
          return this.CreateResponse(todos, ResponseType.Get);
     }
}