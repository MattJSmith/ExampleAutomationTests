using EnsekExample.Domains.Buying;
using EnsekExample.Domains.Energy;
using EnsekExample.Domains.TestReset;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekExample.Test_Features.Orders
{
    internal class OrderTests
    {

        //Each test should be independant of each other, So Instead of Verifying data from a previous test (created a reliance/ specific order to run tests)
        //This test remakes all the same orders to be independant and still meet the criteria you asked for
        [Test(Description = "Verify Orders are returned as expected")]
        public async Task VerifyOrdersTest()
        {

            var gas = await new BuyHelper().BuyEnergy((int)Fuel.gas, 1);
            //skip nuclear as has no data
            var electric = await new BuyHelper().BuyEnergy((int)Fuel.electric, 2);
            var oil = await new BuyHelper().BuyEnergy((int)Fuel.oil, 3);

            var gasOrderId = GetOrderIdFromMessage(gas.message);
            var electricOrderId = GetOrderIdFromMessage(electric.message);
            var oilOrderId = GetOrderIdFromMessage(oil.message);

            var orders = await new OrderHelper().GetOrders();

            var gasOrderFound = orders.Any(o => o.id == gasOrderId);
            var electricOrderFound = orders.Any(o => o.id == electricOrderId);
            var oilOrderFound = orders.Any(o => o.id == oilOrderId);

            Assert.True(gasOrderFound, "The gas orders id wasn't found in the list of orders");
            Assert.True(electricOrderFound, "The electric orders id wasn't found in the list of orders");
            Assert.True(oilOrderFound, "The oil orders id wasn't found in the list of orders");

        }

        //Each test should be independant of each other, So Instead of Verifying data from a previous test (created a reliance/ specific order to run tests)
        //This test remakes all the same orders to be independant and still meet the criteria you asked for
        [Test(Description = "Verify Orders are returned as expected")]
        public async Task VerifyNumberOfOrdersBeforeCurrentDate()
        {
            var orders = await new OrderHelper().GetOrders();

            var ordersOlderThanTodaysDate = orders.Count(o => DateTime.Parse(o.time) < DateTime.Now);

            Console.WriteLine($"There are {ordersOlderThanTodaysDate} Orders older than the current date");
        }

        [Test(Description = "Verify A Gas order can be read")]
        public async Task VerifyGasOrderIsReadable()
        {
            var gas = await new BuyHelper().BuyEnergy((int)Fuel.gas, 1);

            var gasOrderId = GetOrderIdFromMessage(gas.message);

            var gasOrder = await new OrderHelper().GetOrder(gasOrderId);

            Assert.That(gasOrder.fuel,Is.EqualTo(gasOrderId), "The gas orders did not match");
        }

        [Test(Description = "Delete an electric order")]
        public async Task DeleteElectricOrder()
        {
            var electric = await new BuyHelper().BuyEnergy((int)Fuel.electric, 1);

            var electricOrderId = GetOrderIdFromMessage(electric.message);

            var deleteStatus = await new OrderHelper().DeleteOrder(electricOrderId);

            Assert.That((int)deleteStatus, Is.EqualTo(200), "Delete api call returned a non successful status code");

            var allOrders = await new OrderHelper().GetOrders();

            var electricOrderFound = allOrders.Any(o => o.id == electricOrderId);

            Assert.False(electricOrderFound, "Electric order still visible after it was deleted.");
        }

        private string GetOrderIdFromMessage(string wholeMessage)
        {
            return wholeMessage.ToString().Split("id is ").Last().Replace(".", "");
        }
    }
}
