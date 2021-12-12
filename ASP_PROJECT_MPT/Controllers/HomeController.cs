using ASP_PROJECT_MPT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ASP_PROJECT_MPT.Controllers
{
    public class HomeController : Controller
    {
        private AplicationContext db;
        private IHttpContextAccessor _httpContextAccessor;
        private IWebHostEnvironment _app;
        public HomeController(AplicationContext context, IWebHostEnvironment app)
        {
            db = context;
            _app = app;
        }

        public IActionResult AddFile()
        {
            return View(db.Files.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            if (file != null)
            {
                string path = "/Files/" + file.FileName;
                using (var fileStream = new FileStream(_app.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                FileModel newfile = new FileModel { Name = file.FileName, Path = path};
                db.Files.Add(newfile);
               await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<ActionResult> Index( int? id, string login, string email, int page = 1, SortState sortOrder = SortState.IdAsc)
        {
            //ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            //ViewData["EmailSort"] = sortOrder == SortState.EmailAsc ? SortState.EmailDesc : SortState.EmailAsc;
            //ViewData["LoginSort"] = sortOrder == SortState.LoginAsc ? SortState.LoginDesc : SortState.LoginAsc;
            IQueryable <User> users = db.Users;
            //Фильтрация или поиск
            // var users = db.Users.OrderBy(m => m.Id);
            if (id != null && id > 0)
            {
                users = users.Where(p => p.Id == id);
            }
            if (!String.IsNullOrEmpty(login))
               
            {
                users = users.Where(p => p.Login.Contains(login));
            }
            //сортировка
            switch (sortOrder)
            {
                case SortState.IdAsc:
                    {
                        users = users.OrderBy(m => m.Id);
                        break;
                    }

                case SortState.IdDesc:
                    {
                        users = users.OrderByDescending(m => m.Id);
                        break;
                    }

                case SortState.EmailAsc:
                    {
                        users = users.OrderBy(m => m.Email);
                        break;
                    }

                case SortState.EmailDesc:
                    {
                        users = users.OrderByDescending(m => m.Email);
                        break;
                    }


                case SortState.LoginAsc:
                    {
                        users = users.OrderBy(m => m.Login);
                        break;
                    }

                case SortState.LoginDesc:
                    {
                        users = users.OrderByDescending(m => m.Login);
                        break;
                    }
                default:
                    {
                        users = users.OrderBy(m => m.Id);
                        break;
                    }

            }
            //Пагинация
            int pageSize = 4;
            var count = await users.CountAsync();
            var item = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel  = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(id, email, login),
                Users = item
            };

                return View(viewModel);
        }
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
       
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> OtherUserBlog(string login) //Тоже самое что и Index
        {
            IQueryable<Post> posts = db.Posts;
            if (!String.IsNullOrEmpty(login))
                posts = posts.Where(p => p.UserId.Contains(login));
            var item = await posts.ToListAsync();
            BlogViewModel BlogViewModel = new BlogViewModel
            {
                BlogFilterViewModel = new BlogFilterViewModel(login), //создать новый filterviewmodel
                Posts = item
            };
            return View(BlogViewModel);
        }

        //public async Task<ActionResult> Blog() //Тоже самое что и Index
        //{
        //    //var pos = db.Posts.Include(c => c.UserId);
        //    //IQueryable<Post> Posts = db.Posts.Include(c => c.UserId);
        //    ////if (id != null && id > 0)
        //    //{
        //    //    Posts = Posts.Where(p => p.UserId == id);
        //    //}

        //    //var posts = await Posts.ToListAsync();
        //    return View(await db.Posts.ToListAsync());

        //}

        //public IActionResult CreateBlog()// Страница создания постов
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateBlog(PostModel model)//Создание поста возврат его на страницу Blog
        //{
        //    //string cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["IdUser"];

        //         //В этом способе все посты выкладываются от имени админа (то есть от первого Id)
        //         //if (ModelState.IsValid)
        //         //{
        //         // User userid = await db.Users.FirstOrDefaultAsync(u => u.Id == model.UserId);

        //    // Post post = await db.Posts.Include(u => u.User).FirstOrDefaultAsync(u => u.User == model.UserId);

        //    Post post = new Post { Title = model.Title, Message = model.Message }; //прописать строчку с куки 
        //                                                                                                //скорее всего выпилить отсюда создание простов и вставить в Forregcontroller

        //  //  User userId = await db.Users.FirstOrDefaultAsync(r => r.Login == );


        //        //if (userId != null)
        //        //     post.User = userId;


        //        db.Posts.Add(post);
        //        await db.SaveChangesAsync();

        //        return RedirectToAction("Blog");
        //    //}


        //    //return RedirectToAction("Blog");


        //    //Стандартный способ, как с Index
        //    //db.Posts.Add(post);
        //    //await db.SaveChangesAsync();
        //    //return RedirectToAction("Blog");
        //}




        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User post = await db.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (post != null)
                {
                    db.Users.Remove(post);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        [HttpGet]
        [ActionName("DeletePost")]
        public async Task<IActionResult> ConfirmDeletePost(int? id)
        {
            if (id != null)
            {
                Post post = await db.Posts.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }

       
        [HttpPost]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id != null)
            {
                Post user = await db.Posts.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                {
                    db.Posts.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Blog", "ForReg");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }


        public async Task<IActionResult> DetailsUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        public async Task<IActionResult> DetailsUserBlog(string login)
        {
            if (login != null)
            {
                Post post = await db.Posts.FirstOrDefaultAsync(predicate => predicate.UserId == login);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }
    }
}
