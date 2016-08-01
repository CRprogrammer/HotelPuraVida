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
        public string Username { get; set; }
        public int People { get; set; }
        public DateTime Date { get; set; }
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public int LoginID { get; set; }
    }
}