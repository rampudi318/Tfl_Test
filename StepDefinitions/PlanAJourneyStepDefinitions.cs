using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            Thread.Sleep(3000);
            new JourneyPlannerPage(_driver).settojourneyplanner.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }

        [Then(@"it is shown a valid journey can be planne on widget page")]
        public void ThenItIsShownAValidJourneyCanBePlanneOnWidgetPage()
        {
            String expectedText4 = "We found more than one location matching 'east ham'";
            String actualTextFound4 = new JourneyPlannerPage(_driver).actualText(new JourneyPlannerPage(_driver).searchResults);
            Assert.AreEqual(expectedText4, actualTextFound4);
        }

        [When(@"I enter the invalid From address and valid TO address")]
        public void WhenIEnterTheInvalidFromAddressAndValidTOAddress()
        {
            new JourneyPlannerPage(_driver).SetFromJourneyPlanner("123234456");
            new JourneyPlannerPage(_driver).SetTOJourneyPlanner("97865542");
            new JourneyPlannerPage(_driver).PlanMyJourney();
            Thread.Sleep(4000);
        }

        [When(@"I not enter  From and To address click the journey")]
        public void WhenINotEnterFromAndToAddressClickTheJourney()
        {
            new JourneyPlannerPage(_driver).PlanMyJourney();
            Thread.Sleep(4000);
        }

        [Then(@"user should see from field validation message ""([^""]*)""")]
        public void ThenUserShouldSeeFromFieldValidationMessage(string fromValidationMessage)
        {
            new JourneyPlannerPage(_driver).verifyText(fromValidationMessage, new JourneyPlannerPage(_driver).InputFromError);
        }

        [Then(@"user should see To filed validation message ""([^""]*)""")]
        public void ThenUserShouldSeeToFiledValidationMessage(string toValidationMessage)
        {
            new JourneyPlannerPage(_driver).verifyText(toValidationMessage, new JourneyPlannerPage(_driver).InputToError);
        }


        [When(@"journey can be amended by using the “Edit Journey” button")]
        public void WhenJourneyCanBeAmendedByUsingTheEditJourneyButton()
        {

            new JourneyPlannerPage(_driver).EditJourney();
        }

        [When(@"entert the valid differnt values and update journey")]
        public void WhenEntertTheValidDifferntValuesAndUpdateJourney()
        {
            new JourneyPlannerPage(_driver).clearFromField.Click();
            new JourneyPlannerPage(_driver).SetFromJourneyPlanner("East Ham Underground Station");
            new JourneyPlannerPage(_driver).clearToField.Click();
            new JourneyPlannerPage(_driver).SetTOJourneyPlanner("Barking");
            new JourneyPlannerPage(_driver).UpdateJourney();
        }


        [Then(@"it is shown a invalid journey can be planned on widget page with a message ""([^""]*)""")]
        public void ThenItIsShownAInvalidJourneyCanBePlannedOnWidgetPageWithAMessage(string expectedText)
        {
            new JourneyPlannerPage(_driver).verifyText(expectedText, new JourneyPlannerPage(_driver).sorryMessage);
        }


        [When(@"I click the Recent button it will show the recent journeys")]
        public void WhenIClickTheRecentButtonItWillShowTheRecentJourneys()
        {
            new JourneyPlannerPage(_driver).RecentsJournes();
        }

        [Then(@"I will find the recent journey details\.")]
        public void ThenIWillFindTheRecentJourneyDetails_()
        {

            new JourneyPlannerPage(_driver).getListOfRecentJourneys();
        }
        [Then(@"it is shown a valid journey can be updateon Edit page and shown results ""([^""]*)""")]
        public void ThenItIsShownAValidJourneyCanBeUpdateonEditPageAndShownResults(string expectedText)
        {
            new JourneyPlannerPage(_driver).waitUntilElementVisible(new JourneyPlannerPage(_driver).editjourney);
        }
    

    }
}
