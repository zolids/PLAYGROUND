using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace AMSCore
{
    public class getFleetStrategy : getFleetInterface
    {

        private RestClientMessageSender _messageSender;
        private List<Fleet> _updates;

        public bool processFleet(getFleetStorage storage)
        {

            bool result = false;

            _messageSender = new RestClientMessageSender();

            var response = _messageSender.sendRequest<getFleetStorage>(storage);

            _updates = (List<Fleet>)response;
            

            
            return result;

        }
    }
}
