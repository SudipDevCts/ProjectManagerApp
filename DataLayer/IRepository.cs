using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IRepository
    {
        void AddUser(User user);
        List<User> GetUsers();
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void AddProject(Project project, int? userId = null, int? taskId = null);
        List<Project> GetProjects();
        void EndProject(int projectId);
        User GetSpecificUser(int userId);
        void UpdateProject(Project prj, int? userId = null);
        void AddParentTask(string taskTitle);
        List<ParentTask> GetParentTasks();
        void AddTask(DataLayer.Task task, int? parentId = null, int? userId = null, int? projectId = null);
    }
}
