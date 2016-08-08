using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPuraVida.Models
{
    public class ReservationModel
    {
        [Key]
        public int ReservationID { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "You must enter a valid {0}")]

        public string Username { get; set; }

        public int People { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }

        public int HotelID { get; set; }

        public int RoomID { get; set; }

        public int LoginID { get; set; }

        public virtual HotelModels HotelModels { get; set; }

        public virtual RoomModel RoomModel { get; set; }
    }
}