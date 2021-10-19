using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Hotel119691868.Models
{
    public class Room
    {

        public int ID { get; set; }

        [Required]
        [RegularExpression(@"[G1-3]{1}", ErrorMessage = "Must be one character and be from the following: 'G','1','2','3'.")]
        public string Level { get; set; }

        [RegularExpression(@"[1-3]{1}", ErrorMessage = "Must be one character between 1-3 inclusive")]
        public int BedCount { get; set; }
        [Range(50,300)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public ICollection<Booking> TheBookings { get; set; }
    }
}