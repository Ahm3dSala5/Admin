using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AdminPageTests
{
    public class AdminAdministrationInstructionManualTests : IDisposable
    {
        private IWebDriver driver;

        public void Dispose()
        {
            driver.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Login");

            // this for skip login page
            var usernameField = driver.FindElement(By.Name("usernameOrEmailAddress"));
            var passwordField = driver.FindElement(By.Name("Password"));
            var signInButton = driver.FindElement(By.Id("LoginButton"));
            usernameField.SendKeys("Admin");
            passwordField.SendKeys("ctdot@123");
            signInButton.Click();

            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Dashboard");
        }

        [Test]
        public void AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayDrodownlist()
        {
            var administrationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));

            administrationBtn.Click();
        }

        [Test]
        public void InstructionManual_WhenClickOnInstructionOption_MustOpenInstructionPage()
        {
            // to click on administaration option
            AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayDrodownlist();

            var instructionManual = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[5]/a/span/span"));
            instructionManual.Click();
        }

        [Test]
        public void InstructionManualPage_PageTitleTest()
        {
            // to open instraction page
            InstructionManual_WhenClickOnInstructionOption_MustOpenInstructionPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Instruction Manual");
            Assert.True(title.Enabled);
            Assert.True(title.Displayed);
        }

        [Test]
        public void InstructionManualPage_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open instraction page
            InstructionManual_WhenClickOnInstructionOption_MustOpenInstructionPage();

            var dashbaordBtn = driver.FindElement(
               By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            var assetClassUrl = driver.Url;

            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
            Assert.IsTrue(dashbaordBtn.Displayed);
            Assert.IsTrue(dashbaordBtn.Enabled);
            dashbaordBtn.Click();
            var dashbaordUrl = driver.Url;
            Assert.AreNotEqual(dashbaordUrl, assetClassUrl);
        }

        [Test]
        public void InstructionManualPage_UploadBtnTest()
        {
            // to open instraction page
            InstructionManual_WhenClickOnInstructionOption_MustOpenInstructionPage();

            var uploadBtn = driver.FindElement
                (By.XPath("//*[@id=\"InstructionManualForm\"]/div[2]/button"));
            Assert.AreEqual(uploadBtn.Text, "Upload");
            Assert.True(uploadBtn.Displayed);
            Assert.True(uploadBtn.Enabled);
            uploadBtn.Click();
        }

        [Test]
        public void InstructionManual_UploadFileTest()
        {
            // to open instraction page
            InstructionManual_WhenClickOnInstructionOption_MustOpenInstructionPage();

            var formTitle = driver.FindElement(By.XPath("//*[@id=\"InstructionManualForm\"]/div[1]/label"));
            Assert.AreEqual(formTitle.Text, "Upload your file");
            Assert.True(formTitle.Displayed);
            Assert.True(formTitle.Enabled);
        }
    }
}
