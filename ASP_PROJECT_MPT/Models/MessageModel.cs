using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class MessageModel
    {
        [Required(ErrorMessage = "Напишите что-нибудь!")]
        public string MessageBody { get; set; } //Текст самой записи
        [Required(ErrorMessage = "Напишите что-нибудь!")]
        public string UserSender { get; set; } //данные айдишника пользователя, который отправляет сообщение
        [Required(ErrorMessage = "Напишите что-нибудь!")]
        public string UserReceiver { get; set; } //данные айдишника пользователя, который получает сообщение
    }
}
