using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Penalty
    {
        public int penaltyID { get; set; }
        public int readerID { get; set; }
        public int bookID { get; set; }
        public double fine { get; set; }
        public bool isPayed { get; set; }
        public virtual Reader Reader { get; set; }
        public virtual Book Book { get; set; }
    }
}