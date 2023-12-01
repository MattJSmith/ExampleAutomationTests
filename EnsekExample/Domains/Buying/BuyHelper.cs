using EnsekExample.Tools.ApiFactory;


namespace EnsekExample.Domains.Buying
{
    internal class BuyHelper
    {
        private readonly ApiHelper apiHelper = new ApiHelper();


        internal async Task<BuyResponse> BuyEnergy(int energyId, int quantity)
        {

            var apiCall = $"buy/{energyId}/{quantity}";

            var response = await apiHelper.SendPutRequest<BuyResponse>(apiCall);

            if(response.status != 200) throw new Exception($"Buy Energy api call was unsuccessful with code: {response.status}");
            if (response.content == null) throw new Exception("No Response returned for buy energy api call");

            return response.content;
        }
    }
}
