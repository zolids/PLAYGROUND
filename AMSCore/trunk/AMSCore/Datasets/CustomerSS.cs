using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMSCore
{
   public class CustomerSS
    {
        public string SurveyCode { get; set; }

        public Nullable<DateTime> Date { get; set; }

        public int WeekNo { get; set; }

        public string MILNo { get; set; }

        public decimal EaseVehReq { get; set; }

        public decimal StaffCourtesyDes { get; set; }

        public decimal VehPerformance { get; set; }

        public decimal VehCleanliness { get; set; }

        public decimal VehicleReturn { get; set; }

        public decimal StaffCourtesyRet { get; set; }

        public decimal StafPerfAll { get; set; }

        public decimal VehicleSelect { get; set; }

        public string Remarks { get; set; }

        public string SiteCode { get; set; }        
    }

   public class Personnel
   {
       public long CusPerID { get; set; }
       
       public string LastName { get; set; }

       public string FirstName { get; set; }

       public string MiddleName { get; set; }

       public string Position { get; set; }

       public string SiteCode { get; set; }
       
       public string Unit { get; set; }

       public string CmdName { get; set; }

       public string CmdContactNo { get; set; }

       public string ContactNo { get; set; }

       public string Email { get; set; }

       public string LicenseNo { get; set; }

       public string MILNo { get; set; }

       public string LicenseCat { get; set; }

       public Nullable<DateTime> DateOfBirth { get; set; }

       public string Status { get; set; }

   }
}
