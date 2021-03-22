using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyFisrtMVC.Models
{
    public class User
    {
        public string LoginName { get; set; }
    }
    public interface IUserRepo
    {
        void Add(User newUser);
        User FetchByLoginName(string loginName);
        void SubmitChange();
    }
    public class DefaultRepo : IUserRepo
    {
        public void Add(User newUser)
        {
            throw new NotImplementedException();
        }

        public User FetchByLoginName(string loginName)
        {
            return new User() { LoginName = loginName };
        }

        public void SubmitChange()
        {
            throw new NotImplementedException();
        }
    }
}