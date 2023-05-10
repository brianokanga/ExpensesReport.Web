using Microsoft.AspNetCore.Mvc;

namespace ExpensesReport.Web.Controllers
{
    public class ExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
