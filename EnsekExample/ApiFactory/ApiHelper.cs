using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace EnsekExample.ApiFactory
{
    internal class ApiHelper
    {
        const string baseUrl = "https://api.twitter.com/1.1"; //This would be passed in through appsettings/ be configurable if neccessary


        public async Task<U?> SendGetRequest<U>(string apiCallName)
        {
            return await ApiRequest<object,U>(apiCallName, Method.Get, null);
         
        }

        public async Task<U?> SendPostRequest<T,U>(string apiCallName, T requestBody)
        {
            return await ApiRequest<T, U>(apiCallName, Method.Post, requestBody);
        }
        public async Task<U?> SendPutRequest<T, U>(string apiCallName, T requestBody)
        {
            return await ApiRequest<T, U>(apiCallName, Method.Put, requestBody);
        }
        public async Task<U?> SendDeleteRequest<T, U>(string apiCallName, T requestBody)
        {
            return await ApiRequest<T, U>(apiCallName, Method.Delete, requestBody);
        }

        private async Task<U?> ApiRequest<T,U>(string apiCallName,Method method, T? requestBody)
            {
    
                var client = new RestClient();
                var request = new RestRequest(apiCallName, method);
                if(requestBody != null) request.AddBody(requestBody,ContentType.Json);

                //Could use cancellation tokens to control timeouts
                return await client.GetAsync<U>(request);
                    
            }
            }
      
}
