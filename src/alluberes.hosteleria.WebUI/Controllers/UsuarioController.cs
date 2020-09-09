using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace alluberes.hosteleria.WebUI.Controllers
{
    public class UsuarioController : Controller
    {

        Models.HotelEntities1 repo;
        Models.SecurityManager sm;

        public UsuarioController()
        {
            this.repo = new Models.HotelEntities1();
            this.sm = new Models.SecurityManager();
        }



        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CrearUsuario()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CrearUsuario(Models.Usuario usuario)
        {

            try
            {

                usuario.CreateDate = DateTime.Now;


                this.repo.Usuarios.Add(usuario);
                this.repo.SaveChanges();

                return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                // Models.ComonFunctions.LogError(this.Content, ex);
            }

            return View();
        }


        [HttpPost]
        public ActionResult Login(string usuario, string clave)
        {
            if (sm.IsUserValid(usuario, clave))
            {
                var oUser = this.repo.Usuarios.Where(x => x.UserName.Equals(usuario)).FirstOrDefault();
                FormsAuthentication.SetAuthCookie(usuario, true);
                Session["Usuario"] = oUser;
                Session["UsuarioId"] = oUser.UsuarioId;


            }

            return RedirectToAction("index");
        }


        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }



    }
}