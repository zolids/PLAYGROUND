using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendInspectionStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }        

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable table { get; set; }

        public DataTable details_table { get; set; }

        public SimpleModel list { get; set; }

        private sendInspectionStrategy _strategy;

        internal void setStrategy(sendInspectionStrategy sendInspectionStrategy)
        {
            this._strategy = sendInspectionStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }
    }
}
