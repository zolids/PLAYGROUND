using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace AMSCore
{
    public class dailyMelStrategy : dailyMelInterface
    {

        private RestClientMessageSender _messageSender;

        public bool processFleet(dailyMelStorage storage)
        {

            bool result = false;

            storage.list = new SimpleModel();

            storage.list.Code = storage.date;
            storage.list.Name = storage.user;
            storage.list.SiteCode = storage.siteCode;

            if (string.IsNullOrEmpty(storage.list.Name.ToString()))
                return result;

            _messageSender = new RestClientMessageSender();
            var response = (RestResponseBase)_messageSender.sendRequest<dailyMelStorage>(storage);

            if (response.Content != string.Empty)

                result = ((response.Content == "true") ? true : false);

            return result;

        }

    }

}
