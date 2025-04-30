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
        public void ErrorListPage_AdministratioOptionTest()
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
        public void ErrorListPage_ErrorListOptionTest()
        {
            var adminstrationOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a"));
            adminstrationOption.Click();

            var errorListOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[4]/a"));
            Assert.IsTrue(errorListOption.Enabled);
            Assert.IsTrue(errorListOption.Displayed);
            Assert.AreEqual(errorListOption.Text, "Error List");
            Assert.AreEqual(errorListOption.GetAttribute("custom-data"), "Error List");
            Assert.AreEqual(errorListOption.GetAttribute("target"), "_self");
            Assert.AreEqual(errorListOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(errorListOption.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/ErrorList");

            var errorListOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[4]/a/i"));
            Assert.IsTrue(errorListOptionIcon.Enabled);
            Assert.IsTrue(errorListOptionIcon.Displayed);
            Assert.AreEqual(errorListOptionIcon.GetAttribute("class"), "m-menu__link-icon fa fa-exclamation-triangle");

            var errorListTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[4]/a/span/span"));
            Assert.IsTrue(errorListTitle.Enabled);
            Assert.IsTrue(errorListTitle.Displayed);
            Assert.AreEqual(errorListTitle.Text, "Error List");
            Assert.AreEqual(errorListTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void ErrorListPage_OpenPage()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var errorListOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[4]/a/span/span"));
            errorListOption.Click();
        }

        [Test]
        public void ErrorListPage_TopBarUserNameTest()
        {
            // to open Error List page
            ErrorListPage_OpenPage();

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
        public void ErrorListPage_LogoutBtnTest()
        {
            // To Open Error List page
            ErrorListPage_OpenPage();

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
        public void ErrorListPage_SubHeaderTitleTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

             var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));
            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Error List");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void ErrorListPage_DateRangeTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

            var dateRange = driver.FindElement(By.Id("daterange"));
            Assert.IsTrue(dateRange.Enabled);
            Assert.IsTrue(dateRange.Displayed);
            dateRange.Click();

            var calenderIcon = driver.FindElement(By.XPath("//*[@id=\"daterange\"]/i[1]"));
            Assert.IsTrue(calenderIcon.Enabled);
            Assert.IsTrue(calenderIcon.Displayed);
            Assert.AreEqual(calenderIcon.GetAttribute("class"), "fa fa-calendar");

            var caretDownIcon = driver.FindElement(By.XPath("//*[@id=\"daterange\"]/i[2]"));
            Assert.IsTrue(caretDownIcon.Enabled);
            Assert.IsTrue(caretDownIcon.Displayed);
            Assert.AreEqual(caretDownIcon.GetAttribute("class"), "fa fa-caret-down");
        }

        [Test]
        public void ErrorListPage_DataTableFilterTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

            var searchLabel = driver.FindElement
                (By.Id("errorListDetails_filter"));
            Assert.IsTrue(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");
            searchLabel.Click();

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails_filter\"]/label/input"));
            searchInput.SendKeys("Test");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("aria-controls"), "errorListDetails");
        }

        [Test]
        public void ErrorListPage_ErrorListTableTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

            var SerialNo = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[1]"));
            Assert.IsTrue(SerialNo.Enabled);
            Assert.IsTrue(SerialNo.Displayed);
            Assert.AreEqual(SerialNo.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(SerialNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(SerialNo.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(SerialNo.GetAttribute("aria-label"), "Serial No: activate to sort column descending");
            SerialNo.Click();

            var Exceptions = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[2]"));
            Assert.True(Exceptions.Enabled);
            Assert.True(Exceptions.Displayed);
            Assert.AreEqual(Exceptions.Text, "Exception");
            Assert.AreEqual(Exceptions.GetAttribute("class"), "sorting");
            Assert.AreEqual(Exceptions.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(Exceptions.GetAttribute("aria-label"), "Exception: activate to sort column ascending");
            Exceptions.Click();

            var ExecutionDuration = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[3]"));
            Assert.IsTrue(ExecutionDuration.Enabled);
            Assert.IsTrue(ExecutionDuration.Displayed);
            Assert.AreEqual(ExecutionDuration.Text, "Execution Duration");
            Assert.AreEqual(ExecutionDuration.GetAttribute("class"), "sorting");
            Assert.AreEqual(ExecutionDuration.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(ExecutionDuration.GetAttribute("aria-label"), "Execution Duration: activate to sort column ascending");
            ExecutionDuration.Click();

            var ExecutionTime = driver.FindElement
               (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[4]"));
            Assert.IsTrue(ExecutionTime.Enabled);
            Assert.IsTrue(ExecutionTime.Displayed);
            Assert.AreEqual(ExecutionTime.Text, "Execution Time");
            Assert.AreEqual(ExecutionTime.GetAttribute("class"), "sorting");
            Assert.AreEqual(ExecutionTime.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(ExecutionTime.GetAttribute("aria-label"), "Execution Time: activate to sort column ascending");
            ExecutionTime.Click();

            var MethodName = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[5]"));
            Assert.IsTrue(MethodName.Enabled);
            Assert.IsTrue(MethodName.Displayed);
            Assert.AreEqual(MethodName.GetAttribute("class"), "sorting");
            Assert.AreEqual(MethodName.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(MethodName.GetAttribute("aria-label"), "Method Name: activate to sort column ascending");
            MethodName.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"errorListDetails\"]/thead/tr/th[6]"));
            Assert.IsTrue(Actions.Enabled);
            Assert.IsTrue(Actions.Displayed);
            Assert.AreEqual(Actions.Text,"Actions");
            Assert.AreEqual(Actions.GetAttribute("class"), "sorting");
            Assert.AreEqual(Actions.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(Actions.GetAttribute("aria-label"), "Actions: activate to sort column ascending");
            Actions.Click();
        }

        [Test]
        public void ErrorListPage_PaginationTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("errorListDetails_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("errorListDetails_previous"));
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.AreEqual(previoustBtn.GetAttribute("aria-controls"), "errorListDetails");
            Assert.AreEqual(previoustBtn.GetAttribute("class"), "paginate_button previous disabled");
            previoustBtn.Click();

            var pages = driver.FindElements(By.Id("errorListDetails_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
            }
        }

        [Test]
        public void ErrorListPage_DataTableInfoTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("errorListDetails_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void ErrorListPage_CopyRightTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void ErrorListPage_MinimizeToggleBtnTest()
        {
            // to open error list page
            ErrorListPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
