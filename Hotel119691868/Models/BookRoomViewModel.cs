using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel119691868.Models
{
    public class BookRoomViewModel
    {
        public int ID { get; set; }

        [Required, Display(Name = "Room ID")]
        public int RoomID { get; set; }

        public string CustomerEmail { get; set; }

        [Required, Display(Name = "Check In")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CheckIn { get; set; }

        [Required, Display(Name = "Check Out")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CheckOut { get; set; }
        public decimal Cost { get; set; }

    }
}
