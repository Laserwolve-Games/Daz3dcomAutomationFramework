using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Daz3dcomFramework
{
    public class Tests
    {
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://www.daz3d.com/shop/";

            IWebElement myAccountIcon = driver.FindElement(By.XPath("//i[@class='fd fd-my-account']"));

            myAccountIcon.Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}