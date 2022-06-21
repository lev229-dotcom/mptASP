using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Hubs
{


    public class WebRTCHub : Hub
    {
        private static RoomManager roomManager = new RoomManager();

        /// <summary>
        /// Метод при присоединении 
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        /// <summary>
        /// Метод вызывающийся при отключении
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            roomManager.DeleteRoom(Context.ConnectionId);
            _ = NotifyRoomInfoAsync(false);
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// Создание комнаты
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task CreateRoom(string name)
        {
            RoomInfo roomInfo = roomManager.CreateRoom(Context.ConnectionId, name);
            if (roomInfo != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomInfo.RoomId);
                await Clients.Caller.SendAsync("created", roomInfo.RoomId);
                await NotifyRoomInfoAsync(false);
            }
            else
            {
                await Clients.Caller.SendAsync("error", "error occurred when creating a new room.");
            }
        }

        /// <summary>
        /// Присоеденение к комнате
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task Join(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Caller.SendAsync("joined", roomId);
            await Clients.Group(roomId).SendAsync("ready");

            //remove the room from room list.
            if (int.TryParse(roomId, out int id))
            {
                roomManager.DeleteRoom(id);
                await NotifyRoomInfoAsync(false);
            }
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task LeaveRoom(string roomId)
        {
            await Clients.Group(roomId).SendAsync("bye");
        }

        /// <summary>
        /// Получение информации о чате
        /// </summary>
        /// <returns></returns>
        public async Task GetRoomInfo()
        {
            await NotifyRoomInfoAsync(true);
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string roomId, object message)
        {
            await Clients.OthersInGroup(roomId).SendAsync("message", message);
        }

        /// <summary>
        /// Уведомление по появлении комнаты
        /// </summary>
        /// <param name="notifyOnlyCaller"></param>
        /// <returns></returns>
        public async Task NotifyRoomInfoAsync(bool notifyOnlyCaller)
        {
            List<RoomInfo> roomInfos = roomManager.GetAllRoomInfo();
            var list = from room in roomInfos
                       select new
                       {
                           RoomId = room.RoomId,
                           Name = room.Name,
                           Button = "<button class=\"joinButton\">Join!</button>"
                       };
            var data = JsonConvert.SerializeObject(list);

            if (notifyOnlyCaller)
            {
                await Clients.Caller.SendAsync("updateRoom", data);
            }
            else
            {
                await Clients.All.SendAsync("updateRoom", data);
            }
        }
    }

    /// <summary>
    /// RУправление комнатой
    /// </summary>
    public class RoomManager
    {
        private int nextRoomId;
        /// <summary>
        /// Список комнат 
        /// </summary>
        private ConcurrentDictionary<int, RoomInfo> rooms;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public RoomManager()
        {
            nextRoomId = 1;
            rooms = new ConcurrentDictionary<int, RoomInfo>();
        }
        /// <summary>
        /// Создание комнаты
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public RoomInfo CreateRoom(string connectionId, string name)
        {
            rooms.TryRemove(nextRoomId, out _);

            //create new room info
            var roomInfo = new RoomInfo
            {
                RoomId = nextRoomId.ToString(),
                Name = name,
                HostConnectionId = connectionId
            };
            bool result = rooms.TryAdd(nextRoomId, roomInfo);

            if (result)
            {
                nextRoomId++;
                return roomInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Удаление комнаты
        /// </summary>
        /// <param name="roomId"></param>
        public void DeleteRoom(int roomId)
        {
            rooms.TryRemove(roomId, out _);
        }
        /// <summary>
        /// Удаление комнаты
        /// </summary>
        /// <param name="connectionId"></param>
        public void DeleteRoom(string connectionId)
        {
            int? correspondingRoomId = null;
            foreach (var pair in rooms)
            {
                if (pair.Value.HostConnectionId.Equals(connectionId))
                {
                    correspondingRoomId = pair.Key;
                }
            }

            if (correspondingRoomId.HasValue)
            {
                rooms.TryRemove(correspondingRoomId.Value, out _);
            }
        }
        /// <summary>
        /// Поолучение информации о всех комнатах
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> GetAllRoomInfo()
        {
            return rooms.Values.ToList();
        }
    }
    /// <summary>
    /// Класс с полями для создания комнаты
    /// </summary>
    public class RoomInfo
    {
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string HostConnectionId { get; set; }
    }

}
