using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class Users
    {
        public long user_id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string name { get; set; }

        public string position { get; set; }

        public int usertype { get; set; }

        public int rfqApprover { get; set; }

        public int rfqAmount { get; set; }

        public string email { get; set; }

        public string Status { get; set; }

        public virtual List<Location> UserSites { get; set; }
    }

    public class Location
    {
        public long SiteID { get; set; }

        public string TMPLocation { get; set; }

        public string SiteCode { get; set; }

        public string SiteName { get; set; }

        public byte stat { get; set; }

        public bool Selected { get; set; }
    }
}
