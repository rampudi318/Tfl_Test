//using BoDi;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Tfl_Test.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

       /* public static IWebDriver _driver = DriverContext.Driver;

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag1()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-Maximizes");
            option.AddArguments("--disable-gpu");
            option.AddArguments("--headless");
            _driver = new ChromeDriver(option);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            _driver.Close();
        }
       */
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