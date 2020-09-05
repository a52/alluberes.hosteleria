using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alluberes.hosteleria.WebUI.Models
{
    public static class ComonFunctions
    {
        public static string messageError;


        public static void LogError(HttpContext context, Exception ex)
        {
            messageError += string.Format("<br /> {0}", ex.Message);
        }



        public static int getCurrentUsuarioId()
        {
            var result = -1;

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    var oUsr = HttpContext.Current.Session["Usuario"] as Models.Usuario;

                    result = oUsr.UsuarioId;

                }
            }


            return result;

        }



    }
}