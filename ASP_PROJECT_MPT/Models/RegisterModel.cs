using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Otchestvo { get; set; }
        public string Description { get; set; }
        public String Date_Brith { get; set; }
        public string Image { get; set; }
        public string Login { get; set; }

        public IFormFile Avatar { get; set; }
        //ДИВ ДЛЯ ПОВТОРА ПАРОЛЯ ПОКА НЕ ЗАМОРОЖЕН (Create.cshtml)
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
