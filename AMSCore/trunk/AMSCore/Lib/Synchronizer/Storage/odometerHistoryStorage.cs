using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class odometerHistoryStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public string siteCode { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable fleet_odomhistory { get; set; }

        public SimpleModel list { get; set; }


        private odometerHistoryStrategy _strategy;

        internal void setStrategy(odometerHistoryStrategy odometerHistory)
        {
            this._strategy = odometerHistory;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }

    }
}
