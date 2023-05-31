using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;
using System.Net.Mail;

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
                    HttpContext.Session.SetString("Name", Convert.ToString(result.Rows[0]["Name"]));
                    HttpContext.Session.SetString("dep_name", Convert.ToString(result.Rows[0]["dep_name"]));
                   HttpContext.Session.SetString("loginfor", Convert.ToString(result.Rows[0]["post"]));
                    // return RedirectToAction("us2", "US2");
                    HttpContext.Session.SetString("department", Convert.ToString(result.Rows[0]["department"]));
                    HttpContext.Session.SetString("reg_id", Convert.ToString(result.Rows[0]["reg_id"]));
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
        public IActionResult logincandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>logincandidate(ManageDepreg model)
        {
            if (ModelState.IsValid)
            {
               var result = _login.candidatelogin(model.candidatelogin);
                if (result.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("Name", Convert.ToString(result.Rows[0]["Name"]));
                    HttpContext.Session.SetString("Reg_no", Convert.ToString(result.Rows[0]["Reg_no"]));
                    HttpContext.Session.SetString("DOB", Convert.ToString(result.Rows[0]["DOB"]));
                    return RedirectToAction("candidate_dashboard", "Candidatedata");
                }
                TempData["error"] = "Please Enter Valid User Name And Password";
                //TempData["tab"] = "US";
                return RedirectToAction("logincandidate", "Login");
            }
            TempData["error"] = "Please Enter Valid User Name And Password";
            return RedirectToAction("logincandidate", "Login");
        }

        

        [HttpGet]
        public IActionResult usviewback(string id,string post_id)
        {
           var usdata = _login.getdatelist(id,post_id);
            getpost dep_reg = new getpost();
            dep_reg = JsonConvert.DeserializeObject<List<getpost>>(usdata)[0];
            return View(dep_reg);         
            
        }
        public ActionResult Approve(int id,string post_id )
        {
            _login.UpdatecandidateStatus(id, "Approved",post_id);
            SendEmail("neha@ornatets.com", "abhishek@ornatets.com", "NehaSahu@123", 587, "mail.ornatets.com", "Test", "wwwroot/message.html");
            return RedirectToAction("usview", "Candidatedata");
        }

        public ActionResult Reject(int id, string post_id)
        {
            _login.UpdatecandidateStatus(id, "Rejected", post_id);
            SendEmail("neha@ornatets.com", "abhishek@ornatets.com", "NehaSahu@123", 587, "mail.ornatets.com", "Test", "wwwroot/re_message.html");

            return RedirectToAction("usview", "Candidatedata");
        }
        public ActionResult Rejected(int id, string post_id)
        {
            _login.UpdatecandidateStatus(id, "Re_Rejected", post_id);

            return RedirectToAction("usview", "Candidatedata");
        }

        [HttpGet]
        public IActionResult linkselectionmts()
        {
            return View();
        }
        protected void SendEmail(string from, string to, string password, int port, string host, string test, string message)
        {
            string memberString = System.IO.File.ReadAllText(message).ToString();
            // string memberString = File.ReadAllText(filePath);
            string body = memberString;
            //var bodyhtml = memberString;
            //string from = "neha@ornatets.com";
            //Creates the email message
            MailMessage emailMessage = new MailMessage(from, to);
            //Adds the subject for email
            emailMessage.Subject = test;
            //Sets the HTML string as email body
            emailMessage.IsBodyHtml = true;
            emailMessage.Body = body;

            //  emailMessage.Bcc.Add(new MailAddress("vivek@ornatets.com"));
            using (SmtpClient client = new SmtpClient())
            {
                //Update your SMTP Server address here
                //client.Host = "mail.ornatets.com";
                client.Host = host;
                client.UseDefaultCredentials = false;
                //Update your email credentials here
                client.Credentials = new System.Net.NetworkCredential(from, password);
                //client.Port = 587;
                client.Port = port;
                client.EnableSsl = false;
                client.Send(emailMessage);
            }
            // Logic to send the email
        }
    }
}
