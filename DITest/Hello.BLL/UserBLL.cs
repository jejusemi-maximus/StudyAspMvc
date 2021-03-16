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
            if (userNo <= 0)
            {
                throw new ArgumentException();
            }
            return _userDal.GetUser(userNo);
        }

        public List<User> GetUserList()
        {
            return _userDal.GetUserList();
        }

        public bool SaveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentException();
            }
            return _userDal.SaveUser(user);
        }
    }
}
