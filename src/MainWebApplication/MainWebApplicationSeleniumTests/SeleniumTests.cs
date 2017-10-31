using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace MainWebApplicationSeleniumTests
{
    public class SeleniumTests
    {
        public TestContext TestContext { get; set; }
        protected string BaseUrl = "http://localhost:63643/";
        protected RemoteWebDriver Driver;

        [TestInitialize()]
        public void TestInitialize()
        {
            //Manage BaseUrl from TestContext.
            if (TestContext.Properties["BaseUrl"] != null)
            {
                //Set the BaseURL from a build
                BaseUrl = TestContext.Properties["BaseUrl"].ToString();
            }

            //Manage Browser from TestContext.
            var browser = TestContext.Properties["Browser"] != null ? TestContext.Properties["Browser"].ToString() : "PhantomJS";
            switch (browser)
            {
                case "Firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    Driver = new ChromeDriver();
                    break;
                case "IE":
                    Driver = new InternetExplorerDriver();
                    break;
                case "PhantomJS":
                    Driver = new PhantomJSDriver();
                    break;
                case "Edge":
                    Driver = new EdgeDriver();
                    break;
                default:
                    Driver = new PhantomJSDriver();
                    break;
            }
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            Driver.Quit();
        }
    }
}
