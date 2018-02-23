using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Book
    {
        public int bookID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string iSBN { get; set; }
        [DataType(DataType.Date)]
        public DateTime releaseDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime addDate { get; set; }
        public string description { get; set; }
        public int categoryID { get; set; }
        public int stock { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> tags { get; set; }
        public virtual ICollection<File> files { get; set; }
    }
}