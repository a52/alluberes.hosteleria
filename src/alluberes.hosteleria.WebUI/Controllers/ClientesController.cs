using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alluberes.hosteleria.WebUI.Controllers
{
    public class ClientesController : Controller
    {

        Models.HotelEntities repo;

        public ClientesController()
        {
            this.repo = new Models.HotelEntities();
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

            var idUsuario = Models.ComonFunctions.getCurrentUsuarioId();
            var oferta = this.repo.Ofertas.Where(x => x.OfertaId.Equals(id)).FirstOrDefault();
            var usuario = this.repo.Usuarios.Where(x => x.UsuarioId.Equals(idUsuario)).FirstOrDefault();

            var reserva = new Models.Reserva();
            reserva.Usuario = usuario;
            reserva.Oferta = oferta;
            reserva.FechaReserva = fechareseva;
            reserva.Comentario = comentario;


            //oferta.Reservas.Add(reserva);




            this.repo.Reservas.Add(reserva);
            this.repo.SaveChanges();

            return Redirect("index");

        }

    }
}