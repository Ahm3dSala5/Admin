using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminAdministrationSetupAssetTypeTests : IDisposable
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
        public void AssetTypePage_AdministratioOptionTest()
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
        public void AssetTypePage_SetupOptionTest()
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
        public void AssetTypePage_AssetTypeOtionTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetTypeOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[3]/a"));
            Assert.IsTrue(assetTypeOption.Enabled);
            Assert.IsTrue(assetTypeOption.Displayed);
            Assert.AreEqual(assetTypeOption.GetAttribute("target"), "_self");
            Assert.AreEqual(assetTypeOption.GetAttribute("custom-data"), "Asset Types");
            Assert.AreEqual(assetTypeOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(assetTypeOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetTypes");

            var assetSubClassesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[2]/a/i"));
            Assert.IsTrue(assetSubClassesOptionIcon.Enabled);
            Assert.IsTrue(assetSubClassesOptionIcon.Displayed);
            Assert.AreEqual(assetSubClassesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var assetTypeOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[3]/a/span/span"));
            Assert.IsTrue(assetTypeOptionTitle.Enabled);
            Assert.IsTrue(assetTypeOptionTitle.Displayed);
            Assert.AreEqual(assetTypeOptionTitle.Text, "Asset Types");
            Assert.AreEqual(assetTypeOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetTypesPage_OpenPage()
        {
            var administrationOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetTypeOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[3]/a"));
            assetTypeOption.Click();
        }

        [Test]
        public void AssertTypePage_TopBarUserNameTest()
        {
            //  to open asset Tyoe page
            AssetTypesPage_OpenPage();

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
        public void AssetTypePage_LogoutBtnTest()
        {
            //  to open asset Tyoe page
            AssetTypesPage_OpenPage();

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
        public void AssetTypesPage_SubHeaderTitleTest()
        {
            //  to open asset Tyoe page
            AssetTypesPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Asset Sub Classes");
        }

        [Test]
        public void AssetTypesPage_DashboardNavigationLinkTest()
        {
            //  to open asset Tyoe page
            AssetTypesPage_OpenPage();

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
        public void AssetTypesPage_AssetTypeNavigationLinkTest()
        {
            //  to open asset Tyoe page
            AssetTypesPage_OpenPage();

            var assetType = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(assetType.Enabled);
            Assert.True(assetType.Displayed);
            Assert.AreEqual(assetType.Text, "Asset Types");
            Assert.AreEqual(assetType.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void AssetTypesPage_SeperatorBetweenNavigationLinksTest()
        {
            //  to open asset Tyoe page
            AssetTypesPage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AssetTypesPage_DataTableLengthTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetTypeTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetTypesPage_DataTableFilterTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_filter\"]/label/input"));
            searchInput.SendKeys("Test");
            Assert.True(searchLabel.Enabled);
        }

        [Test]
        public void AssetTypesPage_AssetClassDropdownlistTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"), "form-label");

            var defualtOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassIdChange\"]/option[1]"));
            Assert.IsTrue(defualtOption.Enabled);
            Assert.IsTrue(defualtOption.Displayed);
            Assert.AreEqual(defualtOption.Text, "Please Select...");

            var assetClassDropdownlist = driver.FindElement(By.Id("AssetClassIdChange"));
            Assert.IsTrue(assetClassDropdownlist.Enabled);
            Assert.IsTrue(assetClassDropdownlist.Displayed);
            Assert.AreEqual(assetClassDropdownlist.GetAttribute("class"), "form-control form-line");

            var selectedAssetClass = new SelectElement(assetClassDropdownlist);
            selectedAssetClass.SelectByIndex(1);
        }

        [Test]
        public void AssetTypesPage_AssetSubClassDropdownlistTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
               (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[2]/div/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Sub Class");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"), "AssetSubClass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"), "form-label");

            var defualtOption = driver.FindElement(By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option[1]"));
            Assert.IsTrue(defualtOption.Enabled);
            Assert.IsTrue(defualtOption.Displayed);
            Assert.AreEqual(defualtOption.Text, "Please Select...");

            var assetSubClassDropdownlList = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassDropdownlList.Enabled);
            Assert.IsTrue(assetSubClassDropdownlList.Displayed);
            Assert.AreEqual(assetSubClassDropdownlList.GetAttribute("class"), "form-control");
        }

        [Test]
        public void AssetTypesPage_WhenClickOnCreateBtn_MustOpenCreateForm()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var createBtn = driver.FindElement(By.XPath("//*[@id=\"btnCreate\"]"));
            createBtn.Click();
        }

        [Test]
        public void AssetTypesPage_CreateFormTest()
        {
            // to open create form
            AssetTypesPage_WhenClickOnCreateBtn_MustOpenCreateForm();

            var assetTypeNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetTypeNameLabel.Click();
            Assert.True(assetTypeNameLabel.Enabled);
            Assert.True(assetTypeNameLabel.Displayed);

            var assetTypeNameInput = driver.FindElement(By.Id("AssetTypeName"));
            var requiredField = assetTypeNameInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetTypeNameInput.Enabled);
            Assert.True(assetTypeNameInput.Displayed);
            assetTypeNameInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("AssetTypesDesc"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            //var assetSubClass = driver.FindElement(By.Id("AssetSubClassIdDropdown"));
            //var selectedAssetSubClass = new SelectElement(assetSubClass);
            //selectedAssetSubClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetTypesPage_ReOrderTableTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var tableColumns = driver.FindElements(By.Id("AssetTypeTable"));
            foreach(var column in tableColumns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var assetClass = driver.FindElement(By.XPath("//*[@id=\"AssetTypeTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(assetClass.Enabled);
            Assert.IsTrue(assetClass.Displayed);
            Assert.AreEqual(assetClass.Text,"Asset Class");
            Assert.AreEqual(assetClass.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(assetClass.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(assetClass.GetAttribute("aria-controls"), "AssetTypeTable");
            Assert.AreEqual(assetClass.GetAttribute("aria-label"), "Asset Class: activate to sort column descending");

            var assetSubClass = driver.FindElement(By.XPath("//*[@id=\"AssetTypeTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(assetSubClass.Enabled);
            Assert.IsTrue(assetSubClass.Displayed);
            Assert.AreEqual(assetSubClass.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClass.GetAttribute("class"), "sorting");
            Assert.AreEqual(assetSubClass.GetAttribute("aria-controls"), "AssetTypeTable");
            Assert.AreEqual(assetSubClass.GetAttribute("aria-label"), "Asset Subclass: activate to sort column ascending");

            var assetType = driver.FindElement(By.XPath("//*[@id=\"AssetTypeTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(assetType.Enabled);
            Assert.IsTrue(assetType.Displayed);
            Assert.AreEqual(assetType.Text, "Asset Type");
            Assert.AreEqual(assetType.GetAttribute("class"), "sorting");
            Assert.AreEqual(assetType.GetAttribute("aria-controls"), "AssetTypeTable");
            Assert.AreEqual(assetType.GetAttribute("aria-label"), "Asset Type: activate to sort column ascending");

            var Actions = driver.FindElement(By.XPath("//*[@id=\"AssetTypeTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(Actions.Enabled);
            Assert.IsTrue(Actions.Displayed);
            Assert.AreEqual(Actions.Text, "Actions");
            Assert.AreEqual(Actions.GetAttribute("class"), "sorting_disabled");
            Assert.AreEqual(Actions.GetAttribute("aria-label"), "Actions");
        }

        [Test]
        public void AssetTypesPage_EditAssetTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var assetTypeNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetTypeNameLabel.Click();
            Assert.True(assetTypeNameLabel.Enabled);
            Assert.True(assetTypeNameLabel.Displayed);

            var assetTypeNameInput = driver.FindElement(By.Id("AssetTypeName"));
            var requiredField = assetTypeNameInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetTypeNameInput.Enabled);
            Assert.True(assetTypeNameInput.Displayed);
            assetTypeNameInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("AssetTypesDesc"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            //var assetSubClass = driver.FindElement(By.Id("AssetSubClassIdDropdown"));
            //var selectedAssetSubClass = new SelectElement(assetSubClass);
            //selectedAssetSubClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetTypesPage_DeleteAssetTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable\"]/tbody/tr[1]/td[4]/a[2]"));
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            deleteIcon.Click();

            var confirmWindo = driver.FindElement(By.XPath("/html/body/div[4]/div/div[1]"));
            Assert.True(confirmWindo.Enabled);

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
        public void AssetTypesPage_PaginateTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("AssetTypeTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetTypeTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();

            var pages = driver.FindElements(By.Id("AssetTypeTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void AssetTypesPage_DataTableInfoTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("AssetTypeTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void AssetTypesPage_CopyRightTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void AssetTypesPage_MinimizeToggleBtnTest()
        {
            // to open asset type page
            AssetTypesPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
