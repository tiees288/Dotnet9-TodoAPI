using TodoApi.Entity;
using TodoApi.Models;

class TodoReportModel : TodoItemModel {
    public string ReportName { get; set; }
    public string ReportDescription { get; set; }

     public IEnumerable<TodoDetail> Detail { get; set; }

     public TodoReportModel(string reportName, string reportDescription, IEnumerable<TodoDetail> detail,long id, string name, bool isComplete) : base(id, name, isComplete)
     {
          ReportName = reportName;
          ReportDescription = reportDescription;
          Detail = detail;

          // Inherited from TodoItemModel
          Id = id;
          Name = name;
          IsComplete = isComplete;
     }
}