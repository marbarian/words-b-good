using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Models
{
    public class CatVocab
    {
        public Category Category { get; set; }
        public List<Vocab> VocabList { get; set; }
        public User User { get; set; }
        public Vocab Vocab { get; set; }
    }
}