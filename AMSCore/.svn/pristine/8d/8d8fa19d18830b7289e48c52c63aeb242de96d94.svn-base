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
    public class sendRequestStrategy : sendRequestInterface
    {
        private RestClientMessageSender _messageSender;

        public bool processFleet(sendRequestStorage storage)
        {

            bool result = false;

            if ((storage.req_request = storage.getTable("SELECT * FROM req_request WHERE TransactNo = '" + storage.referenceId + "'")) != null)
            {

                Request dataSet = Mapper.DynamicMap<IDataReader, List<Request>>(storage.req_request.CreateDataReader()).First();

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendRequestStorage>(storage);

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
