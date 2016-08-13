using HotelPuraVida.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPuraVida.ModelView
{
    public class OrderReservationViewModels
    {
        //Por ahora 
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 6)]
        public string Name { get; set; }
        public RoomOrderModels Room { get; set; }
        public UserViewModels UserViewModels { get; set; }
        public List<RoomModels> room { get; set; }
        public List<RoomOrderModels> RoomOrder { get; set; }

    }
}