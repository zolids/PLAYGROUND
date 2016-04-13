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
    public class sendUtilizationStrategy : utilizationInterface
    {
        
        private RestClientMessageSender _messageSender;

        public bool processFleet(sendUtilizationStorage storage)
        {

            bool result = false;

            if ((storage.req_utilize_form = storage.getTable("SELECT * FROM req_utilize_form WHERE TransactNo = '" + storage.referenceId + "'")) != null)
            {

                storage.req_utilize_destination = storage.getTable("SELECT * FROM req_utilize_destination WHERE TransactNo = '" + storage.referenceId + "'");
                storage.req_utilize_action      = storage.getTable("SELECT * FROM req_utilize_action WHERE TransactNo = '" + storage.referenceId + "'");

                RequestUtilizeForm dataSet = Mapper.DynamicMap<IDataReader, List<RequestUtilizeForm>>(storage.req_utilize_form.CreateDataReader()).First();
                dataSet.Action             = AutoMapper.Mapper.DynamicMap<IDataReader, List<RequestUtilizeAction>>(storage.req_utilize_action.CreateDataReader());
                dataSet.Destination        = AutoMapper.Mapper.DynamicMap<IDataReader, List<RequestUtilizeDestination>>(storage.req_utilize_destination.CreateDataReader());

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendUtilizationStorage>(storage);

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
