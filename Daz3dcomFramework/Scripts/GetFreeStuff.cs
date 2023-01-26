using OpenQA.Selenium;

namespace Daz3dcomFramework.Scripts
{
    public class Tests
    {
        Actions actions = new();

        [SetUp]
        public void Setup()
        {
            actions.Maximize();
        }

        [Test]
        public void GetFreeStuff()
        {
            actions.SetURL("https://www.daz3d.com/shop/");
            actions.Click(Locators.myAccountIcon);
        }

        [TearDown]
        public void TearDown()
        {
            actions.Quit();
        }
    }
}