using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Search
    {
        public int searchID { get; set; }
        public int readerID { get; set; }
        public string searchString { get; set; }
        public virtual Reader Reader { get; set; }
    }
}