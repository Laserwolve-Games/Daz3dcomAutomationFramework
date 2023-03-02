using OpenQA.Selenium;

namespace Daz3dcomFramework.Scripts
{
    public class getFreeStuff
    {
        readonly Actions actions = new();
        readonly double price = 0;

        [SetUp]
        public void Setup()
        {
            actions.SetImplicitWaitTimer(10);
            actions.Maximize();
        }

        [Test]
        public void GetFreeStuff()
        {
            actions.BrowseToShop();

            actions.SignIn();

            actions.Refresh(); // The free/cheapest items will display, but it'll include items already owned. Refresh the page to exclude them.

            actions.SortShopLowToHigh();

            actions.addItemsToCart(actions.GetAddToCartButtons(actions.GetItemsByPrice(price, actions.ConvertElementCollectionToList(actions.GetElements(Locators.shop.items)))));

            actions.browseToShoppingCart();

            if (actions.getShoppingCartTotal() > price) Assert.Fail("Shopping cart total isn't $" + price);
        }

        [TearDown]
        public void TearDown()
        {
            actions.Wait(10);
            actions.Quit();
        }
    }
}