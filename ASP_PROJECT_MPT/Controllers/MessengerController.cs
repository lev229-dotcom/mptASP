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
using Microsoft.AspNetCore.SignalR;

namespace ASP_PROJECT_MPT.Controllers
{
    public class MessengerController : Controller
    {
        private AplicationContext _context;
     
        private IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContextAccessor"></param>
        public MessengerController(AplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Отображение страницы
        /// </summary>
        /// <returns></returns>
        public IActionResult WebRTC()
        {
            return View();
        }
        /// <summary>
        /// Удаление чата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("DeleteChat")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Chat chat = await _context.Chats.FirstOrDefaultAsync(predicate => predicate.ChatId == id);
                if (chat != null)
                    return View(chat);
            }
            return NotFound();
        }
        /// <summary>
        /// Удаление чата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteChat(int? id)
        {
            if (id != null)
            {
                Chat chat = await _context.Chats.FirstOrDefaultAsync(predicate => predicate.ChatId == id);
                if (chat != null)
                {
                    _context.Chats.Remove(chat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChatTable");
                }
            }
            return NotFound();
        }
        /// <summary>
        /// Редактирование чата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditChat(int? id)
        {
            if (id != null)
            {
                Chat chat = await _context.Chats.FirstOrDefaultAsync(predicate => predicate.ChatId == id);
                if (chat != null)
                    return View(chat);
            }
            return NotFound();
        }
        /// <summary>
        /// Редактирование чата
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditChat(Chat chat)
        {
            _context.Chats.Update(chat);
            await _context.SaveChangesAsync();
            return RedirectToAction("ChatTable");
        }
        /// <summary>
        /// Создание чата
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateChat()
        {
            return View();
        }
        /// <summary>
        /// Создание чата
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateChat(Chat chat)
        {
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
            return RedirectToAction("ChatTable");
        }

        /// <summary>
        /// Создание чата
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult>  MesBeg()
        {
            IQueryable<Message> messages = _context.Messages;
            var item = await messages.ToListAsync();
            
            MessageViewModel postViewModel = new MessageViewModel
            {
                Messages = item
            };
            return View(postViewModel);
        }
        /// <summary>
        /// Таблица чатов
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult>  ChatTable()
        {
            IQueryable<Chat> chats = _context.Chats;
            var item = await chats.ToListAsync();

            ChatTableViewModel chatViewModel = new ChatTableViewModel
            {
                Chats = item
            };
            return View(chatViewModel);
        }
        /// <summary>
        /// Создание таблицы чатов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Chat(int id)
        {
            IQueryable<Message> messages = _context.Messages;
            if (!String.IsNullOrEmpty(Convert.ToString(id)))
                messages = messages.Where(p => p.ChatId.ToString().Contains(Convert.ToString(id)));
            var item = await messages.ToListAsync();
            ChatTableViewModel messagesViewModel = new ChatTableViewModel
            {
                Messages = item
            };
            return View(GetChat(id));
        }
        /// <summary>
        /// Отображение страницы
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Test()
        {
           
            return View();
        }

        //[HttpGet("{id}")]
        //public IActionResult Chat(int id)
        //{
        //    return View(GetChat(id));
        //}
        /// <summary>
        /// Сортировка чатов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Chat GetChat(int id)
        {
            return _context.Chats
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.ChatId == id);
        }
        /// <summary>
        /// Отправка сообщений
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="message"></param>
        /// <param name="username"></param>
        /// <param name="chat"></param>
        /// <returns></returns>
        public async Task<IActionResult> SendMessage(int roomId, string message,string username, [FromServices] IHubContext<ChatHub> chat)
        {
            var Message = await CreateMessage(message, roomId);

            await chat.Clients.Group(roomId.ToString()).SendAsync("Receive", Message, username);


            return Ok();
        }
        /// <summary>
        /// Создание сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public async Task<Message> CreateMessage( string message, int chatId)
        {
            var Message = new Message
            {
               
                MessageStr = message,
                ChatId = chatId,
                Timestamp = DateTime.Now
            };

           

            return Message;
        }

      

    }
}
