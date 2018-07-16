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


        [HttpPost]
        [Route("AddUser")]
        public void AddUser(UserModel user)
        {
            _businessLayer.AddUser(user);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public void UpdateUser(UserModel user)
        {
            _businessLayer.UpdateUser(user);
        }

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public void DeleteUser(int userId)
        {
            _businessLayer.DeleteUser(userId);
        }

        [HttpGet]
        [Route("User/{userId}")]
        public UserModel GetUser(int userId)
        {
            return _businessLayer.GetSpecificUser(userId);
        }

        [HttpGet]
        [Route("GetUser")]
        public List<UserModel> GetUser()
        {
            return _businessLayer.GetUsers();
        }

        [HttpPost]
        [Route("AddProject")]
        public void AddProject(ProjectModel prj)
        {
            _businessLayer.AddProject(prj);
        }

        [HttpPost]
        [Route("UpdateProject")]
        public void UpdateProject(ProjectModel prj)
        {
            _businessLayer.UpdateProject(prj);
        }

        [HttpGet]
        [Route("GetProject")]
        public List<ProjectModel> GetProject()
        {
            return _businessLayer.GetProjects();
        }

        [HttpPut]
        [Route("EndProject")]
        public void EndTask(ProjectModel project)
        {
            _businessLayer.EndProject(project.Project_ID);
        }
    }
}
