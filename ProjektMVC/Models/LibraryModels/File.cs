using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class File
    {
        public int fileID { get; set; }
        public string filename { get; set; }
        public string description { get; set; }
        public virtual ICollection<Book> books { get; set; }
    }
}