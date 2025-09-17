namespace VendingMachinesAPI.Models
{
    public class My_errors
    {
        public long Timestamp { get; set; }
        public string Message { get; set; } = null!;
        public int ErrorCode { get; set; }
    }
}
