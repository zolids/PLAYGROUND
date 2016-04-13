using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendPersonnelStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }        

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable customers_personnel { get; set; }

        public SimpleModel list { get; set; }

        private sendPersonnelStrategy _strategy;

        internal void setStrategy(sendPersonnelStrategy sendPersonnelStrategy)
        {
            this._strategy = sendPersonnelStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }
    }
}
