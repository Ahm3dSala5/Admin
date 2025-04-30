using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminAdminstrationOrgnizationTypeTest : IDisposable
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
        public void OrgnizationTypesPage_AdministratioOptionTest()
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
        public void OrgnizationTypesPage_SetupOptionTest()
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
        public void OrgnizationTypesPage_OrgnizationTypesOptionsTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var orgnizationTypesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[5]/a"));
            Assert.IsTrue(orgnizationTypesOption.Enabled);
            Assert.AreEqual(orgnizationTypesOption.GetAttribute("target"),"_self");
            Assert.AreEqual(orgnizationTypesOption.GetAttribute("custom-data"), "Organization Types");
            Assert.AreEqual(orgnizationTypesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(orgnizationTypesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/OrganizationTypes");

            var orgnizationTypesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[5]/a/i"));
            Assert.IsTrue(orgnizationTypesOptionIcon.Enabled);
            Assert.IsTrue(orgnizationTypesOptionIcon.Displayed);
            Assert.AreEqual(orgnizationTypesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var orgnizationTypesOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[5]/a/span/span"));
            Assert.IsTrue(orgnizationTypesOptionTitle.Enabled);
            Assert.IsTrue(orgnizationTypesOptionTitle.Displayed);
            Assert.AreEqual(orgnizationTypesOptionTitle.Text, "Organization Types");
            Assert.AreEqual(orgnizationTypesOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void OrginizationTypesPage_OpenPage()
        {
            var administrationOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var orgnizationTypesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[5]/a"));
            orgnizationTypesOption.Click();
        }

        [Test]
        public void OrgnizationTypesPage_TopBarUserNameTest()
        {
            // to open asset Orgnization Types page
            OrginizationTypesPage_OpenPage();

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
        public void OrgnizationTypesPage_LogoutBtnTest()
        {
            // to open asset Orgnization Types page
            OrginizationTypesPage_OpenPage();

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
        public void OrgnizationTypesPage_SubHeaderTitleTest()
        {
            // to open asset Orgnization Types page
            OrginizationTypesPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Organization Types");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void OrgnizationTypesPage_DashboardNavigationLinkTest()
        {
            // to open asset Orgnization Types page
            OrginizationTypesPage_OpenPage();

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
        public void OrgnizationTypesPage_OrgnizationTypesNavigationLinkTest()
        {
            // to open asset Orgnization Types page
            OrginizationTypesPage_OpenPage();

            var OrgnizationTypesBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(OrgnizationTypesBtn.Enabled);
            Assert.True(OrgnizationTypesBtn.Displayed);
            Assert.AreEqual(OrgnizationTypesBtn.Text, "Organization Types");
            Assert.AreEqual(OrgnizationTypesBtn.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void OrgnizationTypesPage_SeperatorBetweenNavigationLinksTest()
        {
            // to open asset Orgnization Types page
            OrginizationTypesPage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.Text,">");
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void OrgnizationTypePage_DataTableLengthTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable_length\"]/label"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            Assert.True(showLabel.Text.Contains("Show"));
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("OrganizationTypesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            Assert.AreEqual(showValue.GetAttribute("aria-controls"), "OrganizationTypesTable");

            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void OrginizationTypesPage_DataTableFilterTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_filter\"]/label/input"));
            searchInput.SendKeys("Test");
            Assert.True(searchInput.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("type"), "Search");
            Assert.AreEqual(searchInput.GetAttribute("aria-controls"), "OrganizationTypesTable");
        }

        [Test]
        public void OrgnizationTypePage_CreateBtnTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual(createBtn.Text, "Create");
            Assert.AreEqual(createBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");
            createBtn.Click();
        }

        [Test]
        public void OrgnizationTypePage_CreateFormTest()
        {
            // to open create form 
            OrgnizationTypePage_CreateBtnTest();

            var orgnizationTypeLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/div/div/label"));
            orgnizationTypeLabel.Click();
            Assert.True(orgnizationTypeLabel.Enabled);
            Assert.True(orgnizationTypeLabel.Displayed);
            Assert.AreEqual(orgnizationTypeLabel.Text, "Organization Type");
            Assert.AreEqual(orgnizationTypeLabel.GetAttribute("for"), "OrganizationType");
            Assert.AreEqual(orgnizationTypeLabel.GetAttribute("class"), "form-label");

            var orgnizationTypeInput = driver.FindElement(By.Id("OrgType"));
            Assert.True(orgnizationTypeInput.Enabled);
            Assert.True(orgnizationTypeInput.Displayed);
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("type"), "text");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("maxlength"), "255");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("data-val-length-max"), "255");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("class"), "validate form-control");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("data-val-required"), "The OrgType field is required.");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("data-val-length"), "The field OrgType must be a string with a maximum length of 255.");
            orgnizationTypeInput.SendKeys("Test Name");


            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("class"), "form-label-default ");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");
            Assert.AreEqual(descriptionInput.GetAttribute("type"), "textarea");
            Assert.AreEqual(descriptionInput.GetAttribute("maxlength"), "500");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length-max"), "500");
            Assert.AreEqual(descriptionInput.GetAttribute("class"), "validate form-control");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length"), "The field Description must be a string with a maximum length of 500.");

            var IsActiveLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[3]/div/div/div/label"));
            Assert.AreEqual(IsActiveLabel.Text, "Is Active");
            Assert.True(IsActiveLabel.Enabled);
            Assert.True(IsActiveLabel.Displayed);
            Assert.AreEqual(IsActiveLabel.GetAttribute("for"), "IsActive");
            Assert.AreEqual(IsActiveLabel.GetAttribute("class"), "custom-control-label");

            var isActiveValue = driver.FindElement(By.Id("IsActive"));
            Assert.IsTrue(isActiveValue.Enabled);
            Assert.AreEqual(isActiveValue.GetAttribute("type"), "checkbox");
            Assert.AreEqual(isActiveValue.GetAttribute("class"), "custom-control-input form-control");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void OrgnizationTypePage_OrgnizationTypesTableTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var tableColumns = driver.FindElements(By.Id("OrganizationTypesTable"));
            foreach(var column in tableColumns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var orgnizationType = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[1]"));
            Assert.True(orgnizationType.Enabled);
            Assert.True(orgnizationType.Displayed);
            Assert.AreEqual(orgnizationType.Text, "Organization Type");
            Assert.AreEqual(orgnizationType.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(orgnizationType.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(orgnizationType.GetAttribute("aria-controls"), "OrganizationTypesTable");
            Assert.AreEqual(orgnizationType.GetAttribute("aria-label"), "Organization Type: activate to sort column descending");
            orgnizationType.Click();

            var description = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[2]"));
            Assert.True(description.Enabled);
            Assert.True(description.Displayed);
            Assert.AreEqual(description.Text, "Description");
            Assert.AreEqual(description.GetAttribute("class"), "sorting");
            Assert.AreEqual(description.GetAttribute("aria-controls"), "OrganizationTypesTable");
            Assert.AreEqual(description.GetAttribute("aria-label"), "Description: activate to sort column ascending");
            description.Click();

            var Active = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[3]"));
            Assert.True(Active.Enabled);
            Assert.True(Active.Displayed);
            Assert.AreEqual(Active.Text, "Active?");
            Assert.AreEqual(Active.GetAttribute("aria-label"),"Active?");
            Assert.AreEqual(Active.GetAttribute("class"), "sorting_disabled");
            Active.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[4]"));
            Assert.True(Actions.Enabled);
            Assert.IsTrue(Actions.Displayed);
            Assert.AreEqual(Actions.Text, "Actions");
            Assert.AreEqual(Actions.GetAttribute("class"),"sorting");
            Assert.AreEqual(Actions.GetAttribute("aria-controls"), "OrganizationTypesTable");
            Assert.AreEqual(Actions.GetAttribute("aria-label"), "Actions: activate to sort column ascending");
        }

        [Test]
        public void OrgnizationTypesPage_EditIconTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var editIcon = driver.FindElement
               (By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[1]"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.IsTrue(editIcon.GetAttribute("onclick").Contains("editOrganizationType"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[1]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-edit");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void OrgnizationTypePage_EditIconFormTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();

            var orgnizationTypeLabel = driver.FindElement
               (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/div/div/label"));
            orgnizationTypeLabel.Click();
            Assert.True(orgnizationTypeLabel.Enabled);
            Assert.True(orgnizationTypeLabel.Displayed);
            Assert.AreEqual(orgnizationTypeLabel.Text, "Organization Type");
            Assert.AreEqual(orgnizationTypeLabel.GetAttribute("for"), "OrganizationType");
            Assert.AreEqual(orgnizationTypeLabel.GetAttribute("class"), "form-label");

            var orgnizationTypeInput = driver.FindElement(By.Id("OrgType"));
            Assert.True(orgnizationTypeInput.Enabled);
            Assert.True(orgnizationTypeInput.Displayed);
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("type"),"text");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("maxlength"),"255");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("data-val-length-max"),"255");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("class"),"validate form-control");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("data-val-required"), "The OrgType field is required.");
            Assert.AreEqual(orgnizationTypeInput.GetAttribute("data-val-length"), "The field OrgType must be a string with a maximum length of 255.");
            orgnizationTypeInput.SendKeys("Test Name");


            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("class"), "form-label-default ");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");
            Assert.AreEqual(descriptionInput.GetAttribute("type"), "textarea");
            Assert.AreEqual(descriptionInput.GetAttribute("maxlength"), "500");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length-max"), "500");
            Assert.AreEqual(descriptionInput.GetAttribute("class"), "validate form-control");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length"), "The field Description must be a string with a maximum length of 500.");
          
            var IsActiveLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[3]/div/div/div/label"));
            Assert.AreEqual(IsActiveLabel.Text, "Is Active");
            Assert.True(IsActiveLabel.Enabled);
            Assert.True(IsActiveLabel.Displayed);
            Assert.AreEqual(IsActiveLabel.GetAttribute("for"),"IsActive");
            Assert.AreEqual(IsActiveLabel.GetAttribute("class"), "custom-control-label");

            var isActiveValue = driver.FindElement(By.Id("IsActive"));
            Assert.IsTrue(isActiveValue.Enabled);
            //Assert.IsTrue(isActiveValue.Displayed);
            Assert.AreEqual(isActiveValue.GetAttribute("type"),"checkbox");
            Assert.AreEqual(isActiveValue.GetAttribute("class"), "custom-control-input form-control");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void OrgnizationTypesPage_DeleteIconTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var deleteIcon = driver.FindElement
             (By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[2]"));
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            Assert.AreEqual("Delete", deleteIcon.GetAttribute("title"));
            Assert.IsTrue(deleteIcon.GetAttribute("onclick").Contains("deleteOrganizationType"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[2]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-trash");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void OrgnizationTypePage_DeleteIConFormTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[2]"));
            deleteIcon.Click();

            /////// swal modal is warning modal  ////////
            var swalModal = driver.FindElement(By.XPath("/html/body/div[4]/div"));
            Assert.IsTrue(swalModal.Enabled);
            Assert.IsTrue(swalModal.Displayed);
            Assert.AreEqual(swalModal.GetAttribute("role"),"dialog");
            Assert.AreEqual(swalModal.GetAttribute("class"),"swal-modal");

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
        public void OrgnizationTypePage_PaginationTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("OrganizationTypesTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "OrganizationTypesTable");
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("OrganizationTypesTable_previous"));
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.AreEqual(previoustBtn.GetAttribute("aria-controls"), "OrganizationTypesTable");
            Assert.AreEqual(previoustBtn.GetAttribute("class"), "paginate_button previous disabled");
            previoustBtn.Click();

            var pages = driver.FindElements(By.Id("OrganizationTypesTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void OrginizationTypesPage_DataTableInfoTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("OrganizationTypesTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void OrginizationTypesPage_CopyRightTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void OrginizationTypesPage_MinimizeToggleBtnTest()
        {
            // to open orgnization type page
            OrginizationTypesPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
