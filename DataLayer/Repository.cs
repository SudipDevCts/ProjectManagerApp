using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Repository: IRepository
    {
        private ProjectManagerDBEntities _db;
        public Repository()
        {
            ProjectManagerDBEntities db = new ProjectManagerDBEntities();
            _db = db;
        }
        public Repository(ProjectManagerDBEntities db)
        {
            _db = db;
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            var usr = _db.Users.FirstOrDefault(x=>x.User_ID == user.User_ID);
            usr.FirstName = user.FirstName;
            usr.LastName = user.LastName;
            usr.Employee_ID = user.Employee_ID;
            _db.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            _db.Users.Remove(_db.Users.FirstOrDefault(x => x.User_ID == userId));
            _db.SaveChanges();
        }
        public User GetSpecificUser(int userId)
        {
            return _db.Users.FirstOrDefault(x => x.User_ID == userId);
        }
        

        public void AddProject(Project project, int? userId=null, int? taskId = null)
        {
            if(userId.HasValue)
            {
                var user = _db.Users.FirstOrDefault(x => x.User_ID == userId.Value);
                if (user != null)
                {
                    project.Users.Add(user);
                }
                
            }
            if (taskId.HasValue)
            {
                project.Tasks.Add(_db.Tasks.FirstOrDefault(x => x.Task_ID == taskId.GetValueOrDefault()));
            }
            _db.Projects.Add(project);
            _db.SaveChanges();

        }
        public void UpdateProject(Project prj, int? userId = null)
        {
            User user = null;
            var project = _db.Projects.FirstOrDefault(x=>x.Project_ID == prj.Project_ID);
            project.Project1 = prj.Project1;
            project.Priority = prj.Priority;
            project.StartDate = prj.StartDate;
            project.EndDate = prj.EndDate;
            if ( userId.HasValue && userId.Value > 0)
            {
                user = _db.Users.FirstOrDefault(x => x.User_ID == userId.Value);
                project.Users.Add(user);
            }

            //if (project.Users.Count() == 0 && userId.HasValue && userId.Value > 0)
            //{
            //    user = _db.Users.FirstOrDefault(x => x.User_ID == userId.GetValueOrDefault());
            //    project.Users.Add(user);
            //}
            //else if (project.Users.Count() > 0 && userId.HasValue && userId.Value > 0)
            //{
            //    user = _db
            //}

            _db.SaveChanges();
        }

        public List<Project> GetProjects()
        {
           return _db.Projects.ToList();
        }
        public void EndProject(int projectId)
        {
            var project = _db.Projects.FirstOrDefault(x => x.Project_ID == projectId);
            project.EndDate = DateTime.Now;
            _db.SaveChanges();

        }

        public List<ParentTask> GetParentTasks()
        {
            return _db.ParentTasks.ToList();
        }

        public List<Task> GetTasks()
        {
            return _db.Tasks.ToList();
        }
        public void AddParentTask(string taskTitle)
        {
            try { 
            var parent = new ParentTask();
            parent.Parent_Task = taskTitle;
            _db.ParentTasks.Add(parent);
            _db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public void AddTask(DataLayer.Task task, int? parentId=null, int? userId=null, int? projectId=null)
        {
            if (userId.HasValue)
            {
                var user = _db.Users.FirstOrDefault(x => x.User_ID == userId.Value);
                if (user != null)
                {
                    task.Users.Add(user);
                }
                task.Project_ID = projectId;
                if(parentId.HasValue && parentId.Value > 0)
                task.Parent_ID = parentId;

            }
            _db.Tasks.Add(task);
            _db.SaveChanges();

        }

        public void EndTask(int taskId)
        {
            var task = _db.Tasks.FirstOrDefault(x => x.Task_ID == taskId);
            task.Status = "Complete";
            _db.SaveChanges();
        }
    }
}
