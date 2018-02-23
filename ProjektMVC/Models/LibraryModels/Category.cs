using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public string name { get; set; }
    }
}