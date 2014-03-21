using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Concrete
{
    public class VocabRepository : IVocabRepository
    {
        //want to add vocab to data store

        public void AddVocab(Vocab v)
        {
            var db = new WordsBGoodDbContext();
            v.Category = db.Categories.Find(v.Category.CategoryId);
            db.Vocabs.Add(v);
            db.SaveChanges();
        }

        public Vocab GetVocab(DateTime date)
        {
            var db = new WordsBGoodDbContext();
            return (from v in db.Vocabs
                    where v.UsedDate == date
                    select v).FirstOrDefault();
        }

        public List<Vocab> GetVocabList(string category)
        {
            var db = new WordsBGoodDbContext();
            List<Vocab> l = new List<Vocab>();
            l = (from v in db.Vocabs
                 where v.Category.Subject == category
                 select v).ToList();
            return l;


            
        }
    }
}
