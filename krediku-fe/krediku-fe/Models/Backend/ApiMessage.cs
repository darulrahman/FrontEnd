namespace krediku_fe.Models.Backend
{
    public class ApiMessage<T>
    {
        public bool isSuccess { get; set; }
        public string message { get; set; } = string.Empty;
        public DateTime messageTime { get; set; }
        public T data { get; set; }
    }
}
