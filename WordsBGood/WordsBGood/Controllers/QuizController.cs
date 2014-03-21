using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Concrete;
using WordsBGood.Domain.Entities;
using WordsBGood.WebUI.Controllers;
using WordsBGood.WebUI.Models;

namespace WordsBGood.Controllers
{
    public class QuizController : Controller
    {
        IUserRepository userRepo;
        ICategoryRepository catRepo;
        IVocabRepository vocabRepo;
        IQuizResultsInterface quizRepo;
        

        // The default constructor is called by the framework
        public QuizController()
        {
            userRepo = new UserRepository();
            catRepo = new CategoryRepository();
            vocabRepo = new VocabRepository();
            quizRepo = new QuizResultsRepository();

        }

        // Use this for dependency injection
        public QuizController(IUserRepository repo, ICategoryRepository cRepo, IVocabRepository vRepo, IQuizResultsInterface qRepo)
        {
            userRepo = repo;
            catRepo = cRepo;
            vocabRepo = vRepo;
            quizRepo = qRepo;
        }

        public ViewResult QuizSetup()
        {
            User u = (User)Session["user"];
            UserCategories uCats = new UserCategories();
            uCats.userCats = catRepo.GetCategories(u);
            uCats.OnlineNow = userRepo.GetOnlineUsers();
            var db = new WordsBGoodDbContext();
            uCats.Results = new List<QuizResult>();
            foreach (var category in uCats.userCats)
            {
                QuizResult result = new QuizResult();
                int score = (from q in db.QuizResults
                                    where q.Category.CategoryId == category.CategoryId && q.User.UserId == u.UserId
                                    select q.HighScore).DefaultIfEmpty(0).Max();

                result.HighScore = score;
                result.User = u;
                result.Category = category;
                uCats.Results.Add(result);
            }
            uCats.User = u;
            return View(uCats);
        }

        public ViewResult Quiz(string subject)
        {
            Session["quiz"] = null;
            //Timer timer = new Timer(60000);
            Category cat = catRepo.GetCategory(subject);
            //cat.VocabList = vocabRepo.GetVocabList(cat.Subject);
            Quiz q = new Quiz();
            q.Player = (User)Session["user"];
            q.Score = 0;
            q.Category = cat;
            //q.TimerTick();
            Session["quiz"] = q;
            return View(q);
        }
        [HttpPost]
        public ActionResult Quiz(Quiz q)
        {
            List<Vocab> correct = new List<Vocab>();
            List<Vocab> incorrect = new List<Vocab>();

            Quiz graded = (Quiz)Session["quiz"];
            graded.Answer = q.Answer;

            for(var i = 0; i<graded.Category.VocabList.Count; i++)
            {
                Vocab w = graded.Category.VocabList[i];
                if (w.Word.ToLower() == graded.Answer[i].ToLower())
                {
                    correct.Add(w);
                    graded.Score = graded.GetScore(graded.Score);
                }
                else
                {
                    incorrect.Add(w);
                }
                i++;
            }
            graded.Correct = correct;
            graded.Incorrect = incorrect;
            Session["quiz"] = graded;
            User u = (User)Session["user"];
            QuizResult results = new QuizResult { Category = graded.Category, User = u, HighScore = graded.Score };
            quizRepo.AddQuizResults(results);
            return View("QuizResults", graded);
        }

    }
}
