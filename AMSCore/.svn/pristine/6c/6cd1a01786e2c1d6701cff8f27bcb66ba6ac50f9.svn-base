using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendWorkOrderStorage : GenericStorage
    {

        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public string siteCode { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable workorder { get; set; }

        public DataTable workorderparts { get; set; }

        public DataTable workorderservices { get; set; }

        public DataTable wo_laborers { get; set; }

        public SimpleModel list { get; set; }

        private workOrderStrategy _strategy;

        internal void setStrategy(workOrderStrategy workOrderStrategy)
        {
            this._strategy = workOrderStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }

    }
}
