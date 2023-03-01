package daz3dcomAutomation;

import java.time.Duration;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.edge.EdgeDriver;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.openqa.selenium.support.ui.ExpectedConditions;

public class DazMethodLibrary
{
	WebDriver driver = new EdgeDriver();
	
	public WebElement clickableElement(By by)
	{
		return clickableElement(by, 5);
	}
	public WebElement clickableElement(By by, int seconds)
	{
		return wait(seconds).until(ExpectedConditions.elementToBeClickable(by));
	}
	public WebDriverWait wait(int seconds)
	{
		return new WebDriverWait(driver, Duration.ofSeconds(seconds));
	}
	public void quit()
	{
		driver.quit();
	}
	public void click(By by)
	{
		clickableElement(by).click();
	}
	public void sendText(By by, String text)
	{
		clickableElement(by).sendKeys(text);
	}
	public void switchToIframe(By by)
	{
		driver.switchTo().frame(clickableElement(by));
	}
	public void setUp()
	{
		System.setProperty(Data.driverKey, Data.driverPath);
	}
	public void start()
	{	
		driver.get(Data.shopURL);
		wait(5).until(ExpectedConditions.not(ExpectedConditions.refreshed(ExpectedConditions.visibilityOfElementLocated(DazElementMap.shop.loadingPopup))));
	}
}
