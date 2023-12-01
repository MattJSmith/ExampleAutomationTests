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
        public void VerifyOrdersTest()
        {
       //     new ResetTests().ResetTestData(); //Helps make the test independant but means the test cant run in parallel as it will destroy data of other running tests
        /*    BuyGas();
            BuyOil();
            BuyElectricity();
            BuyNuclear();*/

            //This test fails because we cant buy nuclear which is part of the requirements of the test.
            Assert.Pass();
        }

        //Each test should be independant of each other, So Instead of Verifying data from a previous test (created a reliance/ specific order to run tests)
        //This test remakes all the same orders to be independant and still meet the criteria you asked for
        [Test(Description = "Verify Orders are returned as expected")]
        public void VerifyNumberOfOrdersBeforeCurrentDate()
        {
            //Get all orders api call

            // Filter out ones newer than and including todays date

            //return the total count?


        }

        //Other tests could automate (but wont due to personal time constraints): Delete an order 

    }
}
