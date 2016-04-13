using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using AutoMapper;
using RestSharp;

/**
 *  Send object/ json request to portal or webservices
 *  Start Syncing inventory
 */
namespace AMSCore
{
    public class sendFleetStrategy : fleetInterface
    {

        private RestClientMessageSender _messageSender;

        public bool processFleet(sendFleetStorage storage)
        {

            bool result = false;

            if ((storage.table = storage.getTable(" SELECT * FROM fleet WHERE NLID = '" + storage.referenceId + "' ")) != null)
            {

                Fleet dataSet = Mapper.DynamicMap<IDataReader, List<Fleet>>(storage.table.CreateDataReader()).First();

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.SiteCode = storage.siteCode;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendFleetStorage>(storage);

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
