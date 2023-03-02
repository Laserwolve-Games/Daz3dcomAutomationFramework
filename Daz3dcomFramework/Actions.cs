using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace Daz3dcomFramework
{
    public class Actions
    {
        // TODO: Optimize the waits
        // TODO: Make methods boolean pass/fail

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
        public List<IWebElement> GetItemsByPrice(double price, List<IWebElement> items)
        {   
            // If an item's price is higher than the specified price, remove that item.
            foreach (IWebElement item in items.ToList())
            {
                string priceValue = item.FindElement(Locators.shop.anItemsPrice).Text;
                double individualPrice;

                if (priceValue == "Free") individualPrice = 0;
                else individualPrice = double.Parse(priceValue.Trim().Replace("$", ""));

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
        public void addItemsToCart(List<IWebElement> items) 
        {
            foreach (IWebElement button in items)
            {
                button.Click();
                Wait();
                Click(Locators.shop.addedToCartPopout.close);
                Wait();
            }
        }
        public void browseToShoppingCart()
        {
            Click(Locators.shop.cart);
            // This can take a very long time.
            Wait(15);
        }
        public void completeCheckout()
        {
            Click(Locators.checkout.proceedToBillingInfo);
            Wait();
            Click(Locators.checkout.placeOrder);
        }
        public double getShoppingCartTotal()
        {
            return double.Parse(GetElement(Locators.checkout.total).Text.Replace("$", ""));
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