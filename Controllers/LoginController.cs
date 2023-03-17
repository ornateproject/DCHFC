using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Index(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _login.LoginCheck(model);
                if (result.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("user_id", Convert.ToString(result.Rows[0]["id"]));
                    HttpContext.Session.SetString("userType", Convert.ToString(result.Rows[0]["usertype"]));
                    //HttpContext.Session.SetString("userType", Convert.ToString(result.Rows[0]["usertype"]));
                    //HttpContext.Session.SetString("emp_name", Convert.ToString(dt.Rows[0][1]));
                    //HttpContext.Session.SetString("emp_email", Convert.ToString(dt.Rows[0][2]));
                    return RedirectToAction("dashboard", "US");
                }
                TempData["error"] = "Please Enter Valid User Name And Password";
                TempData["tab"] = "US";
                return RedirectToAction("Index", "Home");
            }
            // TempData["error"] = "Please Enter Valid User Name And Password";
            TempData["tab"] = "US";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _login.userlogin(model);
                if (result.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("user_id", Convert.ToString(result.Rows[0]["id"]));
                    HttpContext.Session.SetString("userType", Convert.ToString(result.Rows[0]["UserType"]));
                    // return RedirectToAction("us2", "US2");
                    return RedirectToAction("dashboard", "US");
                }
                TempData["error"] = "Please Enter Valid User Name And Password";
                TempData["tab"] = "US2";
                return RedirectToAction("Index", "Home");
            }

            TempData["tab"] = "US2";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult logincandidate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult usview()
        {
            return View();
        }

    }
}
