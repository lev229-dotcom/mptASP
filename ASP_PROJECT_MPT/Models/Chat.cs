using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
        }

        public int ChatId { get; set; }
        public string Name { get; set; }
        //public IFormFile Image { get; set; }
        public ICollection<Message> Messages { get; set; }


    }
}
