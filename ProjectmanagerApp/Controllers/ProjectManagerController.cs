using BusinessLayer.Models;
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
        private BusinessLayer.ProjectManagerCore _businessLayer;
        public ProjectManagerController()
        {
            var businessLayer = new BusinessLayer.ProjectManagerCore();
            _businessLayer = businessLayer;    
        }

        // POST: api/TaskManager
        [HttpPost]
        [Route("AddUser")]
        public void AddUser(UserModel user)
        {
            _businessLayer.AddUser(user);
        }

        [HttpGet]
        [Route("GetUser")]
        public List<UserModel> GetUser()
        {
            return _businessLayer.GetUsers();
        }
    }
}
