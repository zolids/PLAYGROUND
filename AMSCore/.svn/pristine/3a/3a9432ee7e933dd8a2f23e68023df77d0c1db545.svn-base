using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendCutomerSSStorage : GenericStorage
    {

        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public string siteCode { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable customer_ss { get; set; }

        public SimpleModel list { get; set; }

        private sendCustomerStrategy _strategy;

        internal void setStrategy(sendCustomerStrategy sendCutomerStrategy)
        {
            this._strategy = sendCutomerStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }

    }
}
