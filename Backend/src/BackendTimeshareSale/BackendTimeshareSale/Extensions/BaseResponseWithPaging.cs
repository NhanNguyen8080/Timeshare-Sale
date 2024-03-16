namespace BackendTimeshareSale.Extensions
{
    public class BaseResponseWithPaging<T> where T : class
    {
        public string status { get; set; }
        public string message { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public double total_pages { get; set; }
        public T data { get; set; }

    }
}
