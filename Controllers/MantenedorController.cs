using Microsoft.AspNetCore.Mvc;
using RegistroEmpleados.Datos;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos contactoDatos = new ContactoDatos();//
        //Método que mostrara la lista de empleados
        public IActionResult Listar()
        {
            var Lista = contactoDatos.Listar();
            return View(Lista);
        }
        //Método ver la vista 
        public IActionResult Guardar()
        {
            return View();
        }
        //Método para guardar empleado
        [HttpPost]
        public IActionResult Guardar(ContactoModel empleado)
        {
            if(!ModelState.IsValid)//Validar 
                return View();

            var respuesta = contactoDatos.Guardar(empleado);
            if (respuesta)
                return RedirectToAction("Listar");
            else
            return View();
        }
        //Método ver la vista 
        public IActionResult Editar(int ID)
        {
            var contacto = contactoDatos.Obtener(ID);
            return View(contacto);
        }
        //Método para editar empleado
        [HttpPost]
        public IActionResult Editar(ContactoModel empleado)
        {
            if (!ModelState.IsValid)//Validar 
                return View();

            var respuesta = contactoDatos.Editar(empleado);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        //Método ver la vista 
        public IActionResult Eliminar(int ID)
        {
            var contacto = contactoDatos.Obtener(ID);
            return View(contacto);
        }
        //Método para eliminar empleado 
        [HttpPost]
        public IActionResult Eliminar(ContactoModel empleado)
        {
            var respuesta = contactoDatos.Eliminar(empleado.ID);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
