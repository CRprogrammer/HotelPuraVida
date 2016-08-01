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
        public string RoomName { get; set; }
        public DateTime AvailableDays { get; set; }
        public int MaxPeople { get; set; }
        public int HotelID { get; set; }
    }
}