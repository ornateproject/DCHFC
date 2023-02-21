using Microsoft.AspNetCore.Mvc;

namespace ssc.Controllers
{
    public class UserDeptDashboard : Controller
    {
        public IActionResult UserDeptDash()
        {
            return View();
        }
    }
}
