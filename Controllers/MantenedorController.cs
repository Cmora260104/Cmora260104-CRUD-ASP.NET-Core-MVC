using Microsoft.AspNetCore.Mvc;
using PracticaMVC.Datos;
using PracticaMVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PracticaMVC.Controllers
{
    public class MantenedorController : Controller
    {
        CrudDatos _Datos = new CrudDatos(); // objeto de la clase donde estan las operaciones
        public IActionResult Listar()
        {
            // la vista mostrara una lista de contactos
            var oLista = _Datos.Listar();
            return View(oLista);
        }

        public IActionResult Insertar()
        {
            // metodo devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Insertar(DatosModels odatos)
        {
            if (!ModelState.IsValid)
                return View();

            // metodo recibe el objeto para guardarlo en la bd
            var respuesta = _Datos.Insertar(odatos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Actualizar(int Id)
        {
            // metodo devuelve la vista
            var ocontacto = _Datos.Obtener(Id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Actualizar(DatosModels odatos)
        {
            // metodo devuelve la vista
            if (!ModelState.IsValid)
                return View();

            // metodo recibe el objeto para guardarlo en la bd
            var respuesta = _Datos.Actualizar(odatos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Id)
        {
            // metodo devuelve la vista
            var ocontacto = _Datos.Obtener(Id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(DatosModels odatos)
        {

            // metodo recibe el objeto para guardarlo en la bd
            var respuesta = _Datos.Eliminar(odatos.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}

