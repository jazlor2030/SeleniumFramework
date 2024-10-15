using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SeleniumFramework.Drivers; // importa tu clase de WebDriverFactory

namespace SeleniumFramework.Steps
{
    [Binding]
    public class Hooks(ScenarioContext scenarioContext)
    {
        private readonly ScenarioContext scenarioContext = scenarioContext;
        private IWebDriver? driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = WebDriverFactory.CreateWebDriver(); // Usa la fábrica para crear el WebDriver
            this.scenarioContext["WebDriver"] = driver; // Almacena el WebDriver en el contexto del escenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit(); // Cierra Navegador
                driver.Dispose(); // Libera los recursos
            }
        }
    }
}