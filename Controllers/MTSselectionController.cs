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
                
                //  TempData["show"] = "Post created successfully";
                department.TOTAL = department.UR + department.OBC + department.SC + department.ST + department.EWS;

                department.Total_vacancy = department.VH + department.HH + department.OH + department.OTHERS;

                var asd = _mtsrepo.InsertpostData(department);


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
