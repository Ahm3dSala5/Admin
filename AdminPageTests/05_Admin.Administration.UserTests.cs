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
            //driver.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
              //  driver.Quit();
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
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Users");
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
               By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a/span"));
            Assert.True(usersBtn.Enabled);
            Assert.True(usersBtn.Displayed);
            Assert.AreEqual(usersBtn.Text, "Users");
            Assert.AreEqual(usersBtn.GetAttribute("class"), "m-nav__link-text");

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
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void UserPage_DataTableLengthTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"userTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("userTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
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
            Assert.AreEqual(searchLabel.Text, "Search:");
            Assert.IsTrue(searchLabel.Displayed);

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"userTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
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
        public void UserPage_ReOrderTableTest()
        {
            // to open user page
            UsersPage_OpenPage();

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
        public void UserPage_EditFormTest()
        {
            // to open user page
            UsersPage_OpenPage();

            // to open edit form
            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[1]"));
            editIcon.Click();

            var selectTenant = driver.FindElement
               (By.Id("TenantId"));
            var selectedTenantName = new SelectElement(selectTenant);
            selectedTenantName.SelectByIndex(1);

            var usernameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[1]/div[2]/div/div/label"));
            Assert.True(usernameLabel.Enabled);

            var usernameInput = driver.FindElement(By.Id("username"));
            var requiredField = usernameInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(usernameInput.Enabled);
            //Assert.True(usernameInput.Displayed);
            usernameInput.SendKeys("Tset User Name");

            var firstnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div[1]/div/div/label"));
            firstnameLabel.Click();
            Assert.True(firstnameLabel.Enabled);
            Assert.True(firstnameLabel.Displayed);
            Assert.AreEqual(firstnameLabel.Text, "First Name");

            var firstnameInput = driver.FindElement(By.Id("name"));
            Assert.True(firstnameInput.Enabled);
            Assert.True(firstnameInput.Displayed);
            firstnameInput.SendKeys("first Name Test");

            var lastnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div[2]/div/div/label"));
            lastnameLabel.Click();
            Assert.True(lastnameLabel.Enabled);
            Assert.True(lastnameLabel.Displayed);
            Assert.AreEqual(lastnameLabel.Text, "Last Name");

            var lastnameInput = driver.FindElement(By.Id("surname"));
            Assert.True(lastnameInput.Enabled);
            Assert.True(lastnameInput.Displayed);
            lastnameInput.SendKeys("last Name Test");


            var emailLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[3]/div/div/div/label"));
            Assert.AreEqual(emailLabel.Text, "Email address");
            Assert.True(emailLabel.Displayed);
            Assert.True(emailLabel.Enabled);

            var emailInput = driver.FindElement(By.Id("email"));
            Assert.True(emailInput.Displayed);
            Assert.True(emailInput.Enabled);
            emailInput.SendKeys($"{Helper.GenerateRandomEmail()}@gmail.com");

            var isActiveLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[4]/div/div/div/label"));
            Assert.AreEqual(isActiveLabel.Text, "Is Active");
            Assert.True(isActiveLabel.Displayed);
            Assert.True(isActiveLabel.Enabled);
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
        public void UserPage_EditPasswordIConTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var editPasswordICon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[2]"));
            editPasswordICon.Click();

            var passwordLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[1]/div/div/div/label"));
            passwordLabel.Click();
            Assert.True(passwordLabel.Displayed);
            Assert.True(passwordLabel.Enabled);

            var passwordInput = driver.FindElement(By.Id("pass"));
            Assert.True(passwordInput.Displayed);
            Assert.True(passwordInput.Enabled);
            passwordInput.SendKeys("Test Password");
            var passwordPlaceholder = passwordInput.GetAttribute("placeholder");
            Assert.AreEqual(passwordPlaceholder, "Password");
            var passwordSettingMessage = 
            "Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters";
            Assert.AreEqual(passwordSettingMessage,passwordInput.GetAttribute("title"));

            var confirmPasswordLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div/div/div/label"));
            confirmPasswordLabel.Click();
            Assert.AreEqual(confirmPasswordLabel.Text, "Confirm Password");
            Assert.True(confirmPasswordLabel.Displayed);
            Assert.True(confirmPasswordLabel.Enabled);

            var confirmPasswordInput = driver.FindElement(By.Id("cpass"));
            Assert.True(confirmPasswordInput.Displayed);
            Assert.True(confirmPasswordInput.Enabled);
            confirmPasswordInput.SendKeys("Test Password");
            var confirmpasswordPlaceholder = confirmPasswordInput.GetAttribute("placeholder");
            Assert.AreEqual(confirmpasswordPlaceholder, "Confirm password");

            var saveBtn = driver.FindElement
            (By.XPath("//*[@id=\"EditUserPasswordModalId\"]/div/div/div[3]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "button");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"EditUserPasswordModalId\"]/div/div/div[3]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "button");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
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

        [Test]
        public void UserPage_PermissionsFormTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var permissionIcon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[5]/td[8]/a[4]"));
            permissionIcon.Click();
            Assert.AreEqual(permissionIcon.GetAttribute("title"), "Permission");
            Assert.True(permissionIcon.Displayed);
            Assert.True(permissionIcon.Enabled);

            var assetAttributes = driver.FindElement(By.Id("Pages.AssetAttributes_anchor"));
            Assert.True(assetAttributes.Enabled);
            assetAttributes.Click();
            Assert.AreEqual(assetAttributes.Text,"Asset Attributes");

            var assetClasses = driver.FindElement(By.Id("Pages.AssetClasses_anchor"));
            Assert.True(assetClasses.Enabled);
            assetClasses.Click();
            Assert.AreEqual(assetClasses.Text, "Asset Classes");

            var assetSubClasses = driver.FindElement(By.Id("Pages.AssetSubClasses_anchor"));
            Assert.True(assetSubClasses.Enabled);
            assetSubClasses.Click();
            Assert.AreEqual(assetSubClasses.Text, "Asset Sub Classes");

            var assetType = driver.FindElement(By.Id("Pages.AssetTypes_anchor"));
            Assert.True(assetType.Enabled);
            assetType.Click();
            Assert.AreEqual(assetType.Text, "Asset Types");

            var assets = driver.FindElement(By.Id("Pages.Assets_anchor"));
            Assert.True(assets.Enabled);
            assets.Click();
            Assert.AreEqual(assets.Text, "Assets");

            var audit = driver.FindElement(By.Id("Pages.Audit_anchor"));
            Assert.True(audit.Enabled);
            audit.Click();
            Assert.AreEqual(audit.Text, "Audit");

            var Organization = driver.FindElement(By.Id("Pages.OrganizationTypes_anchor"));
            Assert.True(Organization.Enabled);
            Organization.Click();
            Assert.AreEqual(Organization.Text, "Organizations");

            var message = driver.FindElement(By.Id("Pages.Message_anchor"));
            Assert.True(message.Enabled);
            message.Click();
            Assert.AreEqual(message.Text, "Messages");

            var operations = driver.FindElement(By.Id("Pages.Operations_anchor"));
            Assert.True(operations.Enabled);
            operations.Click();
            Assert.AreEqual(operations.Text, "Operations");

            var report = driver.FindElement(By.Id("Pages.Report_anchor"));
            Assert.True(report.Enabled);
            report.Click();
            Assert.AreEqual(report.Text, "Report");

            var reviewEdit = driver.FindElement(By.Id("Pages.Reviewer.ReviewEdit_anchor"));
            Assert.True(reviewEdit.Enabled);
            reviewEdit.Click();
            Assert.AreEqual(reviewEdit.Text, "Review Edits");

            var roles = driver.FindElement(By.Id("Pages.Roles_anchor"));
            Assert.True(roles.Enabled);
            roles.Click();
            Assert.AreEqual(roles.Text, "Roles");

            var user = driver.FindElement(By.Id("Pages.Users_anchor"));
            Assert.True(user.Enabled);
            user.Click();
            Assert.AreEqual(user.Text, "Users");

            var viewEdit = driver.FindElement(By.Id("Pages.ViewEdit_anchor"));
            Assert.True(viewEdit.Enabled);
            viewEdit.Click();
            Assert.AreEqual(viewEdit.Text, "View/Edit");
        }

        [Test]
        public void UserPage_PaginationTest()
        {
            // to open user page
            UsersPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("userTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("userTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();
        }

        // delete and review all forms of icons and last methods

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
