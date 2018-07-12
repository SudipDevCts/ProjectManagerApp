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
    }
}
