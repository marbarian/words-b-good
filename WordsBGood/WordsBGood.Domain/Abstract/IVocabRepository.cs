using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Abstract
{
    public interface IVocabRepository
    {
        //want to add vocab to data store
        void AddVocab(Vocab v);

        //want to get a word for word by date
        Vocab GetVocab(DateTime date);

        //want to get a list of words by category
        List<Vocab> GetVocabList(string category);
    }
}
