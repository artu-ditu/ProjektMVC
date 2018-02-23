using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class CategoryParent
    {
        public int categoryParentID { get; set; }
        public int parentID { get; set; }
        public int childID { get; set; }
        public virtual Category Parent { get; set; }
        public virtual Category Child { get; set; }
    }
}