using Microsoft.AspNetCore.Mvc;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class MTSselectionController : Controller
    {
        private readonly MTSrepo _mtsrepo;
        public MTSselectionController(IConfiguration configuration)
        {
            _mtsrepo = new MTSrepo(configuration);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MTSselection department)
        {
            if (ModelState.IsValid)
            {
                var asd = _mtsrepo.InsertpostData(department);
              //  TempData["show"] = "Post created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


    }
}
