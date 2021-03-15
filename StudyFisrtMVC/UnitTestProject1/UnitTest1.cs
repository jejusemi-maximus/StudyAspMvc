using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyFisrtMVC.Models;
using System.Collections.Generic;
using StudyFisrtMVC.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanChangeName()
        {
            User user = new User() { LoginName = "me" };
            FakeRepo repo = new FakeRepo();
            repo.Add(user);
            TestController target = new TestController(repo);
            string oldname = user.LoginName;
            string newName = "이얍";

            target.ChangeLoginName(oldname, newName);

            Assert.AreEqual(newName, user.LoginName);
            Assert.IsTrue(repo.DidChangeSubmit);
        }

        class FakeRepo : IUserRepo
        {
            public List<User> Users = new List<User>();
            public bool DidChangeSubmit = false;
            public void Add(User newUser)
            {
                Users.Add(newUser);
            }

            public User FetchByLoginName(string loginName)
            {
                return Users.First(m => m.LoginName == loginName);
            }

            public void SubmitChange()
            {
                DidChangeSubmit = true;
            }
        }
    }
}
