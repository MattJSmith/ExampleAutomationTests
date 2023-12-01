using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnsekExample.Domains.Energy;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace EnsekExample.Tools.ApiFactory
{
    internal class ApiHelper
    {
        const string baseUrl = "https://qacandidatetest.ensek.io/ENSEK/"; //Future: Can make this configurable. E.G. set this in appsettings.json.

        /// <summary>
        /// Send a HTTP Get Request. Returns data in the format of your choosing
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apiCallName"></param>
        /// <returns>Nullable Generic</returns>
        public async Task<(U? content, int status)> SendGetRequest<U>(string apiCallName)
        {
            return await ApiRequest<object, U?>(apiCallName, Method.Get, null);

        }

        /// <summary>
        /// Send a HTTP Post Request. Returns data in the format of your choosing
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apiCallName"></param>
        /// <returns>Nullable Generic</returns>
        public async Task<(U? content, int status)> SendPostRequest<U>(string apiCallName)
        {
            return await ApiRequest<object, U?>(apiCallName, Method.Post, default); //Default here would be a null (empty) body
        }

        /// <summary>
        /// Send a HTTP Post Request. Returns data in the format of your choosing
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apiCallName"></param>
        /// <returns>Nullable Generic</returns>
        public async Task<(U? content, int status)> SendPostRequest<T, U>(string apiCallName, T requestBody)
        {
            return await ApiRequest<T, U?>(apiCallName, Method.Post, requestBody);
        }

        /// <summary>
        /// Send a HTTP Post Request. Returns data in the format of your choosing
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apiCallName"></param>
        /// <returns>Nullable Generic</returns>
        public async Task<(U? content, int status)> SendPutRequest<U>(string apiCallName)
        {
            return await ApiRequest<object,U?>(apiCallName, Method.Put, default);
        }

        /// <summary>
        /// Send a HTTP Post Request. Returns data in the format of your choosing
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apiCallName"></param>
        /// <returns>Nullable Generic</returns>
        public async Task<(U? content, int status)> SendPutRequest<T, U>(string apiCallName, T requestBody)
        {
            return await ApiRequest<T, U?>(apiCallName, Method.Put, requestBody);
        }

        /// <summary>
        /// Send a HTTP Post Request. Returns data in the format of your choosing
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="apiCallName"></param>
        /// <returns>Nullable Generic</returns>
        public async Task<(U? content, int status)> SendDeleteRequest<T, U>(string apiCallName, T requestBody)
        {
            return await ApiRequest<T, U?>(apiCallName, Method.Delete, requestBody);
        }

        //Private Method to send any kind of http request using RestClient.
        //This library will make it easier for less experienced programmers to understand
        //but the downside microsoft http library is more secure due to it being inbuilt already and not third party.
        private async Task<(U? content, int status)> ApiRequest<T, U>(string apiCallName, Method method, T? requestBody)  where U: notnull
        {
            var options = new RestClientOptions("https://local.xyz")
            {
                MaxTimeout = -1,
                ThrowOnAnyError = true,
                BaseUrl = new Uri(baseUrl)
            };

            var client = new RestClient(options);

            var request = new RestRequest(apiCallName, method);

            if (requestBody != null) request.AddBody(requestBody, ContentType.Json);

            //Future: Can use cancellation tokens to have control over timeouts

            var response = await client.ExecuteAsync<U>(request);

            var content = JsonConvert.DeserializeObject<U>(response.Content);

            return (content, (int)response.StatusCode);
        }
    }

}
