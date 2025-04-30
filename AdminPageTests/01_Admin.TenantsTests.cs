using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminTenantsTests : IDisposable
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
        public void TenantsPage_TenantsOptionTest()
        {
            var tenantsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a"));
            Assert.IsTrue(tenantsOption.Enabled);
            Assert.IsTrue(tenantsOption.Displayed);
            Assert.AreEqual(tenantsOption.Text,"Tenants");
            Assert.AreEqual(tenantsOption.GetAttribute("target"),"_self");
            Assert.AreEqual(tenantsOption.GetAttribute("custom-data"), "Tenants");
            Assert.AreEqual(tenantsOption.GetAttribute("href"), 
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Tenants");

            string Icon = "m-menu__link-icon flaticon-suitcase";
            var tenantsOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/i"));
            Assert.IsTrue(tenantsOptionIcon.Enabled);
            Assert.IsTrue(tenantsOptionIcon.Displayed);
            Assert.AreEqual(tenantsOptionIcon.GetAttribute("class"), Icon);

            var tenantsOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/span/span"));
            Assert.IsTrue(tenantsOptionTitle.Enabled);
            Assert.IsTrue(tenantsOptionTitle.Displayed);
            Assert.AreEqual(tenantsOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void TenantsPage_OpenPage()
        {
            var TenantsBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/span/span"));
            TenantsBtn.Click();
        }

        [Test]
        public void TenantsPage_TopBarUserNameTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

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
        public void TenantsPage_LogoutBtnTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

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
        public void TenantsPage_SubHeaderTitleTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var subTitle = driver.FindElement
            (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Tenants");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void TenantsPage_DashboardNavigationLinkTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var dashboardNavLink = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.True(dashboardNavLink.Enabled);
            Assert.True(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");

            var urlBeforeClick = driver.Url;
            dashboardNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick, urlBeforeClick);
        }

        [Test]
        public void TenantsPage_TenantsNavigationLinkTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var tenantsNavLink = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(tenantsNavLink.Enabled);
            Assert.True(tenantsNavLink.Displayed);
            Assert.AreEqual(tenantsNavLink.Text, "Tenants");
            Assert.AreEqual(tenantsNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void TenantsPage_SeperatorBetweenNavigationLinksTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.Text, ">");
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void TenantsPage_DataTableLengthTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable_length\"]/label"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            Assert.True(showLabel.Text.Contains("Show"));
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("TenantTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            Assert.AreEqual(showValue.GetAttribute("aria-controls"), "TenantTable");

            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void TenantsPage_DataTableFilterTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var searchLabel = driver.FindElement
               (By.XPath("//*[@id=\"TenantTable_filter\"]/label"));
            searchLabel.Click();
            Assert.IsTrue(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("type"), "search");
            Assert.AreEqual(searchInput.GetAttribute("aria-controls"), "TenantTable");
        }

        [Test]
        public void TenantsPage_CreateBtnTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual(createBtn.Text, "Create");
            Assert.AreEqual(createBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");
        }

        [Test]
        public void TenantsPage_CreateFormTest()
        {

            // to open tenants page 
            TenantsPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();

            var TenancyNameLabel = driver.FindElement
             (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/label"));
            Assert.True(TenancyNameLabel.Enabled);
            Assert.IsTrue(TenancyNameLabel.Displayed);
            Assert.AreEqual(TenancyNameLabel.Text, "Tenancy name");
            Assert.AreEqual(TenancyNameLabel.GetAttribute("class"), "form-label");
            TenancyNameLabel.Click();

            var TenancyNameInput = driver.FindElement(By.Name("TenancyName"));
            Assert.True(TenancyNameInput.Enabled);
            Assert.True(TenancyNameInput.Displayed);
            Assert.AreEqual(TenancyNameInput.GetAttribute("minlength"), "2");
            Assert.AreEqual(TenancyNameInput.GetAttribute("maxlength"), "64");
            Assert.AreEqual(TenancyNameInput.GetAttribute("required"), "true");
            Assert.AreEqual(TenancyNameInput.GetAttribute("class"), "form-control");
            TenancyNameInput.SendKeys("tenency Name Test");

            var NameLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/label"));
            Assert.True(NameLabel.Enabled);
            Assert.True(NameLabel.Displayed);
            Assert.AreEqual(NameLabel.Text, "Name");
            Assert.AreEqual(NameLabel.GetAttribute("class"), "form-label");
            NameLabel.Click();

            var NameInput = driver.FindElement(By.Name("Name"));
            Assert.True(NameInput.Enabled);
            Assert.True(NameInput.Displayed);
            Assert.AreEqual(NameInput.GetAttribute("type"), "text");
            Assert.AreEqual(NameInput.GetAttribute("maxlength"), "128");
            Assert.AreEqual(NameInput.GetAttribute("required"), "true");
            NameInput.SendKeys("Name Test");

            var TierDropsownlistLabel = driver.FindElement(By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[3]/div/label"));
            Assert.IsTrue(TierDropsownlistLabel.Enabled);
            Assert.IsTrue(TierDropsownlistLabel.Displayed);
            Assert.AreEqual(TierDropsownlistLabel.Text, "Tier");
            Assert.AreEqual(TierDropsownlistLabel.GetAttribute("class"), "form-label");

            var Tier = driver.FindElement(By.Name("Tier"));
            Assert.IsTrue(Tier.Enabled);
            Assert.IsTrue(Tier.Displayed);
            Assert.AreEqual(Tier.GetAttribute("required"), "true");
            Assert.AreEqual(Tier.GetAttribute("class"), "form-control tier");

            var selectedTier = new SelectElement(Tier);
            selectedTier.SelectByIndex(0);

            var IsActiveLabel = driver.FindElement(By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/div/label"));
            Assert.IsTrue(IsActiveLabel.Enabled);
            Assert.IsTrue(IsActiveLabel.Displayed);
            Assert.AreEqual(IsActiveLabel.Text, "Is Active");
            Assert.AreEqual(IsActiveLabel.GetAttribute("for"), "isactive");
            Assert.AreEqual(IsActiveLabel.GetAttribute("class"), "form-label");

            var IsActiveInput = driver.FindElement(By.Id("isactive"));
            IsActiveInput.Click();
            Assert.IsTrue(IsActiveInput.Enabled);
            Assert.IsTrue(IsActiveInput.Displayed);
            Assert.AreEqual(IsActiveInput.GetAttribute("type"), "checkbox");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        // this methode test all features for each cloumn in table 
        [Test]
        public void TenantsPageTest_TenantsTableTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var tableColumns = driver.FindElements(By.Id("TenantTable"));
            foreach(var column in tableColumns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var TenancyName = driver.FindElement(By.XPath("//*[@id=\"TenantTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(TenancyName.Enabled);
            Assert.IsTrue(TenancyName.Displayed);
            Assert.AreEqual(TenancyName.Text,"Tenancy name");
            Assert.AreEqual(TenancyName.GetAttribute("class"), "sorting");
            Assert.AreEqual(TenancyName.GetAttribute("aria-controls"), "TenantTable");
            Assert.AreEqual(TenancyName.GetAttribute("aria-label"), "Tenancy name: activate to sort column ascending");

            var Name = driver.FindElement(By.XPath("//*[@id=\"TenantTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(Name.Enabled);
            Assert.IsTrue(Name.Displayed);
            Assert.AreEqual(Name.Text, "Name");
            Assert.AreEqual(Name.GetAttribute("class"), "sorting");
            Assert.AreEqual(Name.GetAttribute("aria-controls"), "TenantTable");
            Assert.AreEqual(Name.GetAttribute("aria-label"), "Name: activate to sort column ascending");

            var Tier = driver.FindElement(By.XPath("//*[@id=\"TenantTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(Tier.Enabled);
            Assert.IsTrue(Tier.Displayed);
            Assert.AreEqual(Tier.Text, "Tier");
            Assert.AreEqual(Tier.GetAttribute("class"), "sorting");
            Assert.AreEqual(Tier.GetAttribute("aria-controls"), "TenantTable");
            Assert.AreEqual(Tier.GetAttribute("aria-label"), "Tier: activate to sort column ascending");

            var isActive = driver.FindElement(By.XPath("//*[@id=\"TenantTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(isActive.Enabled);
            Assert.IsTrue(isActive.Displayed);
            Assert.AreEqual(isActive.Text, "Is Active");
            Assert.AreEqual(isActive.GetAttribute("aria-label"), "Is Active");
            Assert.AreEqual(isActive.GetAttribute("class"), "sorting_disabled");

            var actions = driver.FindElement(By.XPath("//*[@id=\"TenantTable\"]/thead/tr/th[6]"));
            Assert.IsTrue(actions.Enabled);
            Assert.IsTrue(actions.Displayed);
            Assert.AreEqual(actions.Text, "Actions");
            Assert.AreEqual(actions.GetAttribute("aria-controls"), "TenantTable");
            Assert.AreEqual(actions.GetAttribute("aria-label"), "Actions: activate to sort column ascending");
        }

        [Test]
        public void TenantsPage_EditIconTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();
            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[5]/td[6]/a[1]"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);
            Assert.AreEqual(editIcon.GetAttribute("title"), "Edit");
            Assert.IsTrue(editIcon.GetAttribute("onclick").Contains("createOrEditModal"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[6]/a[1]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-edit");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void TenentsPage_EditIconFormTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();
            
            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[5]/td[6]/a[1]"));
            editIcon.Click();

            var TenancyNameLabel = driver.FindElement
             (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/label"));
            Assert.True(TenancyNameLabel.Enabled);
            Assert.IsTrue(TenancyNameLabel.Displayed);
            Assert.AreEqual(TenancyNameLabel.Text, "Tenancy name");
            Assert.AreEqual(TenancyNameLabel.GetAttribute("class"),"form-label");
            TenancyNameLabel.Click();

            var TenancyNameInput = driver.FindElement(By.Name("TenancyName"));
            Assert.True(TenancyNameInput.Enabled);
            Assert.True(TenancyNameInput.Displayed);
            Assert.AreEqual(TenancyNameInput.GetAttribute("minlength"), "2");
            Assert.AreEqual(TenancyNameInput.GetAttribute("maxlength"), "64");
            Assert.AreEqual(TenancyNameInput.GetAttribute("required"), "true");
            Assert.AreEqual(TenancyNameInput.GetAttribute("class"), "form-control");
            TenancyNameInput.SendKeys("tenency Name Test");

            var NameLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/label"));
            Assert.True(NameLabel.Enabled);
            Assert.True(NameLabel.Displayed);
            Assert.AreEqual(NameLabel.Text, "Name");
            Assert.AreEqual(NameLabel.GetAttribute("class"),"form-label");
            NameLabel.Click();

            var NameInput = driver.FindElement(By.Name("Name"));
            Assert.True(NameInput.Enabled);
            Assert.True(NameInput.Displayed);
            Assert.AreEqual(NameInput.GetAttribute("type"), "text");
            Assert.AreEqual(NameInput.GetAttribute("maxlength"),"128");
            Assert.AreEqual(NameInput.GetAttribute("required"), "true");
            NameInput.SendKeys("Name Test");

            var TierDropsownlistLabel = driver.FindElement(By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[3]/div/label"));
            Assert.IsTrue(TierDropsownlistLabel.Enabled);
            Assert.IsTrue(TierDropsownlistLabel.Displayed);
            Assert.AreEqual(TierDropsownlistLabel.Text,"Tier");
            Assert.AreEqual(TierDropsownlistLabel.GetAttribute("class"), "form-label");

            var Tier = driver.FindElement(By.Name("Tier"));
            Assert.IsTrue(Tier.Enabled);
            Assert.IsTrue(Tier.Displayed);
            Assert.AreEqual(Tier.GetAttribute("required"), "true");
            Assert.AreEqual(Tier.GetAttribute("class"), "form-control tier");

            var selectedTier = new SelectElement(Tier);
            selectedTier.SelectByIndex(0);

            var IsActiveLabel = driver.FindElement(By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/div/label"));
            Assert.IsTrue(IsActiveLabel.Enabled);
            Assert.IsTrue(IsActiveLabel.Displayed);
            Assert.AreEqual(IsActiveLabel.Text, "Is Active");
            Assert.AreEqual(IsActiveLabel.GetAttribute("for"), "isactive");
            Assert.AreEqual(IsActiveLabel.GetAttribute("class"), "form-label");

            var IsActiveInput = driver.FindElement(By.Id("isactive"));
            IsActiveInput.Click();
            Assert.IsTrue(IsActiveInput.Enabled);
            Assert.IsTrue(IsActiveInput.Displayed);
            Assert.AreEqual(IsActiveInput.GetAttribute("type"), "checkbox");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"),"submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void TenantsPage_DeleteIconTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[6]/a[2]"));
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            Assert.AreEqual("Delete", deleteIcon.GetAttribute("title"));
            Assert.IsTrue(deleteIcon.GetAttribute("onclick").Contains("deleteTenant"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[6]/a[2]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-trash");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void TenentsPage_DeleteIConTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[6]/a[2]"));
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
                (By.XPath("/html/body/div[4]/div/div[4]/div[2]/button"));
            Assert.True(yesBtn.Enabled);
            Assert.True(yesBtn.Displayed);
            Assert.AreEqual(yesBtn.Text, "Yes");
            Assert.AreEqual(yesBtn.GetAttribute("class"), "swal-button swal-button--confirm");

            var cancelBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div[4]/div[1]/button"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "swal-button swal-button--cancel");
        }

        [Test]
        public void TenantsPage_UserLoginIconTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var loginUserIcon = driver.FindElement
               (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[1]/a"));
            Assert.IsTrue(loginUserIcon.Enabled);
            Assert.IsTrue(loginUserIcon.Displayed);
            Assert.AreEqual(loginUserIcon.GetAttribute("title"),"User Login");
            Assert.IsTrue(loginUserIcon.GetAttribute("onclick").Contains("lookupModal"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[1]/a/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-cog");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }


        // this method contains code for test user login model 
        // all features in user login form or page are tested in this code 
        [Test]
        public void TenantsPage_UserLoginIconFormTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var LoginUserIcon = driver.FindElement
               (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[1]/a"));
            LoginUserIcon.Click();

            var modalTitle = driver.FindElement
                (By.XPath("//*[@id=\"UserModal\"]/div/div/div[1]"));
            Assert.IsTrue(modalTitle.Enabled);
            Assert.IsTrue(modalTitle.Displayed);
            Assert.AreEqual(modalTitle.Text, "Select a user");
            Assert.AreEqual(modalTitle.GetAttribute("class"), "modal-header");


            //// data table length test
            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"UserTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("UserTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);


            /////// data tabel filter ///////////
            var searchLabel = driver.FindElement
               (By.XPath("//*[@id=\"UserTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"UserTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed); 


            ///// table test /////
            var Select = driver.FindElement(By.XPath("//*[@id=\"UserTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(Select.Enabled);
            Assert.IsTrue(Select.Displayed);
            Assert.AreEqual(Select.GetAttribute("class"),"sorting_asc");
            Assert.AreEqual(Select.GetAttribute("aria-controls"), "UserTable");
            Assert.AreEqual(Select.GetAttribute("aria-label"), "Select: activate to sort column descending");

            var Name = driver.FindElement(By.XPath("//*[@id=\"UserTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(Name.Enabled);
            Assert.IsTrue(Name.Displayed);
            Assert.AreEqual(Name.GetAttribute("class"), "sorting");
            Assert.AreEqual(Name.GetAttribute("aria-controls"), "UserTable");
            Assert.AreEqual(Name.GetAttribute("aria-label"), "Name: activate to sort column ascending");

            var Roles = driver.FindElement(By.XPath("//*[@id=\"UserTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(Roles.Enabled);
            Assert.IsTrue(Roles.Displayed);
            Assert.AreEqual(Roles.GetAttribute("class"), "sorting");
            Assert.AreEqual(Roles.GetAttribute("aria-controls"), "UserTable");
            Assert.AreEqual(Roles.GetAttribute("aria-label"), "Roles: activate to sort column ascending");


            //// paginate test /////
            var PrevisouBtn = driver.FindElement(By.Id("UserTable_previous"));
            Assert.True(PrevisouBtn.Enabled);
            Assert.True(PrevisouBtn.Displayed);
            Assert.AreEqual(PrevisouBtn.Text, "Previous");
            Assert.AreEqual(PrevisouBtn.GetAttribute("class"), "paginate_button previous disabled");
            Assert.AreEqual(PrevisouBtn.GetAttribute("aria-controls"), "UserTable");
            PrevisouBtn.Click();

            var nextBtn = driver.FindElement(By.Id("UserTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "UserTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var pages = driver.FindElements(By.Id("UserTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }


            //// table information Test /////
            var tableInfo = driver.FindElement(By.Id("TenantTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");


            ///// close Icon Test
            var CloseBtn = driver.FindElement(By.Id("closeButton"));
            Assert.True(CloseBtn.Enabled);
            Assert.True(CloseBtn.Displayed);
            Assert.AreEqual(CloseBtn.GetAttribute("class"),"close");
            Assert.AreEqual(CloseBtn.GetAttribute("type"),"button");

            var Icon = driver.FindElement(By.XPath("//*[@id=\"closeButton\"]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-times");
        }

        [Test]
        public void TenantsPage_PaginateTest()
        {
            // to open Tenants Page 
            TenantsPage_OpenPage();

            var PrevisouBtn = driver.FindElement(By.Id("TenantTable_previous"));
            Assert.True(PrevisouBtn.Enabled);
            Assert.True(PrevisouBtn.Displayed);
            Assert.AreEqual(PrevisouBtn.Text, "Previous");
            Assert.AreEqual(PrevisouBtn.GetAttribute("aria-controls"), "TenantTable");
            Assert.AreEqual(PrevisouBtn.GetAttribute("class"), "paginate_button previous disabled");
            PrevisouBtn.Click();

            var nextBtn = driver.FindElement(By.Id("TenantTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "TenantTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var pages = driver.FindElements(By.Id("TenantTable_paginate"));
            foreach (var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void TenantsPage_DataTableInfoTest()
        {
            // to open Tenants page 
            TenantsPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("TenantTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void TenantsPage_CopyRightTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
        [Test]
        public void TenantsPage_MinimizeToggleBtnTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
