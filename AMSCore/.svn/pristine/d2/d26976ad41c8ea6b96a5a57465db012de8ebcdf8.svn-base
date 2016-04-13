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
    public class odometerHistoryStrategy : odometerHistoryInterface
    {
        
        private RestClientMessageSender _messageSender;

        public bool processFleet(odometerHistoryStorage storage)
        {

            bool result = false;

            if ((storage.fleet_odomhistory = storage.getTable("SELECT * FROM fleet_odomhistory WHERE OHID = '" + storage.referenceId + "'")) != null)
            {

                FleetOdomHistory dataSet = Mapper.DynamicMap<IDataReader, List<FleetOdomHistory>>(storage.fleet_odomhistory.CreateDataReader()).First();

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Name = json;
                storage.list.Code = storage.code;
                storage.list.SiteCode = storage.siteCode;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<odometerHistoryStorage>(storage);

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
