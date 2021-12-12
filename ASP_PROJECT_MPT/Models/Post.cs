using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }// заголовок записи
        public string Message { get; set; } //Текст самой записи
        public byte[] PostImage { get; set; }

        //public int? UserId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
