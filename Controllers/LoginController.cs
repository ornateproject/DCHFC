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
        public async Task<IActionResult> Index(ManageDepreg model)
        {
            if (ModelState.IsValid)
            {
                var result = _login.LoginCheck(model.loginuser);
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
            TempData["error"] = "Please Enter Valid User Name And Password";
            TempData["tab"] = "US";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult login()
        {
            var phases = _login.selection_post();
            ManageDepreg manageDepreg = new ManageDepreg();
            manageDepreg.phases_post = JsonConvert.DeserializeObject<List<phases>>(phases);
            return View(manageDepreg);
        }

        [HttpPost]
        public async Task<IActionResult> login(ManageDepreg model)
        {
            if (ModelState.IsValid)
            {
                var result = _login.userlogin(model.loginuser);
                if (result.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("user_id", Convert.ToString(result.Rows[0]["id"]));
                    HttpContext.Session.SetString("userType", Convert.ToString(result.Rows[0]["UserType"]));
                    // return RedirectToAction("us2", "US2");
                    HttpContext.Session.SetString("department", Convert.ToString(result.Rows[0]["department"]));
                    HttpContext.Session.SetString("reg_id", Convert.ToString(result.Rows[0]["reg_id"]));
                    return RedirectToAction("dashboard", "US");
                }
                TempData["error"] = "Please Enter Valid User Name And Password";
                TempData["tab"] = "US";
                return RedirectToAction("Index", "Home");
            }

           TempData["tab"] = "US";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult logincandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> logincandidate(ManageDepreg model)
        {
            if (ModelState.IsValid)
            {
               var result = _login.candidatelogin(model.candidatelogin);
                if (result.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("Reg_no", Convert.ToString(result.Rows[0]["Reg_no"]));
                    HttpContext.Session.SetString("DOB", Convert.ToString(result.Rows[0]["DOB"]));

                    return RedirectToAction("candidate_dashboard", "Candidatedata");
                }
                TempData["error"] = "Please Enter Valid User Name And Password";
                TempData["tab"] = "US";
                return RedirectToAction("logincandidate", "Login");
            }
            return RedirectToAction("logincandidate", "Login");
        }

        

        [HttpGet]
        public IActionResult usviewback(int id)
        {
            var usdata = _login.getdatelist(id);
            getpost dep_reg = new getpost();
            dep_reg = JsonConvert.DeserializeObject<List<getpost>>(usdata)[0];
            return View(dep_reg);         
            
        }
        public ActionResult Approve(int id)
        {
            _login.UpdatecandidateStatus(id, "Approved");
            return RedirectToAction("getcandidatelist", "Candidatedata");
        }

        public ActionResult Reject(int id)
        {
            _login.UpdatecandidateStatus(id, "Rejected");
            return RedirectToAction("getcandidatelist", "Candidatedata");
        }

        [HttpGet]
        public IActionResult linkselectionmts()
        {
            return View();
        }
    }
}
