using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAdministrationRolesTests : IDisposable
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
        public void Roles_AdministratioOptionTest()
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
        public void UsersPage_UserOptionTest()
        {
            var administrationOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var rolesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[3]/a"));
            Assert.IsTrue(rolesOption.Enabled);
            Assert.IsTrue(rolesOption.Displayed);
            Assert.AreEqual(rolesOption.Text, "Roles");
            Assert.AreEqual(rolesOption.GetAttribute("custom-data"), "Roles");
            Assert.AreEqual(rolesOption.GetAttribute("target"), "_self");
            Assert.AreEqual(rolesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(rolesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Roles");

            var rolesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[3]/a/i"));
            Assert.IsTrue(rolesOptionIcon.Enabled);
            Assert.IsTrue(rolesOptionIcon.Displayed);
            Assert.AreEqual(rolesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-map");

            var rolesOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[3]/a/span/span"));
            Assert.IsTrue(rolesOptionTitle.Enabled);
            Assert.IsTrue(rolesOptionTitle.Displayed);
            Assert.AreEqual(rolesOptionTitle.Text, "Roles");
            Assert.AreEqual(rolesOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void RolesPage_OpenPage()
        {
            var administrationBtn = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationBtn.Click();

            var rolesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[3]/a"));
            rolesOption.Click();
        }

        [Test]
        public void RolesPage_SubHeaderTitleTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));
            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text,"Roles");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void RolesPage_TopBarUserNameTest()
        {
            // to open roles page
            RolesPage_OpenPage();

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
        public void RolesPage_LogoutBtnTest()
        {
            // to open Roles page
            RolesPage_OpenPage();

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
        public void RolesPage_DashboardNavigationLinkTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text,"Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            dashboardNavLink.Click();
            var UrlAfterCkick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick,UrlAfterCkick);
        }

        [Test]
        public void RolesPage_RolesNavigationLinkTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var rolesNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.True(rolesNavLink.Displayed);
            Assert.True(rolesNavLink.Enabled);
            Assert.AreEqual(rolesNavLink.Text,"Roles");
            Assert.AreEqual(rolesNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClickOnRolesBtn = driver.Url;
            rolesNavLink.Click();
            var UrlAfterClickOnRolesBtn = driver.Url;
            Assert.AreEqual(UrlAfterClickOnRolesBtn,UrlAfterClickOnRolesBtn);
        }

        [Test]
        public void RolesPage_SeperatorBetweenNavLinksTest()
        {
            // to open create form 
            RolesPage_CreateBtnTest();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void RolesPage_CreateBtnTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreateRoles"));
            createBtn.Click();
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual(createBtn.Text, "Create");
            Assert.AreEqual(createBtn.GetAttribute("type"), "button");
            Assert.AreEqual(createBtn.GetAttribute("data-target"), "#RoleCreateModal");
            Assert.AreEqual(createBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");
        }

        [Test]
        public void RolesPage_CreateFormTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreateRoles"));
            createBtn.Click();

            var roleNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[1]/div/div/div/label"));
            roleNameLabel.Click();
            Assert.True(roleNameLabel.Enabled);
            Assert.True(roleNameLabel.Displayed);
            Assert.AreEqual(roleNameLabel.Text, "Role Name");
            Assert.AreEqual(roleNameLabel.GetAttribute("for"),"rolename");
            Assert.AreEqual(roleNameLabel.GetAttribute("class"),"form-label");

            var roleNameInpout = driver.FindElement(By.Id("rolename"));
            Assert.IsTrue(roleNameInpout.Enabled);
            Assert.IsTrue(roleNameInpout.Displayed);
            roleNameInpout.SendKeys("Test Role Name");
            Assert.AreEqual(roleNameInpout.GetAttribute("type"),"text");
            Assert.AreEqual(roleNameInpout.GetAttribute("minlength"),"2");
            Assert.AreEqual(roleNameInpout.GetAttribute("maxlength"),"32");
            Assert.AreEqual(roleNameInpout.GetAttribute("required"),"true");
            Assert.AreEqual(roleNameInpout.GetAttribute("class"),"validate form-control");

            var displayNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[2]/div/div/div/label"));
            displayNameLabel.Click();
            Assert.True(displayNameLabel.Enabled);
            Assert.True(displayNameLabel.Displayed);
            Assert.AreEqual(displayNameLabel.Text, "Display Name");
            Assert.AreEqual(displayNameLabel.GetAttribute("for"),"displayname");
            Assert.AreEqual(displayNameLabel.GetAttribute("class"),"form-label");

            var displayNameInput = driver.FindElement(By.Id("displayname"));
            Assert.True(displayNameInput.Enabled);
            Assert.True(displayNameInput.Displayed);
            displayNameInput.SendKeys("Display Name Test");
            Assert.AreEqual(displayNameInput.GetAttribute("minlength"), "2");
            Assert.AreEqual(displayNameInput.GetAttribute("maxlength"), "32");
            Assert.AreEqual(displayNameInput.GetAttribute("required"),"true");
            Assert.AreEqual(displayNameInput.GetAttribute("class"),"validate form-control");

            var tenantDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[3]/div/div/div/label"));
            Assert.IsTrue(tenantDropdownlistLabel.Enabled);
            Assert.IsTrue(tenantDropdownlistLabel.Displayed);
            Assert.AreEqual(tenantDropdownlistLabel.GetAttribute("class"), "form-label1");

            var tenantNameDropdownlist = driver.FindElement(By.Id("Tenants"));
            Assert.IsTrue(tenantNameDropdownlist.Enabled);
            Assert.IsTrue(tenantNameDropdownlist.Displayed);
            Assert.AreEqual(tenantNameDropdownlist.GetAttribute("class"),"form-control");
            Assert.AreEqual(tenantNameDropdownlist.GetAttribute("onchange"), "callChangefunc(this.value)");

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"Tenants\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Please Select...");

            var selectedAssetAttributesValue = new SelectElement(tenantNameDropdownlist);
            selectedAssetAttributesValue.SelectByIndex(1);

            var roleDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[4]/div/div/div/label"));
            roleDescriptionLabel.Click();
            Assert.True(roleDescriptionLabel.Enabled);
            Assert.True(roleDescriptionLabel.Displayed);
            Assert.AreEqual(roleDescriptionLabel.Text, "Role description");

            var roleDescriptionInput = driver.FindElement(By.Id("role-description"));
            Assert.True(roleDescriptionInput.Enabled);
            Assert.True(roleDescriptionInput.Displayed);
            roleDescriptionInput.SendKeys("Role Discription Test");
            Assert.AreEqual(roleDescriptionInput.GetAttribute("class"), "validate form-control");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[5]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[5]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"),"button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void RolesPage_DataTableLengthTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"roleTable_length\"]/label"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            Assert.True(showLabel.Text.Contains("Show"));
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("roleTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            Assert.AreEqual(showValue.GetAttribute("aria-controls"), "roleTable");

            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void RolesPage_DataTableFilterTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var searchLabel = driver.FindElement(By.Id("roleTable_filter"));
            searchLabel.Click();
            Assert.IsTrue(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"roleTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("type"), "search");
            Assert.AreEqual(searchInput.GetAttribute("aria-controls"), "roleTable");
        }

        [Test]
        public void RolesPage_RolesTableTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var tableColumns = driver.FindElements(By.Id(""));
            foreach(var column in tableColumns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var Name = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(Name.Enabled);
            Assert.IsTrue(Name.Displayed);
            Assert.AreEqual(Name.Text, "Name");
            Assert.AreEqual(Name.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(Name.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(Name.GetAttribute("aria-controls"),"roleTable");
            Assert.AreEqual(Name.GetAttribute("aria-label"), "Name: activate to sort column descending");
            Name.Click();

            var DisplayName = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(DisplayName.Enabled);
            Assert.IsTrue(DisplayName.Displayed);
            Assert.AreEqual(DisplayName.Text, "Display Name");
            Assert.AreEqual(DisplayName.GetAttribute("class"), "sorting");
            Assert.AreEqual(DisplayName.GetAttribute("aria-controls"), "roleTable");
            Assert.AreEqual(DisplayName.GetAttribute("aria-label"), "Display Name: activate to sort column ascending");
            DisplayName.Click();

            var Tenant = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(Tenant.Enabled);
            Assert.IsTrue(Tenant.Displayed);
            Assert.AreEqual(Tenant.Text, "Tenant");
            Assert.AreEqual(Tenant.GetAttribute("class"), "sorting");
            Assert.AreEqual(Tenant.GetAttribute("aria-controls"), "roleTable");
            Assert.AreEqual(Tenant.GetAttribute("aria-label"), "Tenant: activate to sort column ascending");
            Tenant.Click();

            var AgencyName = driver.FindElement
               (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(AgencyName.Enabled);
            Assert.IsTrue(AgencyName.Displayed);
            Assert.AreEqual(AgencyName.Text, "Agency Name");
            Assert.AreEqual(AgencyName.GetAttribute("class"), "sorting");
            Assert.AreEqual(AgencyName.GetAttribute("aria-controls"), "roleTable");
            Assert.AreEqual(AgencyName.GetAttribute("aria-label"), "Agency Name: activate to sort column ascending");
            AgencyName.Click();

            var Description = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(Description.Enabled);
            Assert.IsTrue(Description.Displayed);
            Assert.AreEqual(Description.Text, "Description");
            Assert.AreEqual(Description.GetAttribute("class"), "sorting");
            Assert.AreEqual(Description.GetAttribute("aria-controls"), "roleTable");
            Assert.AreEqual(Description.GetAttribute("aria-label"), "Description: activate to sort column ascending");
            Description.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[6]"));
            Assert.IsTrue(Actions.Enabled);
            Assert.IsTrue(Actions.Displayed);
            Assert.AreEqual(Actions.Text, "Actions");
            Assert.AreEqual(Actions.GetAttribute("class"), "sorting");
            Assert.AreEqual(Actions.GetAttribute("aria-controls"), "roleTable");
            Assert.AreEqual(Actions.GetAttribute("aria-label"), "Actions: activate to sort column ascending");
            Actions.Click();
        }

        [Test]
        public void RolesPage_EditIconTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var editIcon = driver.FindElement
              (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[1]"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);
            Assert.AreEqual(editIcon.GetAttribute("title"), "Edit");
            Assert.IsTrue(editIcon.GetAttribute("onclick").Contains("openRolesModal"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[1]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-edit");
        }

        [Test]
        public void RolesPage_EditIconFormTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[3]/td[6]/a[1]"));
            editIcon.Click();
            
            var roleNameLabel = driver.FindElement
               (By.XPath("//*[@id=\"edit-user-details\"]/div[1]/div/div/div/label"));
            Assert.IsTrue(roleNameLabel.Enabled);
            Assert.IsTrue(roleNameLabel.Displayed);
            Assert.AreEqual(roleNameLabel.Text, "Role Name");
            Assert.AreEqual(roleNameLabel.GetAttribute("for"), "rolename");
            Assert.AreEqual(roleNameLabel.GetAttribute("class"),"form-label");

            var roleNameInpout = driver.FindElement(By.Id("rolename"));
            Assert.IsTrue(roleNameInpout.Enabled);
            Assert.AreEqual(roleNameInpout.GetAttribute("type"),"text");
            Assert.AreEqual(roleNameInpout.GetAttribute("minlength"), "2");
            Assert.AreEqual(roleNameInpout.GetAttribute("required"),"true");
            Assert.AreEqual(roleNameInpout.GetAttribute("maxlength"), "32");
            Assert.AreEqual(roleNameInpout.GetAttribute("class"),"validate form-control");

            var displayNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div/div/div/label"));
            Assert.True(displayNameLabel.Enabled);
            Assert.True(displayNameLabel.Displayed);
            Assert.AreEqual(displayNameLabel.Text, "Display Name");
            Assert.AreEqual(displayNameLabel.GetAttribute("for"), "displayname");
            Assert.AreEqual(displayNameLabel.GetAttribute("class"), "form-label");

            var displayNameInput = driver.FindElement(By.Id("displayname"));
            Assert.True(displayNameInput.Enabled);
            Assert.AreEqual(displayNameInput.GetAttribute("type"),"text");
            Assert.AreEqual(displayNameInput.GetAttribute("minlength"), "2");
            Assert.AreEqual(displayNameInput.GetAttribute("maxlength"), "32");
            Assert.AreEqual(displayNameInput.GetAttribute("required"),"true");
            Assert.AreEqual(displayNameInput.GetAttribute("class"),"validate form-control");

            var roleDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[3]/div/div/div/label"));
            Assert.True(roleDescriptionLabel.Enabled);
            Assert.True(roleDescriptionLabel.Displayed);
            Assert.AreEqual(roleDescriptionLabel.Text, "Role description");
            Assert.AreEqual(roleDescriptionLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(roleDescriptionLabel.GetAttribute("for"), "role-description");

            var roleDescriptionInput = driver.FindElement(By.Id("role-description"));
            Assert.IsTrue(roleDescriptionInput.Enabled);
            Assert.AreEqual(roleDescriptionInput.GetAttribute("type"),"textarea");
            Assert.AreEqual(roleDescriptionInput.GetAttribute("class"), "validate form-control");
        }

        [Test]
        public void RolesPage_DeleteIconTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[2]"));
            deleteIcon.Click();
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
            Assert.IsTrue(deleteIcon.GetAttribute("onclick").Contains("deleteRole"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[2]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-trash");
        }

        [Test]
        public void RolesPage_DeleteIConFormTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[2]"));
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
        public void RolesPage_PaginationTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("roleTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"),"roleTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("roleTable_previous"));
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.AreEqual(previoustBtn.GetAttribute("aria-controls"),"roleTable");
            Assert.AreEqual(previoustBtn.GetAttribute("class"), "paginate_button previous disabled");
            previoustBtn.Click();

            var pages = driver.FindElements(By.Id("roleTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
            }
        }

        [Test]
        public void RolesPage_DataTableInfoTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("roleTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void RolesPage_CopyRightTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void RolesPage_MinimizeToggleBtnTest()
        {
            // to open roles page
            RolesPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
