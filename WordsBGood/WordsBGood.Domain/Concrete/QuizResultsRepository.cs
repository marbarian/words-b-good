using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;

namespace WordsBGood.Domain.Concrete
{
    public class QuizResultsRepository : IQuizResultsInterface
    {

        public void AddQuizResults(Entities.QuizResult q)
        {
            var db = new WordsBGoodDbContext();
            q.User = db.Users.Find(q.User.UserId);
            q.Category = db.Categories.Find(q.Category.CategoryId);
            //if the quizresult doesn't exist yet then add it
            db.QuizResults.Add(q);
            db.SaveChanges();
            //if it does exist, need to updat the score -- maybe do this in the controller?
        }

        public Entities.QuizResult GetQuizResult(Entities.User u, Entities.Category c)
        {
            throw new NotImplementedException();
        }

        public int UpdateHighScore(int score)
        {
            //TODO:  something like if the new score for the quiz result is > one in db
            //then update the score in the db
            //need to check is a quiz result for that user and that category exists already
            throw new NotImplementedException();
        }


        public int GetHighScore(int categoryId, int userId)
        {
            var db = new WordsBGoodDbContext();
            int score = (from s in db.QuizResults
                         where s.Category.CategoryId == categoryId && s.User.UserId == userId
                         select s.HighScore).Max();
            return score;
        }
    }
}
