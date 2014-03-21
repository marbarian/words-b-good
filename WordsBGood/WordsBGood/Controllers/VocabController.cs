using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Concrete;
using WordsBGood.Domain.Entities;
using WordsBGood.Models;

namespace WordsBGood.WebUI.Controllers
{
    public class VocabController : Controller
    {

        IUserRepository userRepo;
        ICategoryRepository catRepo;
        IVocabRepository vocabRepo;

        // The default constructor is called by the framework
        public VocabController()
        {
            userRepo = new UserRepository();
            catRepo = new CategoryRepository();
            vocabRepo = new VocabRepository();
        }

        // Use this for dependency injection
        public VocabController(IUserRepository repo, ICategoryRepository cRepo, IVocabRepository vRepo)
        {
            userRepo = repo;
            catRepo = cRepo;
            vocabRepo = vRepo;
        }
        //tested
        public ViewResult ShowVocab(string subject)
        {
            Category cat = catRepo.GetCategory(subject);
            //cat.VocabList = vocabRepo.GetVocabList(cat.Subject);
            return View(cat);
        }

        [HttpGet]
        public ViewResult AddVocab(string subject)
        {
            CatVocab cV = new CatVocab();
            cV.Category = catRepo.GetCategory(subject);
            return View(cV);
        }
        [HttpPost]
        public ActionResult AddVocab(CatVocab cV)
        {
            if (ModelState.IsValid)
            {
                cV.Vocab.Category = cV.Category;
                vocabRepo.AddVocab(cV.Vocab);
                cV.VocabList = vocabRepo.GetVocabList(cV.Vocab.Category.Subject);
                return View("VocabAdded", cV);
            }
            else
                return View(cV);
        }

        

    }
}
