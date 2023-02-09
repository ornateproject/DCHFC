using Microsoft.AspNetCore.Mvc;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class MTSselectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MTSselection department)
        {
            if (ModelState.IsValid)
            {
                //var asd = _userDepRepo.InsertpostData(department);

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
