using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMSCore
{
    public class dailyMelStorage : GenericStorage
    {

        public string code { get; set; }

        public string date { get; set; }

        public string user { get; set; }

        public string webUrl { get; set; }

        public string siteCode { get; set; }

        public SimpleModel list { get; set; }


        private dailyMelStrategy _strategy;

        internal void setStrategy(dailyMelStrategy dailyMelStorage)
        {
            this._strategy = dailyMelStorage;
        }

        internal bool process()
        {
            return this._strategy.processFleet(this);
        }

    }

}
