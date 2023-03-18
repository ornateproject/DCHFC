using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;
using System.Diagnostics;

namespace ssc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginRepo _login;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _login = new LoginRepo(configuration);
        }

        public IActionResult Index()
        {
            //var active_tab = TempData["tab"];
            var phases = _login.selection_post();
            ManageDepreg manageDepreg = new ManageDepreg();
            manageDepreg.phases_post = JsonConvert.DeserializeObject<List<phases>>(phases);
            return View(manageDepreg);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}