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
        public string Name { get; set; }
        public string Company { get; set; }
        public int Rating { get; set; }
       

    }
}