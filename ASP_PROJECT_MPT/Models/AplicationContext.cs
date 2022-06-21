using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_PROJECT_MPT.Models
{
    public class AplicationContext : DbContext    
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public AplicationContext(DbContextOptions<AplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Метод для создания записей в базе данных
        /// </summary>
        /// <param name="modelBuilder"> экземпляр класса создания модели</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            //Создание ролей
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id, Login = "AdminGOd" };
            
            Post adminPost = new Post { Id = 1, Title = "Первая запись админа!", Message = "Первый тестовый пост", UserId = adminUser.Login }; //создание поста
            
            Chat chat = new Chat { ChatId = 1, Name = "FirstChat" };
            Chat chat1 = new Chat { ChatId = 2, Name = "SecondChat" };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<Post>().HasData(new Post[] { adminPost });
            modelBuilder.Entity<Chat>().HasData(new Chat[] { chat, chat1 });
            base.OnModelCreating(modelBuilder);
        }

    }
}
