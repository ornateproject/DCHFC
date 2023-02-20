using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class US2approvalController : Controller
    {
        private readonly US2approval _us2repo;
        public US2approvalController(IConfiguration configuration)
        {
            _us2repo = new US2approval(configuration);


        }

        [HttpGet]
        public IActionResult us2details(int id)
        {
            var usdata = _us2repo.get_approval(id);
            UserDepartment dep_reg = new UserDepartment();
            dep_reg = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata)[0];
            return View(dep_reg);
        }

        public ActionResult Approve(int id)
        {
            _us2repo.UpdateStatusData(id, "Approved");
            return RedirectToAction("us2", "US2");
        }

        public ActionResult Reject(int id)
        {
            _us2repo.UpdateStatusData(id, "Rejected");
            return RedirectToAction("us2", "US2");


        }
    }
}
