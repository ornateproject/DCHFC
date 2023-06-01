using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;
using iTextSharp.text;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using DocumentFormat.OpenXml.Wordprocessing;
using Grpc.Core;

namespace ssc.Controllers
{
    public class CandidatedataController : Controller
    {
        
        private readonly candidatedata_repo _candidaterepo;
        private readonly candidateuser_Repo _canduserrepo;

        public CandidatedataController(IConfiguration configuration)
        {
            _candidaterepo = new candidatedata_repo(configuration);
             _canduserrepo = new candidateuser_Repo(configuration);
        }
       
        [HttpGet]
        public IActionResult candidate()
        {
          var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
            var usdata = _candidaterepo.get_postcanddata(reg_no);
           
            managecandidatedata managecandidatedata = new managecandidatedata();

           // managecandidatedata.getposts = usdata.getposts.Where(x => x.is_present == "true").ToList();
            managecandidatedata.getposts = JsonConvert.DeserializeObject<List<getpost>>(usdata);
           //managecandidatedata.getposts = model.candidatepersonaldetails(usdata);

            return View(managecandidatedata);
        }
       
        [HttpPost]
        public async Task<IActionResult> candidate(managecandidatedata data)
        {

            var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
            var name = HttpContext.Session.GetString("Name").ToString();
           
                var asd = _candidaterepo.Insertdata(data, reg_no);
                // return View("candidate", "Candidatedata");
                return View("candidate_dashboard", "Candidatedata");

            
          //  var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
          //  var name = HttpContext.Session.GetString("Name").ToString();
          ////  var asd = _candidaterepo.InsertpostData(data,reg_no,name);

          //  managecandidatedata managecan = new managecandidatedata();

          //  managecan.getposts = data.getposts.Where(x => x.is_checked == "true").ToList();
          //  managecan.candetails = data.candetails;
          //  var savedfiles = _candidaterepo.savepdf(managecan);
          //  var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/document/FinalDocument", reg_no + ".pdf");

          //  using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
          //  {
          //      Document document = new Document();
          //      PdfCopy pdf = new PdfCopy(document, stream);
          //      document.Open();

          //      foreach (string pdfFile in savedfiles)
          //      {
          //          PdfReader reader = new PdfReader(pdfFile);
          //          pdf.AddDocument(reader);
          //          reader.Close();
          //      }
          //      // var asd = _candidaterepo.InsertpostData(managecan);
          //      // return View("candidate_dashboard", "Candidatedata");
          //      pdf.Close();
          //      document.Close();
          //  }

          //  managecan.candetails.regNo = reg_no + ".pdf";
          //  //HttpContext.Session.SetString("selected_post",JsonConvert.SerializeObject(managecan));
          //  return View("~/Views/Candidatedata/candidate_preview.cshtml", managecan);

        }

        [HttpPost]
        public ActionResult candidate_preview(managecandidatedata data)
        {
            //  managecandidatedata managecan = new managecandidatedata();

            var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
            var name = HttpContext.Session.GetString("Name").ToString();
            //var selected_post = HttpContext.Session.GetString("selected_post");
            //data = JsonConvert.DeserializeObject<managecandidatedata>(selected_post);
            if (ModelState.IsValid)
            {
                var asd = _candidaterepo.Insertdata(data,reg_no);
                // return View("candidate", "Candidatedata");
                return View("candidate_dashboard", "Candidatedata");

            }
            return View();
        }


        [HttpGet]
        public IActionResult usview()
        {
            // var reg_no = HttpContext.Session.GetString("Reg_no").ToString();

            var user = HttpContext.Session.GetString("userType").ToString();
            if (@user == "2")
            {
                var usdata = _candidaterepo.get_uspostdata();
                List<getpost> deptm = new List<getpost>();
                deptm = JsonConvert.DeserializeObject<List<getpost>>(usdata);
                return View(deptm);
            }
            else if (@user=="3")
            {
                var depart = HttpContext.Session.GetString("dep_name").ToString();
                var usdata = _candidaterepo.get_postdata(depart);
                List<getpost> dept = new List<getpost>();
                dept = JsonConvert.DeserializeObject<List<getpost>>(usdata);
                return View(dept);
            }

            return View();

        }

        [HttpGet]
        public IActionResult getcandidatedata()
        {
         return View();
        }
        [HttpGet]
        public IActionResult getcandidatedatadept()
        {
          
          return View();
        }

        [HttpGet]
        public IActionResult getcandidatelist(string id)
        {
           var usdata = _candidaterepo.getcandidatelist(id);
            List<getpost> dept = new List<getpost>();
           dept = JsonConvert.DeserializeObject<List<getpost>>(usdata);
            return View(dept);            
        }
        [HttpGet]
        public IActionResult getuscandidatelist()
        {
            return View();
        }

        [HttpGet]
        public IActionResult candidateupload_doc(string post_id)
        {
            var document_name = _candidaterepo.get_docname();            
                var postdata = _candidaterepo.get_applypostdata( post_id);
            managecandidatedata managecandata = new managecandidatedata();
            managecandata.candocument = JsonConvert.DeserializeObject<List<candidatedocument_data>>(document_name);
            managecandata.getposts = JsonConvert.DeserializeObject<List<getpost>>(postdata);

            return View(managecandata);
        }


        [HttpPost]
        public IActionResult candidateupload_doc(managecandidatedata data,string post_id)
        {
            var name = HttpContext.Session.GetString("Name").ToString();
            var reg_no = HttpContext.Session.GetString("Reg_no").ToString();

            managecandidatedata managecan = new managecandidatedata();
          //  var asd = _candidaterepo.Insertcandidate_doc(data, post_id);
            managecan.upload_doc = data.upload_doc;
            var savedfiles = _canduserrepo.savepdf(managecan);
            var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf/finaldocument", post_id+"_" +reg_no +".pdf");

            using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
            {
               iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfCopy pdf = new PdfCopy(document, stream);
                document.Open();
                foreach (string pdfFile in savedfiles)
                {
                    PdfReader reader = new PdfReader(pdfFile);
                    pdf.AddDocument(reader);
                    reader.Close();
                }
                pdf.Close();
                document.Close();
            }
            managecan.upload_doc.regNo = post_id+"_" +reg_no+ ".pdf";
            var asd = _candidaterepo.InsertpostData(data, reg_no, name, outputFilePath);
            return RedirectToAction("candidate", "Candidatedata");

        }


        [HttpGet]
        public IActionResult candidate_dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult candidate_preview()
        {
            //  var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
            var dept= HttpContext.Session.GetString("department").ToString();

            var usdata = _candidaterepo.get_postdata(dept);

            managecandidatedata managecandidatedata = new managecandidatedata();

            managecandidatedata.getposts = JsonConvert.DeserializeObject<List<getpost>>(usdata);

            return View(managecandidatedata);
            
        }
        
       
        //public IActionResult Email(string status)
        //{
          
        //    try
        //    {
        //        if (status== "Approved")
        //        {
        //            SendEmail("neha@ornatets.com", "abhishek@ornatets.com", "NehaSahu@123",587, "mail.ornatets.com", "Test", "wwwroot/message.html");
        //        }
        //        if (status== "Rejected")
        //        {
        //            SendEmail("neha@ornatets.com", "abhishek@ornatets.com", "NehaSahu@123", 587, "mail.ornatets.com", "Test", "wwwroot/re_message.html");
        //        }
               
        //    }
        //    catch (Exception) { }
        //    return RedirectToAction("usview","Candidatedata");
        //}
    }
}
