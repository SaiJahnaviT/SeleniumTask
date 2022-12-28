using Newtonsoft.Json;
using RestApiAutomationBL.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiAutomationBL.RequestBody
{
    public class RequestBody
    {
        public static string ModifyRequestBody(int id, string title, string author, ValidRequestModel request)
        {
            if (title != null)
            {
                request.title = title;
            }
            if (author != null)
            {
                request.author = author;
            }
            return JsonConvert.SerializeObject(request);
        }

        public static string CreateRequestBody(int id, string title, string author)
        {
            ValidRequestModel request = new ValidRequestModel();
            request.id = id;
            request.title = title;
            request.author = author;

            return JsonConvert.SerializeObject(request);
        }
    }
}
