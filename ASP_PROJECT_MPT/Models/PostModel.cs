using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class PostModel
    {
        [Required(ErrorMessage = "Укажите тему поста!")]
        public string Title { get; set; }// заголовок записи
        [Required(ErrorMessage = "Напишите что-нибудь!")]
        public string Message { get; set; } //Текст самой записи
        [Required(ErrorMessage = "Напишите что-нибудь!")]
        public string UserId { get; set; } //данные айдишника пользователя
        public IFormFile PostImage { get; set; }
    }
}
