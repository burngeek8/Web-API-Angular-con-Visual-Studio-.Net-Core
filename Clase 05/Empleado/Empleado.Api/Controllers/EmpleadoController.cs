using Microsoft.AspNetCore.Mvc;

namespace Empleado.Api.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
