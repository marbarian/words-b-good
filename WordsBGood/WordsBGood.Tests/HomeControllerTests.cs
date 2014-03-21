using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordsBGood.Domain.Concrete;
using WordsBGood.Domain.Entities;
using WordsBGood.WebUI.Controllers;
using System.Collections.Generic;
using WordsBGood.WebUI.Models;

namespace WordsBGood.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void OnlineListTest()
        {
            //arrange
            var repo = new FakeUserRepository();
            var cRepo = new FakeCategoryRepository();
            var vRepo = new FakeVocabRepository();
            var qRepo = new FakeQuizResultRepository();
            User user1 = new User { UserId = 25, Name = "Marian", Online = true };
            User user2 = new User { UserId = 26, Name = "Martha", Online = true };
            User user3 = new User { UserId = 27, Name = "Billy", Online = false };
            User user4 = new User { UserId = 28, Name = "Esmarelda", Online = false };

            repo.AddUser(user1);
            repo.AddUser(user2);
            repo.AddUser(user3);
            repo.AddUser(user4);

            //list for testing
            List<User> testList = new List<User>
            {
                new User () {UserId = 25,Name = "Marian", Online = true},
                new User() { UserId = 26, Name = "Martha", Online = true},
               
            };
            HomeController target = new HomeController(repo, cRepo, vRepo, qRepo);
            //act -- don't forget the .Model part :)
            List<User> returnedUsers = (List<User>)target.OnlineList().Model;
            
            //assert
            for (int i = 0; i < testList.Count; i++)
            {
                Assert.AreSame(testList[i].Name, returnedUsers[i].Name);
            }

        }

        [TestMethod]
        public void ShowVocabTest()
        {
            // Arrange
            var repo = new FakeUserRepository();
            var cRepo = new FakeCategoryRepository();
            var vRepo = new FakeVocabRepository();

            Category cat1 = new Category() { Subject = "New Subject" };
            cRepo.AddCategory(cat1);
            Category cat2 = new Category() { Subject = "And Then" };
            cRepo.AddCategory(cat2);
            Category cat3 = new Category() { Subject = "Books" };
            cRepo.AddCategory(cat3);
            VocabController target = new VocabController(repo, cRepo, vRepo);
            
            // Act
            // get the Model property out of the view it returns
            Category returnedCategory = (Category)target.ShowVocab("New Subject").Model;

            // Assert
            Assert.AreSame(cat1, returnedCategory);
        }

        [TestMethod]
        public void NewUserCanRegister()
        {
            //arrange
            var repo = new FakeUserRepository();
            var cRepo = new FakeCategoryRepository();
            var vRepo = new FakeVocabRepository();
            var qRepo = new FakeQuizResultRepository();
            HomeController target = new HomeController(repo, cRepo, vRepo, qRepo);

            User u1 = new User () {UserId = 25,Name = "Marian", Online = true};
            User u2 = new User() { UserId = 26, Name = "Martha", Online = true };
            User u3 = new User() { UserId = 27, Name = "Maria", Online = false };
            repo.AddUser(u1);
            repo.AddUser(u2);

            UserCategories uCats = new UserCategories { User = u3, userCats = cRepo.GetCategories(u3) };

            //act
            UserCategories returnedUCats = (UserCategories)target.Registered(u3).Model;
            //assert
            Assert.AreSame(uCats, returnedUCats);

        }

        
    }
}
