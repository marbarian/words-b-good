using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsBGood.Domain.Entities
{
    public class QuizResult
    {
        public int QuizResultId { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public int HighScore { get; set; }
    }
}
