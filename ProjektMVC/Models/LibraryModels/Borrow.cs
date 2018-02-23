using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Borrow
    {
        public int borrowID { get; set; }
        public string borrowState { get; set; }
        public int readerID { get; set; }
        public int bookID { get; set; }
        [DataType(DataType.Date)]
        public DateTime borrowDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime maxReturnDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime actualReturnDate { get; set; }

        public virtual Reader Reader { get; set; }
        public virtual Book Book { get; set; }
    }
}