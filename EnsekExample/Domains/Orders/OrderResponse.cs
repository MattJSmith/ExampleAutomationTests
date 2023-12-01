
namespace EnsekExample.Domains.Orders
{
    public class OrderResponse
    {
        public string id { get; set; }
        public string fuel { get; set; }
        public int quantity { get; set; }

        public string time { get; set; }
        public string message { get; set; }
    }
}
