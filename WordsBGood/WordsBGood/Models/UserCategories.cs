using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordsBGood.Domain.Entities;

namespace WordsBGood.WebUI.Models
{
    public class UserCategories
    {
        public User User {get; set;}
        public List<Category> userCats { get; set; }
        public List<User> OnlineNow { get; set; }
        public Quiz Quiz { get; set; }
        public List<QuizResult> Results { get; set; }
    }
}