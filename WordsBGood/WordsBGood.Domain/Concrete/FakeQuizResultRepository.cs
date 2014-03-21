using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;

namespace WordsBGood.Domain.Concrete
{
    public class FakeQuizResultRepository : IQuizResultsInterface
    {

        public void AddQuizResults(Entities.QuizResult q)
        {
            throw new NotImplementedException();
        }

        public Entities.QuizResult GetQuizResult(Entities.User u, Entities.Category c)
        {
            throw new NotImplementedException();
        }

        public int UpdateHighScore(int score)
        {
            throw new NotImplementedException();
        }


        public int GetHighScore(int categoryId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
