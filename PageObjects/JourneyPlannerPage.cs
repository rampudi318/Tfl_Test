using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfl_Test.PageObjects
{
    public class JourneyPlannerPage
    {
        private IWebDriver driver;
        public JourneyPlannerPage(IWebDriver _driver)
        {
            this.driver = _driver;

        }

        public IWebElement searchResults =>
            driver.FindElement(By.XPath("//span[contains(text(),'We found more than one location matching')]"));
        public IWebElement InputFromError => driver.FindElement(By.Id("InputFrom-error"));
        public IWebElement InputToError => driver.FindElement(By.Id("InputTo-error"));
        public IWebElement NagativeJourneyResult =>
            driver.FindElement(By.XPath("//*[@id='full - width - content']/div/div[8]/div/div/ul/li/text()"));
        public IWebElement easthamElement =>
           driver.FindElement(By.XPath("//span[contains(text(),'We found more than one location matching')]"));
        public IWebElement journeyPlannerLink => driver.FindElement(By.LinkText("Plan a journey"));

        public IWebElement acceptCookies => driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));

        public IWebElement Done => driver.FindElement(By.XPath("//strong[contains(text(),'Done')]"));

        public IWebElement editjourney => driver.FindElement(By.XPath("//span[contains(text(),'Edit journey')]"));
        public IWebElement SetFromjourneyplanner => driver.FindElement(By.XPath("//input[@id='InputFrom']"));
        public IWebElement settojourneyplanner => driver.FindElement(By.XPath("//input[@id='InputTo']"));

        public IWebElement planMyjourney => driver.FindElement(By.XPath("//input[@id='plan-journey-button']"));

        public IWebElement Updatejourney => driver.FindElement(By.XPath("//input[@id='plan-journey-button']"));

        public IWebElement Discoverquiterlike => driver.FindElement(By.XPath("//a[contains(text(),\"Discover quieter times to travel.\")]"));

        public IWebElement sorryMessage => driver.FindElement(By.XPath("//li[contains(text(),\"Sorry, we can't find a journey matching your crite\")]"));

        public IWebElement Recentsjournes => driver.FindElement(By.XPath("//a[contains(text(),'Recents')]"));

        public IWebElement clearFromField => driver.FindElement(By.XPath("//a[contains(text(),'Clear From location')]"));

        public IWebElement clearToField => driver.FindElement(By.XPath("//a[contains(text(),'Clear To location')]"));

        public void NavigateJourneyPlannerHpmepage(string url)
        {

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public void ClickJourneyPlannerlink()
        {

            journeyPlannerLink.Click();
        }
        public void EditJourney()
        {

            editjourney.Click();
        }
        public void RecentsJournes()
        {

            Recentsjournes.Click();
        }
        public void UpdateJourney()
        {

            Updatejourney.Click();
        }
        public void clickAcceptCookies()
        {
            acceptCookies.Click();
        }
        public void clickCookiesDone()
        {
            Done.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(driver => journeyPlannerLink.Displayed);
        }
        public void SetFromJourneyPlanner(String fromText)
        {
            SetFromjourneyplanner.SendKeys(fromText);

        }
        public void SetTOJourneyPlanner(string toText)
        {
            settojourneyplanner.SendKeys(toText);
        }
        public void PlanMyJourney()
        {
            planMyjourney.Click();
        }


        public void WeFoundMoreThanOneLocationMatching()
        {

            bool v = AssertionOptions.Equals("We found more than one location matching", "expected");


        }

        public void verifyText(String expectedString, IWebElement element)
        {
            String actualValue = actualText(element);
            Assert.AreEqual(expectedString, actualValue);
        }
       
        public string actualText(IWebElement element)
        {

            return element.GetAttribute("textContent");


        }
        public void getListOfRecentJourneys()
        {
            IList<IWebElement> recentJourneys = driver.FindElements(By.XPath("//div[@id='jp-recent-content-jp-']/a"));
            int listCount = recentJourneys.Count;

              for( int i=1; i <= listCount; i++)
                {
                Assert.That(recentJourneys[i].Displayed);
                if (recentJourneys[i].Displayed)
                {
                    Console.WriteLine(recentJourneys[i].Text);
                }
            }
        }
        public void waitUntilElementVisible(IWebElement element)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => element.Displayed);
        }
    }
}
