using Chat.BE.Data;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Chat.FE.Web
{
    public static class UsersInRoom
    {
        private static ConcurrentDictionary<string, List<string>> _usersInRooms = new ConcurrentDictionary<string, List<string>>();
        
        static UsersInRoom()
        {
            using (Db db = new Db())
            {
                db.Rooms.Select(r => r.Title).ToList().ForEach(room => {
                    _usersInRooms.TryAdd(room, new List<string>());
                });
            }
        }
                
        public static List<string> GetUsers(string room)
        {
            return _usersInRooms[room];
        }

        public static void AddUserToRoom(string user, string room)
        {
            _usersInRooms[room].Add(user);
        }


        public static void RemoveUserFromRoom(string user, string room)
        {
            _usersInRooms[room].Remove(user);
        }

        public static void AddRoom(string room)
        {
            
            _usersInRooms.TryAdd(room, new List<string>());
        }




    }
}
