# [Daz3d.com](https://www.daz3d.com/) Framework
## This is an automation framework for [Daz3d.com](https://www.daz3d.com/) written in [Java](https://en.wikipedia.org/wiki/Java_(programming_language)), using [Selenium](https://www.selenium.dev/) libraries and [Microsoft Edge WebDriver](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/).

Currently, the purpose of this framework is to maximize the amount of free assets you can get out of [Daz3d.com](https://www.daz3d.com/). We are going about that in two ways:

### Automate checking for free assets — Completion: 80%

There is no rhyme or reason to determine when free assets are available on [Daz3d.com](https://www.daz3d.com/). We will make a script that will check if anything free is available, add it to the cart, then checkout.

![2023-02-28_13-25-13](https://user-images.githubusercontent.com/87336074/221983758-4324a584-fa25-4087-9a5a-8f0845ecc0bb.gif)

### Maximum utilization of the monthly [Daz+](https://www.daz3d.com/daz-plus) coupon — Completion: 0%

If you're a [Daz+](https://www.daz3d.com/daz-plus) member, you'll get a $5 coupon each month, which ironically can't be used on [Daz+](https://www.daz3d.com/daz-plus) assets.

![image](https://user-images.githubusercontent.com/87336074/217616951-e0534e89-9623-4c55-912c-725b82e16b02.png)

There's no way to search for non-[Daz+](https://www.daz3d.com/daz-plus) assets, so we will write a script that will scroll through the near-infinite asset list, parsing out assets that meet certain qualifications.
