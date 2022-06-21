using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class ChatTableViewModel
    {
        public IEnumerable<Chat> Chats { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
