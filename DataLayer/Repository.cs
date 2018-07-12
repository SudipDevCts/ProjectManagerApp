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
    }
}
