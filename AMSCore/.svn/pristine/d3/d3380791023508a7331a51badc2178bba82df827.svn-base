using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendFleetAuthorizedStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public string siteCode { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public bool fromFleetAutoCopy { get; set; }

        public DataTable fleet_authorized { get; set; }

        public SimpleModel list { get; set; }


        private sendFleetAuthorizedStrategy _strategy;

        internal void setStrategy(sendFleetAuthorizedStrategy sendFleetAuthorized)
        {
            this._strategy = sendFleetAuthorized;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }

    }
}
