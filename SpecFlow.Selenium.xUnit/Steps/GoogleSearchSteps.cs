using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlow.Selenium.xUnit.Steps
{
    [Binding]
    public class GoogleSearchSteps : TechTalk.SpecFlow.Steps, IDisposable
    {
        private readonly IWebDriver _webDriver;
        private const string TextKey = "text";

        public GoogleSearchSteps()
        {
            _webDriver = new ChromeDriver();
        }

        ~GoogleSearchSteps()
        {
            Dispose();
        }

        [Given(@"I going to the ""(.*)"" home page")]
        public void GivenIGoingToTheHomePage(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        [When(@"I enter a text ""(.*)"" to search")]
        public void WhenIEnterATextToSearch(string text)
        {
            var element = _webDriver.FindElement(By.Name("q"));
            element.SendKeys(text);

            this.ScenarioContext.Add(TextKey, text);
        }

        [When(@"I click on the search button")]
        public void WhenIClickOnTheSearchButton()
        {
            var element = _webDriver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[3]/center/input[1]"));
            element.Click();
        }

        [Then(@"The text inside the search field should not be changed")]
        public void ThenTheTextInsideTheSearchFieldShouldNotBeChanged()
        {
            var element = _webDriver.FindElement(By.Name("q"));

            var actual = element.GetAttribute("value");
            var expected = this.ScenarioContext.Get<string>(TextKey);

            Assert.Equal(expected, actual);
        }

        public void Dispose()
        {
            _webDriver?.Dispose();
        }
    }
}
