using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class getFleetStorage : GenericStorage
    {
       
        public string webUrl { get; set; }

        public string referenceId { get; set; }

        public string classDataSet { get; set; }

        public string module { get; set; }

        public DataTable _table { get; set; }

        private getFleetStrategy _strategy;

        internal void setStrategy(getFleetStrategy getFleetStrategy)
        {
            this._strategy = getFleetStrategy;   
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }

    }
}
