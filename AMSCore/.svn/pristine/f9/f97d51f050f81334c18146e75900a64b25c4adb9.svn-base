using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendWOVehicleStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public string siteCode { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable wor_vehicle_info { get; set; }

        public SimpleModel list { get; set; }


        private sendWOVehicleStrategy _strategy;

        internal void setStrategy(sendWOVehicleStrategy sendWOVehicleStrategy)
        {
            this._strategy = sendWOVehicleStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }

    }
}
