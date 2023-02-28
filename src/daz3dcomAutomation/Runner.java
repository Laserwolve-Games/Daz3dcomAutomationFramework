package daz3dcomAutomation;

public class Runner
{
	static Actions actions = new Actions();

	public static void main(String[] args) throws InterruptedException
	{	
		actions.setUp();
		actions.quit();
	}
}
