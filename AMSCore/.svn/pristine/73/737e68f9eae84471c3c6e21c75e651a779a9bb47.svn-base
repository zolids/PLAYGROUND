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
    public class sendToFeppStrategy : feppInterface
    {

        private RestClientMessageSender _messageSender;

        public bool processFleet(sendToFeppStorage storage)
        {

            bool result = false;

            if ((storage.table = storage.getTable("SELECT * FROM fepp WHERE NLID = '" + storage.referenceId + "'")) != null)
            {

                Fepp dataSet = Mapper.DynamicMap<IDataReader, List<Fepp>>(storage.table.CreateDataReader()).First();

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendToFeppStorage>(storage);

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
