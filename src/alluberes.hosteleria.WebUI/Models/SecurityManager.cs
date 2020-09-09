using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace alluberes.hosteleria.WebUI.Models
{
    public class SecurityManager
    {
        Models.HotelEntities1 repo;

        public SecurityManager()
        {
            this.repo = new HotelEntities1();


        }


        public bool IsUserValid(string usr, string pwd)
        {
            var result = false;


            var usuario = this.repo.Usuarios.Where(x => x.UserName.Equals(usr)).FirstOrDefault();

            if (usuario != null)
                if (usuario.UserPassword.Equals(pwd))
                    result = true;



            return result;
        }

    }
}