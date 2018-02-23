using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMVC.Models
{
    public class ManageUsers
    {
        public class UserRoleInfo
        {
            public ApplicationUser User { set; get; }
            public List<string> Roles { set; get; }
        }
    }
}