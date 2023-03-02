package daz3dcomAutomation;

import java.time.Duration;
import java.util.ArrayList;
import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.StaleElementReferenceException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.edge.EdgeDriver;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.openqa.selenium.support.ui.ExpectedConditions;
import static com.codeborne.selenide.Selenide.*;

public class DazMethodLibrary
{
	WebDriver driver = new EdgeDriver();
	Actions actions = new Actions(driver);
	
	public WebElement clickableElement(WebElement element)
	{
		return stop().until(ExpectedConditions.elementToBeClickable(element));
	}
	public WebElement clickableElement(By by)
	{
		return stop().until(ExpectedConditions.elementToBeClickable(by));
	}
	public WebElement clickableElement(By by, int seconds)
	{
		return stop(seconds).until(ExpectedConditions.elementToBeClickable(by));
	}
	public WebElement visibleElement(By by)
	{
		return stop().until(ExpectedConditions.elementToBeClickable(by));
	}
	public WebElement visibleElement(By by, int seconds)
	{
		return stop(seconds).until(ExpectedConditions.elementToBeClickable(by));
	}
	public WebDriverWait stop()
	{
		return stop(5);
	}
	public WebDriverWait stop(int seconds)
	{
		return new WebDriverWait(driver, Duration.ofSeconds(seconds));
	}
	public void quit()
	{
		driver.quit();
	}
	public void quit(String message)
	{
		log(message);
		
		driver.quit();
	}
	public void click(By by)
	{
		clickableElement(by).click();
	}
	public void click(By by, int seconds)
	{
		clickableElement(by, seconds).click();
	}
	public void click(WebElement element)
	{
		clickableElement(element).click();
	}
	public void sendText(By by, String text)
	{
		clickableElement(by).sendKeys(text);
	}
	public void sendText(By by, int seconds, String text)
	{
		clickableElement(by, seconds).sendKeys(text);
	}
	public void switchToIframe(By by)
	{
		driver.switchTo().frame(clickableElement(by));
	}
	public void switchToIframe(By by, int seconds)
	{
		driver.switchTo().frame(clickableElement(by, seconds));
	}
	public void waitUntilElementIsGone(By by)
	{
		stop().until(ExpectedConditions.not(ExpectedConditions.refreshed(ExpectedConditions.visibilityOfElementLocated(by))));
	}
	public void log(String message)
	{
		System.out.println(message);
	}
	public void setUp()
	{
		System.setProperty(Data.driverKey, Data.driverPath);

		driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
		
//		driver.manage().window().maximize();
	}
	public void openShop()
	{	
		driver.get(Data.shopURL);
		
		waitUntilElementIsGone(DazElementMap.shop.loadingPopup);
	}
	public void logIn()
	{
		click(DazElementMap.myAccountButton);
		
		sendText(DazElementMap.AccountDropdown.emailAddressField, SensitiveData.emailAddress);
		
		sendText(DazElementMap.AccountDropdown.passwordField, SensitiveData.password + Keys.ENTER);
		
		stop().until(ExpectedConditions.attributeContains(DazElementMap.myAccountIcon, "class", "logged_in"));
		
		waitUntilElementIsGone(DazElementMap.shop.loadingPopup);
		
		refresh(); // Refresh to get rid of free items that have already been acquired
		
		waitUntilElementIsGone(DazElementMap.shop.loadingPopup);
	}
	public void scrollTo(By by)
	{
		actions.scrollToElement(clickableElement(by));
	}
	public void sortStoreLowToHigh()
	{
		scrollTo(DazElementMap.shop.sortBy);
		
		click(DazElementMap.shop.sortBy);
		
		click(DazElementMap.shop.sortByDropdown.priceLowHigh);
	}
	public void refresh()
	{
		driver.navigate().refresh();
	}
	public List<WebElement> visibleElements(By by)
	{
		return stop().until(ExpectedConditions.visibilityOfAllElementsLocatedBy(by));
	}
	public void addFreeItemsToCart() throws InterruptedException
	{
		sortStoreLowToHigh();
		
		List<WebElement> cartButtons = visibleElements(DazElementMap.shop.addToCartButtonsOfFreeItems);
		
		for(WebElement i : cartButtons)
		{
			Thread.sleep(5000);
			click(i);
			waitUntilElementIsGone(DazElementMap.shop.addingToCartAnimation);
			
			click(DazElementMap.shop.addedToCartPopout.close);
		}
	}
//	private void retryClick(WebElement i) {
//		boolean result = false;
//		int attempts = 0;
//		while(attempts != 2) try
//		{
//			
//		}
//		catch(StaleElementReferenceException e) {}
//		
//	}
}
