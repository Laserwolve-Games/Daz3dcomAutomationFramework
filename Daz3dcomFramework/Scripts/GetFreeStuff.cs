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
            actions.SetURL(Data.dazShopURL);

            actions.Wait();

            actions.Click(Locators.myAccountIcon);

            actions.FillTextbox(Locators.AccountDropdown.emailAddressField, Data.emailAddress);

            actions.FillTextbox(Locators.AccountDropdown.passwordField, Data.password);

            actions.Click(Locators.AccountDropdown.loginButton);

            actions.Wait();

            actions.ScrollTo(Locators.sortBy);

            actions.Click(Locators.sortBy);

            actions.Click(Locators.sortByDropdown.lowToHigh);

            // The free/cheapest items will display, but it'll include items already owned. Refresh the page, then repeat the previous steps to exclude them.

            actions.Refresh();

            actions.Wait();

            actions.ScrollTo(Locators.sortBy);

            actions.Click(Locators.sortBy);

            actions.Click(Locators.sortByDropdown.lowToHigh);
        }

        [TearDown]
        public void TearDown()
        {
            actions.Wait(10);
            actions.Quit();
        }
    }
}