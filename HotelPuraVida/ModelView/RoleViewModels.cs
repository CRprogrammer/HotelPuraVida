using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPuraVida.ModelView
{
    public class RoleViewModels
    {
        [Key]
        public string RoleID { get; set; }
        public string Name { get; set; }
    }
}