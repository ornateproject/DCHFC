using Microsoft.AspNetCore.Mvc;

namespace ssc.Controllers
{
    public class US1_status : Controller
    {
        public IActionResult Status()
        {
            return View();
        }
    }
}
