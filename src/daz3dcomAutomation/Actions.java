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
		return new WebDriverWait(driver, Duration.ofSeconds(15)).until(ExpectedConditions.elementToBeClickable(by));
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
		driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
//		openEditor();
	}
}
