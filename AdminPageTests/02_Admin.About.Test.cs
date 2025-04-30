using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AdminPageTests
{
    [TestFixture]
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
        public void AboutPage_AboutOptionTest()
        {
            var aboutOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a"));
            Assert.IsTrue(aboutOption.Enabled);
            Assert.IsTrue(aboutOption.Displayed);
            Assert.AreEqual(aboutOption.Text,"About");
            Assert.AreEqual(aboutOption.GetAttribute("target"),"_self");
            Assert.AreEqual(aboutOption.GetAttribute("custom-data"),"About");
            Assert.AreEqual(aboutOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/About");

            var aboutOptionTitle = driver.FindElement(By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a/span/span"));
            Assert.IsTrue(aboutOptionTitle.Enabled);
            Assert.IsTrue(aboutOptionTitle.Displayed);
            Assert.AreEqual(aboutOptionTitle.Text,"About");
            Assert.AreEqual(aboutOptionTitle.GetAttribute("class"),"title");

            string Icon = "m-menu__link-icon flaticon-interface-10";
            var aboutOptionIcon = driver.FindElement(By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a/i"));
            Assert.IsTrue(aboutOptionIcon.Enabled);
            Assert.IsTrue(aboutOptionIcon.Displayed);
            Assert.AreEqual(aboutOptionIcon.GetAttribute("class"),Icon);
        }

        [Test]
        public void AboutPage_OpenPage()
        {
            var aboutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a"));
            aboutBtn.Click();
        }

        [Test]
        public void AboutPage_TopBarUserNameTest()
        {
            // to open about page
            AboutPage_OpenPage();

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
        public void AboutPage_LogoutBtnTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var username = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            username.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text,"Logout");

            var urlBeforeClick = driver.Url;
            logoutBtn.Click();
            var urlAfterClick = driver.Url;
            Assert.AreNotEqual(urlAfterClick,urlBeforeClick);
            Assert.IsTrue(urlAfterClick.Contains("Login"));
        }

        [Test]
        public void AboutPage_SubHeaderTitleTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "About");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void AboutPage_DashboardNavigationLinkTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var dashbaordNavLink = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.True(dashbaordNavLink.Enabled);
            Assert.True(dashbaordNavLink.Displayed);
            Assert.AreEqual(dashbaordNavLink.Text, "Dashboard");
            Assert.AreEqual(dashbaordNavLink.GetAttribute("class"), "m-nav__link");

            var urlBeforeClick = driver.Url;
            dashbaordNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick, urlBeforeClick);
        }

        [Test]
        public void AboutPage_AboutNavigationLinkTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var aboutNavLink = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(aboutNavLink.Enabled);
            Assert.True(aboutNavLink.Displayed);
            Assert.AreEqual(aboutNavLink.Text, "About");
            Assert.AreEqual(aboutNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void AboutPage_SeperatorBetweenNavigationLinksTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.Text, ">");
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AboutPage_ParagraphTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var paragraph1Text = "The Transit Asset Management Database is a relational database that integrates the asset inventory and condition data used to develop Connecticut DOT’s Transit Asset Management Plan (TAMP), as well as the Group TAMP for Tier II providers in Connecticut. Using a web-based user interface, agencies can enter data with review and approval by CTDOT.";
            var paragraph1 = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[1]"));
            Assert.IsTrue(paragraph1.Enabled);
            Assert.IsTrue(paragraph1.Displayed);
            Assert.AreEqual(paragraph1.TagName,"p");
            Assert.AreEqual(paragraph1Text,paragraph1.Text);

            var paragraphsOrderList = driver.FindElements
                (By.CssSelector("body > div.m-grid.m-grid--hor.m-grid--root.m-page > div > div.m-grid__item.m-grid__item--fluid.m-wrapper > div.m-content > div > div > div > div > ol"));
            foreach(var paragraph in paragraphsOrderList)
            {
                Assert.IsTrue(paragraph.Enabled);
                Assert.IsTrue(paragraph.Displayed);
            }

            var paragraph2Text = "The Database stores data on facilities, revenue vehicles, fixed guideway, and equipment.";
            var paragraph2 = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[3]"));
            Assert.IsTrue(paragraph2.Enabled);
            Assert.IsTrue(paragraph2.Displayed);
            Assert.AreEqual(paragraph2.TagName, "p");
            Assert.AreEqual(paragraph2Text, paragraph2.Text);

            var paragraph3Text = "Group Plan members update the Database with inventory, condition, and other data for revenue vehicles (rolling stock) and equipment (non-revenue service vehicles).";
            var paragraph3 = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[4]"));
            Assert.IsTrue(paragraph3.Enabled);
            Assert.IsTrue(paragraph3.Displayed);
            Assert.AreEqual(paragraph3.TagName, "p");
            Assert.AreEqual(paragraph3Text, paragraph3.Text);
        }

        [Test]
        public void AboutPage_CopyRightTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void AboutPage_MinimizeToggleBtnTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
