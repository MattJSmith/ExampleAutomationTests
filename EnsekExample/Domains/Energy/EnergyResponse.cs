using EnsekExample.Tools.ApiFactory;
using Newtonsoft.Json;

namespace EnsekExample.Domains.Energy
{
    public class EnergyResponse
    {
        public Electric Electric { get; set; }
        public Gas Gas { get; set; }
        public Nuclear Nuclear { get; set; }
        public Oil Oil { get; set; }
    }

    public class Electric : IEnergyValues
    {
        [JsonProperty("energy_id")]
        public int EnergyId { get; set; }
        [JsonProperty("price_per_unit")]
        public decimal PricePerUnit { get; set; }
        [JsonProperty("quantity_of_units")]
        public int QuantityOfUnits { get; set; }
        [JsonProperty("unit_type")]
        public string UnitType { get; set; }
    }

    public class Gas : IEnergyValues
    {
        [JsonProperty("energy_id")]
        public int EnergyId { get; set; }
        [JsonProperty("price_per_unit")]
        public decimal PricePerUnit { get; set; }
        [JsonProperty("quantity_of_units")]
        public int QuantityOfUnits { get; set; }
        [JsonProperty("unit_type")]
        public string UnitType { get; set; }
    }

    public class Nuclear : IEnergyValues
    {
        [JsonProperty("energy_id")]
        public int EnergyId { get; set; }
        [JsonProperty("price_per_unit")]
        public decimal PricePerUnit { get; set; }
        [JsonProperty("quantity_of_units")]
        public int QuantityOfUnits { get; set; }
        [JsonProperty("unit_type")]
        public string UnitType { get; set; }
    }

    public class Oil : IEnergyValues
    {
        [JsonProperty("energy_id")]
        public int EnergyId { get; set; }
        [JsonProperty("price_per_unit")]
        public decimal PricePerUnit { get; set; }
        [JsonProperty("quantity_of_units")]
        public int QuantityOfUnits { get; set; }
        [JsonProperty("unit_type")]
        public string UnitType { get; set; }
    }

    public interface IEnergyValues
    {

        public int EnergyId { get; set; }


        public decimal PricePerUnit { get; set; }

        public int QuantityOfUnits { get; set; }


        public string UnitType { get; set; }
    }

}
