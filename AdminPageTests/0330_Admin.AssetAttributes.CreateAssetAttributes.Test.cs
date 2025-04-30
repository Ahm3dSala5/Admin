using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminAssetAttributesCreateAssetAttributesTest : IDisposable
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
        public void CreateAssetAttributesPage_AdministratioOptionTest()
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
        public void CreateAssetAttributesPage_SetupOptionTest()
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
        public void CreateAssetAttributesPage_AssetAttributesOtionTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a"));
            assetAttributesOption.Click();
            Assert.IsTrue(assetAttributesOption.Enabled);
            Assert.IsTrue(assetAttributesOption.Displayed);
            Assert.AreEqual(assetAttributesOption.GetAttribute("custom-data"), "Asset Attributes");
            Assert.AreEqual(assetAttributesOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");
            Assert.AreEqual(assetAttributesOption.GetAttribute("href"), $"{driver.Url}#");

            var assetAttributesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/i[1]"));
            Assert.IsTrue(assetAttributesOptionIcon.Enabled);
            Assert.IsTrue(assetAttributesOptionIcon.Displayed);
            Assert.AreEqual(assetAttributesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var assetAttributesOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            Assert.IsTrue(assetAttributesOptionTitle.Enabled);
            Assert.IsTrue(assetAttributesOptionTitle.Displayed);
            Assert.AreEqual(assetAttributesOptionTitle.Text, "Asset Attributes");
            Assert.AreEqual(assetAttributesOptionTitle.GetAttribute("class"), "title");

            var assetAttributesArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/i[2]"));
            Assert.IsTrue(assetAttributesArrow.Enabled);
            Assert.IsTrue(assetAttributesArrow.Displayed);
            Assert.AreEqual(assetAttributesArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");
        }

        [Test]
        public void CreateAssetAttributesPage_CreateAssetAttributesOptionTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a"));
            assetAttributesOption.Click();

            var CreateAssetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[1]/a"));
            Assert.IsTrue(CreateAssetAttributesOption.Enabled);
            Assert.IsTrue(CreateAssetAttributesOption.Displayed);
            Assert.AreEqual(CreateAssetAttributesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(CreateAssetAttributesOption.GetAttribute("custom-data"), "Create Asset Attributes");
            Assert.AreEqual(CreateAssetAttributesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetAttributes");

            var CreateAssetAttributesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[1]/a/i"));
            Assert.IsTrue(CreateAssetAttributesOptionIcon.Enabled);
            Assert.IsTrue(CreateAssetAttributesOptionIcon.Displayed);
            Assert.AreEqual(CreateAssetAttributesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var CreateAssetAttributesOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[1]/a/span/span"));
            Assert.IsTrue(CreateAssetAttributesOptionTitle.Enabled);
            Assert.IsTrue(CreateAssetAttributesOptionTitle.Displayed);
            Assert.AreEqual(CreateAssetAttributesOptionTitle.Text, "Create Asset Attributes");
            Assert.AreEqual(CreateAssetAttributesOptionTitle.GetAttribute("class"), "title");

        }

        [Test]
        public void CreateAssetAttributes_OpenPage()
        {
            var administrationOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            assetAttributesOption.Click();

            var createAssetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[1]/a/span/span"));
            createAssetAttributesOption.Click();
        }

        [Test]
        public void CreateAssetAttributesPage_TopBarUserNameTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

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
        public void CreateAssetAttributesPage_LogoutBtnTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

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
        public void CreateAssetAttributesPage_SubHeaderTitleTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Asset Attribute");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void CreateAssetAttributesPage_DashboardNavigationLinkTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var dashbaordNavLink = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.True(dashbaordNavLink.Enabled);
            Assert.True(dashbaordNavLink.Displayed);
            Assert.AreEqual(dashbaordNavLink.Text, "Dashboard");
            Assert.AreEqual(dashbaordNavLink.GetAttribute("class"), "m-nav__link-text");

            var urlBeforeClick = driver.Url;
            dashbaordNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick, urlBeforeClick);
        }

        [Test]
        public void CreateAssetAttributesPage_AssetTypeNavigationLinkTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var assetAttributes = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(assetAttributes.Enabled);
            Assert.True(assetAttributes.Displayed);
            Assert.AreEqual(assetAttributes.Text, "Asset Attributes");
            Assert.AreEqual(assetAttributes.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void CreateAssetAttributesPage_SeperatorBetweenNavigationLinksTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.Text,">");
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }


        [Test]
        public void CreateAssetAttributesPage_DataTableLengthTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_length\"]/label"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            Assert.True(showLabel.Text.Contains("Show"));
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetAttributesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            Assert.AreEqual(showValue.GetAttribute("aria-controls"), "AssetAttributesTable");

            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void CreateAssetAttributesPage_DataTableFilterTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label"));
            searchLabel.Click();
            Assert.IsTrue(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label/input"));
            Assert.IsTrue(searchInput.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("type"),"Search");
            Assert.AreEqual(searchInput.GetAttribute("aria-controls"), "AssetAttributesTable");
            searchInput.SendKeys("Code");
        }

        [Test]
        public void CreateAssetAttributesPage_CreateAssetAttributeTableTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var tableColumns = driver.FindElements(By.Id("AssetAttributesTable"));
            foreach(var column in tableColumns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var attributesName = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[1]"));
            Assert.True(attributesName.Enabled);
            Assert.True(attributesName.Displayed);
            Assert.AreEqual(attributesName.Text, "Attribute Name");
            Assert.AreEqual(attributesName.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(attributesName.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(attributesName.GetAttribute("aria-controls"), "AssetAttributesTable");
            Assert.AreEqual(attributesName.GetAttribute("aria-label"), "Attribute Name: activate to sort column descending");
            attributesName.Click();

            var attributesUnit = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[2]"));
            Assert.True(attributesUnit.Enabled);
            Assert.True(attributesUnit.Displayed);
            Assert.AreEqual(attributesUnit.Text, "Attribute Units");
            Assert.AreEqual(attributesUnit.GetAttribute("class"), "sorting");
            Assert.AreEqual(attributesUnit.GetAttribute("aria-controls"), "AssetAttributesTable");
            Assert.AreEqual(attributesUnit.GetAttribute("aria-label"), "Attribute Units: activate to sort column ascending");
            attributesUnit.Click();

            var attributeDataType = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[3]"));
            Assert.True(attributeDataType.Enabled);
            Assert.True(attributeDataType.Displayed);
            Assert.AreEqual(attributeDataType.Text, "Attribute DataType");
            Assert.AreEqual(attributeDataType.GetAttribute("class"), "sorting_disabled");
            Assert.AreEqual(attributeDataType.GetAttribute("aria-label"), "Attribute DataType");
            attributeDataType.Click();
            
            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[4]"));
            Assert.True(action.Enabled);
            Assert.True(action.Displayed);
            Assert.AreEqual(action.Text, "Actions");
            Assert.AreEqual(action.GetAttribute("class"), "sorting_disabled");
            Assert.AreEqual(action.GetAttribute("aria-label"), "Actions");
        }

        [Test]
        public void CreateAssetAttributesPage_CreateBtnTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual("Create", createBtn.Text);
            Assert.AreEqual("class", "btn btn-success btn-primary blue m-btn--wide m-btn--air");
            createBtn.Click();
        }


        // there are two issues in this piece 
        // [1] Asset Units Label Must Linked With Asset Unit Dropdownlist but is Linked With Description Text Area
        // [2] Asset DataType Label Must Linked With Asset DataType Dropdownlist but is Linked With Description Text Area

        [Test]
        public void CreateAssetAttributesPage_CreateFormTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            // to open create form
            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();

            var assetAttributesLabel = driver.FindElement
               (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetAttributesLabel.Click();
            Assert.True(assetAttributesLabel.Enabled);
            Assert.True(assetAttributesLabel.Displayed);
            Assert.AreEqual(assetAttributesLabel.Text, "Asset Attribute");
            Assert.AreEqual(assetAttributesLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetAttributesLabel.GetAttribute("class"), "form-label");

            var assetAttributesInput = driver.FindElement(By.Id("AssetAttributeName"));
            Assert.True(assetAttributesInput.Enabled);
            Assert.True(assetAttributesInput.Displayed);
            Assert.AreEqual(assetAttributesInput.GetAttribute("type"), "text");
            Assert.AreEqual(assetAttributesInput.GetAttribute("required"), "true");
            Assert.AreEqual(assetAttributesInput.GetAttribute("maxlength"), "128");
            Assert.AreEqual(assetAttributesInput.GetAttribute("class"), "form-control");
            assetAttributesInput.SendKeys("Test Name");

            var attributeUnitsDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[2]/div/div/div/label"));
            Assert.IsTrue(attributeUnitsDropdownlistLabel.Enabled);
            Assert.IsTrue(attributeUnitsDropdownlistLabel.Displayed);
            Assert.AreEqual(attributeUnitsDropdownlistLabel.Text, "Attribute Units");
            Assert.AreEqual(attributeUnitsDropdownlistLabel.GetAttribute("for"), "AssetAttributeUnits");
            Assert.AreEqual(attributeUnitsDropdownlistLabel.GetAttribute("class"), "form-label-default ");

            var AttributeUnitsDropdownlist = driver.FindElement(By.Id("AssetAttributeUnits"));
            Assert.IsTrue(AttributeUnitsDropdownlist.Enabled);
            Assert.IsTrue(AttributeUnitsDropdownlist.Displayed);
            Assert.AreEqual(AttributeUnitsDropdownlist.GetAttribute("class"), " form-control");

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetAttributeUnits\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "No Units");

            var selectedAttributeUnitsDropdownlist = new SelectElement(AttributeUnitsDropdownlist);
            selectedAttributeUnitsDropdownlist.SelectByIndex(1);


            var AttributeDateTypeDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[3]/div/div/div/label"));
            Assert.IsTrue(AttributeDateTypeDropdownlistLabel.Enabled);
            Assert.IsTrue(AttributeDateTypeDropdownlistLabel.Displayed);
            Assert.AreEqual(AttributeDateTypeDropdownlistLabel.Text, "Attribute DataType");
            Assert.AreEqual(AttributeDateTypeDropdownlistLabel.GetAttribute("for"), "AssetAttributeDataType");
            Assert.AreEqual(AttributeDateTypeDropdownlistLabel.GetAttribute("class"), "form-label-default ");


            var AttributeDataTypeDropdownlist = driver.FindElement(By.Id("AssetAttributeDataType"));
            Assert.IsTrue(AttributeUnitsDropdownlist.Enabled);
            Assert.IsTrue(AttributeUnitsDropdownlist.Displayed);
            Assert.AreEqual(AttributeUnitsDropdownlist.GetAttribute("class"), " form-control");

            var selectedAttributeDataType = new SelectElement(AttributeDataTypeDropdownlist);
            selectedAttributeDataType.SelectByIndex(1);

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[4]/div/div/div/label"));
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("class"), "form-label-default ");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            Assert.AreEqual(descriptionInput.GetAttribute("maxlength"), "500");
            Assert.AreEqual(descriptionInput.GetAttribute("type"), "textarea");
            Assert.AreEqual(descriptionInput.GetAttribute("class"), " form-control");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length-max"), "500");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length"), "The field Description must be a string with a maximum length of 500.");
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void CreateAssetAttributesPage_EditIconTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[1]"));
            Assert.IsTrue(editIcon.Enabled);
            Assert.IsTrue(editIcon.Displayed);
            Assert.IsTrue(editIcon.GetAttribute("onclick").Contains("editAssetAttribute"));
            Assert.AreEqual(editIcon.GetAttribute("title"), "Edit");

            var DeleteIcon = driver.FindElement(By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[1]/i"));
            Assert.IsTrue(DeleteIcon.Enabled);
            Assert.IsTrue(DeleteIcon.Displayed);
            Assert.AreEqual(DeleteIcon.GetAttribute("class"), "fa fa-edit");
        }

        // there are two issues in this piece 
        // [1] Asset Units Label Must Linked With Asset Unit Dropdownlist but is Linked With Description Text Area
        // [2] Asset DataType Label Must Linked With Asset DataType Dropdownlist but is Linked With Description Text Area
        [Test]
        public void CreateAssetAttributesPage_EditIconFormTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();

            var assetAttributesLabel = driver.FindElement
               (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetAttributesLabel.Click();
            Assert.True(assetAttributesLabel.Enabled);
            Assert.True(assetAttributesLabel.Displayed);
            Assert.AreEqual(assetAttributesLabel.Text, "Asset Attribute");
            Assert.AreEqual(assetAttributesLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetAttributesLabel.GetAttribute("class"),"form-label");

            var assetAttributesInput = driver.FindElement(By.Id("AssetAttributeName"));
            Assert.True(assetAttributesInput.Enabled);
            Assert.True(assetAttributesInput.Displayed);
            Assert.AreEqual(assetAttributesInput.GetAttribute("type"),"text");
            Assert.AreEqual(assetAttributesInput.GetAttribute("required"),"true");
            Assert.AreEqual(assetAttributesInput.GetAttribute("maxlength"),"128");
            Assert.AreEqual(assetAttributesInput.GetAttribute("class"),"form-control");
            assetAttributesInput.SendKeys("Test Name");

            var attributeUnitsDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[2]/div/div/div/label"));
            Assert.IsTrue(attributeUnitsDropdownlistLabel.Enabled);
            Assert.IsTrue(attributeUnitsDropdownlistLabel.Displayed);
            Assert.AreEqual(attributeUnitsDropdownlistLabel.Text,"Attribute Units");
            Assert.AreEqual(attributeUnitsDropdownlistLabel.GetAttribute("for"), "AssetAttributeUnits");
            Assert.AreEqual(attributeUnitsDropdownlistLabel.GetAttribute("class"),"form-label-default ");

            var AttributeUnitsDropdownlist = driver.FindElement(By.Id("AssetAttributeUnits"));
            Assert.IsTrue(AttributeUnitsDropdownlist.Enabled);
            Assert.IsTrue(AttributeUnitsDropdownlist.Displayed);
            Assert.AreEqual(AttributeUnitsDropdownlist.GetAttribute("class")," form-control");

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetAttributeUnits\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"No Units");

            var selectedAttributeUnitsDropdownlist = new SelectElement(AttributeUnitsDropdownlist);
            selectedAttributeUnitsDropdownlist.SelectByIndex(1);


            var AttributeDateTypeDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[3]/div/div/div/label"));
            Assert.IsTrue(AttributeDateTypeDropdownlistLabel.Enabled);
            Assert.IsTrue(AttributeDateTypeDropdownlistLabel.Displayed);
            Assert.AreEqual(AttributeDateTypeDropdownlistLabel.Text, "Attribute DataType");
            Assert.AreEqual(AttributeDateTypeDropdownlistLabel.GetAttribute("for"), "AssetAttributeDataType");
            Assert.AreEqual(AttributeDateTypeDropdownlistLabel.GetAttribute("class"), "form-label-default ");


            var AttributeDataTypeDropdownlist = driver.FindElement(By.Id("AssetAttributeDataType"));
            Assert.IsTrue(AttributeUnitsDropdownlist.Enabled);
            Assert.IsTrue(AttributeUnitsDropdownlist.Displayed);
            Assert.AreEqual(AttributeUnitsDropdownlist.GetAttribute("class"), " form-control");

            var selectedAttributeDataType = new SelectElement(AttributeDataTypeDropdownlist);
            selectedAttributeDataType.SelectByIndex(1);

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[4]/div/div/div/label"));
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("class"),"form-label-default ");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            Assert.AreEqual(descriptionInput.GetAttribute("maxlength"),"500");
            Assert.AreEqual(descriptionInput.GetAttribute("type"),"textarea");
            Assert.AreEqual(descriptionInput.GetAttribute("class")," form-control");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length-max"),"500");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length"), "The field Description must be a string with a maximum length of 500.");
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"),"submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void CreateAssetAttributesPage_DeleteIconTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var deleteIcon = driver.FindElement
               (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[2]"));
            Assert.IsTrue(deleteIcon.Enabled);
            Assert.IsTrue(deleteIcon.Displayed);
            Assert.IsTrue(deleteIcon.GetAttribute("onclick").Contains("deleteAssetAttribute"));
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");

            var DeleteIcon = driver.FindElement(By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[2]/i"));
            Assert.IsTrue(DeleteIcon.Enabled);
            Assert.IsTrue(DeleteIcon.Displayed);
            Assert.AreEqual(DeleteIcon.GetAttribute("class"), "fa fa-trash");
        }

        [Test]
        public void CreateAssetAttributesPage_DeleteIconFormTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[2]"));
            deleteIcon.Click();

            /////// swal modal is warning modal  ////////
            var swalModal = driver.FindElement(By.XPath("/html/body/div[4]/div"));
            Assert.IsTrue(swalModal.Enabled);
            Assert.IsTrue(swalModal.Displayed);
            Assert.AreEqual(swalModal.GetAttribute("role"), "dialog");
            Assert.AreEqual(swalModal.GetAttribute("class"), "swal-modal");

            var swalTitle = driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]"));
            Assert.IsTrue(swalTitle.Enabled);
            Assert.IsTrue(swalTitle.Displayed);
            Assert.AreEqual(swalTitle.Text, "Are you sure?");
            Assert.AreEqual(swalTitle.GetAttribute("class"), "swal-title");

            var swalIcon = driver.FindElement(By.XPath("/html/body/div[4]/div/div[1]"));
            Assert.IsTrue(swalIcon.Enabled);
            Assert.IsTrue(swalIcon.Displayed);
            Assert.AreEqual(swalIcon.GetAttribute("class"), "swal-icon swal-icon--warning");

            var yesBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div[3]/div[2]/button"));
            Assert.True(yesBtn.Enabled);
            Assert.True(yesBtn.Displayed);
            Assert.AreEqual(yesBtn.Text, "Yes");
            Assert.AreEqual(yesBtn.GetAttribute("class"), "swal-button swal-button--confirm");

            var cancelBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div[3]/div[1]/button"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "swal-button swal-button--cancel");
        }

        [Test]
        public void CreateAssetAttibutesPage_ViewIconTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var View = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[4]/td[4]/a[1]"));
            Assert.IsTrue(View.Enabled);
            Assert.IsTrue(View.Displayed);
            Assert.AreEqual(View.GetAttribute("title"),"View");

            var ViewIcon = driver.FindElement(By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[4]/td[4]/a[1]/i"));
            Assert.IsTrue(ViewIcon.Enabled);
            Assert.IsTrue(ViewIcon.Displayed);
            Assert.AreEqual(ViewIcon.GetAttribute("class"), "fa fa-eye");
        }


        /// <summary>
        ///  this method test all features in view page
        ///  when click on view icon will go to view page
        /// </summary>
        [Test]
        public void CreateAssetAttributesPage_ViewIcon_TestAllPage()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            // to click on view page 
            driver.Navigate().GoToUrlAsync("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetAttributes/Labels/");

            
            ///////// page sub title test /////////
            var subTitle = driver.FindElement
                   (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Asset Attribute Values");


            /////// Asset attibutes value navigation link test //////
            var assetAttributes = driver.FindElement(
                   By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(assetAttributes.Enabled);
            Assert.True(assetAttributes.Displayed);
            Assert.AreEqual(assetAttributes.Text, "Asset Attribute Values");
            Assert.AreEqual(assetAttributes.GetAttribute("class"), "m-nav__link-text");

            ////// seperator between navigation links test //////
            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");


            ////// back btn test ///////////////////
            var backBtn = driver.FindElement
               (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/p/a[1]"));
            Assert.True(backBtn.Enabled);
            Assert.True(backBtn.Displayed);
            Assert.AreEqual("Back", backBtn.Text);
            Assert.AreEqual(backBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");


            /////// cancel btn test /////////////////////
            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual("Create", createBtn.Text);
            Assert.AreEqual(createBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");
            
            
            /////////////// data table length test ////////////////
            var showLabel = driver.FindElement
            (By.XPath("//*[@id=\"AssetAttributesTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetAttributesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);


            /////////////// data table filter test //////////////
            var searchLabel = driver.FindElement
            (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);


            // reorder table test /////////
            var attributesCode = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[1]"));
            Assert.True(attributesCode.Enabled);
            Assert.True(attributesCode.Displayed);
            Assert.AreEqual(attributesCode.Text, "Attribute Code");
            Assert.AreEqual(attributesCode.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(attributesCode.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(attributesCode.GetAttribute("aria-controls"), "AssetAttributesTable");
            Assert.AreEqual(attributesCode.GetAttribute("aria-label"), "Attribute Code: activate to sort column descending");
            attributesCode.Click();

            var attributeValue = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[2]"));
            Assert.True(attributeValue.Enabled);
            Assert.True(attributeValue.Displayed);
            Assert.AreEqual(attributeValue.Text, "Attribute Value");
            Assert.AreEqual(attributeValue.GetAttribute("class"), "sorting");
            Assert.AreEqual(attributeValue.GetAttribute("aria-controls"), "AssetAttributesTable");
            Assert.AreEqual(attributeValue.GetAttribute("aria-label"), "Attribute Value: activate to sort column ascending");
            attributeValue.Click();

            var attributeShortValue = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[3]"));
            Assert.True(attributeShortValue.Enabled);
            Assert.True(attributeShortValue.Displayed);
            Assert.AreEqual(attributeShortValue.Text, "Attribute Short Value");
            Assert.AreEqual(attributeShortValue.GetAttribute("class"), "sorting");
            Assert.AreEqual(attributeShortValue.GetAttribute("aria-controls"), "AssetAttributesTable");
            Assert.AreEqual(attributeShortValue.GetAttribute("aria-label"), "Attribute Short Value: activate to sort column ascending");
            attributeShortValue.Click();

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[4]"));
            Assert.True(action.Enabled);
            Assert.True(action.Displayed);
            Assert.AreEqual(action.Text, "Actions");
            Assert.AreEqual(action.GetAttribute("aria-label"), "Actions");
            Assert.AreEqual(action.GetAttribute("class"), "sorting_disabled");


            ////// dashboard navigation link test /////////////////
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
        public void CreateAssetAttributesPage_PaginateTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var nextBtn = driver.FindElement(By.Id("AssetAttributesTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "AssetAttributesTable");
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetAttributesTable_previous"));
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.AreEqual(previoustBtn.GetAttribute("class"), "paginate_button previous disabled");
            Assert.AreEqual(previoustBtn.GetAttribute("aria-controls"),"AssetAttributesTable");
            previoustBtn.Click(); 

            var pages = driver.FindElements(By.XPath("AssetAttributesTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
            }
        }

        [Test]
        public void CreateAssetAttributesPage_DataTableInfoTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var tableInfo = driver.FindElement(By.Id("AssetAttributesTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void CreateAssetAttributesPage_CopyRightTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void CreateAssetAttributesPage_MinimizeToggleBtnTest()
        {
            // to open create asset attributes page
            CreateAssetAttributes_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
