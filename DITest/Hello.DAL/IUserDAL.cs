
using Hello.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.DAL
{
    public interface IUserDAL
    {
        List<User> GetUserList();

        User GetUser(int userNo);
        bool SaveUser(User user);
    }
}
