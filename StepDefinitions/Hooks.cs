using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Tfl_Test.StepDefinitions
{
    [Binding]
    public class Hooks
    {
       
        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;
        public Hooks(IObjectContainer _objectContainer) => this.objectContainer = _objectContainer;


        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        
    }
}