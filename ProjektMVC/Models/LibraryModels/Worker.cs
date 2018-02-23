using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class Worker
    {
        public int workerID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }
        public string address { get; set; }
    }
}