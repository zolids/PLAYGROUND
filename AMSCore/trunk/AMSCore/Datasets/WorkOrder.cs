using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class WorkOrder
    {
        public string WONo { get; set; }

        public Nullable<DateTime> Issued { get; set; }

        public Nullable<DateTime> Closed { get; set; }

        public Nullable<DateTime> DtCompleted { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        public long Meter { get; set; }

        public string WorkPerformed { get; set; }

        public string InspectedBy1 { get; set; }

        public string InspectedBy2 { get; set; }

        public decimal WONet { get; set; }

        public string Notes { get; set; }

        public string NLID { get; set; }

        public string Status { get; set; }

        public long DeptID { get; set; }

        public long LocID { get; set; }

        public string VehStatus { get; set; }

        public string SiteCode { get; set; }

        public byte Accidental { get; set; }

        public decimal PartsCost { get; set; }

        public decimal Recovery { get; set; }

        public int Labor { get; set; }

        public decimal NoHour { get; set; }

        public decimal Total { get; set; }

        public string DamageCause { get; set; }

        public string PreventiveCause { get; set; }

        public string CusRefCode { get; set; }

        public Nullable<DateTime> ETC { get; set; }

        public string PricesBy { get; set; }

        public int Fuel1 { get; set; }

        public int Fuel2 { get; set; }

        public string InvoiceType { get; set; }

        public string WOType { get; set; }

        public string CurrencyCode { get; set; }

        public decimal Gross { get; set; }

        public decimal Discount { get; set; }

        public decimal Net { get; set; }

        public string QuotationNo { get; set; }

        public decimal LaborCost { get; set; }

        public decimal LaborProfPerc { get; set; }

        public decimal WOGross { get; set; }

        public decimal WODiscount { get; set; }

        public decimal DiscPerc { get; set; }

        public string CTOCusRefCode { get; set; }

        public List<WorkOrderServices> Services { get; set; }

        public List<WorkOrderParts> Parts { get; set; }

        public List<WOLaborers> Laborers { get; set; }

        public byte TempClose { get; set; }

        public byte UpdatedLastServe { get; set; }
    }

    public class WorkOrderParts
    {
        public long WOPartID { get; set; }

        public string WONO { get; set; }

        public long PartID { get; set; }

        public string PartNo { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string UnitType { get; set; }

        public decimal SalesPrice { get; set; }

        public string Remarks { get; set; }

        public byte Issued { get; set; }

        public byte Approved { get; set; }

        public Nullable<DateTime> IssuedDate { get; set; }

        public string IssuedBy { get; set; }
    }

    public class WorkOrderServices
    {
        public long WOServiceID { get; set; }

        public string WONO { get; set; }

        public long ServiceID { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceDesc { get; set; }

        public string SubCategory { get; set; }

        public decimal Hours { get; set; }

        public decimal SalesPrice { get; set; }

        public string Remarks { get; set; }

        public byte Issued { get; set; }

        public byte Approved { get; set; }
    }

    public class WOLaborers
    {
        public int LaborID { get; set; }

        public string WONo { get; set; }

        public string Name { get; set; }

        public string EmpCode { get; set; }

        public string Position { get; set; }

        public decimal Hour { get; set; }

        public long WOServiceID { get; set; }
    }

    public class WOInvoice
    {
        public int WOInvID { get; set; }

        public string WONo { get; set; }

        public string InvoiceNo { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public Nullable<DateTime> DateOpen { get; set; }

        public Nullable<DateTime> DateClosed { get; set; }

        public int PrintCount { get; set; }

        public Nullable<DateTime> DateModified { get; set; }

        public long PaymentTermId { get; set; }

        public string BankAccountCode { get; set; }
    }

    public class WrittenOff
    {
        public long WRID { get; set; }

        public string VIN { get; set; }

        public string WONo { get; set; }

        public string WOType { get; set; }

        public Nullable<DateTime> ReportDate { get; set; }

        public string DamageCause { get; set; }

        public string ReqRepairs { get; set; }

        public string LimitedTechIns { get; set; }

        public string DamInfo { get; set; }

        public decimal RecoveryCost { get; set; }

        public int Labor { get; set; }

        public decimal NoHour { get; set; }

        public decimal TotalAmount { get; set; }

        public string TotalAmountWords { get; set; }

        public string PrepBy { get; set; }

        public string Position { get; set; }

        public string SiteManager { get; set; }

        public string SiteLocation { get; set; }

        public string Preventive { get; set; }

        public Nullable<DateTime> LastUpdate { get; set; }

        public byte IsDirectWriteOff { get; set; }

        public string Status { get; set; }
    }
}
