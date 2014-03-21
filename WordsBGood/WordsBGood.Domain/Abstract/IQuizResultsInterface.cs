using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Abstract
{
    public interface IQuizResultsInterface
    {
        void AddQuizResults(QuizResult q);
        QuizResult GetQuizResult(User u, Category c);
        int UpdateHighScore(int score);
        int GetHighScore(int categoryId, int userId);
    }
}
