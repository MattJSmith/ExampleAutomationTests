using EnsekExample.Domains.Orders;
using EnsekExample.Tools.ApiFactory;

namespace EnsekExample.Domains.TestReset
{
    /// <summary>
    /// Helper methods for Reset api calls.
    /// </summary>
    internal class OrderHelper //Future Could make public/ We could seperate the entire domain folder structure into a new project that other teams can use.
    {
        private readonly ApiHelper apiHelper;

        internal OrderHelper()
        {
            apiHelper = new ApiHelper();
        }

        internal async Task<List<OrderResponse>> GetOrders()
        {
            return (await apiHelper.SendGetRequest<List<OrderResponse>>("orders")).content;
        }

        internal async Task<OrderResponse> GetOrder(string orderId)
        {
            var apiCall = $"orders/{orderId}";

            return (await apiHelper.SendGetRequest<OrderResponse>(apiCall)).content;
        }

        internal async Task<int> DeleteOrder(string orderId)
        {
            var apiCall = $"orders/{orderId}";

            return (await apiHelper.SendDeleteRequest<OrderResponse>(apiCall)).status;
        }
    }
}
