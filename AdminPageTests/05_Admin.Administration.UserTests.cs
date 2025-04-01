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
        public void AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayAdministrationDrodownlist()
        {
            var administrationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));

            administrationBtn.Click();
        }

        [Test]
        public void UserPage_WhenClickOnUserOptions_MustOpenUserPage()
        {
            // to click on administaration option
            AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayAdministrationDrodownlist();

            var userOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[2]/a/span"));
            userOption.Click();
        }

        [Test]
        public void UserPage_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open user page
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

            var dashbaordBtn = driver.FindElement(
               By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            var assetClassUrl = driver.Url;

            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
            Assert.IsTrue(dashbaordBtn.Displayed);
            Assert.IsTrue(dashbaordBtn.Enabled);
            dashbaordBtn.Click();
            var dashbaordUrl = driver.Url;
            Assert.AreNotEqual(dashbaordUrl, assetClassUrl);
        }

        [Test]
        public void UserPage_UserBtnTest()
        {
            // to open user page
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

            var userBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));

            Assert.True(userBtn.Displayed);
            Assert.True(userBtn.Enabled);
            Assert.AreEqual(userBtn.Text,"Users");

            var linkBeforeClick = driver.Url;
            userBtn.Click();
            var linkAfterClick = driver.Url;
            Assert.AreEqual(linkAfterClick,linkBeforeClick);
        }

        [Test]
        public void UserPage_DataTableLengthTest()
        {
            // to open user page
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

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
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

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
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

            var createBtn = driver.FindElement(By.Id("btnCreateUser"));
            createBtn.Click();
            Assert.AreEqual("Create", createBtn.Text);
            Assert.True(createBtn.Displayed);
            Assert.True(createBtn.Enabled);
        }

        [Test]
        public void UserPage_CreateNewUser_UserDetails()
        {
            // to open create form 
            UserPage_CreateBtnTest();

            var usernameLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[1]/div/div/div/label"));
            Assert.True(usernameLabel.Enabled);

            var usernameInput = driver.FindElement(By.Name("UserName"));
            var requiredField = usernameInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(usernameInput.Enabled);
            Assert.True(usernameInput.Displayed);
            usernameInput.SendKeys("TestName");

            var firstnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[2]/div[1]/div/div/label"));
            firstnameLabel.Click();
            Assert.True(firstnameLabel.Enabled);
            Assert.True(firstnameLabel.Displayed);
            Assert.AreEqual(firstnameLabel.Text, "First Name");

            var firstnameInput = driver.FindElement(By.Name("Name"));
            Assert.True(firstnameInput.Enabled);
            Assert.True(firstnameInput.Displayed);
            firstnameInput.SendKeys("first Name Test");

            var lastnameLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[2]/div[2]/div/div/label"));
            lastnameLabel.Click();
            Assert.True(lastnameLabel.Enabled);
            Assert.True(lastnameLabel.Displayed);
            Assert.AreEqual(lastnameLabel.Text, "Last Name");

            var lastnameInput = driver.FindElement(By.Name("Surname"));
            Assert.True(lastnameInput.Enabled);
            Assert.True(lastnameInput.Displayed);
            lastnameInput.SendKeys("last Name Test");

            var tenantName = driver.FindElement
               (By.Id("Tenants"));
            var selectedTenantName = new SelectElement(tenantName);
            selectedTenantName.SelectByIndex(1);

            var emailLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[4]/div/div/div/label"));
            Assert.AreEqual(emailLabel.Text,"Email address");
            Assert.True(emailLabel.Displayed);
            Assert.True(emailLabel.Enabled);

            var emailInput = driver.FindElement(By.Name("EmailAddress"));
            Assert.True(emailInput.Displayed);
            Assert.True(emailInput.Enabled);
            emailInput.SendKeys($"{Helper.GenerateRandomEmail()}@gmail.com");

            var passwordLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[5]/div/div/div/label"));
            Assert.AreEqual(passwordLabel.Text,"Password");
            Assert.True(passwordLabel.Displayed);
            Assert.True(passwordLabel.Enabled);

            var passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("PasswordTest");
            Assert.True(passwordInput.Displayed);
            Assert.True(passwordInput.Enabled);
            Assert.AreEqual(passwordInput.GetAttribute("type"), "password");

            var confirmPasswordLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[6]/div/div/div/label"));
            Assert.AreEqual(confirmPasswordLabel.Text, "Confirm password");
            Assert.True(confirmPasswordLabel.Enabled);
            Assert.True(confirmPasswordLabel.Displayed);

            var confirmPasswordInput = driver.FindElement(By.Id("ConfirmPassword"));
            confirmPasswordInput.SendKeys("PasswordTest");
            Assert.True(confirmPasswordInput.Displayed);
            Assert.True(confirmPasswordInput.Enabled);
            Assert.AreEqual(confirmPasswordInput.GetAttribute("type"), "password");

            var isActiveLabel = driver.FindElement
                (By.XPath("//*[@id=\"create-user-details\"]/div[7]/div/div/label"));
            Assert.AreEqual(isActiveLabel.Text, "Is Active");
            Assert.True(isActiveLabel.Displayed);
            Assert.True(isActiveLabel.Enabled);

            var isActiveValue = driver.FindElement(By.Id("CreateUserIsActive"));
            Assert.True(isActiveValue.Displayed);
            Assert.True(isActiveValue.Enabled);
            isActiveValue.Click();

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void UserPage_CreateNewUser_UserRoles()
        {
            // to add user details 
            UserPage_CreateNewUser_UserDetails();

            var userRoles = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/ul/li[2]/a"));
            Assert.AreEqual(userRoles.Text, "User roles");
            Assert.True(userRoles.Enabled);
            Assert.True(userRoles.Displayed);
            userRoles.Click();

            var saveBtn = driver.FindElement
            (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"UserCreateModal\"]/div/div/div[2]/form/div[2]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);


        }

        [Test]
        public void UserPage_ReOrderTableTest()
        {
            // to open user page
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

            var userName = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[1]"));
            userName.Click();
            Assert.True(userName.Enabled);
            Assert.True(userName.Displayed);
            Assert.AreEqual(userName.Text, "User Name");

            var fullName = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[2]"));
            fullName.Click();
            Assert.True(fullName.Enabled);
            Assert.True(fullName.Displayed);
            Assert.AreEqual(fullName.Text, "Full Name");

            var emailAddress = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[3]"));
            emailAddress.Click();
            Assert.True(emailAddress.Enabled);
            Assert.True(emailAddress.Displayed);
            Assert.AreEqual(emailAddress.Text, "Email Address");

            var role = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[4]"));
            role.Click();
            Assert.True(role.Enabled);
            Assert.True(role.Displayed);
            Assert.AreEqual(role.Text, "Role");

            var tenantId = driver.FindElement
            (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[5]"));
            tenantId.Click();
            Assert.True(tenantId.Enabled);
            Assert.True(tenantId.Displayed);
            Assert.AreEqual(tenantId.Text, "Tenant Id");


            var agencyName = driver.FindElement
            (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[6]"));
            agencyName.Click();
            Assert.True(agencyName.Enabled);
            Assert.True(agencyName.Displayed);
            Assert.AreEqual(agencyName.Text, "Agency Name");

            var isActive = driver.FindElement
            (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[7]"));
            isActive.Click();
            Assert.True(isActive.Enabled);
            Assert.True(isActive.Displayed);
            Assert.AreEqual(isActive.Text, "Is Active");

            var action = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/thead/tr/th[8]"));
            Assert.AreEqual(action.Text, "Actions");
            Assert.True(fullName.Enabled);
        }

        [Test]
        public void UserPage_EditUserIconTest()
        {
            // to open user page
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

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
        public void UserPage_ChangePasswordIConTest()
        {
            // to open user page
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

            var editPasswordICon = driver.FindElement
                (By.XPath("//*[@id=\"userTable\"]/tbody/tr[1]/td[8]/a[2]"));
            editPasswordICon.Click();
            Assert.AreEqual(editPasswordICon.GetAttribute("title"), "Edit Password");
            Assert.True(editPasswordICon.Displayed);
            Assert.True(editPasswordICon.Enabled);

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
        public void UserPage_PermissionTest()
        {
            // to open user page
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

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
            UserPage_WhenClickOnUserOptions_MustOpenUserPage();

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
