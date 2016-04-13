using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendFleetStorage : GenericStorage
    {

        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public string siteCode { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable table { get; set; }

        public SimpleModel list { get; set; }


        private sendFleetStrategy _sendFleetStrategy;

        public void setFleetStrategy(sendFleetStrategy strategy)
        {
            this._sendFleetStrategy = strategy;
        }

        public bool process()
        {
            return this._sendFleetStrategy.processFleet(this);
        }

    }

}
