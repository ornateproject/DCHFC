using Microsoft.AspNetCore.Mvc;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class LoginController : Controller
    {
        UserModel depro = new UserModel();

        private readonly LoginRepo _login;

        public LoginController(IConfiguration configuration)
        {
            _login = new LoginRepo(configuration);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _login.LoginCheck(model);
                if (result.Rows.Count>0)
                {
                    return RedirectToAction("Index", "UserDepartment");
                }
                TempData["error"] = "Please Enter Valid User Name And Password";
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
