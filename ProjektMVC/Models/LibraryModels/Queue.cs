using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Queue
    {
        public int queueID { get; set; }
        public int bookID { get; set; }
        public int readerID { get; set; }
        [DataType(DataType.Date)]
        public DateTime addDate { get; set; }
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}