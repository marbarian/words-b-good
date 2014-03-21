using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WordsBGood.Domain.Entities
{
    public class User
    {
        //properties
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
        [Required (ErrorMessage="Please enter a name")]
        public string Name { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Password { get; set; }
        [Required (ErrorMessage="Please enter an email")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Your email address is not in a valid format. Example of correct format: joe.example@example.org")]
        public string Email { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool Online { get; set; }
        public string Permission { get; set; }

    }
}
