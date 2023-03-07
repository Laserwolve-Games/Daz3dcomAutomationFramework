package daz3dcomAutomation;

public class GetFreeItems
{
	static DazMethodLibrary dml = new DazMethodLibrary();

	public static void main(String[] args) throws InterruptedException
	{	
		try
		{
			dml.setUp();
			
			dml.openShop();
			
			dml.logIn();
			
			dml.addFreeItemsToCart();
		}
		finally
		{
			dml.quit();
		}
	}
}
