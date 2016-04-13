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
    public class sendFleetAuthorizedStrategy : sendFleetAuthorizedInterface
    {
        
        private RestClientMessageSender _messageSender;

        public bool processFleet(sendFleetAuthorizedStorage storage)
        {
            
            bool result = false;

            string VIN   = storage.referenceId;
            string[] vin = VIN.Split('|');

            storage.referenceId = (vin.Length > 1) ? vin[1] : storage.referenceId;

            if ((storage.fleet_authorized = storage.getTable("SELECT * FROM fleet_authorized WHERE VIN = '" + storage.referenceId + "'")) == null)

                if ((storage.fleet_authorized = storage.getTable("SELECT * FROM fleet_authorized_transferred WHERE VIN = '" + storage.referenceId + "'")) != null)

                    storage.fromFleetAutoCopy = true;
            
            if (storage.fleet_authorized != null)
            {

                FleetAutho dataSet = Mapper.DynamicMap<IDataReader, List<FleetAutho>>(storage.fleet_authorized.CreateDataReader()).First();

                if (vin.Length > 1) dataSet.VIN = VIN;

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendFleetAuthorizedStorage>(storage);

                if (response.Content != string.Empty)
                {
                    result = ((response.Content == "true") ? true : false);

                    if (result && storage.fromFleetAutoCopy)

                        storage.executeQuery("DELETE FROM fleet_authorized_transferred WHERE VIN = '" + storage.referenceId + "'");

                }

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
