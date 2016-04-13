using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/**
 *  AMSCore Synchronizer client class
 *  This class contains available POST request method
 *  @author Jcabrito <Oct. 27, 2015>
 *  @return boolean
 *  
 */
namespace AMSCore
{
    public class postMethodSync
    {

        private string api_endpoint     = string.Empty;
        private string connectionString = string.Empty;

        public postMethodSync(string connString = null, string endPoint = null)
        {
            this.connectionString = connString;
            this.api_endpoint     = endPoint;
        }

        public bool sendFleet(string NLID, string siteCode, bool failOver = true)
        {

            sendFleetStorage _storage   = new sendFleetStorage();
            
            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = NLID;
            _storage.siteCode           = siteCode;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.send_fleet;
            _storage.module             = Constant.send_fleet;
            _storage.webUrl             = Constant.fleet_update;

            _storage.setFleetStrategy(new sendFleetStrategy());

            return _storage.process();

        }

        public bool sendWorkRequest(string WRRefNo, string siteCode, bool failOver = true)
        {

            sendWorkRequestStorage _storage = new sendWorkRequestStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = WRRefNo;
            _storage.siteCode           = siteCode;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.send_work_order;
            _storage.module             = Constant.work_module;
            _storage.webUrl             = Constant.work_request;

            _storage.setFleetStrategy(new sendWorkRequestStrategy());

            return _storage.process();

        }

        public bool sendToFepp(string NLID, bool failOver = true)
        {

            sendToFeppStorage _storage = new sendToFeppStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = NLID;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.fepp_module;
            _storage.module             = Constant.fepp_module;
            _storage.webUrl             = Constant.fepp_uri;

            _storage.setStrategy(new sendToFeppStrategy());

            return _storage.process();

        }

        public bool sendInspection(string transactionNo, bool failOver = true)
        {

            sendInspectionStorage _storage = new sendInspectionStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = transactionNo;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.inspections;
            _storage.module             = Constant.inspections;
            _storage.webUrl             = Constant.inspectionUri;

            _storage.setStrategy(new sendInspectionStrategy());

            return _storage.process();

        }

        public bool sendQuotation(string quotationNo, bool failOver = true)
        {

            sendQuotationStorage _storage = new sendQuotationStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = quotationNo;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.quotation;
            _storage.module             = Constant.quotation;
            _storage.webUrl             = Constant.send_quotation;

            _storage.setStrategy(new sendQuotationStrategy());

            return _storage.process();

        }

        public bool sendWorkOrder(string WONo, bool failOver = true)
        {

            sendWorkOrderStorage _storage = new sendWorkOrderStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = WONo;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.work_order;
            _storage.module             = Constant.work_order;
            _storage.webUrl             = Constant.send_quotation;

            _storage.setStrategy(new workOrderStrategy());

            return _storage.process();

        }

        public bool sendWOInvoice(string transactionNo, bool failOver = true){

            sendWOInvoiceStorage _storage = new sendWOInvoiceStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = transactionNo;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.work_order;
            _storage.module             = Constant.WOInvoice;
            _storage.webUrl             = Constant.WOIvoice_uri;

            _storage.setStrategy(new sendWOInvoiceStrategy());

            return _storage.process();

        }

        public bool sendPersonnel(string transactionNO, bool failOver = true)
        {

            sendPersonnelStorage _storage = new sendPersonnelStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = transactionNO;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.personnel;
            _storage.module             = Constant.personnel;
            _storage.webUrl             = Constant.personnel_uri;

            _storage.setStrategy(new sendPersonnelStrategy());

            return _storage.process();

        }

        public bool sendRequest(string transactionNo, bool failOver = true)
        {

            sendRequestStorage _storage = new sendRequestStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = transactionNo;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.send_request;
            _storage.module             = Constant.send_request;
            _storage.webUrl             = Constant.sendRequest_uri;

            _storage.setStrategy(new sendRequestStrategy());

            return _storage.process();

        }

        public bool sendUtilization(string transactionNo, bool failOver = true)
        {

            sendUtilizationStorage _storage = new sendUtilizationStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = transactionNo;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.send_utility;
            _storage.module             = Constant.send_utility;
            _storage.webUrl             = Constant.utilization;

            _storage.setStrategy(new sendUtilizationStrategy());

            return _storage.process();

        }

        public bool sendCustomerSS(string transactionNo, bool failOver = true)
        {
            
            sendCutomerSSStorage _storage = new sendCutomerSSStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = transactionNo;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.customerSS;
            _storage.module             = Constant.customerSS;
            _storage.webUrl             = Constant.customerSS_uri;

            _storage.setStrategy(new sendCustomerStrategy());

            return _storage.process();

        }

        public bool sendWOVehicle(string VIN, bool failOver = true)
        {

            sendWOVehicleStorage _storage = new sendWOVehicleStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = VIN;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.send_utility;
            _storage.module             = Constant.WOVehicle;
            _storage.webUrl             = Constant.WOVehicle_uri;

            _storage.setStrategy(new sendWOVehicleStrategy());

            return _storage.process();

        }

        public bool sendFleetAuthorized(string VIN, bool failOver = true)
        {

            sendFleetAuthorizedStorage _storage = new  sendFleetAuthorizedStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = VIN;
            _storage.failOver           = failOver;
            _storage.fromFleetAutoCopy  = false;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.fleetAuthorized_code;
            _storage.module             = Constant.fleetAuthorized_module;
            _storage.webUrl             = Constant.fleetAuthorized_uri;

            _storage.setStrategy(new sendFleetAuthorizedStrategy());

            return _storage.process();

        }

        public bool sendDailyMEL(string siteCode, string date, string user)
        {

            dailyMelStorage _storage = new dailyMelStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.code               = date;
            _storage.user               = user;
            _storage.siteCode           = siteCode;
            _storage.httpMethod         = Constant.post;
            _storage.webUrl             = Constant.dailyMel_uri;

            _storage.setStrategy(new dailyMelStrategy());

            return _storage.process();

        }

        public bool sendVehicleReg(string VIN, bool failOver = true)
        {

            vehicleRegistrationStorage _storage = new vehicleRegistrationStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = VIN;
            _storage.failOver           = failOver;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.fleetAuthorized_code;
            _storage.module             = Constant.vehicle_registration;
            _storage.webUrl             = Constant.vehicleRegistration_uri;

            _storage.setStrategy(new vehicleRegistrationStrategy());

            return _storage.process();

        }

        public bool sendOdometerHistory(string odomID, string siteCode, bool failOver = true)
        {

            odometerHistoryStorage _storage = new odometerHistoryStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = odomID;
            _storage.failOver           = failOver;
            _storage.siteCode           = siteCode;
            _storage.httpMethod         = Constant.post;
            _storage.code               = Constant.odometer_code;
            _storage.module             = Constant.odometer_module;
            _storage.webUrl             = Constant.odometer_uri;

            _storage.setStrategy(new odometerHistoryStrategy());

            return _storage.process();

        }

    }

}
