using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class sendUtilizationStorage : GenericStorage
    {

        public string sql { get; set; }

        public string code { get; set; }

        public string webUrl { get; set; }

        public string module { get; set; }

        public bool failOver { get; set; }

        public string referenceId { get; set; }

        public DataTable req_utilize_form { get; set; }

        public DataTable req_utilize_destination { get; set; }

        public DataTable req_utilize_action { get; set; }

        public SimpleModel list { get; set; }


        private sendUtilizationStrategy _strategy;

        internal void setStrategy(sendUtilizationStrategy sendUtilizationStrategy)
        {
            this._strategy = sendUtilizationStrategy;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }


    }
}
