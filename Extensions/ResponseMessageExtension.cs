namespace TodoApi.Models
{
     public enum ResponseStatusMessage
     {
          CreateSuccess,
          FetchSuccess,
          UpdateSuccess,

          DeleteSuccess,

          fetchError,

          DataNotFound,
          error
     }

     public static class ResponseStatusMessageExtensions
     {
          public static string toString(this ResponseStatusMessage me)
          {
               switch (me)
               {
                    case ResponseStatusMessage.CreateSuccess:
                         return "Create data success";
                    case ResponseStatusMessage.FetchSuccess:
                         return "Fetch data success";
                    case ResponseStatusMessage.UpdateSuccess:
                         return "Update data success";
                    case ResponseStatusMessage.DeleteSuccess:
                         return "Delete data success";
                    case ResponseStatusMessage.fetchError:
                         return "Fetch data error";
                    case ResponseStatusMessage.DataNotFound:
                         return "Data not found";
                    default:
                         return "Internal server error";
               }
          }
     }
}