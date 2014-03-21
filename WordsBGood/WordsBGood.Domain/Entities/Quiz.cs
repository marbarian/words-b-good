using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WordsBGood.Domain.Entities
{
    public class Quiz
    {
        private int score = 0;
      
        //each quiz will have a list of vocab items
        public Category Category { get; set; }
        
        //each quiz will have a timer that counts down the time
        //public Timer Timer { get; set; }

        public List<Vocab> Incorrect { get; set; }
        public List<Vocab> Correct { get; set; }
        public List<Vocab> QuizList { get; set; }

        //each quiz will have a player
        public User Player { get; set; }
        public int NumQuestions { get; set; }

        public List<string> Answer { get; set; }

        //each quiz will have a score -- score to add to user data for storage/leaderboard?
        public int Score 
        { 
            get
            {
                return score;   
            }
            set
            {
                score = value;
            }
        }

        public int HighScore { get; set; }

        public int GetScore(int score)
        {
            score += 1;
            return score;
        }
        Random rand = new Random();
        public List<Vocab> GetQuizList(int num)
        {
            for (int i = 0; i <= num; i++)
            {
                QuizList.Add(Category.VocabList[rand.Next(0, num + 1)]);
                i++;
            }
            return QuizList;
        }

        //public void TimerTick()
        //{
        //    Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //    //timer to tick every second
        //    Timer.Interval = (1000) * (1);
        //    Timer.Enabled = true;                       // Enable the timer
        //    Timer.Start();                              // Start the timer
        //}

        //private static void OnTimedEvent(object source, ElapsedEventArgs e)
        //{
        //    e.SignalTime.Subtract(DateTime.Parse("1000"));
        //}
    }
}
