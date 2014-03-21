using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsBGood.Domain.Entities
{
    public class VocabList : List<Vocab>
    {
        private List<Vocab> vList = new List<Vocab>();

        public List<Vocab> VList { get { return vList; } }
    }
}
