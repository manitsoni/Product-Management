using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Products
    {
        [Required(ErrorMessage ="Please Select Product Category!")]
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        [Required(ErrorMessage ="Product name is required!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Price is required!")]
        [RegularExpression(@"[0-9]*\.?[0-9]+",ErrorMessage ="{0} must be a number!")]
        public int price { get; set; }

        [Required(ErrorMessage ="Quantity is required!")]
        public int Quantaty { get; set; }

        [Required(ErrorMessage ="Shortdescription is required!")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage ="Longdescription is required!")]
        public string LongDescription { get; set; }

        public string SmallImage { get; set; }
        public string LongImage { get; set; }

        [Required(ErrorMessage = "Small Image file is required!")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required(ErrorMessage = "Long Image file is required!")]
        public HttpPostedFileBase ImageFile1 { get; set; }

    }
}