using ASP_PROJECT_MPT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;


namespace ASP_PROJECT_MPT
{
    public class ChatHub : Hub
    {
        private AplicationContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Конструктор чата
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContextAccessor"></param>
        public ChatHub(AplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Функция чата
        /// </summary>
        /// <param name="message"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task SendToUser(string message, string to)
        {
            string userName = Context.User.Identity.Name;

            if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
                await Clients.User(Context.UserIdentifier).SendAsync("ReceiveUser", message, userName);
            await Clients.User(to).SendAsync("ReceiveUser", message, userName);
        }
        ////var user = Context.User;
        ////var userName = user.Identity.Name;
        //// получаем роль
        //var userRole = user.FindFirst(ClaimTypes.Role)?.Value;
        //// принадлежит ли пользователь роли "admins"
        //var isAdmin = user.IsInRole("admin");
        /// <summary>
        /// Присоедениение
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task JoinRoom(string roomId, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Group(roomId).SendAsync("Notify", $"{username} вошел в чат");
        }
        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <param name="userName"></param>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public async Task SendChat(string message, string userName, string chatId)
        {
            await Clients.All.SendAsync("Send", message, userName, chatId);
        }

        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("Notify", $"Приветствуем1 {Context.UserIdentifier}");
        //    await base.OnConnectedAsync();
        //}
        /// <summary>
        /// Присоедениение к чату
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task Join(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Caller.SendAsync("joined", roomId);
            await Clients.Group(roomId).SendAsync("ready");
        }

        string groupname = "cats";
        /// <summary>
        /// Вход в чат
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task Enter(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                await Clients.Caller.SendAsync("Notify", "Для входа в чат введите логин");
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
                await Clients.Group(groupname).SendAsync("Notify", $"{username} вошел в чат");
            }
        }
        /// <summary>
        /// Отправка сообщений
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="message"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task Send(string roomId, string message, string username)
        {
            await Clients.Group(roomId).SendAsync("Receive", message, username);
            var msg = new Message { MessageStr = username + ": " + message, Timestamp = DateTime.Now ,ChatId = Convert.ToInt32(roomId)};
            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Добавление фото
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roomId"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task AddImg(Chat model, string roomId, string username)
        {
            //Message message = new Message { ChatId = Convert.ToInt32(roomId) };
            //if(model.Image != null)
            //{
            //    byte[] imageData = null;
            //    using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
            //    {
            //        imageData = binaryReader.ReadBytes((int)model.Image.Length);
            //    }
            //    message.Image = imageData;
            //}

            //await Clients.Group(roomId).SendAsync("ReceiveImg");
        }

    }

   
}
