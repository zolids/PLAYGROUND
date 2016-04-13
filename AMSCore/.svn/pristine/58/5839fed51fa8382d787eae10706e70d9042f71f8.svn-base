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
    public class workOrderStrategy : workOrderInterface
    {

        private RestClientMessageSender _messageSender;

        public bool processFleet(sendWorkOrderStorage storage)
        {

            bool result = false;

            if ((storage.workorder = storage.getTable("SELECT * FROM workorder WHERE WONo = '" + storage.referenceId + "'")) != null)
            {

                storage.workorderparts      = storage.getTable("SELECT * FROM workorderparts WHERE WONo = '" + storage.referenceId + "'");
                storage.workorderservices   = storage.getTable("SELECT * FROM workorderservices WHERE WONo = '" + storage.referenceId + "'");
                storage.wo_laborers         = storage.getTable("SELECT * FROM wo_laborers WHERE WONo = '" + storage.referenceId + "'");

                WorkOrder dataSet   = Mapper.DynamicMap<IDataReader, List<WorkOrder>>(storage.workorder.CreateDataReader()).First();
                dataSet.Services    = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderServices>>(storage.workorderparts.CreateDataReader());
                dataSet.Parts       = AutoMapper.Mapper.DynamicMap<IDataReader, List<WorkOrderParts>>(storage.workorderservices.CreateDataReader());
                dataSet.Laborers    = AutoMapper.Mapper.DynamicMap<IDataReader, List<WOLaborers>>(storage.wo_laborers.CreateDataReader());

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendWorkOrderStorage>(storage);

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
