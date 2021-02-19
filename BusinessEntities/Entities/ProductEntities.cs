using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessEntities.Entities
{
    public class ProductEntities
    {
     
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Product Category!")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Product name is required!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a number!")]
        public int price { get; set; }

        [Required(ErrorMessage = "Quantity is required!")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Shortdescription is required!")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Longdescription is required!")]
        public string LongDescription { get; set; }

        public string ImagePath { get; set; }
        public string LongImage { get; set; }

        [Required(ErrorMessage = "Small Image file is required!")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required(ErrorMessage = "Long Image file is required!")]
        public HttpPostedFileBase ImageFile1 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}
