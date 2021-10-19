using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel119691868.Models
{
    public class CustomerViewModel
    {
        [Required, Display(Name = "First Name")]
        [RegularExpression(@"[A-Z][a-z'-]{1,19}")]
        public String FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        [RegularExpression(@"[A-Z][a-z'-]{1,19}")]
        public String LastName { get; set; }
        [Required, Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public String Postcode { get; set; }
    }
}
