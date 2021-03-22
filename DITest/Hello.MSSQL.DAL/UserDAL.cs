using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello.Model;
using Hello.IDAL;

namespace Hello.MSSQL.DAL
{
    public class UserDAL : IUserDal
    {
        public User GetUser(int userNo)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }

        public bool SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
