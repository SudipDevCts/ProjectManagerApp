using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProjectManagerCore
    {
        private IRepository _repository;
        public ProjectManagerCore()
        {
            _repository = new Repository();
        }
        public ProjectManagerCore(IRepository repository)
        {
            _repository = repository;
        }

        public void AddUser(Models.UserModel userModel)
        {
            var user = new User();
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Employee_ID = userModel.EmployeeId;
            _repository.AddUser(user);
        }

        public List<Models.UserModel> GetUsers()
        {
            var users = _repository.GetUsers();
            var userModels = new List<Models.UserModel>();
            foreach (var usr in users)
            {
                var usrModel = new Models.UserModel()
                {
                    User_ID = usr.User_ID,
                    FirstName = usr.FirstName,
                    LastName = usr.LastName,
                    EmployeeId = usr.Employee_ID.GetValueOrDefault()
                };
                userModels.Add(usrModel);
            }
            return userModels;
        }

        public void UpdateUser(Models.UserModel userModel)
        {
            var user = new User();
            user.User_ID = userModel.User_ID;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Employee_ID = userModel.EmployeeId;
            _repository.UpdateUser(user);
        }
        public void DeleteUser(int uiserId)
        {
            _repository.DeleteUser(uiserId);
        }

        public void AddProject(Models.ProjectModel project)
        {
            var projectDb = new Project();
            projectDb.Project1 = project.Project;
            projectDb.Priority = project.Priority;
            if (project.StartDate != null)
                projectDb.StartDate = Convert.ToDateTime(project.StartDate);
            if (project.EndDate != null)
                projectDb.EndDate = Convert.ToDateTime(project.EndDate);
            _repository.AddProject(projectDb, project.UserId);
        }

        public List<Models.ProjectModel> GetProjects()
        {
            var projects = _repository.GetProjects();
            var projectModels = new List<Models.ProjectModel>();
            foreach (var pr in projects)
            {
                var prModel = new Models.ProjectModel();
                prModel.Project = pr.Project1;
                prModel.Project_ID = pr.Project_ID;
                prModel.Priority = pr.Priority.GetValueOrDefault();
                prModel.StartDate = pr.StartDate.ToString();
                prModel.EndDate = pr.EndDate.ToString();
                prModel.TaskCount = pr.Tasks.Count();
                prModel.UserId = pr.Users.Count() > 0 ? pr.Users.FirstOrDefault().User_ID: 0;
                prModel.CompletedTasks = pr.Tasks != null ? pr.Tasks.Count(x => x.Status == "Complete") : 0;
                projectModels.Add(prModel);
            }
            return projectModels;
        }
        public void EndProject(int projectId)
        {
            _repository.EndProject(projectId);
        }
        public BusinessLayer.Models.UserModel GetSpecificUser(int userId)
        {
            var userDb= _repository.GetSpecificUser(userId);
            var user = new Models.UserModel() { FirstName= userDb.FirstName, LastName = userDb.LastName, EmployeeId = userDb.Employee_ID.GetValueOrDefault(), User_ID = userDb.User_ID};
            return user;
        }
        public void UpdateProject(Models.ProjectModel prj)
        {
            Project project = new Project();
            project.Project_ID = prj.Project_ID;
            project.Project1 = prj.Project;
            project.Priority = prj.Priority;
            project.StartDate = Convert.ToDateTime(prj.StartDate);
            project.EndDate = Convert.ToDateTime(prj.EndDate);
            _repository.UpdateProject(project, prj.UserId);
        }

        public void AddParentTask(string title)
        {
            _repository.AddParentTask(title);
        }

        public List<Models.ParentTask> GetparentTasks()
        {
            var parentTasks = _repository.GetParentTasks();
            var result = new List<Models.ParentTask>();
            foreach(var pt in parentTasks)
            {
                var ptask = new Models.ParentTask() { Parent_ID = pt.Parent_ID, Parent_Task = pt.Parent_Task };
                result.Add(ptask);
            }
            return result;
        }

        public List<Models.TaskModel> GetTasks()
        {
            var tasks = _repository.GetTasks();
            var result = new List<Models.TaskModel>();
            foreach (var ts in tasks)
            {
                var ptask = new Models.TaskModel() {
                    Task_ID = ts.Task_ID,
                    Task = ts.Task1,
                    Parent_ID = ts.Parent_ID.GetValueOrDefault(),
                    Project_ID = ts.Project_ID.GetValueOrDefault(),
                    User_ID = (ts.Users.FirstOrDefault()?.User_ID).GetValueOrDefault(),
                    StartDate = Convert.ToString(ts.Start_Date),
                    EndDate = Convert.ToString(ts.End_Date),
                    Priority = ts.Priority.GetValueOrDefault(),
                    TaskStatus = ts.Status,
                    IsEditable = string.IsNullOrEmpty(ts.Status) ? true : ts.Status == "Complete" ? false : true,
                    ParentTask = ts.ParentTask != null ? ts.ParentTask.Parent_Task : "This Task has no parent"

            };
                result.Add(ptask);
            }
            return result;
        }

        public void AddTask(Models.TaskModel taskModel)
        {
            var task = new DataLayer.Task();
            task.Task1 = taskModel.Task;
            task.Priority = taskModel.Priority;
            if (taskModel.StartDate != null)
                task.Start_Date = Convert.ToDateTime(taskModel.StartDate);
            if (taskModel.EndDate != null)
                task.End_Date = Convert.ToDateTime(taskModel.EndDate);
            _repository.AddTask(task, taskModel.Parent_ID, taskModel.User_ID, taskModel.Project_ID);
        }

        public void EndTask(int taskId)
        {
            _repository.EndTask(taskId);
        }
    }
}
