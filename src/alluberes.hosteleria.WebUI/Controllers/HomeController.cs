using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alluberes.hosteleria.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            try
            {
                Models.ComonFunctions.ShowSuccessMessage(this, "Este es un mensaje exitoso.");
                throw new Exception("Error generado en about");
            }
            catch (Exception ex)
            {
                Models.ComonFunctions.ShowErrorMessage(this, ex);


                //TempData["ErrorMessage"] = ex.ToString();
                //return RedirectToAction("MostrarError");

            }
            //ViewBag.Message = "Your application description page.";
            //ViewBag.Nombre = "Carlos";
            //TempData["Nombre"] = "Carlos 2";

            return View();
            //return RedirectToAction("Contact");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult MostrarError()
        {
            return View();
        }

    }
}