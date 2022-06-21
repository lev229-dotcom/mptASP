using Microsoft.AspNetCore.Mvc;
using ASP_PROJECT_MPT.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace ASP_PROJECT_MPT.Controllers
{
    public class ForRegController : Controller
    {

        private AplicationContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public static string cookieValue { get; set; }
        public string cookieValueConst;
        public static Random random = new Random();
        int code = 126414;
        //byte[] test_;
        /// <summary>
        /// Данный метод необходим для инициализации контекста данных
        /// </summary>
        /// <param name="context">Контекст необходимой таблицы базы данных</param>
        /// <param name="httpContextAccessor">Интерфейс для взаимодействия с контекстом данных</param>
        public ForRegController( AplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Асинхронный метод для восстановления доступа к аккаунту
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        /// <summary>
        /// Асинхронный метод для восстановления доступа к аккаунту
        /// </summary>
        /// <param name="model">Модель данных</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
           
           
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    MailAddress from = new MailAddress("yalev1312@gmail.com", "Администрация сайта");
                    string myAdress = model.Email;
                    MailAddress to = new MailAddress(myAdress);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Код";
                    m.Body = Convert.ToString(code);
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                    smtp.Credentials = new NetworkCredential("yalev1312@gmail.com", "xoxcxvvoozggfmfp");
                    smtp.EnableSsl = true;
                    smtp.Send(m);


                    return RedirectToAction("ForgotPasswordConfirmation", new { model.Email });
                }
               
                // пользователь с данным email может отсутствовать в бд
                // тем не менее мы выводим стандартное сообщение, чтобы скрыть 
                // наличие или отсутствие пользователя в бд
                ModelState.AddModelError("", "Пользователь с данным E-mail не найден");


            }
            return View(model);
        }
        /// <summary>
        /// Поиск пользователя
        /// </summary>
        /// <param name="email"> Жлектронная почта пользователя</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ForgotPasswordConfirmation(string email)
        {
            User user = await _context.Users.FirstOrDefaultAsync(predicate => predicate.Email == email);

            return View(user);
        }
        /// <summary>
        /// Редирект на страницу авторизации
        /// </summary>
        /// <param name="user"> экземпляр класса User</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ForgotPasswordConfirmation(User user)
        {
            if(user.Code == code)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Autorization", "ForReg");
            }
            return View();

            
        }

        
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
       /// <summary>
       /// Добавление пользователя в базу данных
       /// </summary>
       /// <param name="model">Модель данных регистрации</param>
       /// <returns></returns>
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Email = model.Email, Password = model.Password, Login = model.Login, Date_Brith = model.Date_Brith, Last_Name = model.Last_Name, Otchestvo = model.Otchestvo, First_Name = model.First_Name };
                    if (model.Avatar != null)
                    {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                        }
                        user.Avatar = imageData;
                    }
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;
                    //CookieOptions cookie = new CookieOptions();
                    //cookie.Expires = DateTime.Now.AddMinutes(30);

                    //--------------------------------------- ЗАКОММЕНТИРОВАНО ДЛЯ КОРРЕКТНОГО ВХОДА С ДВУХ АККАУНТОВ
                    //Response.Cookies.Append("IdUser", user.Login, cookie);
                    //Response.Cookies.Append("IdUser1", user.Id.ToString(), cookie);

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    //await Authenticate(user); // аутентификация

                    //if (user.Role.Name == "user")
                    //return RedirectToAction("DetailsUser", "Home", new { user.Id });
                    //else
                        return RedirectToAction("Autorization", "ForReg");

                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Autorization()
        {
            //string cookieValueUserId = _httpContextAccessor.HttpContext.Request.Cookies["IdUser"];
            //ViewData["IdUser"] = cookieValue;
            return View();
        }
        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        /// <param name="model">Модель данных для авторизации</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Autorization(LoginModel model)
        {
            if (ModelState.IsValid)// Проверка на валидность модели
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);// Поиск пользователя в базе данных
                if (user != null)// Если пользователь был найден
                {
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");// Поиск роли пользователя в базе данных
                    if (user.Role == null)
                        user.Role = userRole;// Установка роли пользователю

                    CookieOptions cookie = new CookieOptions(); // Создание экземпляра класса куки
                    cookie.Expires = DateTime.Now.AddMinutes(30); // Установка времени действия куки
                   
                    await Authenticate(user); // аутентификация    
                    if (user.Role.Name == "user")
                        return RedirectToAction("DetailsUser", "Home", new { user.Id} ); // Перенаправление пользователя на страницу с информацией
                    else
                        return RedirectToAction("Index", "Home");// Перенаправление администратора на страницу Index
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");// Сообщение об ошибке
            }
            return View(model);// При заполении полей некорректными данными происходит пересоздание страницы
        }




        public async Task<IActionResult> Func1(LoginModel model)
        {if (ModelState.IsValid)
        {User user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
        if (user != null)
        {Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
        if (user.Role == null)
        user.Role = userRole;
        CookieOptions cookie = new CookieOptions();
        cookie.Expires = DateTime.Now.AddMinutes(30);
        await Authenticate(user); 
        if (user.Role.Name == "user")
        return RedirectToAction("DetailsUser", "Home", new { user.Id });
        else
        return RedirectToAction("Index", "Home");}
        ModelState.AddModelError("", "Некорректные логин и(или) пароль");}
        return View(model);}


        /// <summary>
        /// Переход к странице пользователя
        /// </summary>
        /// <param name="model">модель данных пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReturnToMyInfo(User model)
        {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
            return RedirectToAction("DetailsUser", "Home", new { cookieValue }); // эта перегрузка очень удобна чтобы сразу данные аккаунта видеть после входа
        }
        /// <summary>
        /// Старница с постами пользователей
        /// </summary>
        /// <param name="login"> пармаетр для поиска пользователей</param>
        /// <param name="message">пармаетр для поиска постов</param>
        /// <returns></returns>
        public async Task<ActionResult> Blog(string login, string message) //Тоже самое что и Index
        {
            IQueryable<Post> posts = _context.Posts;
            if (!String.IsNullOrEmpty(login))
                posts = posts.Where(p => p.UserId.Contains(login));
            if (!String.IsNullOrEmpty(message))
                posts = posts.Where(p => p.Message.Contains(message));
            var item = await posts.ToListAsync();
            var itemUser = await _context.Users.ToListAsync();
            BlogViewModel BlogViewModel = new BlogViewModel
            {
                BlogFilterViewModel = new BlogFilterViewModel(login), //создать новый filterviewmodel
                Posts = item, 
            };
            return View(BlogViewModel);




           // return View(await _context.Posts.ToListAsync());

            //var pos = db.Posts.Include(c => c.UserId);
            //IQueryable<Post> Posts = db.Posts.Include(c => c.UserId);
            ////if (id != null && id > 0)
            //{
            //    Posts = Posts.Where(p => p.UserId == id);
            //}

            //var posts = await Posts.ToListAsync();
        }
        /// <summary>
        /// Страница с чатами
        /// </summary>
        /// <param name="id">уникальный номер чата</param>
        /// <returns></returns>
        public async Task<IActionResult> MesBeg(int? id)
        {
            if (id != null)
            {
                User user = await _context.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

       /// <summary>
       /// Переход на страницу с личными сообщениями
       /// </summary>
       /// <param name="model">модель данных</param>
       /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> MesBeg (MessageModel model)
        {
           
            return View();
        }
        /// <summary>
        /// Страница создания постов
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateBlog()// Страница создания постов
        {
            return View();
        }
        /// <summary>
        /// Добавление поста в базу данных
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBlog(PostModel model)//Создание поста возврат его на страницу Blog
        {
            //string cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser"];

            //В этом способе все посты выкладываются от имени админа (то есть от первого Id)
            //if (ModelState.IsValid)
            //{
            // User userid = await db.Users.FirstOrDefaultAsync(u => u.Id == model.UserId);

            // Post post = await db.Posts.Include(u => u.User).FirstOrDefaultAsync(u => u.User == model.UserId);
            cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser"];
            cookieValueConst = _httpContextAccessor.HttpContext.Request.Cookies["UserAvatar"];
            User user = await _context.Users.FirstOrDefaultAsync(predicate => predicate.Email == User.Identity.Name);
            //byte[] test_ = Encoding.UTF8.GetBytes(cookieValue);
            Post post = new Post { Title = model.Title, Message = model.Message, UserId = user.Login }; //прописать строчку с куки 
            if (model.PostImage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(model.PostImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)model.PostImage.Length);
                }
                post.PostImage = imageData;
            }                                                                                             //скорее всего выпилить отсюда создание простов и вставить в Forregcontroller

            //  User userId = await db.Users.FirstOrDefaultAsync(r => r.Login == );


            //if (userId != null)
            //     post.User = userId;


            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("OtherUserBlog", "Home", new { login = cookieValue});
            //}


            //return RedirectToAction("Blog");


            //Стандартный способ, как с Index
            //db.Posts.Add(post);
            //await db.SaveChangesAsync();
            //return RedirectToAction("Blog");
        }

        /// <summary>
        /// Редактирование постов
        /// </summary>
        /// <param name="id">уникальный номер поста</param>
        /// <returns></returns>
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id != null)
            {
                Post post = await _context.Posts.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }

        /// <summary>
        /// Добавление изменений в базу данных
        /// </summary>
        /// <param name="model">модель данных поста</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditPost(Post model)
        {
            cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser1"];
             //model = new Post { Title = model.Title, Message = model.Message, UserId = cookieValue };
            _context.Posts.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("OtherUserBlog", "Home", new {cookieValue});
        }

       /// <summary>
       /// Переход на домашнюю страницу
       /// </summary>
       /// <param name="name"> имя пользователя</param>
       /// <returns></returns>
        public async Task<IActionResult> UserHomePage(string name)
        {
            User user = await  _context.Users.FirstOrDefaultAsync(u => u.Email == name);
            cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser1"];
            return RedirectToAction("DetailsUser", "Home", new {id = user.Id });
        }
        /// <summary>
        /// Аутентификация
        /// </summary>
        /// <param name="user">модель данных пользователя</param>
        /// <returns></returns>
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Autorization", "ForReg");
        }
        


    }
}
