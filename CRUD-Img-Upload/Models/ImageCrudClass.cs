using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Img_Upload.Models
{
    public class ImageCrudClass
    {
        [Key]
        public int Imgid { get; set; }
        public string Imagename { get; set; }
        public string Imagepath { get; set; }
    }
}
