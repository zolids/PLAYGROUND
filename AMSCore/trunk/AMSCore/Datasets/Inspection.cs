using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMSCore
{    
    public class Inspection
    {
        public long InspectionID { get; set; }

        public string RefNo { get; set; }

        public string NLID { get; set; }

        public Nullable<DateTime> DateReported { get; set; }

        public string Inspector { get; set; }

        public byte HandDrive { get; set; }

        public byte Wheel { get; set; }

        public long Speedo { get; set; }

        public string BodyDamage { get; set; }

        public string QuotationNo { get; set; }

        public string WONo { get; set; }

        public string SiteCode { get; set; }

        public List<InspectionDetails> Details { get; set; }
    }

    public class InspectionDetails
    {
        public long DetailID { get; set; }

        public string RefNo { get; set; }

        public string Areas { get; set; }

        public byte MCap { get; set; }

        public string Remarks { get; set; }
    }
}
