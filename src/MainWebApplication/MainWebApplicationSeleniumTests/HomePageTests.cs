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
            Assert.IsFalse(string.IsNullOrEmpty(Driver.Title));
            Assert.IsTrue(Driver.Title.Equals("Home Page - MainWebApplication"));
            Assert.IsFalse(string.IsNullOrEmpty(Driver.Url));
            Assert.IsTrue(Driver.Url == homepageUrl);
        }
    }
}
