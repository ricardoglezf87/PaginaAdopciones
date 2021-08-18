using PaginaAdopciones.DAL;
using PaginaAdopciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PaginaAdopciones.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult DarAdopcion()
        {
            ViewBag.Message = "Registra tu mascota para darla en adopción";

            return View();
        }

        [HttpPost]
        public ActionResult DarAdopcion(Mascota mascota)
        {
            try 
            { 
                if (ModelState.IsValid)
                {
                    DAL.MascotaManager sdb = new DAL.MascotaManager();
                    if(sdb.AgregarMascota(mascota))
                    {
                        ViewBag.Message = "Muchas por registrar a:" + mascota.Nombre;
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch(Exception e)
            {
                ViewBag.Message = "Error al registrar la mascota";
                return View();
            }
            
        }

        public ActionResult Adoptar()
        {
            ViewBag.Message = "Encuentra tu mascota ideal";
            MascotaManager sdb = new MascotaManager();
            List<Mascota> mascostas = sdb.ObtenerMascotas();
            return View(mascostas);
        }
    }
}