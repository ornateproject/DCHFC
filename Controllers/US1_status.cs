using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using System.IO;
using System.Linq;
using ssc.Models;

namespace ssc.Controllers
{
    public class US1_status : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public US1_status(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Status()
        {
            return View();
        }
        [HttpPost]

        public IActionResult MergePDFs(candidate_doc can_doc)
        {

            List<string> uploadedfiles = new List<string>();
            // Add the file paths of the uploaded PDF files to the list
            foreach (var file in can_doc.PdfFiles)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".pdf")
                {
                    uploadedfiles.Add(Path.Combine(_hostingEnvironment.WebRootPath, "uploads", file.FileName));
                    // Save the uploaded file to the server
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }

            // Set the output file path
            var outputFile = Path.Combine(_hostingEnvironment.WebRootPath, "merged.pdf");

            // Merge the PDF files
            using (var output = new FileStream(outputFile, FileMode.Create))
            {
                var document = new Document();
                var writer = PdfWriter.GetInstance(document, output);
                document.Open();

                foreach (var file in uploadedfiles)
                {
                    var reader = new PdfReader(file);
                    var pageCount = reader.NumberOfPages;

                    for (var i = 1; i <= pageCount; i++)
                    {
                        var page = writer.GetImportedPage(reader, i);
                        document.Add(Image.GetInstance(page));
                    }

                    writer.FreeReader(reader);
                    reader.Close();
                }

                document.Close();
            }

            // Return the merged PDF file as a FileStreamResult
            return new FileStreamResult(new FileStream(outputFile, FileMode.Open), "application/pdf");

        }
    }
   
}