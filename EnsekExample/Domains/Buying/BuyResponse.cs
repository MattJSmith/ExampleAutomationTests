using EnsekExample.Tools.ApiFactory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekExample.Domains.Buying
{
    public class BuyResponse
    {
        [JsonProperty("message")]
        public string message;
    }
}
