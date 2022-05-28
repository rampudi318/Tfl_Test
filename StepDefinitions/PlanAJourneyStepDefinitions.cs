using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Tfl_Test.PageObjects;

namespace Tfl_Test.StepDefinitions
{
    [Binding]
    
    public class PlanAJourneyStepDefinitions
    {
        private IWebDriver _driver;

        public PlanAJourneyStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
        }
        [Given(@"Navigate The widget TFL Homepage")]
        public void GivenNavigateTheWidgetTFLHomepage()
        {
            new JourneyPlannerPage(_driver).NavigateJourneyPlannerHpmepage("https://tfl.gov.uk");
        }

        [Given(@"click the ""Plan a journey” tab from the homepage")]
        public void GivenClickThePlanAJourneyTabFromTheHomepage()
        {
            new JourneyPlannerPage(_driver).clickAcceptCookies();
            new JourneyPlannerPage(_driver).clickCookiesDone();
            Thread.Sleep(3000);
            new JourneyPlannerPage(_driver).ClickJourneyPlannerlink();

            
        }

        [When(@"I enter the valid From address and valid TO address")]
        public void WhenIEnterTheValidFromAddressAndValidTOAddress()
        {
            new JourneyPlannerPage(_driver).SetFromJourneyPlanner("ig1 2er");
            new JourneyPlannerPage(_driver).SetTOJourneyPlanner("east ham");
            new JourneyPlannerPage(_driver).PlanMyJourney();
            Thread.Sleep(4000);
        }

        [Then(@"it is shown a valid journey can be planne on widget page")]
        public void ThenItIsShownAValidJourneyCanBePlanneOnWidgetPage()
        {
            String expectedText = "We found more than one location matching 'east ham'";
            String actualTextFound = new JourneyPlannerPage(_driver).actualText(new JourneyPlannerPage(_driver).searchResults);
            Assert.AreEqual(expectedText, actualTextFound);
        }
    }
       
}
