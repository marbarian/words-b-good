using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordsBGood.Domain.Concrete;
using WordsBGood.Domain.Entities;
using System.Collections.Generic;

namespace WordsBGood.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddUserTest()
        {
            //1. Arrange -- set up the fake data for testing
            //we need to instantiate the fake repository
            FakeUserRepository repo = new FakeUserRepository();
            //need a list of categories for the user -- don't really need fake data for tests
            List<Category> categories = new List<Category>();
            //add some categories to the list just cause
            categories.Add(new Category {Subject = "ASP.NET"});
            //need to create a user to add
            User userA = new User { Name = "Marian", Online = true};

            //2. Act -- run the method we are testing
            repo.AddUser(userA);
            
            //3. Assert -- test against the data store
            Assert.AreEqual(userA, repo.Users[0]);

        }
        [TestMethod]
        public void GetUserTest()
        {
            //arrange

            var target = new FakeUserRepository();
            List<Category> categories = new List<Category>();
            categories.Add(new Category { Subject = "ASP.NET" });
            
            //need a list to query
            User user1 = new User { UserId = 25, Name = "Marian", Online = true, Email = "marian@hotmail.com" };
            User user2 = new User { UserId = 26, Name = "Jessica", Online = false, Email = "jessica@hotmail.com" };
            User user3 = new User { UserId = 27, Name = "Carl", Online = true, Email = "carl@hotmail.com" };

            //List<User> users = new List<User>();
            target.AddUser(user1);
            target.AddUser(user2);
            target.AddUser(user3);

            //act
            User retrievedUser = target.GetUser("Marian", "marian@hotmail.com");

            //assert
            Assert.AreSame(retrievedUser.Name, target.Users[0].Name);
        }

        [TestMethod]
        public void GetOnlineUsersTest()
        {
            //arrange
            var target = new FakeUserRepository();
            List<Category> categories = new List<Category>();
            categories.Add(new Category { Subject = "ASP.NET" });

            //need a list to query
            User user1 = new User { Name = "Marian", Online = true };
            User user2 = new User { Name = "Jessica", Online = false };
            User user3 = new User { Name = "Carl", Online = true };

            //List<User> users = new List<User>();
            target.AddUser(user1);
            target.AddUser(user2);
            target.AddUser(user3);

            //new stupid list to test online users against
            List<User> testing = new List<User>();
            testing.Add(user1);
            testing.Add(user3);

            //act
            var onlineNow = new List<User>(target.GetOnlineUsers());
            

            //assert
            for (int i = 0; i < onlineNow.Count; i++)
            {
                Assert.AreSame(onlineNow[i], target.Online[i]);
            }
        }


    }
}
