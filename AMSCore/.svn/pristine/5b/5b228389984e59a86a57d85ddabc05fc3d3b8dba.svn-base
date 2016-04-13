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
    public class sendWOInvoiceStrategy : sendWOInvoiceInterface
    {

        private RestClientMessageSender _messageSender;
    
        public bool processFleet(sendWOInvoiceStorage storage)
        {

            bool result = false;

            if ((storage.table = storage.getTable("SELECT * FROM workorderinvoices WHERE InvoiceNo = '" + storage.referenceId + "'")) != null)
            {

                WOInvoice dataSet = Mapper.DynamicMap<IDataReader, List<WOInvoice>>(storage.table.CreateDataReader()).First();

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendWOInvoiceStorage>(storage);

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
