package daz3dcomAutomation;

import org.openqa.selenium.By;

public class DazElementMap
{
    public static final By myAccountIcon = By.xpath("//i[@class='fd fd-my-account']");

    public static final class AccountDropdown
    {
        public static final By emailAddressField = By.xpath("//input[@id='email']");
        public static final By passwordField = By.xpath("//input[@id='pass']");
        public static final By loginButton = By.xpath("//button[@id='send2']");
    }  
    public static final class shop
    {
    	public static final By loadingPopup = By.xpath("//div[@id='catalog-loading']");
        public static final By sortBy = By.xpath("//select[@name='sort-by']");
        
        public static final class sortByDropdown
        {
            public static final By priceLowHigh = By.xpath("//option[text()='Price Low-High']");
        }
        public static final class addedToCartPopout
        {
            public static final By close = By.xpath("//span[text()='Close']");
        }
        public static final By items = By.xpath("//li[@class='item']");
        public static final By anItemsPrice = By.xpath("//div[contains(@class, '_price')]");
        public static final By anItemsAddToCartButton = By.xpath("//div[@class='cart-options']");
        public static final By cart = By.xpath("//a[@class='cart_btn']");
    }
    public static final class checkout
    {
        public static final By total = By.xpath("//*[@class='amount-grandtotal']");
        public static final By proceedToBillingInfo = By.xpath("//button[text()='Proceed to Billing Info']");
        public static final By placeOrder = By.xpath("//div[@id='order-summary-container']//button[text()='Place Order']");
    }
}