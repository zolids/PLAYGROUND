using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendWorkRequestStorage : GenericStorage
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

        private sendWorkRequestStrategy _sendWorkRequestStrategy;

        public void setFleetStrategy(sendWorkRequestStrategy strategy)
        {
            this._sendWorkRequestStrategy = strategy;
        }

        public bool process()
        {
            return this._sendWorkRequestStrategy.processFleet(this);
        }

    }
}
