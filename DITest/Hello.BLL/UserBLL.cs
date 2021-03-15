using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello.IDAL;
using Hello.Model;

namespace Hello.BLL
{
    public class UserBLL : IUserDal
    {
        private readonly IUserDal _userDal;

        public UserBLL(IUserDal userParam)
        {
            _userDal = userParam;
        }

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
