using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace alluberes.hosteleria.WebUI.Models
{
    public static class ComonFunctions
    {
        public static string messageError;
        public static string TAG_ERROR_MESSAGES = "ERROR_MESSAGES";
        public static string TAG_SUCCESS_MESSAGES = "SUCCESS_MESSAGES";


        public static void ShowErrorMessage(Controller m, Exception ex)
        {
            var result = new List<string>();
            if (m.TempData[TAG_ERROR_MESSAGES] != null)
                    result = m.TempData[TAG_ERROR_MESSAGES] as List<string>;

            result.Add(ex.Message);

            m.TempData[TAG_ERROR_MESSAGES] = result;    

        }


        public static void ShowSuccessMessage(Controller m, string msg)
        {
            var result = new List<string>();
            if (m.TempData[TAG_SUCCESS_MESSAGES] != null)
                result = m.TempData[TAG_SUCCESS_MESSAGES] as List<string>;

            result.Add(msg);

            m.TempData[TAG_SUCCESS_MESSAGES] = result;

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