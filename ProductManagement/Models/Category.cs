using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Category name is required!")]
        public string CategoryName { get; set; }
    }
}