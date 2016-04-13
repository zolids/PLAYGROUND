using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMSCore
{
    public class Quotation
    {
        public string QuotationNo { get; set; }

        public Nullable<DateTime> QuotationDate { get; set; }

        public string NLID { get; set; }

        public string PreparedBy { get; set; }
     
        public string Status { get; set; }
 
        public string AppDecBy { get; set; }
       
        public Nullable<DateTime> DateApproved { get; set; }

        public Nullable<DateTime> DateRejected { get; set; }

        public long Meter { get; set; }

        public decimal Gross { get; set; }

        public decimal Discount { get; set; }

        public decimal Net { get; set; }

        public string PricesBy { get; set; }

        public string VerifiedBy { get; set; }

        public string Notes { get; set; }

        public string Remarks { get; set; }

        public string Reason { get; set; }

        public byte ForApproval { get; set; }

        public string AccessCode { get; set; }

        public string Passkey { get; set; }

        public string ReqEMail { get; set; }

        public string RefQuotationNo { get; set; }

        public string SiteCode { get; set; }

        public string CusRefCode { get; set; }

        public decimal LaborCost { get; set; }

        public decimal LaborProfPerc { get; set; }

        public decimal DiscPerc { get; set; }

        public string CTOCusRefCode { get; set; }

        public List<QuotationService> Services { get; set; }

        public List<QuotationParts> Parts { get; set; }

    }

    public class QuotationService
    {
        public long QTServiceID { get; set; }

        public string QuotationNo { get; set; }

        public long ServiceID { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceDesc { get; set; }

        public decimal Hours { get; set; }

        public decimal SalesPrice { get; set; }

        public string Remarks { get; set; }

        public byte Approved { get; set; }
    }


    public class QuotationParts
    {

        public long QTPartID { get; set; }

        public string QuotationNo { get; set; }

        public long PartID { get; set; }

        public string PartNo { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string UnitType { get; set; }

        public decimal SalesPrice { get; set; }

        public string Remarks { get; set; }

        public byte Approved { get; set; }

        public string ETD { get; set; }
    }

    public class SimpleModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SiteCode { get; set; }
    }
}