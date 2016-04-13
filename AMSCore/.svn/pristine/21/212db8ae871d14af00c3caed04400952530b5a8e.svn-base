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
    public class vehicleRegistrationStrategy : vehicleRegistrationInterface
    {
        
        private RestClientMessageSender _messageSender;

        public bool processFleet(vehicleRegistrationStorage storage)
        {

            bool result = false;

            string VIN = storage.referenceId;
            string[] vin = VIN.Split('|');

            storage.referenceId = (vin.Length > 1) ? vin[1] : storage.referenceId;

            if ((storage.vehicle_registration = storage.getTable("SELECT * FROM vehicle_registration WHERE VIN = '" + storage.referenceId + "'")) != null)
            {

                VehicleRegistration dataSet = Mapper.DynamicMap<IDataReader, List<VehicleRegistration>>(storage.vehicle_registration.CreateDataReader()).First();

                if (vin.Length > 1) dataSet.VIN = VIN;

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<vehicleRegistrationStorage>(storage);

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
