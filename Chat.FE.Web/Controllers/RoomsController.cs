using Chat.BE.Contracts.DTO;
using Chat.BE.Contracts.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chat.FE.Web.Controllers
{
    [Authorize]
    public class RoomsController : ApiController
    {
        
        public IEnumerable<RoomDTO> Get()
        {
            RoomServiceProxy proxy = new RoomServiceProxy();
            
                var rooms = proxy.GetAll();
                return rooms.ToList();                
        }
                
        public string Get(int id)
        {
            return "value";
        }
                
        public void Post([FromBody]string value)
        {
        }
                
        public void Put(int id, [FromBody]string value)
        {
        }
                
        public void Delete(int id)
        {
        }
    }
}