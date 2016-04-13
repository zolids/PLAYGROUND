using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class vehicleRegistrationStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable vehicle_registration { get; set; }

        public SimpleModel list { get; set; }

        private vehicleRegistrationStrategy _strategy;

        internal void setStrategy(vehicleRegistrationStrategy strategy)
        {
            this._strategy = strategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }
        
    }
}
