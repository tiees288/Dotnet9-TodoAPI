using Microsoft.EntityFrameworkCore;
using TodoApi.DBContext;
using TodoApi.Entity;
using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
     BaseResponse<TodoItemModel> GetTodos(int page, int pageSize);
     Task<BaseResponse<TodoItemModel>> AddTodoAsync(TodoItemModel todo);
     Task<BaseResponse<TodoItemModel>> UpdateTodoAsync(int todoId, TodoItemModel todo);
     Task<BaseResponse<TodoItemModel>> DeleteTodoAsync(int todoId);
}

public class TodoService : ITodoService
{

     // DB context
     private readonly AppDBContext _context;

     public TodoService(AppDBContext context)
     {
          _context = context;
     }

     public BaseResponse<TodoItemModel> GetTodos(int page = 1, int pageSize = 20)
     {

          try
          {
               var totalRecords = _context.TodoItems.Count();
               var todos = _context.TodoItems.FromSqlRaw("SELECT * FROM public.\"TodoItems\" LIMIT {0} OFFSET {1}", pageSize, (page - 1) * pageSize).ToList();
               var todoItems =
               todos.Select(todo => new TodoItemModel
               {
                    Id = todo.Id,
                    Name = todo.Name,
                    IsComplete = todo.IsComplete
               });

               return new BaseResponse<TodoItemModel>(
                    message: "fetch data success",
                    results: todoItems,
                    pagination: new BasePagination
                    {
                         page = page,
                         pageSize = pageSize,
                         total = totalRecords
                    }
               );
          }
          catch (DbUpdateException updateEx)
          {
               return new BaseResponse<TodoItemModel>(
                    message: ResponseStatusMessage.fetchError.toString(),
                    error: updateEx.Message,
                    results: null
               );
          }
          catch (Exception e)
          {
               return new BaseResponse<TodoItemModel>(
                    error: e.Message,
                    message: ResponseStatusMessage.error.toString(),
                    results: null
               );
          }
     }

     public async Task<BaseResponse<TodoItemModel>> AddTodoAsync(TodoItemModel todo)
     {

          var entity = new TodoDTO
          {
               Name = todo.Name,
               IsComplete = todo.IsComplete ?? false
          };

          try
          {

               var result = await _context.TodoItems.AddAsync(entity);
               Console.WriteLine(result.State);
               if (result.State == EntityState.Added)
               {
                    await _context.SaveChangesAsync();
                    return new BaseResponse<TodoItemModel>(
                         message: "Todo item has been added",
                         result: new TodoItemModel
                         {
                              Id = result.Entity.Id,
                              Name = result.Entity.Name,
                              IsComplete = result.Entity.IsComplete
                         }
                    );
               }
               else
               {
                    return new BaseResponse<TodoItemModel>(
                         message: "Failed to add todo item",
                         error: result.Entity.ToString(),
                         result: null
                    );
               }
          }
          catch (DbUpdateException updateEx)
          {
               return new BaseResponse<TodoItemModel>(
                    message: ResponseStatusMessage.fetchError.toString(),
                    error: updateEx.Message,
                    results: null
               );
          }
          catch (Exception e)
          {
               return new BaseResponse<TodoItemModel>(
                    error: e.Message,
                    message: ResponseStatusMessage.error.toString(),
                    results: null
               );
          }
     }

     public async Task<BaseResponse<TodoItemModel>> UpdateTodoAsync(int todoId, TodoItemModel todo)
     {
          return new BaseResponse<TodoItemModel>(
               message: "Todo item has been updated",
               result: todo
          );
     }

     public async Task<BaseResponse<TodoItemModel>> DeleteTodoAsync(int todoId)
     {
          return new BaseResponse<TodoItemModel>(
               message: "Todo item has been deleted",
               result: null
          );
     }
}