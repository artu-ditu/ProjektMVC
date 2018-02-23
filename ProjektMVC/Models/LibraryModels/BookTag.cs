using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class BookTag
    {
        public int bookTagID { get; set; }
        public int bookID { get; set; }
        public int tagID { get; set; }
        public virtual Book Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}