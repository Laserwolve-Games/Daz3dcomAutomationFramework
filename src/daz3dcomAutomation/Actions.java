package daz3dcomAutomation;

import java.time.Duration;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.edge.EdgeDriver;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.openqa.selenium.support.ui.ExpectedConditions;

public class Actions
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
	public void quit() throws InterruptedException
	{
		Thread.sleep(5000);
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
	public void setUp() throws InterruptedException
	{
		System.setProperty("webdriver.edge.driver", "C:\\driver\\msedgedriver.exe");
		driver.get("https://www.daz3d.com/shop/");
		wait(5).until(ExpectedConditions.not(ExpectedConditions.refreshed(ExpectedConditions.visibilityOfElementLocated(ElementMap.loadingPopup))));
	}
}
