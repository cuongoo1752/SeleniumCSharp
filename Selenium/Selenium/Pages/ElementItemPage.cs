using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumExtras.PageObjects;

namespace Selenium.Pages
{
    public class ElementItemPage
    {
        [FindsBy(How = How.Id, Using = "code")]
        public IWebElement Code { get; set; }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.Id, Using = "quantity")]
        public IWebElement Quantity { get; set; }

        [FindsBy(How = How.Id, Using = "price")]
        public IWebElement Price { get; set; }
    }
}
