using EnsekExample.Domains.Buying;
using EnsekExample.Domains.Energy;

namespace EnsekExample.Test_Features.Orders
{
    internal class BuyFuelTests
    {
        [Test(Description = "Buy a quantity of Gas")]
        public async Task BuyGas()
        {
            var gasInfo = await new EnergyHelper().GetEnergyInfo("gas");

            var quantityToPurchase = 10;

            var buyResponse = await new BuyHelper().BuyEnergy(gasInfo.EnergyId, quantityToPurchase);

            VerifyFuelResponse(gasInfo, buyResponse, quantityToPurchase);

        }

        [Test(Description = "Buy a quantity of Nuclear energy")]
        public async Task BuyNuclear()
        {
            var nuclearInfo = await new EnergyHelper().GetEnergyInfo("nuclear");

            var quantityToPurchase = 10;

            var buyResponse = await new BuyHelper().BuyEnergy(nuclearInfo.EnergyId, quantityToPurchase);

            VerifyFuelResponse(nuclearInfo, buyResponse, quantityToPurchase);
        }

        [Test(Description = "Buy a quantity of Electricity")]
        public async Task BuyElectricity()
        {
            var electricInfo = await new EnergyHelper().GetEnergyInfo("electric");

            var quantityToPurchase = 10;

            var buyResponse = await new BuyHelper().BuyEnergy(electricInfo.EnergyId, quantityToPurchase);

            VerifyFuelResponse(electricInfo, buyResponse, quantityToPurchase);
        }

        [Test(Description = "Buy a quantity of Oil")]
        public async Task BuyOil()
        {
            var oilId = await new EnergyHelper().GetEnergyInfo("oil");

            var quantityToPurchase = 10;

            var buyResponse = await new BuyHelper().BuyEnergy(oilId.EnergyId, quantityToPurchase);

            VerifyFuelResponse(oilId, buyResponse, quantityToPurchase);
        }


        public void VerifyFuelResponse(IEnergyValues startEnergyValue, BuyResponse buyResponse, int quantityPurchased)
        {

            //the data in the response is all within a single string without any seperation identifiers. This should be split into seperate fields.
            //As I'm on a time constraint, I'm only going to use a contains to check if the correct data is in the string, rather than interpolate it
            var gasQuantityRemaining = startEnergyValue.QuantityOfUnits - quantityPurchased;

            Assert.That(buyResponse.message, Does.Contain(gasQuantityRemaining.ToString()), "Buy api call did not return the correct remaining quantity");

            var totalCost = startEnergyValue.PricePerUnit * quantityPurchased;

            Assert.That(buyResponse.message, Does.Contain(totalCost.ToString()), "Buy api call did not return correct total cost");
        }
    }
}
