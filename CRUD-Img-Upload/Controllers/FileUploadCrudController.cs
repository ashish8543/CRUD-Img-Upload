using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using CRUD_Img_Upload.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CRUD_Img_Upload.Controllers
{
    public class FileUploadCrudController : Controller
    {

        private readonly ApplicationDbContext _adb;
        private readonly IWebHostEnvironment _iweb;

        public FileUploadCrudController(ApplicationDbContext adb,IWebHostEnvironment iweb)
        {

            _adb = adb;
            _iweb = iweb;


        }
        public IActionResult Index()
        {
            var displayimages = _adb.Saveimg.ToList();

            return View(displayimages);
        }
        [HttpPost]
        public async Task<IActionResult>Index(IFormFile fileobj,ImageCrudClass icc )
        {
            var imgext = Path.GetExtension(fileobj.FileName);
            if(imgext==".jpg"|| imgext==".gif")
            {
                var uploadimg = Path.Combine(_iweb.WebRootPath, "Images", fileobj.FileName);
                var stream = new FileStream(uploadimg, FileMode.Create);
                await fileobj.CopyToAsync(stream);
                stream.Close();


                icc.Imagename = fileobj.FileName;
                icc.Imagepath = uploadimg;
                await _adb.Saveimg.AddAsync(icc);
                await _adb.SaveChangesAsync();
            }
            return RedirectToAction("Index");


        }


    }
}
