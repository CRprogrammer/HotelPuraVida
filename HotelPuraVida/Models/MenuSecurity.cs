using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HotelPuraVida.Models
{
    public class MenuSecurity
    {
        public static bool DashboardVisible
        {
            get
            {
                return
                   HttpContext.Current.User != null &&
                   HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }
    }
}
