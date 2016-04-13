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
    public class sendWOVehicleStrategy : sendWOVehicleInterface
    {
        
        private RestClientMessageSender _messageSender;

        public bool processFleet(sendWOVehicleStorage storage)
        {

            bool result = false;

            if ((storage.wor_vehicle_info = storage.getTable("SELECT * FROM wor_vehicle_info WHERE VIN = '" + storage.referenceId + "'")) != null)
            {

                WrittenOff dataSet = Mapper.DynamicMap<IDataReader, List<WrittenOff>>(storage.wor_vehicle_info.CreateDataReader()).First();

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendWOVehicleStorage>(storage);

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
