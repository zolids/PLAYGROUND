using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 *  AMSCore Synchronizer client class
 *  This class contains available GET request method
 *  @author Jcabrito <Oct. 27, 2015>
 *  @return boolean
 *  
 */
namespace AMSCore
{
    public class getMethodSync
    {
        
        private string api_endpoint = string.Empty;
        private string connectionString = string.Empty;

        public getMethodSync(string connString = null, string endPoint = null)
        {
            this.connectionString = connString;
            this.api_endpoint     = endPoint;
        }

        public bool getFleet(string siteCode)
        {

            getFleetStorage _storage  = new getFleetStorage();

            _storage.connectionString   = this.connectionString;
            _storage.APIEndpoint        = this.api_endpoint;

            _storage.referenceId        = siteCode;
            _storage.httpMethod         = Constant.get;
            _storage.module             = Constant.site_code;
            _storage.webUrl             = Constant.fleet_update;
            _storage.classDataSet       = Constant.send_fleet;

            _storage.setStrategy(new getFleetStrategy());

            return _storage.process();
            
        }

    }
}
