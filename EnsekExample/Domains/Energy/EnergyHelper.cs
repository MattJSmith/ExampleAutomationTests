using EnsekExample.Tools.ApiFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekExample.Domains.Energy
{
    internal class EnergyHelper
    {
        private readonly ApiHelper apiHelper = new ApiHelper();
        private EnergyResponse CachedEnergyResponse = new EnergyResponse();

        internal async Task<IEnergyValues> GetEnergyInfo(string energyName)
        {
            if (CachedEnergyResponse == default(EnergyResponse))
            {
                var response = (await apiHelper.SendGetRequest<EnergyResponse?>("energy"));

                if (response.content == null) throw new Exception("No Energy Data returned");

                CachedEnergyResponse = response.content;
            }

            switch (energyName)
            {
                //Ideally the energy types would be an enum to make them more consistant/ less spelling errors etc
                case "electric": return CachedEnergyResponse.Electric;
                case "gas": return CachedEnergyResponse.Gas;
                case "nuclear": return CachedEnergyResponse.Nuclear;
                case "oil": return CachedEnergyResponse.Oil;
            }
            throw new Exception($"{energyName} is an invalid energy type or not currently supported in the test.");
        }

    }
}
