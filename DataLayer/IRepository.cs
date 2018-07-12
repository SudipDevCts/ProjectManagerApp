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
    }
}
