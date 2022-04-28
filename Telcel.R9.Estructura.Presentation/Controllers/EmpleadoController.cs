using Microsoft.AspNetCore.Mvc;

namespace Telcel.R9.Estructura.Presentation.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            Negocio.Empleado empleado = new Negocio.Empleado();
            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            empleado.ApellidoPaterno = (empleado.ApellidoPaterno == null) ? "" : empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = (empleado.ApellidoMaterno == null) ? "" : empleado.ApellidoMaterno;

            Negocio.Result result = Negocio.Empleado.GetAll(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno);
            if (result.Correct)
            {
                empleado.Empleados = new List<object>();
                empleado.Empleados = result.Objects;
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAll(Negocio.Empleado empleado)
        {
            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            empleado.ApellidoPaterno = (empleado.ApellidoPaterno == null) ? "" : empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = (empleado.ApellidoMaterno == null) ? "" : empleado.ApellidoMaterno;

            Negocio.Result result = Negocio.Empleado.GetAll(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno);
            if (result.Correct)
            {
                empleado.Empleados = new List<object>();
                empleado.Empleados = result.Objects;
            }
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form()
        {
            Negocio.Empleado empleado = new Negocio.Empleado();
            Negocio.Result resultPuestos = Negocio.Puesto.GetAll();
            Negocio.Result resultDepartamentos = Negocio.Departamento.GetAll();

            empleado.Puesto = new Negocio.Puesto();
            empleado.Puesto.Puestos = resultPuestos.Objects;
            empleado.Departamento = new Negocio.Departamento();
            empleado.Departamento.Departamentos = resultDepartamentos.Objects;

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Form(Negocio.Empleado empleado)
        {
            Negocio.Result result = new Negocio.Result();
            result = Negocio.Empleado.Add(empleado);

            if (result.Correct)
            {
                ViewBag.Message = "El empleado se ingresó correctamente!!!";
            }
            else
            {
                ViewBag.Message = "No se insertó el empleado, ocurrió el siguiente error: " + result.ErrorMessage;
            }

            return PartialView("ValidationModal");
        }

        [HttpGet]
        public ActionResult Delete (int IdEmpleado)
        {
            Negocio.Result result = Negocio.Empleado.Delete(IdEmpleado);

            if (result.Correct)
            {
                ViewBag.Message = "El empleado se eliminó correctamente!!!";
            }
            else
            {
                ViewBag.Message = "El empleado no se eliminó, ocurrió el siguiente error: " + result.ErrorMessage;
            }

            return PartialView("ValidationModal");
        }
    }
}
