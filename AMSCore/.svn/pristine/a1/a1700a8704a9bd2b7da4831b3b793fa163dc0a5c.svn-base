using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RestSharp;

namespace AMSCore
{
    class sendCustomerStrategy : sendCustomerInterface
    {
        
        private RestClientMessageSender _messageSender;

        public bool processFleet(sendCutomerSSStorage storage)
        {

            bool result = false;

            if ((storage.customer_ss = storage.getTable("SELECT * FROM customer_ss WHERE SurveyCode = '" + storage.referenceId + "'")) != null)
            {

                CustomerSS dataSet = Mapper.DynamicMap<IDataReader, List<CustomerSS>>(storage.customer_ss.CreateDataReader()).First();

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendCutomerSSStorage>(storage);

                if (response.Content != string.Empty)

                    result = ((response.Content == "true") ? true : false);

                /**
                 * Insert / Queue value to tmp_update table to process by auto snyc when request failed
                 */
                if (!result && storage.failOver)
                {
                    storage.queueFailedRequest(storage.module.ToString(), storage.referenceId.ToString());
                }

            }

            return result;

        }
    }
}
