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
        
        public readonly JourneyPlannerPage journeyPage;

        public PlanAJourneyStepDefinitions(IWebDriver driver)
        {
            journeyPage = new JourneyPlannerPage(driver);
        }

        [Given(@"Navigate The widget TFL Homepage")]
        public void GivenNavigateTheWidgetTFLHomepage()
        {
            journeyPage.NavigateJourneyPlannerHpmepage("https://tfl.gov.uk");
        }

        [Given(@"click the ""Plan a journey” tab from the homepage")]
        public void GivenClickThePlanAJourneyTabFromTheHomepage()
        {
            journeyPage.clickAcceptCookies();
            journeyPage.clickCookiesDone();
            journeyPage.ClickJourneyPlannerlink();
        }

        [When(@"I enter the valid From address and valid TO address")]
        public void WhenIEnterTheValidFromAddressAndValidTOAddress()
        {
            journeyPage.SetFromJourneyPlanner("ig1 2er");
            journeyPage.SetTOJourneyPlanner("east ham");
            journeyPage.settojourneyplanner.SendKeys(Keys.Enter);
            journeyPage.waitUntilElementVisible(journeyPage.editjourney);
        }

        [Then(@"it is shown a valid journey can be planne on widget page")]
        public void ThenItIsShownAValidJourneyCanBePlanneOnWidgetPage()
        {
            String expectedText = "We found more than one location matching 'east ham'";
            String actualTextFound = journeyPage.actualText(journeyPage.searchResults);
            Assert.AreEqual(expectedText, actualTextFound);
        }

        [When(@"I enter the invalid From address and valid TO address")]
        public void WhenIEnterTheInvalidFromAddressAndValidTOAddress()
        {
            journeyPage.SetFromJourneyPlanner("123234456");
            journeyPage.SetTOJourneyPlanner("97865542");
            journeyPage.PlanMyJourney();
            journeyPage.waitUntilElementVisible(journeyPage.editjourney);
        }

        [When(@"I not enter  From and To address click the journey")]
        public void WhenINotEnterFromAndToAddressClickTheJourney()
        {
            journeyPage.PlanMyJourney();
        }

        [Then(@"user should see from field validation message ""([^""]*)""")]
        public void ThenUserShouldSeeFromFieldValidationMessage(string fromValidationMessage)
        {
            journeyPage.verifyText(fromValidationMessage, journeyPage.InputFromError);
        }

        [Then(@"user should see To filed validation message ""([^""]*)""")]
        public void ThenUserShouldSeeToFiledValidationMessage(string toValidationMessage)
        {
            journeyPage.verifyText(toValidationMessage, journeyPage.InputToError);
        }


        [When(@"journey can be amended by using the “Edit Journey” button")]
        public void WhenJourneyCanBeAmendedByUsingTheEditJourneyButton()
        {

            journeyPage.EditJourney();
        }

        [When(@"entert the valid differnt values and update journey")]
        public void WhenEntertTheValidDifferntValuesAndUpdateJourney()
        {
            journeyPage.clearFromField.Click();
            journeyPage.SetFromJourneyPlanner("East Ham Underground Station");
            journeyPage.clearToField.Click();
            journeyPage.SetTOJourneyPlanner("Barking");
            journeyPage.UpdateJourney();
        }


        [Then(@"it is shown a invalid journey can be planned on widget page with a message ""([^""]*)""")]
        public void ThenItIsShownAInvalidJourneyCanBePlannedOnWidgetPageWithAMessage(string expectedText)
        {
            journeyPage.verifyText(expectedText, journeyPage.sorryMessage);
        }


        [When(@"I click the Recent button it will show the recent journeys")]
        public void WhenIClickTheRecentButtonItWillShowTheRecentJourneys()
        {
            journeyPage.RecentsJournes();
        }

        [Then(@"I will find the recent journey details\.")]
        public void ThenIWillFindTheRecentJourneyDetails_()
        {

            journeyPage.getListOfRecentJourneys();
        }
        [Then(@"it is shown a valid journey can be updateon Edit page and shown results ""([^""]*)""")]
        public void ThenItIsShownAValidJourneyCanBeUpdateonEditPageAndShownResults(string expectedText)
        {
            journeyPage.waitUntilElementVisible(journeyPage.editjourney);
        }
    

    }
}
