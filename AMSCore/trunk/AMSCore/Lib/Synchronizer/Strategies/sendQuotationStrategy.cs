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
    public class sendQuotationStrategy : quotationInterface
    {

        private RestClientMessageSender _messageSender;

        public bool processFleet(sendQuotationStorage storage)
        {
            
            bool result = false;

            if ((storage.quotation = storage.getTable("SELECT * FROM quotation WHERE quotationno = '" + storage.referenceId + "'")) != null)
            {

                storage.quotationPart     = storage.getTable("SELECT * FROM quotationparts WHERE quotationno = '" + storage.referenceId + "'");
                storage.quotationServices = storage.getTable("SELECT * FROM quotationservices WHERE quotationno = '" + storage.referenceId + "'");

                Quotation dataSet = Mapper.DynamicMap<IDataReader, List<Quotation>>(storage.quotation.CreateDataReader()).First();
                dataSet.Services  = AutoMapper.Mapper.DynamicMap<IDataReader, List<QuotationService>>(storage.quotationServices.CreateDataReader());
                dataSet.Parts     = AutoMapper.Mapper.DynamicMap<IDataReader, List<QuotationParts>>(storage.quotationPart.CreateDataReader());

                var json = JsonConvert.SerializeObject(dataSet);

                storage.list = new SimpleModel();
                storage.list.Code = storage.code;
                storage.list.Name = json;

                _messageSender = new RestClientMessageSender();
                var response = (RestResponseBase)_messageSender.sendRequest<sendQuotationStorage>(storage);

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
