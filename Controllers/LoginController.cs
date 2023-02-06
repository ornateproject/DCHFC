using Microsoft.AspNetCore.Mvc;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class LoginController : Controller
    {

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
              //  var user = _login.getuser(model);
               return RedirectToAction("Index");
            }
                return View();
        }

    }
}
