using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminAdministrationUserTests : IDisposable
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
        public void Users_AdministratioOptionTest()
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
            var administrationBtn = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationBtn.Click();
            
            var usersOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[2]/a"));
            Assert.IsTrue(usersOption.Enabled);
            Assert.IsTrue(usersOption.Displayed);
            Assert.AreEqual(usersOption.Text,"Users");
            Assert.AreEqual(usersOption.GetAttribute("custom-data"),"Users");
            Assert.AreEqual(usersOption.GetAttribute("target"),"_self");
            Assert.AreEqual(usersOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(usersOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Users");

            var userOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[2]/a/i"));
            Assert.IsTrue(userOptionIcon.Enabled);
            Assert.IsTrue(userOptionIcon.Displayed);
            Assert.AreEqual(userOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-users");

            var userOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[2]/a/span/span"));
            Assert.IsTrue(userOptionTitle.Enabled);
            Assert.IsTrue(userOptionTitle.Displayed);
            Assert.AreEqual(userOptionTitle.Text, "Users");
            Assert.AreEqual(userOptionTitle.GetAttribute("class"),"title");
        }

        [Test]
        public void UsersPage_OpenPage()
        {
            var administrationBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationBtn.Click();

            var userOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[2]/a/span"));
            userOption.Click();
        }

        [Test]
        public void UsersPage_TopBarUserNameTest()
        {
            // to open user page
            UsersPage_OpenPage();

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
        public void UsersPage_LogoutBtnTest()
        {
            // to open user page
            UsersPage_OpenPage();

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
        public void UsersPage_SubHeaderTitleTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Users");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void UsersPage_DashboardNavigationLinkTest()
        {
            // to open user page
            UsersPage_OpenPage();

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
        public void UsersPage_UsersNavigationLinkTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var usersBtn = driver.FindElement(
               By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.True(usersBtn.Enabled);
            Assert.True(usersBtn.Displayed);
            Assert.AreEqual(usersBtn.Text, "Users");
            Assert.AreEqual(usersBtn.GetAttribute("class"), "m-nav__link");

            var urlBeforeClick = driver.Url;
            usersBtn.Click();
            var urlAfterClick = driver.Url;
            Assert.AreEqual(urlBeforeClick,urlAfterClick);
        }

        [Test]
        public void UsersPage_SeperatorBetweenNavigationLinksTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));

            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.Text,">");
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void UserPage_DataTableLengthTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"userTable_length\"]/label"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            Assert.True(showLabel.Text.Contains("Show"));
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("userTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            Assert.AreEqual(showValue.GetAttribute("aria-controls"), "userTable");

            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void UserPage_DataTableFilterTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var searchLabel = driver.FindElement
               (By.XPath("//*[@id=\"userTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"userTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchInput.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("type"),"search");
            Assert.AreEqual(searchInput.GetAttribute("aria-controls"),"userTable");
        }

        [Test]
        public void UserPage_CreateBtnTest()
        {
            /// to open user page
            UsersPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreateUser"));
            createBtn.Click();
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual("Create", createBtn.Text);
            Assert.AreEqual(createBtn.GetAttribute("type"), "button");
            Assert.AreEqual(createBtn.GetAttribute("data-toggle"), "modal");
            Assert.AreEqual(createBtn.GetAttribute("data-target"), "#UserCreateModal");
            Assert.AreEqual(createBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");
        }

        [Test]
        public void UsersPage_CreateUserFormTest()
        {
            // to open create form 
            UserPage_CreateBtnTest();

            var usernameLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[1]/div/div/div/label"));
            Assert.True(usernameLabel.Enabled);
            Assert.IsTrue(usernameLabel.Displayed);
            Assert.AreEqual(usernameLabel.Text, "User name");
            Assert.AreEqual(usernameLabel.GetAttribute("class"), "form-label");

            var usernameInput = driver.FindElement(By.Name("UserName"));
            Assert.AreEqual(usernameInput.GetAttribute("required"), "true");
            usernameInput.SendKeys("TestName");
            Assert.True(usernameInput.Enabled);
            Assert.True(usernameInput.Displayed);

            var firstnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[2]/div[1]/div/div/label"));
            firstnameLabel.Click();
            Assert.True(firstnameLabel.Enabled);
            Assert.True(firstnameLabel.Displayed);
            Assert.AreEqual(firstnameLabel.Text, "First Name");
            Assert.AreEqual(firstnameLabel.GetAttribute("class"),"form-label");

            var firstnameInput = driver.FindElement(By.Name("Name"));
            Assert.True(firstnameInput.Enabled);
            Assert.True(firstnameInput.Displayed);
            Assert.AreEqual(firstnameInput.GetAttribute("maxlength"),"64");
            Assert.AreEqual(firstnameInput.GetAttribute("required"),"true");
            Assert.AreEqual(firstnameInput.GetAttribute("class"),"form-control");
            firstnameInput.SendKeys("first Name Test");

            var lastnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[2]/div[2]/div/div/label"));
            lastnameLabel.Click();
            Assert.True(lastnameLabel.Enabled);
            Assert.True(lastnameLabel.Displayed);
            Assert.AreEqual(lastnameLabel.Text, "Last Name");
            Assert.AreEqual(lastnameLabel.GetAttribute("class"), "form-label");

            var lastnameInput = driver.FindElement(By.Name("Surname"));
            Assert.True(lastnameInput.Enabled);
            Assert.True(lastnameInput.Displayed);
            lastnameInput.SendKeys("last Name Test");
            Assert.AreEqual(lastnameInput.GetAttribute("type"),"text");
            Assert.AreEqual(lastnameInput.GetAttribute("maxlength"),"64");
            Assert.AreEqual(lastnameInput.GetAttribute("required"),"true");
            Assert.AreEqual(lastnameInput.GetAttribute("class"),"form-control");

            var tenatNameDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[3]/div/div/div/label"));
            Assert.IsTrue(tenatNameDropdownlistLabel.Enabled);
            Assert.IsTrue(tenatNameDropdownlistLabel.Displayed);
            Assert.AreEqual(tenatNameDropdownlistLabel.Text, "Tenant Name");
            Assert.AreEqual(tenatNameDropdownlistLabel.GetAttribute("class"), "form-label1");
           
            var tenantNameDropdownlist = driver.FindElement(By.Id("Tenants"));
            Assert.IsTrue(tenantNameDropdownlist.Enabled);
            Assert.IsTrue(tenantNameDropdownlist.Displayed);
            Assert.AreEqual(tenantNameDropdownlist.GetAttribute("onchange"), "callChangefunc(this.value)");
            var selectedTenantName = new SelectElement(tenantNameDropdownlist);
            selectedTenantName.SelectByIndex(1);

            var emailLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[4]/div/div/div/label"));
            Assert.True(emailLabel.Enabled);
            Assert.True(emailLabel.Displayed);
            Assert.AreEqual(emailLabel.Text,"Email address");
            Assert.AreEqual(emailLabel.GetAttribute("class"),"form-label");

            var emailInput = driver.FindElement(By.Name("EmailAddress"));
            Assert.True(emailInput.Enabled);
            Assert.True(emailInput.Displayed);
            Assert.AreEqual(emailInput.GetAttribute("class"), "form-control");
            Assert.AreEqual(emailInput.GetAttribute("maxlength"),"256");
            emailInput.SendKeys($"{Helper.GenerateRandomEmail()}@gmail.com");

            var passwordLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[5]/div/div/div/label"));
            Assert.True(passwordLabel.Enabled);
            Assert.True(passwordLabel.Displayed);
            Assert.AreEqual(passwordLabel.Text,"Password");
            Assert.AreEqual(passwordLabel.GetAttribute("class"),"form-label");

            var passwordInput = driver.FindElement(By.Id("Password"));
            Assert.True(passwordInput.Enabled);
            Assert.True(passwordInput.Displayed);
            passwordInput.SendKeys("PasswordTest");
            Assert.AreEqual(passwordInput.GetAttribute("maxlength"),"32");
            Assert.AreEqual(passwordInput.GetAttribute("required"),"true");
            Assert.AreEqual(passwordInput.GetAttribute("type"), "password");

            var confirmPasswordLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[6]/div/div/div/label"));
            Assert.True(confirmPasswordLabel.Enabled);
            Assert.True(confirmPasswordLabel.Displayed);
            Assert.AreEqual(confirmPasswordLabel.Text, "Confirm password");
            Assert.AreEqual(confirmPasswordLabel.GetAttribute("class"),"form-label");

            var confirmPasswordInput = driver.FindElement(By.Id("ConfirmPassword"));
            Assert.True(confirmPasswordInput.Enabled);
            Assert.True(confirmPasswordInput.Displayed);
            confirmPasswordInput.SendKeys("PasswordTest");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("maxlength"),"32");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("required"),"true");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("type"), "password");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("class"), "form-control");

            var isActiveLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[7]/div/div/label"));
            Assert.True(isActiveLabel.Enabled);
            Assert.True(isActiveLabel.Displayed);
            Assert.AreEqual(isActiveLabel.Text, "Is Active");
            Assert.AreEqual(isActiveLabel.GetAttribute("for"), "CreateUserIsActive");

            var isActiveValue = driver.FindElement(By.Id("CreateUserIsActive"));
            Assert.True(isActiveValue.Enabled);
            Assert.True(isActiveValue.Displayed);
            Assert.AreEqual(isActiveValue.GetAttribute("class"), "filled-in");
            Assert.AreEqual(isActiveValue.GetAttribute("type"), "checkbox");
            isActiveValue.Click();

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text,"Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text,"Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void UserPage_CreateUserForm_RolesTest()
        {
            // to add user details 
            UsersPage_CreateUserFormTest();

            var title = driver.FindElement(By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[1]/h4"));
            Assert.IsTrue(title.Enabled);
            Assert.IsTrue(title.Displayed);
            Assert.AreEqual(title.Text,"Create new user");
            Assert.AreEqual(title.GetAttribute("class"), "modal-title");

            var userRoles = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/ul/li[2]/a"));
            Assert.True(userRoles.Enabled);
            Assert.True(userRoles.Displayed);
            Assert.AreEqual(userRoles.Text, "User roles");
            Assert.AreEqual(userRoles.GetAttribute("data-toggle"),"tab");
            userRoles.Click();

            var AdminRoleLabel = driver.FindElement(By.XPath("//*[@id=\"rolesName\"]/div[1]/label"));
            Assert.IsTrue(AdminRoleLabel.Enabled);
            Assert.IsTrue(AdminRoleLabel.Displayed);
            Assert.AreEqual(AdminRoleLabel.Text,"Admin");
            Assert.AreEqual(AdminRoleLabel.GetAttribute("for"),"role-1");
            Assert.AreEqual(AdminRoleLabel.GetAttribute("title"),"Admin");

            var AdminRoleInput = driver.FindElement(By.XPath("//*[@id=\"role-1\"]"));
            Assert.IsTrue(AdminRoleInput.Enabled);
            Assert.IsTrue(AdminRoleInput.Displayed);
            Assert.AreEqual(AdminRoleLabel.GetAttribute("value"),"ADMIN");
            Assert.AreEqual(AdminRoleLabel.GetAttribute("type"), "checkbox");
            Assert.AreEqual(AdminRoleInput.GetAttribute("class"), "filled-in");

            var HostOperatorRoleLabel = driver.FindElement(By.XPath("//*[@id=\"rolesName\"]/div[3]/label"));
            Assert.IsTrue(HostOperatorRoleLabel.Enabled);
            Assert.IsTrue(HostOperatorRoleLabel.Displayed);
            Assert.AreEqual(HostOperatorRoleLabel.Text, "Host Operator");
            Assert.AreEqual(HostOperatorRoleLabel.GetAttribute("for"), "role-277");
            Assert.AreEqual(HostOperatorRoleLabel.GetAttribute("title"), "Host Operator");

            var HostOperatorInput = driver.FindElement(By.XPath("//*[@id=\"role-277\"]"));
            Assert.IsTrue(HostOperatorInput.Enabled);
            Assert.IsTrue(HostOperatorInput.Displayed);
            Assert.AreEqual(HostOperatorInput.GetAttribute("value"), "HOSTOPERATOR");
            Assert.AreEqual(HostOperatorInput.GetAttribute("type"), "checkbox");
            Assert.AreEqual(HostOperatorInput.GetAttribute("class"), "filled-in");

            var ReviewerRoleLabel = driver.FindElement(By.XPath("//*[@id=\"rolesName\"]/div[2]/label"));
            Assert.IsTrue(ReviewerRoleLabel.Enabled);
            Assert.IsTrue(ReviewerRoleLabel.Displayed);
            Assert.AreEqual(ReviewerRoleLabel.Text, "Reviewer");
            Assert.AreEqual(ReviewerRoleLabel.GetAttribute("for"), "role-276");
            Assert.AreEqual(ReviewerRoleLabel.GetAttribute("title"), "Reviewer");

            var ReviewerRoleInput = driver.FindElement(By.XPath("//*[@id=\"rolesName\"]/div[2]/label"));
            Assert.IsTrue(ReviewerRoleInput.Enabled);
            Assert.IsTrue(ReviewerRoleInput.Displayed);
            Assert.AreEqual(ReviewerRoleInput.GetAttribute("value"), "REVIEWER");
            Assert.AreEqual(ReviewerRoleInput.GetAttribute("type"), "checkbox");
            Assert.AreEqual(ReviewerRoleInput.GetAttribute("class"), "filled-in");

            var saveBtn = driver.FindElement
            (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void UserPage_UserTableTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var tableColumns = driver.FindElements(By.Id("userTable"));
            foreach(var column in tableColumns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var userName = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[1]"));
            Assert.True(userName.Enabled);
            Assert.True(userName.Displayed);
            Assert.AreEqual(userName.Text, "User Name");
            Assert.AreEqual(userName.GetAttribute("class"),"sorting_asc");
            Assert.AreEqual(userName.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(userName.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(userName.GetAttribute("aria-label"), "User Name: activate to sort column descending");
            userName.Click();

            var fullName = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[2]"));
            Assert.True(fullName.Enabled);
            Assert.True(fullName.Displayed);
            Assert.AreEqual(fullName.Text, "Full Name");
            Assert.AreEqual(fullName.GetAttribute("class"), "sorting");
            Assert.AreEqual(fullName.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(fullName.GetAttribute("aria-label"), "Full Name: activate to sort column ascending");
            fullName.Click();

            var emailAddress = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[3]"));
            Assert.True(emailAddress.Enabled);
            Assert.True(emailAddress.Displayed);
            Assert.AreEqual(emailAddress.Text, "Email Address");
            Assert.AreEqual(emailAddress.GetAttribute("class"), "sorting");
            Assert.AreEqual(emailAddress.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(emailAddress.GetAttribute("aria-label"), "Email Address: activate to sort column ascending");
            emailAddress.Click();

            var Role = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[4]"));
            Assert.True(Role.Enabled);
            Assert.True(Role.Displayed);
            Assert.AreEqual(Role.Text, "Role");
            Assert.AreEqual(Role.GetAttribute("class"), "sorting");
            Assert.AreEqual(Role.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(Role.GetAttribute("aria-label"), "Role: activate to sort column ascending");
            Role.Click();

            var TenantId = driver.FindElement
            (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[5]"));
            Assert.True(TenantId.Enabled);
            Assert.True(TenantId.Displayed);
            Assert.AreEqual(TenantId.Text, "Tenant Id");
            Assert.AreEqual(TenantId.GetAttribute("class"), "sorting");
            Assert.AreEqual(TenantId.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(TenantId.GetAttribute("aria-label"), "Tenant Id: activate to sort column ascending");
            TenantId.Click();

            var AgencyName = driver.FindElement
            (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[6]"));
            Assert.True(AgencyName.Enabled);
            Assert.True(AgencyName.Displayed);
            Assert.AreEqual(AgencyName.Text, "Agency Name");
            Assert.AreEqual(AgencyName.GetAttribute("class"), "sorting");
            Assert.AreEqual(AgencyName.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(AgencyName.GetAttribute("aria-label"), "Agency Name: activate to sort column ascending");
            AgencyName.Click();

            var isActive = driver.FindElement
            (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[7]"));
            Assert.True(isActive.Enabled);
            Assert.True(isActive.Displayed);
            Assert.AreEqual(isActive.Text, "Is Active");
            Assert.AreEqual(emailAddress.GetAttribute("class"), "sorting");
            Assert.AreEqual(emailAddress.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(emailAddress.GetAttribute("aria-label"), "Email Address: activate to sort column ascending");
            isActive.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[8]"));
            Assert.True(Actions.Enabled);
            Assert.True(Actions.Displayed);
            Assert.AreEqual(Actions.Text, "Actions");
            Assert.AreEqual(Actions.GetAttribute("class"), "sorting");
            Assert.AreEqual(Actions.GetAttribute("aria-controls"), "userTable");
            Assert.AreEqual(Actions.GetAttribute("aria-label"), "Actions: activate to sort column ascending");
        }

        [Test]
        public void UsersPage_EditUserIconTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var editIcon = driver.FindElement
                 (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[1]"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.IsTrue(editIcon.GetAttribute("onclick").Contains("openUserModal"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[1]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-edit");
        }

        // after click on eidt icon will open this form
        // this method for test form fields
        [Test]
        public void UserPage_EditUserFormTest()
        {
            // to open user page
            UsersPage_OpenPage();

            // to open edit form
            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[1]"));
            editIcon.Click();

            var SelectTenantLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[1]/div[1]/label"));
            Assert.IsTrue(SelectTenantLabel.Enabled);
            Assert.IsTrue(SelectTenantLabel.Displayed);
            Assert.AreEqual(SelectTenantLabel.GetAttribute("for"), "tenantId");

            var selectTenantDropdownlist = driver.FindElement(By.Id("TenantId"));
            Assert.IsTrue(selectTenantDropdownlist.Enabled);
            Assert.IsTrue(selectTenantDropdownlist.Displayed);
            Assert.AreEqual(selectTenantDropdownlist.GetAttribute("class"), "form-control input-sm");

            var selectedTenantName = new SelectElement(selectTenantDropdownlist);
            selectedTenantName.SelectByIndex(1);

            var usernameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[1]/div[2]/div/div/label"));
            Assert.IsTrue(usernameLabel.Enabled);
            Assert.IsTrue(usernameLabel.Enabled);
            Assert.AreEqual(usernameLabel.Text,"User name");
            Assert.AreEqual(usernameLabel.GetAttribute("for"),"username");
            Assert.AreEqual(usernameLabel.GetAttribute("class"),"form-label");

            var usernameInput = driver.FindElement(By.Id("username"));
            Assert.True(usernameInput.Enabled);
            Assert.True(usernameInput.Displayed);
            Assert.AreEqual(usernameInput.GetAttribute("type"),"text");
            Assert.AreEqual(usernameInput.GetAttribute("minlength"),"2");
            Assert.AreEqual(usernameInput.GetAttribute("maxlength"),"32");
            Assert.AreEqual(usernameInput.GetAttribute("required"), "true");
            usernameInput.SendKeys("Tset User Name");

            var firstnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div[1]/div/div/label"));
            Assert.True(firstnameLabel.Enabled);
            Assert.True(firstnameLabel.Displayed);
            Assert.AreEqual(firstnameLabel.Text, "First Name");
            Assert.AreEqual(firstnameLabel.GetAttribute("for"),"name");
            Assert.AreEqual(firstnameLabel.GetAttribute("class"),"form-label");

            var firstnameInput = driver.FindElement(By.Id("name"));
            Assert.True(firstnameInput.Enabled);
            Assert.True(firstnameInput.Displayed);
            firstnameInput.SendKeys("first Name Test");
            Assert.AreEqual(firstnameInput.GetAttribute("type"),"text");
            Assert.AreEqual(firstnameInput.GetAttribute("maxlength"),"32");
            Assert.AreEqual(firstnameInput.GetAttribute("required"),"true");

            var lastnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div[2]/div/div/label"));
            lastnameLabel.Click();
            Assert.True(lastnameLabel.Enabled);
            Assert.True(lastnameLabel.Displayed);
            Assert.AreEqual(lastnameLabel.Text, "Last Name");
            Assert.AreEqual(lastnameLabel.GetAttribute("for"),"surname");
            Assert.AreEqual(lastnameLabel.GetAttribute("class"),"form-label");

            var lastnameInput = driver.FindElement(By.Id("surname"));
            Assert.True(lastnameInput.Enabled);
            Assert.True(lastnameInput.Displayed);
            lastnameInput.SendKeys("last Name Test");
            Assert.AreEqual(lastnameInput.GetAttribute("type"),"text");
            Assert.AreEqual(lastnameInput.GetAttribute("maxlength"),"32");
            Assert.AreEqual(lastnameInput.GetAttribute("required"),"true");


            var emailLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[3]/div/div/div/label"));
            Assert.True(emailLabel.Enabled);
            Assert.True(emailLabel.Displayed);
            Assert.AreEqual(emailLabel.Text, "Email address");
            Assert.AreEqual(emailLabel.GetAttribute("for"),"email");
            Assert.AreEqual(emailLabel.GetAttribute("class"),"form-label");

            var emailInput = driver.FindElement(By.Id("email"));
            Assert.True(emailInput.Displayed);
            Assert.True(emailInput.Enabled);
            Assert.AreEqual(emailInput.GetAttribute("type"),"email");
            Assert.AreEqual(emailInput.GetAttribute("maxlength"),"256");
            //Assert.AreEqual(emailInput.GetAttribute("required"), "true");
            emailInput.SendKeys($"{Helper.GenerateRandomEmail()}@gmail.com");

            var isActiveLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[4]/div/div/div/label"));
            Assert.True(isActiveLabel.Enabled);
            Assert.True(isActiveLabel.Displayed);
            Assert.AreEqual(isActiveLabel.Text, "Is Active");
            Assert.AreEqual(isActiveLabel.GetAttribute("for"), "IsActive");
            Assert.AreEqual(isActiveLabel.GetAttribute("class"), "custom-control-label");

            var IsActiveValue = driver.FindElement(By.Id("IsActive"));
            Assert.IsTrue(IsActiveValue.Enabled);
           // Assert.IsTrue(IsActiveValue.Displayed);
            Assert.AreEqual(IsActiveValue.GetAttribute("type"), "checkbox");
            Assert.AreEqual(IsActiveValue.GetAttribute("class"), "custom-control-input form-control");
        }

        [Test]
        public void UsersPage_EditPasswordIConTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var editPasswordICon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[2]"));
            Assert.True(editPasswordICon.Enabled);
            Assert.True(editPasswordICon.Displayed);
            Assert.AreEqual(editPasswordICon.GetAttribute("title"), "Edit Password");
            Assert.IsTrue(editPasswordICon.GetAttribute("onclick").Contains("openEditPasswordModal"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[2]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-key");
        }

        [Test]
        public void UserPage_EditPasswordFormTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var editPasswordICon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[2]"));
            editPasswordICon.Click();

            var passwordLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[1]/div/div/div/label"));
            Assert.True(passwordLabel.Enabled);
            Assert.AreEqual(passwordLabel.GetAttribute("for"),"Password");
            Assert.AreEqual(passwordLabel.GetAttribute("class"),"form-label");

            var passwordInput = driver.FindElement(By.Id("pass"));
            Assert.True(passwordInput.Enabled);
            Assert.True(passwordInput.Displayed);
            Assert.AreEqual(passwordInput.GetAttribute("maxlength"), "32");
            Assert.AreEqual(passwordInput.GetAttribute("type"),"password");
            Assert.AreEqual(passwordInput.GetAttribute("required"), "true");
            Assert.AreEqual(passwordInput.GetAttribute("class"), "form-control");
            Assert.AreEqual(passwordInput.GetAttribute("placeholder"), "Password");
            Assert.AreEqual(passwordInput.GetAttribute("pattern"), "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}");
            Assert.AreEqual(passwordInput.GetAttribute("title"), "Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters");
            passwordInput.SendKeys("Test Password");
           
            var confirmPasswordLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div/div/div/label"));
            Assert.True(confirmPasswordLabel.Enabled);
            Assert.True(confirmPasswordLabel.Displayed);
            Assert.AreEqual(confirmPasswordLabel.Text, "Confirm Password");
            Assert.AreEqual(confirmPasswordLabel.GetAttribute("for"), "password");
            Assert.AreEqual(confirmPasswordLabel.GetAttribute("class"),"form-label");

            var confirmPasswordInput = driver.FindElement(By.Id("cpass"));
            Assert.True(confirmPasswordInput.Displayed);
            Assert.True(confirmPasswordInput.Enabled);
            Assert.AreEqual(confirmPasswordInput.GetAttribute("maxlength"),"32");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("type"),"password");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("required"), "true");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("placeholder"), "Confirm password");
            Assert.AreEqual(confirmPasswordInput.GetAttribute("pattern"), "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}");

            var saveBtn = driver.FindElement
            (By.XPath("//*[@id=\"EditUserPasswordModalId\"]/div/div/div[3]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "button");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary save-button waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"EditUserPasswordModalId\"]/div/div/div[3]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"),"button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default close-button waves-effect");
        }

        [Test]
        public void UsersPage_PermissionsIconTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var permissionsIcon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[4]"));
            Assert.True(permissionsIcon.Enabled);
            Assert.True(permissionsIcon.Displayed);
            Assert.AreEqual(permissionsIcon.GetAttribute("title"), "Permission");
            Assert.IsTrue(permissionsIcon.GetAttribute("onclick").Contains("openPermissionModal"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[4]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-info-circle");
        }


        // There are Two Error In This Pice 
        // Dashboard It is Writen Wrong in line 1075 and line 1427 it must be Dashboard Instead Dasboard  
        [Test]
        public void UserPage_PermissionsFormTest()
        {
            // to open user page
            UsersPage_OpenPage();

            ///////// to open permsissions page ////////////
            var permissionIcon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[5]/td[8]/a[4]"));
            permissionIcon.Click();


            /////////////////////////// Asset Attributes Permsissions /////////////////
            var AssetAttributesPermissionsAnchor = driver.FindElement(By.Id("Pages.AssetAttributes_anchor"));
            Assert.True(AssetAttributesPermissionsAnchor.Enabled);
            Assert.IsTrue(AssetAttributesPermissionsAnchor.Displayed);
            Assert.AreEqual(AssetAttributesPermissionsAnchor.Text, "Asset Attributes");
            Assert.AreEqual(AssetAttributesPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var AssetAttributesPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetAttributes_anchor\"]/i[1]"));
            Assert.IsTrue(AssetAttributesPermissionsCheckBox.Enabled);
            Assert.IsTrue(AssetAttributesPermissionsCheckBox.Displayed);
            Assert.AreEqual(AssetAttributesPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetAttributesPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var AssetAttributesPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetAttributes_anchor\"]/i[2]"));
            Assert.IsTrue(AssetAttributesPermissionsFolderIcon.Enabled);
            Assert.IsTrue(AssetAttributesPermissionsFolderIcon.Displayed);
            Assert.AreEqual(AssetAttributesPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetAttributesPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Asset Attributes permissions
            var AssetAttributesPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetAttributes\"]/i"));
            Assert.IsTrue(AssetAttributesPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(AssetAttributesPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(AssetAttributesPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetAttributesPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Asset Attributes Permsions
            AssetAttributesPermissionsAnchor.Click();



            ////////////////////// Asset Classes Permsissions ///////////////////
            var AssetClassesPermissionsAnchor = driver.FindElement(By.Id("Pages.AssetClasses_anchor"));
            Assert.IsTrue(AssetClassesPermissionsAnchor.Enabled);
            Assert.IsTrue(AssetClassesPermissionsAnchor.Displayed);
            Assert.AreEqual(AssetClassesPermissionsAnchor.Text, "Asset Classes");
            Assert.AreEqual(AssetClassesPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var AssetClassesPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetClasses_anchor\"]/i[1]"));
            Assert.IsTrue(AssetClassesPermissionsCheckBox.Enabled);
            Assert.IsTrue(AssetClassesPermissionsCheckBox.Displayed);
            Assert.AreEqual(AssetClassesPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetClassesPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var AssetClassesPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetClasses_anchor\"]/i[2]"));
            Assert.IsTrue(AssetClassesPermissionsFolderIcon.Enabled);
            Assert.IsTrue(AssetClassesPermissionsFolderIcon.Displayed);
            Assert.AreEqual(AssetClassesPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetClassesPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Asset Classes permissions
            var AssetClassesPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetClasses\"]/i"));
            Assert.IsTrue(AssetClassesPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(AssetClassesPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(AssetClassesPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetClassesPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Asset Classes Permsions
            AssetClassesPermissionsAnchor.Click();



            //////////////////////Asset Sub Class Permsissons //////////////////
            var AssetSubClassesPermissionsAnchor = driver.FindElement(By.Id("Pages.AssetSubClasses_anchor"));
            Assert.True(AssetSubClassesPermissionsAnchor.Enabled);
            Assert.IsTrue(AssetSubClassesPermissionsAnchor.Displayed);
            Assert.AreEqual(AssetSubClassesPermissionsAnchor.Text, "Asset Sub Classes");
            Assert.AreEqual(AssetSubClassesPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var AssetSubClassesPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetSubClasses_anchor\"]/i[1]"));
            Assert.IsTrue(AssetSubClassesPermissionsCheckBox.Enabled);
            Assert.IsTrue(AssetSubClassesPermissionsCheckBox.Displayed);
            Assert.AreEqual(AssetSubClassesPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetSubClassesPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var AssetSubClassesPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetSubClasses_anchor\"]/i[2]"));
            Assert.IsTrue(AssetSubClassesPermissionsFolderIcon.Enabled);
            Assert.IsTrue(AssetSubClassesPermissionsFolderIcon.Displayed);
            Assert.AreEqual(AssetSubClassesPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetSubClassesPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Asset Sub Classes permissions
            var AssetSubClassesPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetSubClasses\"]/i"));
            Assert.IsTrue(AssetSubClassesPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(AssetSubClassesPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(AssetSubClassesPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetSubClassesPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Asset Sub Classes Permsions
            AssetSubClassesPermissionsAnchor.Click();



            ////////////////////Asset Type Permsissons /////////////////////
            var AssetTypesPermissionsAnchor = driver.FindElement(By.Id("Pages.AssetTypes_anchor"));
            Assert.IsTrue(AssetTypesPermissionsAnchor.Enabled);
            Assert.IsTrue(AssetTypesPermissionsAnchor.Displayed);
            Assert.AreEqual(AssetTypesPermissionsAnchor.Text, "Asset Types");
            Assert.AreEqual(AssetTypesPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var AssetTypesPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetTypes_anchor\"]/i[1]"));
            Assert.IsTrue(AssetTypesPermissionsCheckBox.Enabled);
            Assert.IsTrue(AssetTypesPermissionsCheckBox.Displayed);
            Assert.AreEqual(AssetTypesPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetTypesPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var AssetTypesPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetTypes_anchor\"]/i[2]"));
            Assert.IsTrue(AssetTypesPermissionsFolderIcon.Enabled);
            Assert.IsTrue(AssetTypesPermissionsFolderIcon.Displayed);
            Assert.AreEqual(AssetTypesPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetTypesPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Asset Types permissions
            var AssetTypesPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.AssetTypes_anchor\"]/i"));
            Assert.IsTrue(AssetTypesPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(AssetTypesPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(AssetTypesPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetTypesPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-checkbox");

            //// to check on all Asset Types Permsions
            AssetTypesPermissionsAnchor.Click();



            ///////////////////////////////Assets Permisissons //////////////////////
            var AssetsPermissionsAnchor = driver.FindElement(By.Id("Pages.Assets_anchor"));
            Assert.IsTrue(AssetsPermissionsAnchor.Enabled);
            Assert.IsTrue(AssetsPermissionsAnchor.Displayed);
            Assert.AreEqual(AssetsPermissionsAnchor.Text, "Assets");
            Assert.AreEqual(AssetsPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var AssetsPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Assets_anchor\"]/i[1]"));
            Assert.IsTrue(AssetsPermissionsCheckBox.Enabled);
            Assert.IsTrue(AssetsPermissionsCheckBox.Displayed);
            Assert.AreEqual(AssetsPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetsPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var AssetsPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Assets_anchor\"]/i[2]"));
            Assert.IsTrue(AssetsPermissionsFolderIcon.Enabled);
            Assert.IsTrue(AssetsPermissionsFolderIcon.Displayed);
            Assert.AreEqual(AssetsPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetsPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Assets permissions
            var AssetsPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Assets_anchor\"]/i"));
            Assert.IsTrue(AssetsPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(AssetsPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(AssetsPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(AssetsPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-checkbox");

            //// to check on all Assets Permsions
            AssetsPermissionsAnchor.Click();



            //////////////////////// Audit Permsissions ////////////////////
            var AuditPermissionsAnchor = driver.FindElement(By.Id("Pages.Audit_anchor"));
            Assert.IsTrue(AuditPermissionsAnchor.Enabled);
            Assert.IsTrue(AuditPermissionsAnchor.Displayed);
            Assert.AreEqual(AuditPermissionsAnchor.Text, "Audit");
            Assert.AreEqual(AuditPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var AuditPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Audit_anchor\"]/i[1]"));
            Assert.IsTrue(AuditPermissionsCheckBox.Enabled);
            Assert.IsTrue(AuditPermissionsCheckBox.Displayed);
            Assert.AreEqual(AuditPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(AuditPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var AuditPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Audit_anchor\"]/i[2]"));
            Assert.IsTrue(AuditPermissionsFolderIcon.Enabled);
            Assert.IsTrue(AuditPermissionsFolderIcon.Displayed);
            Assert.AreEqual(AuditPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(AuditPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Audit Permsions
            AuditPermissionsAnchor.Click();



            ////////////////////////// Configuration Permissions ////////////////
            var ConfigurationPermissionsAnchor = driver.FindElement(By.Id("Pages.Configuration_anchor"));
            Assert.IsTrue(ConfigurationPermissionsAnchor.Enabled);
            Assert.IsTrue(ConfigurationPermissionsAnchor.Displayed);
            Assert.AreEqual(ConfigurationPermissionsAnchor.Text, "Configuration");
            Assert.AreEqual(ConfigurationPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var ConfigurationPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Configuration_anchor\"]/i[1]"));
            Assert.IsTrue(ConfigurationPermissionsCheckBox.Enabled);
            Assert.IsTrue(ConfigurationPermissionsCheckBox.Displayed);
            Assert.AreEqual(ConfigurationPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ConfigurationPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ConfigurationPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Configuration_anchor\"]/i[2]"));
            Assert.IsTrue(ConfigurationPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ConfigurationPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ConfigurationPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ConfigurationPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Configurations permissions
            var ConfigurationPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Configuration\"]/i"));
            Assert.IsTrue(ConfigurationPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(ConfigurationPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(ConfigurationPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(ConfigurationPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Configuration Permsions
            ConfigurationPermissionsAnchor.Click();



            ///////////////// Dashboard Permisission ////////////
            var DashboardPermissionsAnchor = driver.FindElement(By.Id("Pages.Dashboard_anchor"));
            Assert.IsTrue(DashboardPermissionsAnchor.Enabled);
            Assert.IsTrue(DashboardPermissionsAnchor.Displayed);
            Assert.AreEqual(DashboardPermissionsAnchor.Text, "Dashboard");
            Assert.AreEqual(DashboardPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var DashboardPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Dashboard_anchor\"]/i[1]"));
            Assert.IsTrue(DashboardPermissionsCheckBox.Enabled);
            Assert.IsTrue(DashboardPermissionsCheckBox.Displayed);
            Assert.AreEqual(DashboardPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(DashboardPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var DashboardPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Dashboard_anchor\"]/i[2]"));
            Assert.IsTrue(DashboardPermissionsFolderIcon.Enabled);
            Assert.IsTrue(DashboardPermissionsFolderIcon.Displayed);
            Assert.AreEqual(DashboardPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(DashboardPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Configuration Permsions
            DashboardPermissionsAnchor.Click();



            ///////////////////// Dashboard View Edits Permissions /////////////
            var DashboardViewEditsPermissionsAnchor = driver.FindElement(By.Id("Pages.Dashboard.ViewEdit_anchor"));
            Assert.IsTrue(DashboardViewEditsPermissionsAnchor.Enabled);
            Assert.IsTrue(DashboardViewEditsPermissionsAnchor.Displayed);
            Assert.AreEqual(DashboardViewEditsPermissionsAnchor.Text, "Dashboard View/Edit");
            Assert.AreEqual(DashboardViewEditsPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var DashboardViewEditsPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Dashboard.ViewEdit_anchor\"]/i[1]"));
            Assert.IsTrue(DashboardViewEditsPermissionsCheckBox.Enabled);
            Assert.IsTrue(DashboardViewEditsPermissionsCheckBox.Displayed);
            Assert.AreEqual(DashboardViewEditsPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(DashboardViewEditsPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var DashboardViewEditsPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Dashboard.ViewEdit_anchor\"]/i[2]"));
            Assert.IsTrue(DashboardViewEditsPermissionsFolderIcon.Enabled);
            Assert.IsTrue(DashboardViewEditsPermissionsFolderIcon.Displayed);
            Assert.AreEqual(DashboardViewEditsPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(DashboardViewEditsPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Dashboard View Edit Permissions
            DashboardViewEditsPermissionsAnchor.Click();



            ///////// Error List Permissions /////////////////
            var ErrorListPermissionsAnchor = driver.FindElement(By.Id("Pages.ErrorList_anchor"));
            Assert.IsTrue(ErrorListPermissionsAnchor.Enabled);
            Assert.IsTrue(ErrorListPermissionsAnchor.Displayed);
            Assert.AreEqual(ErrorListPermissionsAnchor.Text, "Error List");
            Assert.AreEqual(ErrorListPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var ErrorListPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.ErrorList_anchor\"]/i[1]"));
            Assert.IsTrue(ErrorListPermissionsCheckBox.Enabled);
            Assert.IsTrue(ErrorListPermissionsCheckBox.Displayed);
            Assert.AreEqual(ErrorListPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ErrorListPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ErrorListPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.ErrorList_anchor\"]/i[2]"));
            Assert.IsTrue(ErrorListPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ErrorListPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ErrorListPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ErrorListPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Error List Permissions
            ErrorListPermissionsAnchor.Click();



            ///////////// Instruction Manaual Permissions ///////////////
            var InstructionManualPermissionsAnchor = driver.FindElement(By.Id("Pages.InstructionManual_anchor"));
            Assert.IsTrue(InstructionManualPermissionsAnchor.Enabled);
            Assert.IsTrue(InstructionManualPermissionsAnchor.Displayed);
            Assert.AreEqual(InstructionManualPermissionsAnchor.Text, "Instruction Manual");
            Assert.AreEqual(InstructionManualPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var InstructionManualPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.InstructionManual_anchor\"]/i[1]"));
            Assert.IsTrue(InstructionManualPermissionsCheckBox.Enabled);
            Assert.IsTrue(InstructionManualPermissionsCheckBox.Displayed);
            Assert.AreEqual(InstructionManualPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(InstructionManualPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var InstructionManualPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.InstructionManual_anchor\"]/i[2]"));
            Assert.IsTrue(InstructionManualPermissionsFolderIcon.Enabled);
            Assert.IsTrue(InstructionManualPermissionsFolderIcon.Displayed);
            Assert.AreEqual(InstructionManualPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(InstructionManualPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Error List Permissions
            InstructionManualPermissionsAnchor.Click();



            //////////////////// Message Permissions ///////////////
            var MessagesPermissionsAnchor = driver.FindElement(By.Id("Pages.Message_anchor"));
            Assert.IsTrue(MessagesPermissionsAnchor.Enabled);
            Assert.IsTrue(MessagesPermissionsAnchor.Displayed);
            Assert.AreEqual(MessagesPermissionsAnchor.Text, "Messages");
            Assert.AreEqual(MessagesPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var MessagePermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Message_anchor\"]/i[1]"));
            Assert.IsTrue(MessagePermissionsCheckBox.Enabled);
            Assert.IsTrue(MessagePermissionsCheckBox.Displayed);
            Assert.AreEqual(MessagePermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(MessagePermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var MessagePermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Message_anchor\"]/i[2]"));
            Assert.IsTrue(MessagePermissionsFolderIcon.Enabled);
            Assert.IsTrue(MessagePermissionsFolderIcon.Displayed);
            Assert.AreEqual(MessagePermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(MessagePermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Configurations permissions
            var MessagePermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Message\"]/i"));
            Assert.IsTrue(MessagePermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(MessagePermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(MessagePermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(MessagePermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Message Perimssions
            MessagesPermissionsAnchor.Click();



            ///////////////////  Operations Permissions ///////////////
            var OperationsPermissionsAnchor = driver.FindElement(By.Id("Pages.Operations_anchor"));
            Assert.IsTrue(OperationsPermissionsAnchor.Enabled);
            Assert.IsTrue(OperationsPermissionsAnchor.Displayed);
            Assert.AreEqual(OperationsPermissionsAnchor.Text, "Operations");
            Assert.AreEqual(OperationsPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var OperationsPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Operations_anchor\"]/i[1]"));
            Assert.IsTrue(OperationsPermissionsCheckBox.Enabled);
            Assert.IsTrue(OperationsPermissionsCheckBox.Displayed);
            Assert.AreEqual(OperationsPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(OperationsPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var OperationsPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Operations_anchor\"]/i[2]"));
            Assert.IsTrue(OperationsPermissionsFolderIcon.Enabled);
            Assert.IsTrue(OperationsPermissionsFolderIcon.Displayed);
            Assert.AreEqual(OperationsPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(OperationsPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Operations permissions
            var OperationsPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Operations\"]/i"));
            Assert.IsTrue(OperationsPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(OperationsPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(OperationsPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(OperationsPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Operations Perimssions
            OperationsPermissionsAnchor.Click();



            ///////////////////// Orgnization Permissions ///////////////////
            var OrganizationsPermissionsAnchor = driver.FindElement(By.Id("Pages.OrganizationTypes_anchor"));
            Assert.IsTrue(OrganizationsPermissionsAnchor.Enabled);
            Assert.IsTrue(OrganizationsPermissionsAnchor.Displayed);
            Assert.AreEqual(OrganizationsPermissionsAnchor.Text, "Organizations");
            Assert.AreEqual(OrganizationsPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var OrganizationsPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.OrganizationTypes_anchor\"]/i[1]"));
            Assert.IsTrue(OrganizationsPermissionsCheckBox.Enabled);
            Assert.IsTrue(OrganizationsPermissionsCheckBox.Displayed);
            Assert.AreEqual(OrganizationsPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(OrganizationsPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var OrganizationsPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.OrganizationTypes_anchor\"]/i[2]"));
            Assert.IsTrue(OrganizationsPermissionsFolderIcon.Enabled);
            Assert.IsTrue(OrganizationsPermissionsFolderIcon.Displayed);
            Assert.AreEqual(OrganizationsPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(OrganizationsPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Organizations permissions
            var OrganizationsPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.OrganizationTypes\"]/i"));
            Assert.IsTrue(OrganizationsPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(OrganizationsPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(OrganizationsPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(OrganizationsPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Message Perimssions
            OrganizationsPermissionsAnchor.Click();



            ////////////////// Reports Permissions ///////////////
            var ReportPermissionsAnchor = driver.FindElement(By.Id("Pages.Report_anchor"));
            Assert.IsTrue(ReportPermissionsAnchor.Enabled);
            Assert.IsTrue(ReportPermissionsAnchor.Displayed);
            Assert.AreEqual(ReportPermissionsAnchor.Text, "Report");
            Assert.AreEqual(ReportPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var ReportPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Report_anchor\"]/i[1]"));
            Assert.IsTrue(ReportPermissionsCheckBox.Enabled);
            Assert.IsTrue(ReportPermissionsCheckBox.Displayed);
            Assert.AreEqual(ReportPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReportPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ReportPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Report_anchor\"]/i[2]"));
            Assert.IsTrue(ReportPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ReportPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ReportPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReportPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Reports permissions
            var ReportPermsissionMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Report\"]/i"));
            Assert.IsTrue(ReportPermsissionMinimizeCollection.Enabled);
            Assert.IsTrue(ReportPermsissionMinimizeCollection.Displayed);
            Assert.AreEqual(ReportPermsissionMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReportPermsissionMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Reports Perimssions
            ReportPermissionsAnchor.Click();



            /////////////// Review Edit Create Btn Permissions ////////////
            var ReviewEditCreateBtnPermissionsAnchor = driver.FindElement(By.Id("Pages.ViewEdit.CreateButton_anchor"));
            Assert.IsTrue(ReviewEditCreateBtnPermissionsAnchor.Enabled);
            Assert.IsTrue(ReviewEditCreateBtnPermissionsAnchor.Displayed);
            Assert.AreEqual(ReviewEditCreateBtnPermissionsAnchor.Text, "Review Edit Create Button");
            Assert.AreEqual(ReviewEditCreateBtnPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var ReviewEditCreateBtnPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.ViewEdit.CreateButton_anchor\"]/i[1]"));
            Assert.IsTrue(ReviewEditCreateBtnPermissionsCheckBox.Enabled);
            Assert.IsTrue(ReviewEditCreateBtnPermissionsCheckBox.Displayed);
            Assert.AreEqual(ReviewEditCreateBtnPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditCreateBtnPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ReviewEditCreateBtnPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.ViewEdit.CreateButton_anchor\"]/i[2]"));
            Assert.IsTrue(ReviewEditCreateBtnPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ReviewEditCreateBtnPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ReviewEditCreateBtnPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditCreateBtnPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Review Edits Create Btn Permissions 
            ReviewEditCreateBtnPermissionsAnchor.Click();



            //////  Review Edits Permissions /////////////////////
            var ReviewEditsPermissionsAnchor = driver.FindElement(By.Id("Pages.Reviewer.ReviewEdit_anchor"));
            Assert.IsTrue(ReviewEditsPermissionsAnchor.Enabled);
            Assert.IsTrue(ReviewEditsPermissionsAnchor.Displayed);
            Assert.AreEqual(ReviewEditsPermissionsAnchor.Text, "Review Edits");
            Assert.AreEqual(ReviewEditsPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var ReviewEditsPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Reviewer.ReviewEdit_anchor\"]/i[1]"));
            Assert.IsTrue(ReviewEditsPermissionsCheckBox.Enabled);
            Assert.IsTrue(ReviewEditsPermissionsCheckBox.Displayed);
            Assert.AreEqual(ReviewEditsPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditsPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ReviewEditsPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Reviewer.ReviewEdit_anchor\"]/i[2]"));
            Assert.IsTrue(ReviewEditsPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ReviewEditsPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ReviewEditsPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditsPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Review Edits permissions
            var ReviewEditsMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Reviewer.ReviewEdit\"]/i"));
            Assert.IsTrue(ReviewEditsMinimizeCollection.Enabled);
            Assert.IsTrue(ReviewEditsMinimizeCollection.Displayed);
            Assert.AreEqual(ReviewEditsMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditsMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Message Perimssions
            ReviewEditsPermissionsAnchor.Click();



            ///////////////// Review Edits For Reviewer Permissions /////////////
            var ReviewEditsForReviewerPermissionsAnchor = driver.FindElement(By.Id("Pages.Reviewer.ViewEdit_anchor"));
            Assert.IsTrue(ReviewEditsForReviewerPermissionsAnchor.Enabled);
            Assert.IsTrue(ReviewEditsForReviewerPermissionsAnchor.Displayed);
            Assert.AreEqual(ReviewEditsForReviewerPermissionsAnchor.Text, "Review Edits for Reviewer");
            Assert.AreEqual(ReviewEditsForReviewerPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var ReviewEditsForReviewerBtnPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Reviewer.ViewEdit_anchor\"]/i[1]"));
            Assert.IsTrue(ReviewEditsForReviewerBtnPermissionsCheckBox.Enabled);
            Assert.IsTrue(ReviewEditsForReviewerBtnPermissionsCheckBox.Displayed);
            Assert.AreEqual(ReviewEditsForReviewerBtnPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditsForReviewerBtnPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ReviewEditsForReviewerPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Reviewer.ViewEdit_anchor\"]/i[2]"));
            Assert.IsTrue(ReviewEditsForReviewerPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ReviewEditsForReviewerPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ReviewEditsForReviewerPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditsForReviewerPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Review Edits For Reviewer
            ReviewEditsForReviewerPermissionsAnchor.Click();



            ///////////// Review Edits For Reviewer Side Menu /////////////
            var ReviewEditsSideMenuPermissionsAnchor = driver.FindElement(By.Id("Pages.SideBar.ReviewEdit_anchor"));
            Assert.IsTrue(ReviewEditsSideMenuPermissionsAnchor.Enabled);
            Assert.IsTrue(ReviewEditsSideMenuPermissionsAnchor.Displayed);
            Assert.AreEqual(ReviewEditsSideMenuPermissionsAnchor.Text, "Review Edits Side Menu");
            Assert.AreEqual(ReviewEditsSideMenuPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var ReviewEditsSideMenuBtnPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.SideBar.ReviewEdit_anchor\"]/i[1]"));
            Assert.IsTrue(ReviewEditsSideMenuBtnPermissionsCheckBox.Enabled);
            Assert.IsTrue(ReviewEditsSideMenuBtnPermissionsCheckBox.Displayed);
            Assert.AreEqual(ReviewEditsSideMenuBtnPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditsSideMenuBtnPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ReviewEditsSideMenuPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.SideBar.ReviewEdit_anchor\"]/i[2]"));
            Assert.IsTrue(ReviewEditsSideMenuPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ReviewEditsSideMenuPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ReviewEditsSideMenuPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewEditsSideMenuPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all review Edit Side Menu Permissions 
            ReviewEditsSideMenuPermissionsAnchor.Click();



            // ///////////// Reviewer Dashboard Permsissions /////////////
            var ReviewerDashboardPermissionsAnchor = driver.FindElement(By.Id("Pages.SideBar.ReviewEdit_anchor"));
            Assert.IsTrue(ReviewerDashboardPermissionsAnchor.Enabled);
            Assert.IsTrue(ReviewerDashboardPermissionsAnchor.Displayed);
             Assert.AreEqual(ReviewerDashboardPermissionsAnchor.Text, "Reviewer Dashborad");
            Assert.AreEqual(ReviewerDashboardPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var ReviewerDashboardPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.SideBar.ReviewEdit_anchor\"]/i[1]"));
            Assert.IsTrue(ReviewerDashboardPermissionsCheckBox.Enabled);
            Assert.IsTrue(ReviewerDashboardPermissionsCheckBox.Displayed);
            Assert.AreEqual(ReviewerDashboardPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewerDashboardPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ReviewerDashboardPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.SideBar.ReviewEdit_anchor\"]/i[2]"));
            Assert.IsTrue(ReviewerDashboardPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ReviewerDashboardPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ReviewerDashboardPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ReviewerDashboardPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Reviewer Dashboard Permissions 
            ReviewerDashboardPermissionsAnchor.Click();



            ////////////// Roles Permissions /////////////
            var RolesPermissionsAnchor = driver.FindElement(By.Id("Pages.Roles_anchor"));
            Assert.IsTrue(RolesPermissionsAnchor.Enabled);
            Assert.IsTrue(RolesPermissionsAnchor.Displayed);
            Assert.AreEqual(RolesPermissionsAnchor.Text, "Roles");
            Assert.AreEqual(RolesPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var RolesPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Roles_anchor\"]/i[1]"));
            Assert.IsTrue(RolesPermissionsCheckBox.Enabled);
            Assert.IsTrue(RolesPermissionsCheckBox.Displayed);
            Assert.AreEqual(RolesPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(RolesPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var RolesPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Roles_anchor\"]/i[2]"));
            Assert.IsTrue(RolesPermissionsFolderIcon.Enabled);
            Assert.IsTrue(RolesPermissionsFolderIcon.Displayed);
            Assert.AreEqual(RolesPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(RolesPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            // this icon when click on it will minimize all Roles permissions
            var RolesMinimizeCollection = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Roles\"]/i"));
            Assert.IsTrue(RolesMinimizeCollection.Enabled);
            Assert.IsTrue(RolesMinimizeCollection.Displayed);
            Assert.AreEqual(RolesMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(RolesMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Roles Permissions
            RolesPermissionsAnchor.Click();


            
            ////////////// Tenants Permissions /////////////
            var TenantsPermissionsAnchor = driver.FindElement(By.Id("Pages.Tenants_anchor"));
            Assert.IsTrue(TenantsPermissionsAnchor.Enabled);
            Assert.IsTrue(TenantsPermissionsAnchor.Displayed);
            Assert.AreEqual(TenantsPermissionsAnchor.Text, "Tenants");
            Assert.AreEqual(TenantsPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var TenantsPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Tenants_anchor\"]/i[1]"));
            Assert.IsTrue(TenantsPermissionsCheckBox.Enabled);
            Assert.IsTrue(TenantsPermissionsCheckBox.Displayed);
            Assert.AreEqual(TenantsPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(TenantsPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var TenantsPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Tenants_anchor\"]/i[2]"));
            Assert.IsTrue(TenantsPermissionsFolderIcon.Enabled);
            Assert.IsTrue(TenantsPermissionsFolderIcon.Displayed);
            Assert.AreEqual(TenantsPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(TenantsPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Tenants Permissions
            TenantsPermissionsAnchor.Click();




            ///////////// Users Permissions //////////////
            var UsersPermissionsAnchor = driver.FindElement(By.Id("Pages.Users_anchor"));
            Assert.IsTrue(UsersPermissionsAnchor.Enabled);
            Assert.IsTrue(UsersPermissionsAnchor.Displayed);
            Assert.AreEqual(UsersPermissionsAnchor.Text, "Users");
            Assert.AreEqual(UsersPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var UsersPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Users_anchor\"]/i[1]"));
            Assert.IsTrue(UsersPermissionsCheckBox.Enabled);
            Assert.IsTrue(UsersPermissionsCheckBox.Displayed);
            Assert.AreEqual(UsersPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(UsersPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var UsersPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Users_anchor\"]/i[2]"));
            Assert.IsTrue(UsersPermissionsFolderIcon.Enabled);
            Assert.IsTrue(UsersPermissionsFolderIcon.Displayed);
            Assert.AreEqual(UsersPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(UsersPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            var UsersMinimizeCollection = driver.FindElement
               (By.XPath("//*[@id=\"Pages.Users\"]/i"));
            Assert.IsTrue(UsersMinimizeCollection.Enabled);
            Assert.IsTrue(UsersMinimizeCollection.Displayed);
            Assert.AreEqual(UsersMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(UsersMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all Users Permissions
            UsersPermissionsAnchor.Click();



            ///////////// View/Edit Permissions //////////////
            var ViewEditsPermissionsAnchor = driver.FindElement(By.Id("Pages.ViewEdit_anchor"));
            Assert.IsTrue(ViewEditsPermissionsAnchor.Enabled);
            Assert.IsTrue(ViewEditsPermissionsAnchor.Displayed);
            Assert.AreEqual(ViewEditsPermissionsAnchor.Text, "View/Edit");
            Assert.AreEqual(ViewEditsPermissionsAnchor.GetAttribute("class"), "jstree-anchor  jstree-clicked");

            var ViewEditsPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.ViewEdit_anchor\"]/i[1]"));
            Assert.IsTrue(ViewEditsPermissionsCheckBox.Enabled);
            Assert.IsTrue(ViewEditsPermissionsCheckBox.Displayed);
            Assert.AreEqual(ViewEditsPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(ViewEditsPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var ViewEditsPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.ViewEdit_anchor\"]/i[2]"));
            Assert.IsTrue(ViewEditsPermissionsFolderIcon.Enabled);
            Assert.IsTrue(ViewEditsPermissionsFolderIcon.Displayed);
            Assert.AreEqual(ViewEditsPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(ViewEditsPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            var ViewEditsMinimizeCollection = driver.FindElement
               (By.XPath("//*[@id=\"Pages.ViewEdit\"]/i"));
            Assert.IsTrue(ViewEditsMinimizeCollection.Enabled);
            Assert.IsTrue(ViewEditsMinimizeCollection.Displayed);
            Assert.AreEqual(ViewEditsMinimizeCollection.GetAttribute("role"), "presentation");
            Assert.AreEqual(ViewEditsMinimizeCollection.GetAttribute("class"), "jstree-icon jstree-ocl");

            //// to check on all View Edits Permissions
            ViewEditsPermissionsAnchor.Click();


            
            ///////////// Visualizations Permissions //////////////
            var VisualizationPermissionsAnchor = driver.FindElement(By.Id("Pages.Visualization_anchor"));
            Assert.IsTrue(VisualizationPermissionsAnchor.Enabled);
            Assert.IsTrue(VisualizationPermissionsAnchor.Displayed);
            Assert.AreEqual(VisualizationPermissionsAnchor.Text, "Visualization");
            Assert.AreEqual(VisualizationPermissionsAnchor.GetAttribute("class"), "jstree-anchor");

            var VisualizationPermissionsCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Visualization_anchor\"]/i[1]"));
            Assert.IsTrue(VisualizationPermissionsCheckBox.Enabled);
            Assert.IsTrue(VisualizationPermissionsCheckBox.Displayed);
            Assert.AreEqual(VisualizationPermissionsCheckBox.GetAttribute("role"), "presentation");
            Assert.AreEqual(VisualizationPermissionsCheckBox.GetAttribute("class"), "jstree-icon jstree-checkbox");

            var VisualizationPermissionsFolderIcon = driver.FindElement
                (By.XPath("//*[@id=\"Pages.Visualization_anchor\"]/i[2]"));
            Assert.IsTrue(VisualizationPermissionsFolderIcon.Enabled);
            Assert.IsTrue(VisualizationPermissionsFolderIcon.Displayed);
            Assert.AreEqual(VisualizationPermissionsFolderIcon.GetAttribute("role"), "presentation");
            Assert.AreEqual(VisualizationPermissionsFolderIcon.GetAttribute("class"), "jstree-icon jstree-themeicon fa fa-folder m--font-warning jstree-themeicon-custom");

            //// to check on all Visualization Permissions
            VisualizationPermissionsAnchor.Click();

            var noteWarning = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div[2]/div[2]"));
            Assert.IsTrue(noteWarning.Enabled);
            Assert.IsTrue(noteWarning.Displayed);
            Assert.AreEqual(noteWarning.GetAttribute("class"), "note note-warning");
            Assert.AreEqual(noteWarning.Text, "If you are changing your own permissions, you may need to refresh page (F5) to take effect of permission changes on your own screen!");
        }

        [Test]
        public void UsersPage_DeleteIconTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var deleteIcon = driver.FindElement
               (By.XPath("//*[@id=\"userTable\"]/tbody/tr[7]/td[8]/a[3]"));
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
            Assert.IsTrue(deleteIcon.GetAttribute("onclick").Contains("deleteUser"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"userTable\"]/tbody/tr[7]/td[8" +
                "]/a[3]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-trash");
        }

        [Test]
        public void UsersPage_DeleteFormTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var deleteIcon = driver.FindElement
               (By.XPath("//*[@id=\"userTable\"]/tbody/tr[7]/td[8]/a[3]"));
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
        public void UserPage_PaginationTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("userTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"),"userTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next");
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("userTable_previous"));
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.AreEqual(previoustBtn.GetAttribute("aria-controls"),"userTable");
            Assert.AreEqual(previoustBtn.GetAttribute("class"), "paginate_button previous disabled");
            previoustBtn.Click();

            var pages = driver.FindElements(By.XPath("userTable"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void UsersPage_DataTableInfoTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("userTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void UsersPage_CopyRightTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void UsersPage_MinimizeToggleBtnTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }

    // becuse database not allow store two user by same email address this method will generate random email 
    // in each testcase
    public static class Helper
    {
        public static string GenerateRandomEmail()
        {
            var buffer = "abcdefgh09ijklmnoprsquz1245678";
            var email = "";
            for (int i = 0; i < 8; i++)
            {
                var randIndex = Random.Shared.Next(0,buffer.Length); 
                email += buffer[randIndex];
            }
            return email;
        }
    }
}
