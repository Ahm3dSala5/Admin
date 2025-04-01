using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAdministrationErrorListTests :IDisposable
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
        public void AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayAdministrationDrodownlist()
        {
            var administrationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));

            administrationBtn.Click();
        }

        [Test]
        public void ErrorListPage_WhenClickErrorListOption_MustOpenErrorListPage()
        {
            // to click on administaration option
            AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayAdministrationDrodownlist();

            var errorListPage = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[4]/a/span/span"));
            errorListPage.Click();
        }

        [Test]
        public void RolesPage_PageTitleTest()
        {
            // to open error list page
            ErrorListPage_WhenClickErrorListOption_MustOpenErrorListPage();

             var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Error List");
            Assert.True(title.Enabled);
            Assert.True(title.Displayed);
        }

        [Test]
        public void ErrorListPage_DateRangeTest()
        {
            // to open error list page
            ErrorListPage_WhenClickErrorListOption_MustOpenErrorListPage();

            var dateRange = driver.FindElement(By.Id("daterange"));
            Assert.True(dateRange.Displayed);
            Assert.True(dateRange.Enabled);
            dateRange.Click();
            
            var dateRangeIcon = driver.FindElement
                (By.XPath("//*[@id=\"daterange\"]/i[1]"));
            Assert.True(dateRangeIcon.Displayed);
            Assert.True(dateRangeIcon.Enabled);

            var customRange = driver.FindElement
                (By.XPath("/html/body/div[4]/div[1]/ul/li[6]"));
            customRange.Click();
        }

        [Test]
        public void ErrorListPage_DataTableFilterTest()
        {
            // to open error list page
            ErrorListPage_WhenClickErrorListOption_MustOpenErrorListPage();

            var searchLabel = driver.FindElement
                (By.Id("errorListDetails_filter"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");
            Assert.IsTrue(searchLabel.Displayed);

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails_filter\"]/label/input"));
            searchInput.SendKeys("Test");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
        }


        [Test]
        public void ErrorListPage_ReOrderTableTest()
        {
            // to open error list page
            ErrorListPage_WhenClickErrorListOption_MustOpenErrorListPage();

            var serialNo = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[1]"));
            serialNo.Click();
            Assert.True(serialNo.Enabled);
            Assert.True(serialNo.Displayed);
            Assert.AreEqual(serialNo.Text, "Serial No");
            var serialNoSortMessage = serialNo.GetAttribute("aria-label");
            var message = "Serial No: activate to sort column ascending";
            Assert.AreEqual(serialNoSortMessage, message);

            var Exceptions = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[2]"));
            Exceptions.Click();
            Assert.True(Exceptions.Enabled);
            Assert.True(Exceptions.Displayed);
            Assert.AreEqual(Exceptions.Text, "Exception");
            var ExceptionSortMessage = Exceptions.GetAttribute("aria-label");
            var Exceptionmessage = "Exception: activate to sort column descending";
            Assert.AreEqual(ExceptionSortMessage, Exceptionmessage);

            var executionDuration = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[3]"));
            executionDuration.Click();
            Assert.True(executionDuration.Enabled);
            Assert.True(executionDuration.Displayed);
            Assert.AreEqual(executionDuration.Text, "Execution Duration");
            var exceptionDurationSortMessage = executionDuration.GetAttribute("aria-label");
            var exceptionDurationMessage = "Execution Duration: activate to sort column descending";
            Assert.AreEqual(exceptionDurationSortMessage, exceptionDurationMessage);

            var executionTime = driver.FindElement
               (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[4]"));
            executionTime.Click();
            Assert.True(executionTime.Enabled);
            Assert.True(executionTime.Displayed);
            Assert.AreEqual(executionTime.Text, "Execution Time");
            var exceptionTimeSortMessage = executionTime.GetAttribute("aria-label");
            var exceptionTimeMessage = "Execution Time: activate to sort column descending";
            Assert.AreEqual(exceptionTimeSortMessage, exceptionTimeMessage);

            var methodName = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[5]"));
            methodName.Click();
            Assert.True(methodName.Enabled);
            Assert.True(methodName.Displayed);
            Assert.AreEqual(methodName.Text, "Method Name");
            var methodNameSortMessage = methodName.GetAttribute("aria-label");
            var methodNameMessage = "Method Name: activate to sort column descending";
            Assert.AreEqual(methodNameSortMessage, methodNameMessage);

            var actions = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[6]"));
            actions.Click();
            Assert.True(actions.Enabled);
            Assert.True(actions.Displayed);
            Assert.AreEqual(actions.Text, "Actions");
            var actionSortMessage = actions.GetAttribute("aria-label");
            var actionMessage = "Actions: activate to sort column descending";
            Assert.AreEqual(actionSortMessage, actionMessage);
        }


        [Test]
        public void ErrorListPage_PaginationTest()
        {
            // to open error list page
            ErrorListPage_WhenClickErrorListOption_MustOpenErrorListPage();

            var nextBtn = driver.FindElement(By.Id("errorListDetails_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("errorListDetails_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();
        }
    }
}
