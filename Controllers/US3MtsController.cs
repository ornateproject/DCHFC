using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class US3MtsController : Controller
    {
        private readonly US3mtsapprovalrepo _us3repo;
        public US3MtsController(IConfiguration configuration)
        {
            _us3repo = new US3mtsapprovalrepo(configuration);


        }

        [HttpGet]
        public IActionResult us3mtsapproval(int id)
        {
            var usdata = _us3repo.get_approval(id);
            MTSselection dep_reg = new MTSselection();
            dep_reg = JsonConvert.DeserializeObject<List<MTSselection>>(usdata)[0];
            return View(dep_reg);
        }

        
    }
}
