using OpenQA.Selenium;

namespace Daz3dcomFramework.Scripts
{
    public class Tests
    {
        readonly Actions actions = new();

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

            actions.SortShopLowToHigh();

            // The free/cheapest items will display, but it'll include items already owned. Refresh the page, then repeat the previous steps to exclude them.

            actions.Refresh();

            actions.SortShopLowToHigh();

            List<IWebElement> buttons = actions.GetAddToCartButtons(actions.GetItemsByPrice(5, actions.ConvertElementCollectionToList(actions.GetElements(Locators.shop.items))));

            foreach (IWebElement button in buttons)
            {

            }
        }

        [TearDown]
        public void TearDown()
        {
            actions.Wait(10);
            actions.Quit();
        }
    }
}