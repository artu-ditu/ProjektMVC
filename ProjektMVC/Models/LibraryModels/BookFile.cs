using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class BookFile
    {
        public int bookFileID { get; set; }
        public int bookID { get; set; }
        public int fileID { get; set; }
        public virtual Book Book { get; set; }
        public virtual File Tag { get; set; }
    }
}