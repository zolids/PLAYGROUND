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
    public class sendInspectionStrategy : inspectionInterface
    {
        
        private RestClientMessageSender _messageSender;

        public bool processFleet(sendInspectionStorage storage)
        {

            bool result = false;

            if ((storage.table = storage.getTable("SELECT * FROM vehicle_inspection WHERE RefNo = '" + storage.referenceId + "'")) != null)
            {
                storage.details_table = storage.getTable("SELECT * FROM vehicle_inspection_details WHERE RefNo = '" + storage.referenceId + "'");

                Inspection dataSet = Mapper.DynamicMap<IDataReader, List<Inspection>>(storage.table.CreateDataReader()).First();
                dataSet.Details = AutoMapper.Mapper.DynamicMap<IDataReader, List<InspectionDetails>>(storage.details_table.CreateDataReader());

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendInspectionStorage>(storage);

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
