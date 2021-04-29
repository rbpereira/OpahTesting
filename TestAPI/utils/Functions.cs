using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAPI.utils
{
    class Functions
    {
        public static IRestResponse SendApi(string url, string metodo)
        {
            var client = new RestClient(url);
            client.Timeout = -1;

            Method verbo;

            if (metodo.ToUpper().Equals("POST"))
            {
                verbo = Method.POST;
            }
            else
            {
                verbo = Method.GET;
            }

            var request = new RestRequest(verbo);
            //request.AddHeader("Cookie", "__cfduid=db46eefd6b84e474f9d06eeaa9aa862861619673359");
            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
