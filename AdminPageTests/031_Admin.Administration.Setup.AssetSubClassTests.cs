using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminAdministrationSetupAssetSubClassTests : IDisposable
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
        public void AssetSubClassesPage_AdministratioOptionTest()
        {
            // test adminstration option
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
        public void AssetSubClassesPage_SetupOptionTest()
        {
            // to click on adminstration options
            var administrationOption = driver.FindElement
                  (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a"));
            Assert.True(setupOption.Displayed);
            Assert.True(setupOption.Enabled);
            Assert.AreEqual("Setup", setupOption.Text);
            Assert.AreEqual(setupOption.GetAttribute("custom-data"), "Setup");
            Assert.AreEqual(setupOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(setupOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");
            setupOption.Click();

            string Icon = "m-menu__link-icon flaticon-cogwheel";
            var setupOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/i[1]"));
            Assert.True(setupOptionIcon.Displayed);
            Assert.True(setupOptionIcon.Enabled);
            Assert.AreEqual(setupOptionIcon.GetAttribute("class"), Icon);

            string Arrow = "m-menu__ver-arrow la la-angle-right";
            var setupOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/i[2]"));
            Assert.True(setupOptionArrow.Displayed);
            Assert.True(setupOptionArrow.Enabled);
            Assert.AreEqual(setupOptionArrow.GetAttribute("class"), Arrow);

            var setupOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            Assert.True(setupOptionTitle.Displayed);
            Assert.True(setupOptionTitle.Enabled);
            Assert.AreEqual(setupOptionTitle.Text, "Setup");
            Assert.AreEqual(setupOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetSubClassesPage_AssetSubClassesOtionTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetSubClassesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[2]/a"));
            Assert.IsTrue(assetSubClassesOption.Enabled);
            Assert.IsTrue(assetSubClassesOption.Displayed);
            Assert.AreEqual(assetSubClassesOption.GetAttribute("target"), "_self");
            Assert.AreEqual(assetSubClassesOption.GetAttribute("custom-data"), "Asset Sub Classes");
            Assert.AreEqual(assetSubClassesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(assetSubClassesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetSubClasses");

            var assetSubClassesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[2]/a/i"));
            Assert.IsTrue(assetSubClassesOptionIcon.Enabled);
            Assert.IsTrue(assetSubClassesOptionIcon.Displayed);
            Assert.AreEqual(assetSubClassesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var assetSubClassOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[2]/a/span/span"));
            Assert.IsTrue(assetSubClassOptionTitle.Enabled);
            Assert.IsTrue(assetSubClassOptionTitle.Displayed);
            Assert.AreEqual(assetSubClassOptionTitle.Text, "Asset Sub Classes");
            Assert.AreEqual(assetSubClassOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetSubClassesPage_OpenPage()
        {
            var administrationOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetSubClassesOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[2]/a"));
            assetSubClassesOption.Click();
        }

        [Test]
        public void AssertSubClassesPage_TopBarUserNameTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var username = driver.FindElement(By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            Assert.IsTrue(username.Enabled);
            Assert.IsTrue(username.Displayed);
            Assert.AreEqual(username.Text, "HI,");
            Assert.AreEqual(username.GetAttribute("class"), "m-topbar__username");

            var admin = driver.FindElement(By.Id("UserName"));
            Assert.IsTrue(admin.Enabled);
            Assert.IsTrue(admin.Displayed);
        }

        [Test]
        public void AssetSubClassesPage_LogoutBtnTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

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
        public void AssetSubClassPage_SubHeaderTitleTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Asset Sub Classes");
        }

        [Test]
        public void AssetSubClassPage_DashboardNavigationLinkTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var dashbaordBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.True(dashbaordBtn.Enabled);
            Assert.True(dashbaordBtn.Displayed);
            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
            Assert.AreEqual(dashbaordBtn.GetAttribute("class"), "m-nav__link-text");

            var urlBeforeClick = driver.Url;
            dashbaordBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick, urlBeforeClick);
        }

        [Test]
        public void AssetSubClassPage_AssetClassNavigationLinkTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var assetSubclasses = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(assetSubclasses.Enabled);
            Assert.True(assetSubclasses.Displayed);
            Assert.AreEqual(assetSubclasses.Text, "Asset Sub Classes");
            Assert.AreEqual(assetSubclasses.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void AssetSubClassPage_SeperatorBetweenNavigationLinksTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AssetSubClassPage_WhenCLickOnCreateBtn_MustOpenCreateForm()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
        }

        [Test]
        public void AssetSubClassPage_CreateFormTest()
        {
            // to open create form
            AssetSubClassPage_WhenCLickOnCreateBtn_MustOpenCreateForm();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[1]/div/div/div/label"));
            assetSubClassLabel.Click();
            Assert.True(assetSubClassLabel.Enabled);
            Assert.True(assetSubClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("SubClassName"));
            var requiredField = assetClassInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetSubClassPage_AssetClassDropdownlistTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var assetClassLabel = driver.FindElement(By.Id("assetclassbuid"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"), "form-label");

            var defualtOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassId\"]/option[1]"));
            Assert.IsTrue(defualtOption.Enabled);
            Assert.IsTrue(defualtOption.Displayed);
            Assert.AreEqual(defualtOption.Text, "Please Select...");

            var assetClassDropdownlist = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetClassDropdownlist.Enabled);
            Assert.IsTrue(assetClassDropdownlist.Displayed);
            Assert.AreEqual(assetClassDropdownlist.GetAttribute("class"), "form-control");

            var selectedAssetClass = new SelectElement(assetClassDropdownlist);
            selectedAssetClass.SelectByIndex(1);
        }

        [Test]
        public void AssetSubClassesPage_SearchBtnTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var searchBtn = driver.FindElement(By.Id("btnSearch"));
            Assert.IsTrue(searchBtn.Enabled);
            Assert.IsTrue(searchBtn.Displayed);
            Assert.AreEqual(searchBtn.Text,"Search");
            Assert.AreEqual(searchBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");
        }
        
        [Test]
        public void AssetSubClassPage_DataTableLengthTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetSubClassesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetSubClassPage_DataTableFilterTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.Id("WebPagesTableFilter"));
            searchInput.SendKeys("Test");
            Assert.True(searchLabel.Enabled);
        }

        [Test]
        public void AssetSubClassPage_ReOrderPageTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var assetClasseName = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/thead/tr/th[1]"));
            Assert.True(assetClasseName.Enabled);
            Assert.True(assetClasseName.Displayed);
            Assert.AreEqual(assetClasseName.Text, "Asset Class Name");
            Assert.AreEqual(assetClasseName.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(assetClasseName.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(assetClasseName.GetAttribute("aria-controls"), "AssetSubClassesTable");
            Assert.AreEqual(assetClasseName.GetAttribute("aria-label"), "Asset Class Name: activate to sort column descending");
            assetClasseName.Click();

            var assetSubClassName = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(assetSubClassName.Enabled);
            Assert.IsTrue(assetSubClassName.Displayed);
            Assert.AreEqual(assetSubClassName.Text, "Asset Subclass Name");
            Assert.AreEqual(assetSubClassName.GetAttribute("class"), "sorting");
            Assert.AreEqual(assetSubClassName.GetAttribute("aria-controls"), "AssetSubClassesTable");
            Assert.AreEqual(assetSubClassName.GetAttribute("aria-label"), "Asset Subclass Name: activate to sort column ascending");
            assetSubClassName.Click();

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/thead/tr/th[3]"));
            Assert.True(action.Enabled);
            Assert.True(action.Enabled);
            Assert.AreEqual(action.Text, "Actions");
            Assert.AreEqual(action.GetAttribute("class"), "sorting_disabled");
        }

        [Test]
        public void AssetSubClassPage_EditAssetTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/tbody/tr[1]/td[3]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var assetSubClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[1]/div/div/div/label"));
            assetSubClassLabel.Click();
            Assert.True(assetSubClassLabel.Enabled);
            Assert.True(assetSubClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("SubClassName"));
            var requiredField = assetClassInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetClassPage_DeleteAssetTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/tbody/tr[1]/td[3]/a[2]"));
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            deleteIcon.Click();

            var confirmWindo = driver.FindElement(By.XPath("/html/body/div[4]/div"));
            Assert.True(confirmWindo.Displayed);

            var warninigMessage = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div[2]"));
            Assert.AreEqual(warninigMessage.Text, "Are you sure?");

            var yesBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div[3]/div[2]/button"));
            Assert.AreEqual(yesBtn.Text, "Yes");
            Assert.True(yesBtn.Enabled);
            Assert.True(yesBtn.Displayed);

            var cancelBtn = driver.FindElement(
                By.XPath("/html/body/div[4]/div/div[3]/div[1]/button"));
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetSubClassPage_PaginateTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("AssetSubClassesTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetSubClassesTable_previous"));
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            Assert.AreEqual(previoustBtn.Text, "Previous");
            previoustBtn.Click();

            var pages = driver.FindElements(By.XPath("AssetSubClassesTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void AssetSubclassesPage_DataTableInfoTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("AssetSubClassesTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void AssetSubClassPage_CopyRightTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void AssetSubClassesPage_MinimizeToggleBtnTest()
        {
            //  to open asset sub class page
            AssetSubClassesPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
