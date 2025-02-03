namespace TodoApi.Models
{

    public class BasePagination {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }
    public class BaseResponse<T>
    {
        public string message;

        public T? result;
        public IEnumerable<T> results;
        public string? error;

        public BasePagination? pagination;

        public BaseResponse(string message, IEnumerable<T>? results = null, T? result = default, BasePagination? pagination = null, string? error = null)
        {
            this.message = message;
            this.result = result;
            this.error = error;
            if (results != null)
            {
                this.results = results;
            }
            if (pagination != null)
            {
                this.pagination = pagination;
            }
        }

    }
}
