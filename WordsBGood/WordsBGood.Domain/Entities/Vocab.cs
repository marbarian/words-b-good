using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsBGood.Domain.Entities
{
    public class Vocab
    {
        public int VocabId { get; set; }
        [Required (ErrorMessage="you must enter a word")]
        public string Word { get; set; }
        [Required (ErrorMessage="you must enter a definition")]
        public string Definition { get; set; }
        //each vocab word has one category and one owner
        public Category Category { get; set; }
        //public int UserId { get; set; }
        //need to set a date for word when it is used so it will not go back in rotation for a year
        //also used to get words that have been used so far for review
        public DateTime ? UsedDate { get; set; }
        public string EtyLink { get; set; }
        public string Type { get; set; }
    }
}
