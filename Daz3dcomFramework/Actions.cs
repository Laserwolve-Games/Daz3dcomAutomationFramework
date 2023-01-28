using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Network;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;

namespace Daz3dcomFramework
{
    public class Actions
    {
        static IWebDriver driver = new EdgeDriver();
        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        public IWebElement GetElement(By locator)
        {
            return driver.FindElement(locator);
        }
        public void Click(By locator) => GetElement(locator).Click();

        public void FillTextbox(By locator, String text) => GetElement(locator).SendKeys(text);

        public void ScrollTo(By locator) => javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement(locator));

        public void WaitForShopLoading()
        {
            IWebElement popup = GetElement(Locators.loadingPopup);
            DateTime expiryTime = new DateTime().AddSeconds(10);

            Boolean isPopupDisplayed()
            {
                if (popup.GetAttribute("style").Equals("display: none;")) return false;
                else return true;
            }
            // If this method was called before the loading popup appeared, wait for it to appear.

            while (!isPopupDisplayed())
            {
                Wait(1);
                if (expiryTime < new DateTime())
                {
                    Assert.Fail();
                    break;
                }
            }

            //Now that the popup has appeared, wait for it to go away.

            while (isPopupDisplayed())
            {
                Wait(1);
                if (expiryTime < new DateTime())
                {
                    Assert.Fail();
                    break;
                }
            }
        }

        public void SetURL(string url) => driver.Url = url;

        public void Maximize() => driver.Manage().Window.Maximize();

        public void Refresh() => driver.Navigate().Refresh();

        public void Quit() => driver.Quit();

        public void SetImplicitWaitTimer(int seconds) => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

        public void Wait(int seconds) => Thread.Sleep(seconds * 1000);

        public void Wait() => Wait(5);
    }
}