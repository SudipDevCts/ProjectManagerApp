using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using DataLayer;

namespace ProjectManagerApp.Test
{
    [TestFixture]
    public class ProjectManagerAppDataTest
    {
        [Test]
        public void GetTasksData()
        {
            var data = new List<DataLayer.Task>
            {
                new DataLayer.Task { Task1 = "BBB" },
                new DataLayer.Task { Task1 = "ZZZ" },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<DataLayer.Task>>();
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Tasks).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            var tasks = service.GetTasks();

            Assert.AreEqual(data.Count(), tasks.Count());
            Assert.AreEqual(data.First().Task1, tasks.First().Task1);
        }
        [Test]

        public void GetProjectData()
        {
            var data = new List<DataLayer.Project>
            {
                new DataLayer.Project { Project1 = "BBB" },
                new DataLayer.Project { Project1 = "ZZZ" },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<DataLayer.Project>>();
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Projects).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            var projects = service.GetProjects();

            Assert.AreEqual(data.Count(), projects.Count());
            Assert.AreEqual(data.First().Project1, projects.First().Project1);
        }

        [Test]

        public void GetUsersData()
        {
            var data = new List<DataLayer.User>
            {
                new DataLayer.User { FirstName = "BBB" },
                new DataLayer.User { FirstName = "ZZZ" },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<DataLayer.User>>();
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            var users = service.GetUsers();

            Assert.AreEqual(data.Count(), users.Count());
            Assert.AreEqual(data.First().FirstName, users.First().FirstName);
        }
        [Test]

        public void GetParentData()
        {
            var data = new List<DataLayer.ParentTask>
            {
                new DataLayer.ParentTask { Parent_Task = "BBB" },
                new DataLayer.ParentTask { Parent_Task = "ZZZ" },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<DataLayer.ParentTask>>();
            mockSet.As<IQueryable<DataLayer.ParentTask>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.ParentTask>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.ParentTask>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.ParentTask>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.ParentTasks).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            var ptasks = service.GetParentTasks();

            Assert.AreEqual(data.Count(), ptasks.Count());
            Assert.AreEqual(data.First().Parent_Task, ptasks.First().Parent_Task);
        }


        [Test]
        public void GetSpecificTasksData()
        {
            var data = new List<DataLayer.Task>
            {
                new DataLayer.Task { Task1 = "BBB", Task_ID=5 },
                new DataLayer.Task { Task1 = "ZZZ" },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<DataLayer.Task>>();
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Tasks).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            var task = service.GetSpecificTask(5);

            Assert.AreEqual(data.First().Task1, task.Task1);
            //Assert.AreEqual(data.First().Task, tasks.First().Task);
        }

        [Test]
        public void GetSpecificUserData()
        {
            var data = new List<DataLayer.User>
            {
                new DataLayer.User { FirstName = "BBB", Employee_ID=5, User_ID=5 },
                new DataLayer.User { FirstName = "ZZZ", Employee_ID=6 },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<DataLayer.User>>();
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            var usr = service.GetSpecificUser(5);

            Assert.AreEqual(data.First().FirstName, usr.FirstName);
            //Assert.AreEqual(data.First().Task, tasks.First().Task);
        }

        [Test]
        public void AddTaskData()
        {
            var mockSet = new Mock<DbSet<DataLayer.Task>>();

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            service.AddTask(new DataLayer.Task() { });

            mockSet.Verify(m => m.Add(It.IsAny<DataLayer.Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddUserData()
        {
            var mockSet = new Mock<DbSet<DataLayer.User>>();

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            service.AddUser(new DataLayer.User() { });

            mockSet.Verify(m => m.Add(It.IsAny<DataLayer.User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddProjectData()
        {
            var mockSet = new Mock<DbSet<DataLayer.Project>>();

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.Projects).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            service.AddProject(new DataLayer.Project() { });

            mockSet.Verify(m => m.Add(It.IsAny<DataLayer.Project>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddParentTask()
        {
            var mockSet = new Mock<DbSet<DataLayer.ParentTask>>();

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(m => m.ParentTasks).Returns(mockSet.Object);

            var service = new Repository(mockContext.Object);
            service.AddParentTask("Test");

            mockSet.Verify(m => m.Add(It.IsAny<DataLayer.ParentTask>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void UpdateTaskData()
        {
            var mockSet = new Mock<DbSet<DataLayer.Task>>();
            var data = new List<DataLayer.Task>
            {
                new DataLayer.Task { Task1 = "BBB", Task_ID=5 },
                new DataLayer.Task { Task1 = "ZZZ" },

            }.AsQueryable();


            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Tasks).Returns(mockSet.Object);



            var service = new Repository(mockContext.Object);
            service.UpdateTask(It.IsAny<DataLayer.Task>());

            //mockSet.Verify(m => m.Add(It.IsAny<DataLayer.Task>()), Times.Once());
              mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void UpdateProjectData()
        {
            var mockSet = new Mock<DbSet<DataLayer.Project>>();
            var data = new List<DataLayer.Project>
            {
                new DataLayer.Project { Project1 = "BBB", Project_ID=5 },
                new DataLayer.Project { Project1 = "ZZZ" },

            }.AsQueryable();


            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Projects).Returns(mockSet.Object);



            var service = new Repository(mockContext.Object);
            service.UpdateProject(data.FirstOrDefault());

            //mockSet.Verify(m => m.Add(It.IsAny<DataLayer.Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void UpdateUserData()
        {
            var mockSet = new Mock<DbSet<DataLayer.User>>();
            var data = new List<DataLayer.User>
            {
                new DataLayer.User { FirstName = "BBB", Employee_ID=5 },
                new DataLayer.User { FirstName = "ZZZ", Employee_ID =6 },

            }.AsQueryable();


            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);



            var service = new Repository(mockContext.Object);
            service.UpdateUser(data.FirstOrDefault());

            //mockSet.Verify(m => m.Add(It.IsAny<DataLayer.Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void EndTaskData()
        {
            var mockSet = new Mock<DbSet<DataLayer.Task>>();
            var data = new List<DataLayer.Task>
            {
                new DataLayer.Task { Task1 = "BBB", Task_ID=5 },
                new DataLayer.Task { Task1 = "ZZZ" },

            }.AsQueryable();


            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Tasks).Returns(mockSet.Object);



            var service = new Repository(mockContext.Object);
            service.EndTask(It.IsAny<int>());

            //mockSet.Verify(m => m.Add(It.IsAny<DataLayer.Task>()), Times.Once());
            //mockSet.Verify(m => m.Remove(It.IsAny<DataLayer.Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void EndProjectData()
        {
            var mockSet = new Mock<DbSet<DataLayer.Project>>();
            var data = new List<DataLayer.Project>
            {
                new DataLayer.Project { Project1 = "BBB", Project_ID=5 },
                new DataLayer.Project { Project1 = "ZZZ" },

            }.AsQueryable();


            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Projects).Returns(mockSet.Object);



            var service = new Repository(mockContext.Object);
            service.EndProject(It.IsAny<int>());

            //mockSet.Verify(m => m.Add(It.IsAny<DataLayer.Task>()), Times.Once());
            //mockSet.Verify(m => m.Remove(It.IsAny<DataLayer.Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [Test]
        public void DeleteUserData()
        {
            var mockSet = new Mock<DbSet<DataLayer.User>>();
            var data = new List<DataLayer.User>
            {
                new DataLayer.User { FirstName = "BBB", User_ID=5 },
                new DataLayer.User { FirstName = "ZZZ" },

            }.AsQueryable();


            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DataLayer.User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);



            var service = new Repository(mockContext.Object);
            service.DeleteUser(5);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
           
        }

    }
}
