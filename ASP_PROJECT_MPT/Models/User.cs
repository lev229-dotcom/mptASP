using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ASP_PROJECT_MPT.Models
{
    public class User 
    {
        
        public int Id { get; set; }
        [EmailAddress]
        public String Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
       
        public string Last_Name { get; set; }
        public string Otchestvo { get; set; }
        public string Description { get; set; }
        public String Date_Brith { get; set; }
        public string Image { get; set; }
        public byte[] Avatar { get; set; }
        public int Code { get; set; }


        public int? RoleId { get; set; } // не может быть равен null
        public Role Role { get; set; }

        public List<Post> Posts { get; set; }
        public User() 
        {
            Posts = new List<Post>();
            
        }

       
       

    }

    public enum SortState
    {
        IdAsc,
        IdDesc,
        EmailAsc,
        EmailDesc,
        LoginAsc,
        LoginDesc
    }
}
