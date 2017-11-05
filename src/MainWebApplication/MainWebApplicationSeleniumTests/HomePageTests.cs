using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MainWebApplicationSeleniumTests
{
    [TestClass]
    public class HomePageTests : SeleniumTests
    {
        [TestMethod]
        [TestCategory("SeleniumTests")]
        public void Load_Homepage_And_Validate_PageTitle()
        {
            //Arrange
            var homepageUrl = BaseUrl;

            //Act
            Driver.Navigate().GoToUrl(homepageUrl);

            //Assert
            Assert.AreEqual("Home Page - MainWebApplication", Driver.Title);
            Assert.AreEqual(homepageUrl, Driver.Url);
        }
    }
}
