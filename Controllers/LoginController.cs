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
                var asd = _login.LoginCheck(model);

                return RedirectToAction("Index", "UserDepartment");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
