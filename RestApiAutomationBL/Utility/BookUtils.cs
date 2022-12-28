using Newtonsoft.Json;
using RestApiAutomationBL.Models;
using RestApiAutomationFramework.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestApiAutomationBL.Models.Requests;
using RestApiAutomationBL.Models.Responses;
using RestApiAutomationBL.RequestBody;

namespace RestApiAutomationBL.Utility
{
    public class BookUtils
    {
        public static ValidRequestModel Create(int id, string title, string author)
        {
            return RestClientUtil.ExecuteHttpMethods<ValidRequestModel>("books",DataFormat.Json,Method.Post, RequestBody.RequestBody.CreateRequestBody(id, title, author));
           
        }

        public static bool Delete(int id)
        {
            bool result= RestClientUtil.Delete("books\\"+id.ToString(), DataFormat.Json, HttpStatusCode.OK);

            return result;
        }

        public static ValidResponseModel Get(int id)
        {
            return RestClientUtil.ExecuteHttpMethods<ValidResponseModel>("books\\"+id.ToString(), DataFormat.Json,Method.Get);

        }

        public static ValidRequestModel Put(int id, string title, string author)
        {
            return RestClientUtil.ExecuteHttpMethods<ValidRequestModel>("books\\"+id.ToString(), DataFormat.Json,Method.Put,RequestBody.RequestBody.CreateRequestBody(id, title, author));
        }

        public static ValidRequestModel Patch(int id, string title=null, string author=null)
        {
            var getPost= RestClientUtil.ExecuteHttpMethods<ValidRequestModel>("books\\" + id.ToString(), DataFormat.Json,Method.Get);
            return RestClientUtil.ExecuteHttpMethods<ValidRequestModel>("books\\" + id.ToString(), DataFormat.Json, Method.Patch, RequestBody.RequestBody.ModifyRequestBody(id, title, author, getPost));
        }

        

        

    }
}
