using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class CandidatedataController : Controller
    {


        [HttpGet]
        public IActionResult candidate()
        {
            return View();
        }
        public IActionResult getcandidatedata()
        {
            return View();
        }
    }
}
