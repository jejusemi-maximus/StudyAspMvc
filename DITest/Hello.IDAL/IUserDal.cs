using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello.Model;

namespace Hello.IDAL
{
    public interface IUserDal
    {
        List<User> GetUserList();

        User GetUser(int userNo);

        bool SaveUser(User user);
        
    }


}
