﻿using Chat.BE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chat.FE.Web.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        
        public IEnumerable<string> Get()
        {
            return new List<string>();       
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