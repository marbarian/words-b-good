using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordsBGood.Domain.Entities;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Concrete;
using WordsBGood.WebUI.Models;

namespace WordsBGood.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository userRepo;
        ICategoryRepository catRepo;
        IVocabRepository vocabRepo;
        IQuizResultsInterface quizRepo;

        // The default constructor is called by the framework
        public HomeController()
        {
            userRepo = new UserRepository();
            catRepo = new CategoryRepository();
            vocabRepo = new VocabRepository();
            quizRepo = new QuizResultsRepository();

        }

        // Use this for dependency injection
        public HomeController(IUserRepository repo, ICategoryRepository cRepo, IVocabRepository vRepo, IQuizResultsInterface qRepo)
        {
            userRepo = repo;
            catRepo = cRepo;
            vocabRepo = vRepo;
            quizRepo = qRepo;
        }
        public ViewResult Index()
        {
            DateTime today = System.DateTime.Today;
            Vocab word = vocabRepo.GetVocab(today);
            return View(word);
        }
        //tested
        public ViewResult OnlineList()
        {
            List<User> onList = userRepo.GetOnlineUsers();
            return View(onList);
        }
        [HttpGet]
        public ViewResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginForm(User u)
        {
            if (ModelState.IsValid && userRepo.GetUser(u.Name, u.Email) != null)
                return RedirectToAction("Registered", "Home", u);
            else
                return View();
        }
        public ViewResult Registered(User u)
        {
            Session["user"] = null;
            User currentUser = u;
            if (userRepo.GetUser(u.Name, u.Email) == null)
            {
                userRepo.AddUser(u);
            }
            currentUser = userRepo.GetUser(u.Name, u.Email);
            Session["user"] = currentUser;
            userRepo.LoginUpdate(currentUser);
            UserCategories uCats = new UserCategories();
            uCats.userCats = catRepo.GetCategories(currentUser);
            uCats.OnlineNow = userRepo.GetOnlineUsers();
            uCats.User = currentUser;
            return View(uCats);
        }

        [HttpGet]
        public ViewResult NewUserForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUserForm(User u)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Registered", "Home", u);
            else
                return View(u);
        }
       
        [HttpGet]
        public ViewResult AddCategory()
        {
            Category newCategory = new Category();
            newCategory.User = (User)Session["user"];
            return View(newCategory);
        }

        [HttpPost]
        public ViewResult AddCategory(Category newCategory)
        {
            newCategory.User = (User)Session["user"];
            if (ModelState.IsValid)
            {
                var user = (User)Session["user"];
                ////need to get user by id
                User u = userRepo.GetUser(newCategory.User.Name, newCategory.User.Email);
                newCategory.User = u;
                catRepo.AddCategory(newCategory);
                return View("CategoryAdded", newCategory);
                //return View("CategoryAdded", new Category { Subject = "Please try again later", User = (User)Session["user"]});
            }
            else
                return View(newCategory);
        }

        public ViewResult LoggedOut()
        {
            User u = (User)Session["user"];
            userRepo.LogoutUpdate(u);
            Session["user"] = null;
            return View();
        }

        public ViewResult UserCategories()
        {
            UserCategories uCats = new UserCategories();
            uCats.User = (User)Session["user"];
            uCats.userCats = catRepo.GetCategories(uCats.User);
            uCats.OnlineNow = userRepo.GetOnlineUsers();
            return View(uCats);
        }

    }
}
