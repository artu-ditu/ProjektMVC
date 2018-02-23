using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Tag
    {
        public int tagID { get; set; }
        public string value { get; set; }
        public virtual ICollection<Book> books { get; set; }
    }
}