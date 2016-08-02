using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPuraVida.Models
{
    public class RoomModel
    {
        [Key]
        public int RoomID { get; set; }

        [Display(Name = "Número de cuarto")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public int RoomNumber { get; set; }

        [Display(Name = "Tipo de cuarto")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public string RoomType { get; set; }

        [Display(Name = "Fecha disponible")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public DateTime AvailableDays { get; set; }

        [Display(Name = "Personas por cuarto")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public int MaxPeople { get; set; }

        [Display(Name = "Hotel")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public int HotelID { get; set; }

        [Display(Name = "Costo por noche")]
        [Required(ErrorMessage = "You must enter a valid {0}")]

        public decimal CostPerNight { get; set; }

        public virtual HotelModels HotelModels { get; set; }
    }
}