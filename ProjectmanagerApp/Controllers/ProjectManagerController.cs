using ProjectmanagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectmanagerApp.Controllers
{
    [RoutePrefix("api")]
    public class ProjectManagerController : ApiController
    {
        // POST: api/TaskManager
        [HttpPost]
        [Route("AddUser")]
        public void AddUser(User user)
        {
           
        }
    }
}
