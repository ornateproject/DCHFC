using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class US1_pendingapprovalController : Controller
    {

        private readonly Uspendingrepo _usrepo;
        public US1_pendingapprovalController(IConfiguration configuration)
        {
            _usrepo = new Uspendingrepo(configuration);


        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var usdata = _usrepo.get_approval(id);
            DeptRegistration dep_reg = new DeptRegistration();
            dep_reg = JsonConvert.DeserializeObject<List<DeptRegistration>>(usdata)[0];
            return View(dep_reg);
        }

        //private Uspendingrepo dataAccess = new Uspendingrepo();

        public ActionResult Approve(int id)
        {
            _usrepo.UpdateStatusData(id, "Approved");
            return RedirectToAction("Index");
        }

        public ActionResult Reject(int id)
        {
            _usrepo.UpdateStatusData(id, "Rejected");
            return RedirectToAction("Index");
        }

    }
}
