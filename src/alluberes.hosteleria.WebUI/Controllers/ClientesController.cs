using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alluberes.hosteleria.WebUI.Controllers
{
    public class ClientesController : Controller
    {

        Models.HotelEntities1 repo;

        public ClientesController()
        {
            this.repo = new Models.HotelEntities1();
        }


        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult MisDatos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reservar(int id, DateTime fechareseva, string comentario)
        {
            try
            {

                var idUsuario = Models.ComonFunctions.getCurrentUsuarioId();

                this.repo.InsertReserva(idUsuario, id, fechareseva, comentario);

                this.repo.SaveChanges();

                Models.ComonFunctions.ShowSuccessMessage(this, "Reserva realizada satisfactoriamente.");

            }
            catch (Exception ex)
            {
                Models.ComonFunctions.ShowErrorMessage(this, ex);
            }

            return RedirectToAction("index");

        }

    }
}