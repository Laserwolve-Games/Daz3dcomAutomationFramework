using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Daz3dcomFramework
{
    public class Actions
    {
        readonly IWebDriver driver = new EdgeDriver();
        public IWebElement GetElement(By locator)
        {
            return driver.FindElement(locator);
        }
        public void Click(By locator) => GetElement(locator).Click();

        public void SetURL(string url) => driver.Url = url;

        public void Maximize() => driver.Manage().Window.Maximize();

        public void Quit() => driver.Quit();
    }
}