using EnsekExample.Domains.TestReset;

namespace EnsekExample.Tests.SpecificFeature
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Reset Test Data")]
        public async Task ResetTestData()
        {
            var resetDataResponse = await new ResetHelper().ResetData();
            //Make api call to reset data

            //make an api call to check the quantities are the default values
            
            Assert.Pass();
        }


    }
}