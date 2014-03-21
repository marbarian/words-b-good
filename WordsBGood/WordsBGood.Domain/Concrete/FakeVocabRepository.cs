using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;

namespace WordsBGood.Domain.Concrete
{
    public class FakeVocabRepository : IVocabRepository
    {

        public void AddVocab(Entities.Vocab v)
        {
            throw new NotImplementedException();
        }

        public Entities.Vocab GetVocab(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Vocab> GetVocabList(string category)
        {
            throw new NotImplementedException();
        }
    }
}
