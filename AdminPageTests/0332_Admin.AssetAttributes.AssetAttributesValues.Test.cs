using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminAssetAttributesAssetAttribuetValueTest : IDisposable
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
        public void AssetAttributeValuesPage_AdministratioOptionTest()
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
        public void AssetAttributeValuesPage_SetupOptionTest()
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
        public void AssetAttributeValuesPage_AssetAttributesOtionTest()
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
        public void AssetAttributeValuesPage_AssetAttributeValuesOptionTest()
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

            var assetAttributeValuesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[3]/a"));
            Assert.IsTrue(assetAttributeValuesOption.Enabled);
            Assert.IsTrue(assetAttributeValuesOption.Displayed);
            Assert.AreEqual(assetAttributeValuesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(assetAttributeValuesOption.GetAttribute("custom-data"), "Asset Attribute Values");
            Assert.AreEqual(assetAttributeValuesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetAttributeLabels");

            var AssetAttributeValuesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[3]/a/i"));
            Assert.IsTrue(AssetAttributeValuesOptionIcon.Enabled);
            Assert.IsTrue(AssetAttributeValuesOptionIcon.Displayed);
            Assert.AreEqual(AssetAttributeValuesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var AssetAttributeValuesOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[3]/a/span/span"));
            Assert.IsTrue(AssetAttributeValuesOptionTitle.Enabled);
            Assert.IsTrue(AssetAttributeValuesOptionTitle.Displayed);
            Assert.AreEqual(AssetAttributeValuesOptionTitle.Text, "Asset Attribute Values");
            Assert.AreEqual(AssetAttributeValuesOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetAttributesValuePage_OpenPage()
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

            var assetAttributeValuesOptions = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[3]/a/span"));
            assetAttributeValuesOptions.Click();
        }

        [Test]
        public void AssetAttributeValuesPage_TopBarUserNameTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

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
        public void AssetAttributeValuesPage_LogoutBtnTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

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
        public void AssetAttributeValuesPage_SubHeaderTitleTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Asset Attribute Values");
        }

        [Test]
        public void AssetAttributeValuesPage_DashboardNavigationLinkTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

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
        public void AssetAttributeValuesPage_AssetAttributeValuesNavigationLinkTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var AssetAttributeValuesBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(AssetAttributeValuesBtn.Enabled);
            Assert.True(AssetAttributeValuesBtn.Displayed);
            Assert.AreEqual(AssetAttributeValuesBtn.Text, "Asset Attribute Values");
            Assert.AreEqual(AssetAttributeValuesBtn.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void AssetAttributesValuePage_SeperatorBetweenNavigationLinksTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AssetAttributesValuesPage_DataTableLengthTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable_length\"]/label"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            Assert.True(showLabel.Text.Contains("Show"));
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetAtrributeLabelsTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetAttributeValuesPage_DataTableFilterTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");
            Assert.IsTrue(searchLabel.Displayed);

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
        }

        [Test]
        public void AssetAttributesValuesPage_CreateBtnTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
            Assert.AreEqual("Create", createBtn.Text);
            Assert.True(createBtn.Displayed);
            Assert.True(createBtn.Enabled);
        }

        [Test]
        public void AssetAttributesValuesPage_CreateFormTest()
        {
            // to open create form 
            AssetAttributesValuesPage_CreateBtnTest();

            var assetAttributeValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[1]/div/div/div/label"));
            assetAttributeValueLabel.Click();
            Assert.True(assetAttributeValueLabel.Enabled);
            Assert.True(assetAttributeValueLabel.Displayed);
            Assert.AreEqual(assetAttributeValueLabel.Text, "Asset Attribute Value");

            var assetAttributeValueInput = driver.FindElement(By.Id("AssetAttributeLabel"));
            var requiredField = assetAttributeValueInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetAttributeValueInput.Enabled);
            Assert.True(assetAttributeValueInput.Displayed);
            assetAttributeValueInput.SendKeys("Test Name");

            var assetAttributesDropdownlist = driver.FindElement(By.Id("department"));
            var selectedAssetAttributesValue = new SelectElement(assetAttributesDropdownlist);
            selectedAssetAttributesValue.SelectByIndex(1);
            

            var assetAttributesShowrtValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[2]/div/div/div/label"));
            assetAttributesShowrtValueLabel.Click();
            Assert.True(assetAttributesShowrtValueLabel.Enabled);
            Assert.True(assetAttributesShowrtValueLabel.Displayed);
            Assert.AreEqual(assetAttributesShowrtValueLabel.Text, "Asset Attribute Short Value");

            var assetAttributesShowrtValueInput = driver.FindElement(By.Id("AssetattributeShortLable"));
            Assert.True(assetAttributesShowrtValueInput.Enabled);
            Assert.True(assetAttributesShowrtValueInput.Displayed);
            assetAttributesShowrtValueInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetAttributesValuePage_ReOrderTableTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var assetAttributesValue = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[1]"));
            Assert.True(assetAttributesValue.Enabled);
            Assert.True(assetAttributesValue.Displayed);
            Assert.AreEqual(assetAttributesValue.GetAttribute("class"),"sorting_asc");
            Assert.AreEqual(assetAttributesValue.Text, "Asset Attribute Values");
            Assert.AreEqual(assetAttributesValue.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(assetAttributesValue.GetAttribute("aria-controls"), "AssetAtrributeLabelsTable");
            Assert.AreEqual(assetAttributesValue.GetAttribute("aria-label"), "Asset Attribute Values: activate to sort column descending");
            assetAttributesValue.Click();

            var assetAttribbutesShowrtValues = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[2]"));
            Assert.True(assetAttribbutesShowrtValues.Enabled);
            Assert.True(assetAttribbutesShowrtValues.Displayed);
            Assert.AreEqual(assetAttribbutesShowrtValues.GetAttribute("class"), "sorting");
            Assert.AreEqual(assetAttribbutesShowrtValues.Text, "Asset Attribute Short Value");
            Assert.AreEqual(assetAttribbutesShowrtValues.GetAttribute("aria-controls"), "AssetAtrributeLabelsTable");
            Assert.AreEqual(assetAttribbutesShowrtValues.GetAttribute("aria-label"), "Asset Attribute Short Value: activate to sort column ascending");
            assetAttribbutesShowrtValues.Click();

            var assetAttribuesName = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[3]"));
            Assert.True(assetAttribuesName.Enabled);
            Assert.True(assetAttribuesName.Displayed);
            Assert.AreEqual(assetAttribuesName.GetAttribute("class"),"sorting");
            Assert.AreEqual(assetAttribuesName.GetAttribute("aria-controls"), "AssetAtrributeLabelsTable");
            Assert.AreEqual(assetAttribuesName.GetAttribute("aria-label"), "Asset Attribute Name: activate to sort column ascending");
            Assert.AreEqual(assetAttribuesName.Text, "Asset Attribute Name");
            assetAttribuesName.Click();

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[4]"));
            Assert.True(action.Enabled);
            Assert.IsTrue(action.Displayed);
            Assert.AreEqual(action.Text, "Actions");
            Assert.AreEqual(action.GetAttribute("aria-label"),"Actions");
            Assert.AreEqual(action.GetAttribute("class"), "sorting_disabled");
        }

        [Test]
        public void AssetAttributesValuesPage_EditIconTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[1]"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.IsTrue(editIcon.GetAttribute("onclick").Contains("editAssetClass"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[1]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-edit");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void AssetAttributesValuePage_EditAssetIconTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();

            var assetAttributeValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[1]/div/div/div/label"));
            assetAttributeValueLabel.Click();
            Assert.True(assetAttributeValueLabel.Enabled);
            Assert.True(assetAttributeValueLabel.Displayed);
            Assert.AreEqual(assetAttributeValueLabel.Text, "Asset Attribute Value");

            var assetAttributeValueInput = driver.FindElement(By.Id("AssetAttributeLabel"));
            var requiredField = assetAttributeValueInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetAttributeValueInput.Enabled);
            Assert.True(assetAttributeValueInput.Displayed);
            assetAttributeValueInput.SendKeys("Test Name");

            var assetAttributesDropdownlist = driver.FindElement(By.Id("department"));
            var selectedAssetAttributesValue = new SelectElement(assetAttributesDropdownlist);
            selectedAssetAttributesValue.SelectByIndex(1);


            var assetAttributesShowrtValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[2]/div/div/div/label"));
            assetAttributesShowrtValueLabel.Click();
            Assert.True(assetAttributesShowrtValueLabel.Enabled);
            Assert.True(assetAttributesShowrtValueLabel.Displayed);
            Assert.AreEqual(assetAttributesShowrtValueLabel.Text, "Asset Attribute Short Value");

            var assetAttributesShowrtValueInput = driver.FindElement(By.Id("AssetattributeShortLable"));
            Assert.True(assetAttributesShowrtValueInput.Enabled);
            Assert.True(assetAttributesShowrtValueInput.Displayed);
            assetAttributesShowrtValueInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetAttributesValuesPage_DeleteIconTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var deleteIcon = driver.FindElement
              (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[2]"));
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            Assert.AreEqual("Delete", deleteIcon.GetAttribute("title"));
            Assert.IsTrue(deleteIcon.GetAttribute("onclick").Contains("deleteAssetAttributeValue"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[2]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-trash");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        // this method test delete asset windows
        [Test]
        public void AssetAttributesValuesPage_DeleteIConFormTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[2]"));
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
        public void AssetAttributesValuesPage_PaginationTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("AssetAtrributeLabelsTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetAtrributeLabelsTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();

            var pages = driver.FindElements(By.XPath("AssetAtrributeLabelsTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void AssetAttributeValuessPage_DataTableInfoTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("AssetAtrributeLabelsTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void AssetAttributeValuesPage_CopyRightTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void AssetAttributeValuesPage_MinimizeToggleBtnTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
