using SistemaWebVuelos.Admin;
using SistemaWebVuelos.Data;
using SistemaWebVuelos.Filters;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        
        public ActionResult Index()
        {           
            return View("Index",AdmVuelo.Listar());
        }

        [MyFilterAction]
        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }
        [HttpPost]
        
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdmVuelo.Crear(vuelo);
                return RedirectToAction("Index");
            }
            return View("create", vuelo);
        }



        [HttpGet]
        public ActionResult Detail(int id)
        {
            Vuelo vuelo = AdmVuelo.Listar(id);

            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = AdmVuelo.Listar(id);
            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        // Vuelo/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo = AdmVuelo.Listar(id);
            AdmVuelo.Eliminar(vuelo);
            return RedirectToAction("Index");

        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = AdmVuelo.Buscar(id);

            if (vuelo != null)
            {
                return View("Edit", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdmVuelo.Modificar(vuelo);
                return RedirectToAction("Index");
            }
            return View("Edit", vuelo);
        }
        
        public ActionResult SearchByDestiny(string destino)
        {
            if (destino == null)
            {
                return RedirectToAction("Index");
            }
            
            return View("Index", AdmVuelo.ListarDestino(destino));
        }
    }

}