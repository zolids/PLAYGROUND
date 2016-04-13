using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendToFeppStorage : GenericStorage
    {
        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable table { get; set; }

        public SimpleModel list { get; set; }

        private sendToFeppStrategy _strategy;

        internal void setStrategy(sendToFeppStrategy sendToFeppStrategy)
        {
            this._strategy = sendToFeppStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }


    }

}
