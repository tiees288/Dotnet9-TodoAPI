using TodoApi.Models;

public interface IReportService
{
    BaseResponse<TodoItemModel> GetTodos(int page, int pageSize);
}

class ReportService : IReportService
{
    private readonly IReportService _reportService;

    public ReportService(IReportService reportService)
    {
        _reportService = reportService;
    }

    public BaseResponse<TodoItemModel> GetTodos(int page = 1, int pageSize = 20)
    {
        return _reportService.GetTodos(page, pageSize);
    }
}