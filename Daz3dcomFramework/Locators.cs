using OpenQA.Selenium;

namespace Daz3dcomFramework
{
    public class Locators
    {
        public static readonly By myAccountIcon = By.XPath("//i[@class='fd fd-my-account']");
        public static readonly By loadingPopup = By.XPath("//div[@id='catalog-loading']");
        public static readonly By sortBy = By.XPath("//select[@name='sort-by']");

        public class AccountDropdown
        {
            public static readonly By emailAddressField = By.XPath("//input[@id='email']");
            public static readonly By passwordField = By.XPath("//input[@id='pass']");
            public static readonly By loginButton = By.XPath("//button[@id='send2']");
        }
        
        public class shop
        {
            public class sortByDropdown
            {
                public static readonly By priceLowHigh = By.XPath("//option[text()='Price Low-High']");
            }
            public static readonly By items = By.XPath("//li[@class='item']");
            public static readonly By anItemsPrice = By.XPath("//div[contains(@class, '_price')]");
            public static readonly By anItemsAddToCartButton = By.XPath("//div[@class='cart-options']");
        }
        
    }
}