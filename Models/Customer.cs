using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel119691868.Models
{
    public class Customer
    {
        [Required]
        [EmailAddress]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z-']{2,20}", ErrorMessage = "Put in acceptable email address. Example: student@central.com")]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z-']{2,20}", ErrorMessage = "Name takes letters and needs to be between 2-20 inclusive.")]
        public string GivenName { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Postcode number must be 4 digits.")]
        public int Postcode { get; set; }
        public ICollection<Booking> TheBookings { get; set; }
    }
}