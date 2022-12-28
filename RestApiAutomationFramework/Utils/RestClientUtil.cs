using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Configuration;
using System.Net;

namespace RestApiAutomationFramework.Utils
{
    public class RestClientUtil
    {
        static RestRequest restRequest;
        static RestClient restClient;

        public static RestClient RestClient 
        { 
            get
            {
                if(restClient==null)
                {
                    return new RestClient(ConfigurationManager.AppSettings["BaseUrl"].ToString());
                }
                else
                {
                    return restClient;
                }
            } 
        }

        public static RestRequest CreateRequest(string resource,Method method ,DataFormat dataFormat)
        {
            if (restRequest == null)
            {
                return new RestRequest(resource,method);
            }
            else
            {
                return restRequest;
            }
        }


        public static T ExecuteHttpMethods<T>(string resource, DataFormat dataFormat,Method method, string payload="")
        {
            return JsonConvert.DeserializeObject<T>(RestClient.Execute(CreateRequest(resource, method, dataFormat).AddBody(payload)).Content);
        }

        

        public static bool Delete(string resource, DataFormat dataFormat, HttpStatusCode statusCode)
        {

            return RestClient.Execute(CreateRequest(resource, Method.Delete, dataFormat)).StatusCode.Equals(statusCode);
        }

        
    }
}
