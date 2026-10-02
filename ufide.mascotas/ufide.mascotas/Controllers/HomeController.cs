using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ufide.mascotas.Models.Entities;
using ufide.mascotas.Models.ViewModels;

namespace ufide.mascotas.Controllers
{
    [RoutePrefix("mascotas")]
    public class HomeController : Controller
    {
        private static IList<Mascota> _mascotas = new List<Mascota>();

        [HttpGet]
        public ActionResult Index()
        {
            var mascotas = _mascotas.OrderBy(s => s.Nombre).ToList();
            return View(mascotas);
        }

        [HttpPost]
        public ActionResult Registrar(MascotaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(GetRegistrarContent(modelo));
            }

            var mascota = MascotaFactory.Crear(
            modelo.TipoEspecie.Value,
            modelo.Nombre.Trim(),
            modelo.MesNacimiento,
            modelo.AnioNacimiento);

            _mascotas.Add(mascota);
            TempData["SuccessMessage"] = "Mascota registrada correctamente.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View(GetRegistrarContent());

        }

        [HttpGet]
        [Route("detalle/{id:int:min(1)}")]
        public ActionResult Detalle(int id)
        {
            var mascota = _mascotas.SingleOrDefault(s => s.Id == id);
            if (mascota == null)
            {
                return HttpNotFound("Mascota no encontrada");
            }
            return View(mascota);

        }
        private MascotaViewModel GetRegistrarContent(MascotaViewModel modelo = null)
        {
            modelo = modelo ?? new MascotaViewModel();

            modelo.Especies = Enum.GetValues(typeof(TipoEspecie))
                .Cast<TipoEspecie>().Select(especie => new SelectListItem { 
                    Value = especie.ToString(), 
                    Text = especie.ToString() 
                });

            modelo.Anios = Enumerable.Range(1970, 56)
                .Reverse()
                .Select(anio => new SelectListItem
                {
                    Value = anio.ToString(),
                    Text = anio.ToString()
                });

            modelo.Meses = Enumerable.Range(1, 12)
                .Reverse()
                .Select(mes => new SelectListItem 
                {  
                    Value = mes.ToString(), 
                    Text = mes.ToString() 
                });


            return modelo;
        }
    }
}