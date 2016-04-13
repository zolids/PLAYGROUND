using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

/**
 * Centralize synchronizer request sender.
 * Dynamically Accept Object Storage Classes
 * @author JCabrito <Oct 27, 2015>
 * @return boolean
 * 
 */
namespace AMSCore
{
    public struct resData
    {
        public object reponseData { get; set; }

    }

    public class RestClientMessageSender
    {

        private RestClient client;
        private RestRequest request;

        public RestSharp.Method httpMethod(IDictionary<string, object> param)
        {

            RestSharp.Method method = 0;

            switch (param["httpMethod"].ToString())
            {
                case "POST":

                    method = Method.POST;
                    break;

                case "PUT":
                    method = Method.PUT;
                    break;

            }

            return method;

        }

        /// <summary>
        /// Send Request to API endpoint
        /// </summary>
        /// <typeparam name="storageClass">Dynamic class storage</typeparam>
        /// <param name="storage">Contains all the parameters needed in sending the request</param>
        /// <returns></returns>
        ///
        public object sendRequest<storageClass>(GenericStorage storage) where storageClass : class, new()
        {

            IDictionary<string, object> v = new Dictionary<string, object>();
            IRestResponse<List<Fleet>> fleetResponse;
 
            object response = null;
            
            try
            {

                storageClass sClass = new storageClass();

                foreach (var prop in storage.GetType().GetProperties())
                {

                    if (prop.GetValue(storage, null) != null)

                        v[prop.Name] = prop.GetValue(storage, null);

                }
                if (v.Count > 0)
                {

                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    client = new RestClient(storage.APIEndpoint);

                    client.Authenticator   = new SimpleAuthenticator("Username", Constant.api_username, "Password", Constant.api_password);
                    client.CookieContainer = new System.Net.CookieContainer();

                    request = new RestRequest(v["webUrl"].ToString(), httpMethod(v));

                    switch (request.Method.ToString())
                    {
                        case Constant.post:

                            request.RequestFormat = DataFormat.Json;
                            request.AddObject(v["list"]);
                            response = client.Execute(request);

                            break;

                        case Constant.get:

                            request.AddParameter(v["module"].ToString(), v["referenceId"].ToString());

                            switch (v["classDataSet"].ToString())
                            {
                                case "Fleet":

                                    fleetResponse = client.Execute<List<Fleet>>(request);
                                    response = fleetResponse.Data;

                                    break;

                                default:
                                    break;
                            }

                            break;
                    }

                }

            }
            catch (Exception e) { return response; }

            return response;

        }

    }

}
