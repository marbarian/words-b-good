using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Concrete;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Controllers
{
    public class AdminController : Controller
    {
        IUserRepository userRepo;
        ICategoryRepository catRepo;
        IVocabRepository vocabRepo;

        // The default constructor is called by the framework
        public AdminController()
        {
            userRepo = new UserRepository();
            catRepo = new CategoryRepository();
            vocabRepo = new VocabRepository();

        }
        // Use this for dependency injection
        public AdminController(IUserRepository repo, ICategoryRepository cRepo, IVocabRepository vRepo)
        {
            userRepo = repo;
            catRepo = cRepo;
            vocabRepo = vRepo;
        }
        public ActionResult Index()
        {
            //TODO:  add redirect if user is not an admin
            
                return View();
        }
        public ViewResult EditUserMain()
        {
            var db = new WordsBGoodDbContext();
            List<User> users = (from u in db.Users
                                select u).ToList<User>();
            return View(users);
        }
        public ViewResult EditUser(int userId)
        {
            var db = new WordsBGoodDbContext();
            User user = db.Users.Find(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                userRepo.SaveUser(user);
                TempData["message"] = string.Format("{0} has been saved", user.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
        public ViewResult CreateUser()
        {
            return View("EditUser", new User());
        }
        [HttpPost]
        public ActionResult Delete(int userId)
        {
            User deletedUser = userRepo.DeleteUser(userId);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedUser.Name);
            }
            return RedirectToAction("EditUserMain");
        }
        public ViewResult EditCatsMain()
        {
            var db = new WordsBGoodDbContext();
            List<Category> categories = (from c in db.Categories.Include("User")
                                select c).ToList<Category>();
            
            return View(categories);
        }
        public ViewResult EditCats(int categoryId)
        {
            var db = new WordsBGoodDbContext();
            Category category = db.Categories.Find(categoryId);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCats(Category category)
        {
            if (ModelState.IsValid)
            {
                catRepo.SaveCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.Subject);
                return RedirectToAction("EditCatsMain");
            }
            else
            {
                return View(category);
            }
        }
        //this doesn't work because User needs to be included in order to add a category
        //public ViewResult CreateCat()
        //{
        //    return View("EditCats", new Category());
        //}

        [HttpPost]
        public ActionResult DeleteCat(int categoryId)
        {
            Category deletedCategory = catRepo.DeleteCategory(categoryId);
            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedCategory.Subject);
            }
            return RedirectToAction("EditCatsMain");
        }
        
    }
}
