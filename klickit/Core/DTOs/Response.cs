namespace klickit.Core.DTOs
{
    public class Response<T> where T : class
    {
        public int CurrentPage { get; set; }
        public double TotalPages { get; set; }
        public List<T> Data { get; set; }
    }
}

