using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelPuraVida.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsID { get; set; }
        public int OrdenID { get; set; }
        public int RoomID { get; set; }

        [Display(Name = "Personas")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public float People { get; set; }

        [Display(Name = "Tipo de cuarto")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public string RoomType { get; set; }

        [Display(Name = "Costo por noche")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        public decimal CostPerNight { get; set; }


        public virtual OrderReservationModels OrderReservationModels { get; set; }
        public virtual RoomModels RoomModels { get; set; }

    }

}