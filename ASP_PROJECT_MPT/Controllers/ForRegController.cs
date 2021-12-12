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

namespace ASP_PROJECT_MPT.Controllers
{
    public class ForRegController : Controller
    {

        private AplicationContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public string cookieValue;
        public string cookieValueConst;
        //byte[] test_;
        public ForRegController(AplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

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
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Append("IdUser", user.Login, cookie);

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    if (user.Role.Name == "user")
                    return RedirectToAction("DetailsUser", "Home", new { user.Id });
                    else
                        return RedirectToAction("Index", "Home");

                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Autorization()
        {
            //string cookieValueUserId = _httpContextAccessor.HttpContext.Request.Cookies["IdUser"];
            //ViewData["IdUser"] = cookieValue;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Autorization(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (user.Role == null)
                        user.Role = userRole;

                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Append("IdUser", user.Login, cookie); //Создание Cookie-файла
                    Response.Cookies.Append("IdUser1", user.Id.ToString(), cookie);
                    //Response.Cookies.Append("UserAvatar", user.Avatar.ToString(), cookie);
                    //cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser"];
                    //cookieValueConst = _httpContextAccessor.HttpContext.Request.Cookies["UserAvatar"]; ;
                    //test_ = Encoding.UTF8.GetBytes(cookieValueConst);// удобно для конвертации строки в массив байтов
                    //ViewData["UserAvatar"] = test_;
                    await Authenticate(user); // аутентификация    
                    if (user.Role.Name == "user")
                        return RedirectToAction("DetailsUser", "Home", new { user.Id} ); // эта перегрузка очень удобна чтобы сразу данные аккаунта видеть после входа
                                                                                     // третий параметр это айдишник
                                                                                     // Потом вместо Details нужно создать именно вкладку стены пользователя с вкладкой поиска
                                                                                     //других пользователей  и создать кнопку создания постов 
                    else
                        return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ReturnToMyInfo(User model)
        {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
            return RedirectToAction("DetailsUser", "Home", new { cookieValue }); // эта перегрузка очень удобна чтобы сразу данные аккаунта видеть после входа
        }
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

        public IActionResult CreateBlog()// Страница создания постов
        {
            return View();
        }

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
            byte[] test_ = Encoding.UTF8.GetBytes(cookieValue);
            Post post = new Post { Title = model.Title, Message = model.Message, UserId = cookieValue }; //прописать строчку с куки 
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

        [HttpPost]
        public async Task<IActionResult> EditPost(Post model)
        {
            cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser1"];
             //model = new Post { Title = model.Title, Message = model.Message, UserId = cookieValue };
            _context.Posts.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("OtherUserBlog", "Home", new {cookieValue});
        }

       
        public ActionResult UserHomePage(LoginModel model)
        {
            cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser1"];
            return RedirectToAction("DetailsUser", "Home", new {id = cookieValue });
        }
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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Autorization", "ForReg");
        }


    }
}
