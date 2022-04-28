using Microsoft.AspNetCore.Mvc;

namespace Telcel.R9.Estructura.Presentation.Controllers
{
    public class DepartamentosController : Controller
    {
        public ActionResult GetAll()
        {
            Negocio.Departamento departamento = new Negocio.Departamento();

            Negocio.Result result = Negocio.Departamento.GetAll();
            if (result.Correct)
            {
                departamento.Departamentos = new List<object>();
                departamento.Departamentos = result.Objects;
            }
            return View(departamento);
        }
    }
}
