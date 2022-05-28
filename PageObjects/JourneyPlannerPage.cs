using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public IWebElement easthamElement =>
           driver.FindElement(By.XPath("//span[contains(text(),'We found more than one location matching')]"));
        public IWebElement journeyPlannerLink =>  driver.FindElement(By.LinkText("Plan a journey"));

        public IWebElement acceptCookies => driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));

        public IWebElement Done => driver.FindElement(By.XPath("//strong[contains(text(),'Done')]"));



        public void NavigateJourneyPlannerHpmepage(string url)
        {

            driver.Navigate().GoToUrl(url);

        }
        public void ClickJourneyPlannerlink()
        {

            journeyPlannerLink.Click();
        }

        public void clickAcceptCookies()
        {
            acceptCookies.Click();
        }
        public void clickCookiesDone()
        {
            Done.Click();
        }
        public void SetFromJourneyPlanner(string P)
        {

            driver.FindElement(By.XPath("//input[@id='InputFrom']")).SendKeys(P);
        }
        public void SetTOJourneyPlanner(string T)
        {

            driver.FindElement(By.XPath("//input[@id='InputTo']")).SendKeys(T);
        }
        public void PlanMyJourney()
        {

            driver.FindElement(By.XPath("//input[@id='plan-journey-button']")).Click();
        }


        public void WeFoundMoreThanOneLocationMatching()
        {

            bool v = AssertionOptions.Equals("We found more than one location matching", "expected");


        }
        public string actualText(IWebElement element)
        {

            return element.GetAttribute("textContent");


        }


    }
}
