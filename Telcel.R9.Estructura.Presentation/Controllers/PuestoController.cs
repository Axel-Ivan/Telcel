using Microsoft.AspNetCore.Mvc;

namespace Telcel.R9.Estructura.Presentation.Controllers
{
    public class PuestoController : Controller
    {
        public ActionResult GetAll()
        {
            Negocio.Puesto puesto = new Negocio.Puesto();

            Negocio.Result result = Negocio.Puesto.GetAll();
            if (result.Correct)
            {
                puesto.Puestos = new List<object>();
                puesto.Puestos = result.Objects;
            }
            return View(puesto);
        }
    }
}
