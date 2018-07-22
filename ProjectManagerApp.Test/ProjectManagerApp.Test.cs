using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using DataLayer;

namespace ProjectManagerApp.Test
{
    [TestFixture]
    public class ProjectManagerApp
    {
        [Test]
        public void GetTasks()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            var tasks = new List<DataLayer.Task>();
            tasks.Add(new DataLayer.Task() { Task1 = "Test", Start_Date = DateTime.Now, End_Date = DateTime.Now.AddDays(7), Priority = 7 });
            mockObj.Setup(x => x.GetTasks()).Returns(tasks);
            //Assert
            var actualTasks = businessLayer.GetTasks();
            Assert.AreEqual(tasks.Count(), actualTasks.Count());
            Assert.AreEqual(tasks.FirstOrDefault().Task1, actualTasks.FirstOrDefault().Task);

        }
        [Test]
        public void GetProjects()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            var projects = new List<DataLayer.Project>();
            projects.Add(new DataLayer.Project() { Project1 = "Test", Priority = 5, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2) });
            mockObj.Setup(x => x.GetProjects()).Returns(projects);
            //Assert
            var actualProjects = businessLayer.GetProjects();
            Assert.AreEqual(projects.Count(), actualProjects.Count());
            Assert.AreEqual(projects.FirstOrDefault().Project1, actualProjects.FirstOrDefault().Project);

        }

        [Test]
        public void GetUsers()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            var users = new List<DataLayer.User>();
            users.Add(new DataLayer.User() { FirstName = "Test", LastName = "Test", Employee_ID = 459430 });
            mockObj.Setup(x => x.GetUsers()).Returns(users);
            //Assert
            var actualUsers = businessLayer.GetUsers();
            Assert.AreEqual(users.Count(), actualUsers.Count());
            Assert.AreEqual(users.FirstOrDefault().FirstName, actualUsers.FirstOrDefault().FirstName);

        }

        [Test]
        public void GetParentTasks()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            var ptasks = new List<DataLayer.ParentTask>();
            ptasks.Add(new DataLayer.ParentTask() { Parent_Task = "PTask" });
            mockObj.Setup(x => x.GetParentTasks()).Returns(ptasks);
            //Assert
            var actualParents = businessLayer.GetparentTasks();
            Assert.AreEqual(ptasks.Count(), actualParents.Count());
            Assert.AreEqual(ptasks.FirstOrDefault().Parent_Task, actualParents.FirstOrDefault().Parent_Task);

        }

        [Test]
        public void GetSpecificTask()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            var tasks = new DataLayer.Task() { Task1 = "TestTest", Start_Date = DateTime.Now, End_Date = DateTime.Now.AddDays(7), Parent_ID = 5 };

            mockObj.Setup(x => x.GetSpecificTask(It.IsAny<int>())).Returns(tasks);
            //Assert
            var actualTasks = businessLayer.GetSpecificTask(It.IsAny<int>());
            Assert.AreEqual(tasks.Task1, actualTasks.Task);

        }

        [Test]
        public void GetSpecificUser()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            var users = new DataLayer.User() { FirstName = "Test", LastName = "Test", Employee_ID = 459430 };

            mockObj.Setup(x => x.GetSpecificUser(It.IsAny<int>())).Returns(users);
            //Assert
            var actualUsers = businessLayer.GetSpecificUser(It.IsAny<int>());
            Assert.AreEqual(users.FirstName, actualUsers.FirstName);

        }

        [Test]
        public void EndTask()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            /*ar tasks = new Task_Table() { Task = "P", Start_Date = DateTime.Now, End_Date = DateTime.Now.AddDays(7), Parent_ID = 5 };*/

            //mockObj.Setup(x => x.EndTask(It.IsAny<int>())).Returns(tasks);
            //Assert
            businessLayer.EndTask(5);
            mockObj.Verify(x => x.EndTask(It.IsAny<int>()), Times.Once);

        }

        [Test]
        public void EndProject()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            /*ar tasks = new Task_Table() { Task = "P", Start_Date = DateTime.Now, End_Date = DateTime.Now.AddDays(7), Parent_ID = 5 };*/

            //mockObj.Setup(x => x.EndTask(It.IsAny<int>())).Returns(tasks);
            //Assert
            businessLayer.EndProject(5);
            mockObj.Verify(x => x.EndProject(It.IsAny<int>()), Times.Once);

        }
        [Test]
        public void AddTask()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            /*ar tasks = new Task_Table() { Task = "TestTest", Start_Date = DateTime.Now, End_Date = DateTime.Now.AddDays(7), Parent_ID = 5 };*/

            //mockObj.Setup(x => x.EndTask(It.IsAny<int>())).Returns(tasks);
            //Assert
            businessLayer.AddTask(new BusinessLayer.Models.TaskModel() { Task_ID = 5 });
            mockObj.Verify(x => x.AddTask(It.IsAny<DataLayer.Task>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>()), Times.Once);
        }

        [Test]
        public void UpdateTask()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            var taskModel = new BusinessLayer.Models.TaskModel() { Task_ID = 5, Priority = 2, StartDate = DateTime.Now.ToString(), EndDate = DateTime.Now.AddDays(7).ToString() };
            mockObj.Setup(x => x.GetSpecificTask(It.IsAny<int>())).Returns(new DataLayer.Task() { Task1 = "test" });
            //Assert
            businessLayer.UpdateTask(taskModel);
            mockObj.Verify(x => x.GetSpecificTask(It.IsAny<int>()), Times.Once);
            mockObj.Verify(x => x.UpdateTask(It.IsAny<DataLayer.Task>(), It.IsAny<int?>(), It.IsAny<int?>()), Times.Once);
        }

        [Test]
        public void DeleteUser()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            businessLayer.DeleteUser(5);
            //Assert
            mockObj.Verify(x => x.DeleteUser(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void AddUser()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            //Assert
            businessLayer.AddUser(new BusinessLayer.Models.UserModel() { User_ID = 5 });
            mockObj.Verify(x => x.AddUser(It.IsAny<DataLayer.User>()), Times.Once);
        }

        [Test]
        public void UpdateUser()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            //Assert
            businessLayer.UpdateUser(new BusinessLayer.Models.UserModel() { User_ID = 5 });
            mockObj.Verify(x => x.UpdateUser(It.IsAny<DataLayer.User>()), Times.Once);
        }

        [Test]
        public void AddProject()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            //Assert
            businessLayer.AddProject(new BusinessLayer.Models.ProjectModel() { Project_ID = 5 });
            mockObj.Verify(x => x.AddProject(It.IsAny<DataLayer.Project>(), It.IsAny<int?>(), It.IsAny<int?>()), Times.Once);
        }
        [Test]
        public void UpdateProject()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            //Assert
            businessLayer.UpdateProject(new BusinessLayer.Models.ProjectModel() { Project_ID=5});
            mockObj.Verify(x => x.UpdateProject(It.IsAny<DataLayer.Project>(), It.IsAny<int?>()), Times.Once);
        }

        [Test]
        public void AddParentTask()
        {
            var mockObj = new Mock<IRepository>();
            var businessLayer = new BusinessLayer.ProjectManagerCore(mockObj.Object);
            //Assert
            businessLayer.AddParentTask("test");
            mockObj.Verify(x => x.AddParentTask(It.IsAny<string>()), Times.Once);
        }

    }
}
