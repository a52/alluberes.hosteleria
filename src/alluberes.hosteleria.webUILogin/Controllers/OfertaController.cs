using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alluberes.hosteleria.webUILogin.Controllers
{
    [Authorize]
    public class OfertaController : Controller
    {
        private Models.HotelEntities repo;


        public OfertaController()
        {
            this.repo = new Models.HotelEntities();
        }


        #region Ofertas

        // GET: Oferta
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var list = this.repo.Ofertas.ToList();

            return View(list);

        }


        public ActionResult OfertasList()
        {

            var list = this.repo.Ofertas.ToList();

            return View(list);

        }


        public ActionResult Create()
        {
            var result = new Models.Oferta();

            result.Detalle = HttpContext.User.Identity.Name;

            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Models.Oferta oferta)
        {
            try
            {
                this.repo.Ofertas.Add(oferta);
                this.repo.SaveChanges();

                return RedirectToAction("OfertasList");

            } catch // (Exception ex)
            {


                return View(oferta);
            }


        }

        public ActionResult MostrarOferta(int id)
        {
            var oferta = this.repo.Ofertas.Where(x => x.OfertaId.Equals(id)).FirstOrDefault();

            return View(oferta);
        }

        #endregion


        #region Comentarios

        public ActionResult ComentariosOferta(int id)
        {
            var list = this.repo
                .Comentarios.ToList();


            return View(list.Where(x=>x.OfertaId.Equals(id)).ToList());
        }

        [HttpPost]
        public ActionResult PostComentario(Models.Comentario comentario)
        {

            comentario.Fecha_comentario = DateTime.Now;
            comentario.Usuario = HttpContext.User.Identity.Name;

            this.repo.Comentarios.Add(comentario);
            this.repo.SaveChanges();

            return RedirectToAction("MostrarOferta", new { id = comentario.OfertaId });
        }

        #endregion

    }
}