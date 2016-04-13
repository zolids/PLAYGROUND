using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendQuotationStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable quotation { get; set; }

        public DataTable quotationPart { get; set; }

        public DataTable quotationServices { get; set; }

        public SimpleModel list { get; set; }

        
        private sendQuotationStrategy _strategy;
        
        internal void setStrategy(sendQuotationStrategy sendQuotationStrategy)
        {
            this._strategy = sendQuotationStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }


    }
}
