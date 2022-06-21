using System;

namespace ASP_PROJECT_MPT.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageStr { get; set; } //Текст (объеденение Name & Text)
        public DateTime Timestamp { get; set; }
        public byte[] Image { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}