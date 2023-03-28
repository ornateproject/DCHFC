using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;
using System.IO;

namespace ssc.Controllers
{
    public class Dataupload_userdept : Controller
    {

        private readonly uploaduserdata_repo _uploadrepo;
        public Dataupload_userdept(IConfiguration configuration)
        {
            _uploadrepo = new uploaduserdata_repo(configuration);

        }

        [HttpGet]
        public IActionResult uploaduserdata( )
        {

            var phases = _uploadrepo.selection_post();
            ManageDepreg manageDepreg = new ManageDepreg();
            manageDepreg.phases_post = JsonConvert.DeserializeObject<List<phases>>(phases);
            return View(manageDepreg);

        }

        [HttpPost]
        public async Task<IActionResult> uploaduserdata(ManageDepreg model)
        {
            if (ModelState.IsValid)
            {
                
                var asd = _uploadrepo.InsertpostData(model.upload_data);
                
            }
            
            return View();

        }



    }
}
