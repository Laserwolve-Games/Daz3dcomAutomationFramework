using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

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

        public IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            return driver.FindElements(locator);
        }

        public List<IWebElement> ConvertElementCollectionToList (IReadOnlyCollection<IWebElement> elements)
        {
            return elements.ToList();
        }
        public List<IWebElement> GetItemsByPrice(float price, List<IWebElement> items)
        {   
            // If an item's price is higher than the specified price, remove that item.
            foreach (IWebElement item in items)
            {
                String priceValue = item.FindElement(Locators.shop.anItemsPrice).Text;
                float individualPrice;

                if (priceValue == "Free") individualPrice = 0;
                else individualPrice = float.Parse(priceValue.Trim().Replace("$", ""));

                if (individualPrice >= price) items.Remove(item);
            }
                
            return items;
        }

        public List<IWebElement> GetAddToCartButtons(List<IWebElement> items)
        {
            List<IWebElement> addToCartButtons = new();

            foreach (IWebElement item in items) addToCartButtons.Add(item.FindElement(Locators.shop.anItemsAddToCartButton));

            return addToCartButtons;
        }
        public void Click(By locator) => GetElement(locator).Click();

        public void FillTextbox(By locator, String text) => GetElement(locator).SendKeys(text);

        public void ScrollTo(By locator) => javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement(locator));

        public void SetURL(string url) => driver.Url = url;

        public void Maximize() => driver.Manage().Window.Maximize();

        public void Refresh()
        {
            driver.Navigate().Refresh();

            Wait();
        }

        public void Quit() => driver.Quit();

        public void SetImplicitWaitTimer(int seconds) => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

        public void Wait(int seconds) => Thread.Sleep(seconds * 1000);

        public void Wait() => Wait(5);

        public void SignIn()
        {
            Click(Locators.myAccountIcon);

            FillTextbox(Locators.AccountDropdown.emailAddressField, Data.emailAddress);

            FillTextbox(Locators.AccountDropdown.passwordField, Data.password);

            Click(Locators.AccountDropdown.loginButton);

            Wait();
        }

        public void BrowseToShop()
        {
            SetURL(Data.dazShopURL);

            Wait();
        }

        public void SortShopLowToHigh()
        {
            ScrollTo(Locators.sortBy);

            Click(Locators.sortBy);

            Click(Locators.shop.sortByDropdown.priceLowHigh);

            Wait();
        }
    }
}