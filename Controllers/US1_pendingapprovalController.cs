using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var usdata = _usrepo.get_approval();
            
            return View();
        }

    }
}
