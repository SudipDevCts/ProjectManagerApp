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
            var users =  _repository.GetUsers();
            var userModels = new List<Models.UserModel>();
            foreach(var usr in users)
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
    }
}
