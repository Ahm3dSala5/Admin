using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AdminPageTests
{
    public class AdminAboutPageTest : IDisposable
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
        public void AboutPage_WhenClickAboutButton_MustOpenAboutPage()
        {
            var aboutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a"));
            aboutBtn.Click();

        }


        [Test]
        public void AboudPage_PageTitleTest()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("About", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void AboutPage_WhenClickOnLeftBarIcon_MustOpenOrCloseAllOptions()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var leftBarIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_aside_left_minimize_toggle\"]/span"));
            leftBarIcon.Click();
            Assert.True(leftBarIcon.Displayed);
            Assert.True(leftBarIcon.Enabled);
        }

        [Test]
        public void AboutPage_WhenClicOnDashboardBtn_MustGoToDashboardPage()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var dashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(dashboardBtn.Text, "Dashboard");
            Assert.True(dashboardBtn.Enabled);
            Assert.True(dashboardBtn.Displayed);
            var UrlBeforeClick = driver.Url;
            dashboardBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick, UrlBeforeClick);
        }

        [Test]
        public void AboutPage_WhenOpenDashboardPage_MustDisplayDashboardParagraph()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var paragraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[1]"));

            Assert.True(paragraph.Displayed);
        }

        [Test]
        public void AboutPage_WhenClickOnHiAdmin_MustOpenLogoutOption()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var HiAdminBtn = driver.FindElement(By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            HiAdminBtn.Click();
        }

        [Test]
        public void AdminPaeAbout_WhenCliclOnLogoutBtn_MustBeEnabled()
        {
            // to ckick on hi admin 
            AboutPage_WhenClickOnHiAdmin_MustOpenLogoutOption();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/div/div/div/div/ul/li[4]/a"));
            Assert.True(logoutBtn.Displayed);
            Assert.True(logoutBtn.Enabled);
        }

        [Test]
        public void AboutPage_WhenClickOnLogoutBtn_MustGoLoginPage()
        {
            // to ckick on hi admin 
            AboutPage_WhenClickOnHiAdmin_MustOpenLogoutOption();

            var adminPageUrl = driver.Url;
            var logoutBtn = driver.FindElement
                           (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/div/div/div/div/ul/li[4]/a"));
            logoutBtn.Click();
            var loginPageUrl = driver.Url;

            Assert.AreNotEqual(adminPageUrl,loginPageUrl);
        }

        [Test]
        public void AboutPage_WhenClickOnDashboardBtn_MustBeEnabledAndDisplayed()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var dashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));

            Assert.True(dashboardBtn.Displayed);
            Assert.True(dashboardBtn.Enabled);
        }

        [Test]
        public void AboutPage_WhenClickOnDashboardBtn_MustGoToDashboardBtn()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var AdminPageUrl = driver.Url;
            var dashboardBtn = driver.FindElement
               (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            dashboardBtn.Click();

            var dashbaordPageUrl = driver.Url;
            Assert.AreNotEqual(dashbaordPageUrl,AdminPageUrl);

        }

        [Test]
        public void DashboardPage_ParagraphTest()
        {
            // to open dashboard page
            AboutPage_WhenClickOnDashboardBtn_MustGoToDashboardBtn();

            var paragraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/h3/span"));
            var message = "Welcome to the CTDOT Transit Asset Management Database!\r\n\r\nThis database stores asset inventory data of Connecticut transit providers. Please use the menu bar on the left or dashboard controls to view, edit, create or delete assets. Note that any edits made by a transit operator must be approved before they can be incorporated in the inventory.";
            Assert.True(paragraph.Displayed);
            Assert.True(paragraph.Enabled);
            Assert.AreEqual(message,paragraph.Text);
        }
        
        [Test]
        public void AboutPage_WhenClickOnLogo_MustBeEnabledAndDisplayed()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var logo = driver.FindElement
                (By.XPath("//*[@id=\"m_header\"]/div/div/div[1]/div/div[1]/a/img"));
            Assert.True(logo.Enabled);
            Assert.True(logo.Displayed);
        }

        [Test]
        public void AboutPage_WhenClickOnLogoMustOpenSamePage()
        {
            // to open about page
            AboutPage_WhenClickAboutButton_MustOpenAboutPage();

            var logo = driver.FindElement
                (By.XPath("//*[@id=\"m_header\"]/div/div/div[1]/div/div[1]/a/img"));
            var UrlBeforeClick = driver.Url;
            logo.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }
    }
}
