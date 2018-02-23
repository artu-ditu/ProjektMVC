using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Message
    {
        public int messageID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        [DataType(DataType.Date)]
        public DateTime addDate { get; set; }
    }
}