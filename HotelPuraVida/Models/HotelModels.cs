using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPuraVida.Models
{
    public class HotelModels
    {
        [Key]
        public int HotelID { get; set; }

        [Display(Name="Hotel")]
        [Required(ErrorMessage="You must enter {0}")]
        [StringLength(30,ErrorMessage="The field {0} must be between {1} and {2} characters",MinimumLength=6)]
        public string Name { get; set; }
             
        [Display(Name="Compañia")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 6)]
        public string Company { get; set; }

        [Display(Name="Estrellas")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Rating { get; set; }
       

    }
}