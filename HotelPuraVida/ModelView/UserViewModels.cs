using HotelPuraVida.Models;
using HotelPuraVida.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPuraVida.ModelView
{
    public class UserViewModels
    {
        public string UserID { get; set; }
        public string Name { get; set;}
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        public RoleViewModels Role { get; set; }
        public List<RoleViewModels> Roles { get; set; }

        //public virtual ICollection<ReservationModel> ReservationModel { get; set; }
        public virtual ICollection<OrderReservationModels> Reservation { get; set; }
    }
}