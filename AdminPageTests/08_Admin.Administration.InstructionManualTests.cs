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
        public void InstructionManualPage_AdministratioOptionTest()
        {
            var administrationOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();
            Assert.True(administrationOption.Displayed);
            Assert.True(administrationOption.Enabled);
            Assert.AreEqual("Administration", administrationOption.Text);
            administrationOption.Click();

            string Icon = "m-menu__link-icon flaticon-cogwheel";
            var administrationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[1]"));
            Assert.True(administrationIcon.Displayed);
            Assert.True(administrationIcon.Enabled);
            Assert.AreEqual(administrationIcon.GetAttribute("class"), Icon);

            string arrowIcon = "m-menu__ver-arrow la la-angle-right";
            var administrationArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[2]"));
            Assert.True(administrationArrow.Displayed);
            Assert.True(administrationArrow.Enabled);
            Assert.AreEqual(administrationArrow.GetAttribute("class"), arrowIcon);

            var administrationOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            Assert.True(administrationOptionTitle.Displayed);
            Assert.True(administrationOptionTitle.Enabled);
            Assert.AreEqual(administrationOptionTitle.Text, "Administration");
            Assert.AreEqual(administrationOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void InstructionManualPage_InstructionManualOptionTest()
        {
            var administrationOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a"));
            administrationOption.Click();

            var InstructionManualOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[5]/a"));
            Assert.IsTrue(InstructionManualOption.Enabled);
            Assert.IsTrue(InstructionManualOption.Displayed);
            Assert.AreEqual(InstructionManualOption.Text, "Instruction Manual");
            Assert.AreEqual(InstructionManualOption.GetAttribute("custom-data"), "Instruction Manual");
            Assert.AreEqual(InstructionManualOption.GetAttribute("target"), "_self");
            Assert.AreEqual(InstructionManualOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(InstructionManualOption.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/InstructionManual");

            var InstructionManualOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[5]/a/i"));
            Assert.IsTrue(InstructionManualOptionIcon.Enabled);
            Assert.IsTrue(InstructionManualOptionIcon.Displayed);
            Assert.AreEqual(InstructionManualOptionIcon.GetAttribute("class"), "m-menu__link-icon fa fa-file-pdf");

            var InstructionManualOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[5]/a/span/span"));
            Assert.IsTrue(InstructionManualOptionTitle.Enabled);
            Assert.IsTrue(InstructionManualOptionTitle.Displayed);
            Assert.AreEqual(InstructionManualOptionTitle.Text, "Instruction Manual");
            Assert.AreEqual(InstructionManualOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void InstructionMansualPage_OpenPage()
        {
            var adminstrationOption = driver.FindElement
           (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            adminstrationOption.Click();

            var InstructionManualOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[5]/a"));
            InstructionManualOption.Click();
        }

        [Test]
        public void InstructionMansualPage_TopBarUserNameTest()
        {
            // Open Page
            InstructionMansualPage_OpenPage();

            var username = driver.FindElement(By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            Assert.IsTrue(username.Enabled);
            Assert.IsTrue(username.Displayed);
            Assert.AreEqual(username.Text, "HI,");
            Assert.AreEqual(username.GetAttribute("class"), "m-topbar__username");

            var admin = driver.FindElement(By.Id("UserName"));
            Assert.IsTrue(admin.Enabled);
            Assert.IsTrue(admin.Displayed);
            Assert.AreEqual(admin.GetAttribute("style"), "cursor: pointer; margin-bottom: -1.5rem;");
        }

        [Test]
        public void InstructionMansualPage_LogoutBtnTest()
        {
            // Open Page
            InstructionMansualPage_OpenPage();

            var username = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            username.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");

            var urlBeforeClick = driver.Url;
            logoutBtn.Click();
            var urlAfterClick = driver.Url;
            Assert.AreNotEqual(urlAfterClick, urlBeforeClick);
            Assert.IsTrue(urlAfterClick.Contains("Login"));
        }

        [Test]
        public void InstructionManualPage_SubHeaderTitleTest()
        {
            // Open Page
            InstructionMansualPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));
            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Instruction Manual");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void InstructionManualPage_DashboardNavigationLinkTest()
        {
            // Open Page
            InstructionMansualPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));

            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            dashboardNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick, UrlBeforeClick);
        }

        [Test]
        public void InstructionManualPage_InstructionManualNavigationLinkTest()
        {
            // Open Page
            InstructionMansualPage_OpenPage();

            var instructionManualNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));

            Assert.IsTrue(instructionManualNavLink.Enabled);
            Assert.IsTrue(instructionManualNavLink.Displayed);
            Assert.AreEqual(instructionManualNavLink.Text, "Instruction Manual");
            Assert.AreEqual(instructionManualNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void InstructionManualPage_SeperatorBetweenNavLinksTest()
        {
            // Open Page 
            InstructionMansualPage_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void InstructionManualPage_FormFileTest()
        {
            // Open Page 
            InstructionMansualPage_OpenPage();

            var formFileLabel = driver.FindElement
                (By.XPath("//*[@id=\"InstructionManualForm\"]/div[1]/label"));
            Assert.IsTrue(formFileLabel.Enabled);
            Assert.IsTrue(formFileLabel.Displayed);
            Assert.AreEqual(formFileLabel.Text, "Upload your file");
            Assert.AreEqual(formFileLabel.GetAttribute("for"),"formFile");
            Assert.AreEqual(formFileLabel.GetAttribute("class"),"form-label");

            var formFileInout = driver.FindElement(By.Id("instructionManual"));
            Assert.IsTrue(formFileInout.Enabled);
            Assert.IsTrue(formFileInout.Displayed);
            Assert.AreEqual(formFileInout.GetAttribute("type"),"file");
            Assert.AreEqual(formFileInout.GetAttribute("required"),"true");
            Assert.AreEqual(formFileInout.GetAttribute("class"),"form-control");
            Assert.AreEqual(formFileInout.GetAttribute("accept"), "application/pdf");
        }

        [Test]
        public void InstructionManualPage_UploadBtnTest()
        {
            // Open Page
            InstructionMansualPage_OpenPage();

            var uploadBtn = driver.FindElement
                (By.XPath("//*[@id=\"InstructionManualForm\"]/div[2]/button"));
            Assert.IsTrue(uploadBtn.Enabled);
            Assert.IsTrue(uploadBtn.Displayed);
            Assert.AreEqual(uploadBtn.Text, "Upload");
            Assert.AreEqual(uploadBtn.GetAttribute("type"),"submit");
            Assert.AreEqual(uploadBtn.GetAttribute("class"), "btn btn-primary");
        }

        [Test]
        public void InstructionManualPag_CopyRightTest()
        {
            // Open Page 
            InstructionMansualPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void InstructionManualPagPage_MinimizeToggleBtnTest()
        {
            // Open Page 
            InstructionMansualPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
