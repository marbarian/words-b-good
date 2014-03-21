using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WordsBGood.Domain.Entities
{
    public class Category
    {
        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }
        [Required (ErrorMessage="Please enter a subject")]
        public string Subject { get; set; }
        public User User { get; set; }
       
        public virtual List<Vocab> VocabList { get; set; }
    }
}
