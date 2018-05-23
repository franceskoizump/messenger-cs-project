namespace WebApplication1.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
    }
}