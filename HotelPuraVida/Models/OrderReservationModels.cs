using HotelPuraVida.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPuraVida.Models
{
    public class OrderReservationModels
    {
        [Key]
        public int OrdenID { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "You must enter a valid {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 6)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string UserID { get; set; }
        public OrderStatus OrderStatus { get; set; }


        public virtual UserViewModels UserViewModels { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }


    }
}