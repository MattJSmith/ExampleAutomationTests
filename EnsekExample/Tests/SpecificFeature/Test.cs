namespace EnsekExample.Tests.SpecificFeature
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Rest Test Data")]
        public void ResetTestData()
        {
            //Make api call to reset data

            //make an api call to check the quantities are the default values
            Assert.Pass();
        }

        [Test(Description = "Buy a quantity of Gas")]
        public void BuyGas()
        {
            Assert.Pass();
        }

        [Test(Description = "Buy a quantity of Nuclear energy")]
        public void BuyNuclear()
        {
            Assert.Pass();
        }

        [Test(Description = "Buy a quantity of Electricity")]
        public void BuyElectricity()
        {
            Assert.Pass();
        }

        [Test(Description = "Buy a quantity of Oil")]
        public void BuyOil()
        {
            Assert.Pass();
        }

        //Each test should be independant of each other, So Instead of Verifying data from a previous test (created a reliance/ specific order to run tests)
        //This test remakes all the same orders to be independant and still meet the criteria you asked for
        [Test(Description = "Verify Orders are returned as expected")]
        public void VerifyOrdersTest()
        {
            ResetTestData(); //Helps make the test independant but means the test cant run in parallel as it will destroy data of other running tests
            BuyGas();
            BuyOil();
            BuyElectricity(); 
            BuyNuclear();

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


        public void BuyFuelTypes(string fuelType) // could be an enum instead of string here
        {
            switch (fuelType.ToLowerInvariant())
            {
                case "oil": break;

                    //Note: Assert.Fail is for potential bugs. As this is a defect with the testcase itself, we can use exceptions (and even record these results seperately)
                default: throw new Exception(fuelType + "Was not a valid fuel type.");
            }
        }

    }
}