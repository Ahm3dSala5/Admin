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
        public void AdministrationOption_WhenClickOnAdministrationBtn_MustOpenDrodownlist()
        {
            var administrationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));

            administrationBtn.Click();
        }

        [Test]
        public void RolesPage_WhenClickOnRolesOption_MustOpenRolesPage()
        {
            // to click on administaration option
            AdministrationOption_WhenClickOnAdministrationBtn_MustOpenDrodownlist();

            var roleBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[3]/a/span/span"));
            roleBtn.Click();
        }

        [Test]
        public void RolesPage_PageTitleTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));
            Assert.AreEqual(title.Text,"Roles");
            Assert.True(title.Enabled);
            Assert.True(title.Displayed);   
        }

        [Test]
        public void RolesPage_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

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
        public void RolesPage_DataTableLengthTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"roleTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("roleTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void RolesPage_CreateBtnTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var createBtn = driver.FindElement(By.Id("btnCreateRoles"));
            createBtn.Click();
            Assert.AreEqual("Create", createBtn.Text);
            Assert.True(createBtn.Displayed);
            Assert.True(createBtn.Enabled);
        }

        [Test]
        public void RolesPage_DataTableFilterTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var searchLabel = driver.FindElement
                (By.Id("roleTable_filter"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");
            Assert.IsTrue(searchLabel.Displayed);

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"roleTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
        }

        [Test]
        public void RolesPage_RolesBtnTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var rolesBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a/span"));
            Assert.AreEqual(rolesBtn.Text,"Roles");
            Assert.True(rolesBtn.Displayed);
            Assert.True(rolesBtn.Enabled);

            var UrlBeforeClickOnRolesBtn = driver.Url;
            rolesBtn.Click();
            var UrlAfterClickOnRolesBtn = driver.Url;
            Assert.AreEqual(UrlAfterClickOnRolesBtn,UrlAfterClickOnRolesBtn);
        }

        [Test]
        public void RolesPage_CreateFormTest()
        {
            // to open create form 
            RolesPage_CreateBtnTest();

            var roleNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[1]/div/div/div/label"));
            roleNameLabel.Click();
            Assert.True(roleNameLabel.Enabled);
            Assert.True(roleNameLabel.Displayed);
            Assert.AreEqual(roleNameLabel.Text, "Role Name");

            var roleNameInpout = driver.FindElement(By.Id("rolename"));
            var requiredField = roleNameInpout.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(roleNameInpout.Enabled);
            Assert.True(roleNameInpout.Displayed);
            roleNameInpout.SendKeys("Test Role Name");
            var roleNameMinLength = roleNameInpout.GetAttribute("minlength");
            var roleNameMaxLength = roleNameInpout.GetAttribute("maxlength");
            Assert.AreEqual(roleNameMinLength,"2");
            Assert.AreEqual(roleNameMaxLength,"32");

            var displayNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[2]/div/div/div/label"));
            displayNameLabel.Click();
            Assert.True(displayNameLabel.Enabled);
            Assert.True(displayNameLabel.Displayed);
            Assert.AreEqual(displayNameLabel.Text, "Display Name");

            var displayNameInput = driver.FindElement(By.Id("displayname"));
            Assert.True(displayNameInput.Enabled);
            Assert.True(displayNameInput.Displayed);
            displayNameInput.SendKeys("Display Name Test");
            var displayNameminLength = displayNameInput.GetAttribute("minlength");
            var displayNamemaxLength = displayNameInput.GetAttribute("maxlength");
            Assert.AreEqual(displayNameminLength, "2");
            Assert.AreEqual(displayNamemaxLength, "32");

            var tenantNameDropdownlist = driver.FindElement(By.Id("Tenants"));
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
            var descripotionminLength = displayNameInput.GetAttribute("minlength");
            var descriptionmaxLength = displayNameInput.GetAttribute("maxlength");
            Assert.AreEqual(descripotionminLength, "2");
            Assert.AreEqual(descriptionmaxLength, "32");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"RoleCreateModal\"]/div/div/div[2]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }


        [Test]
        public void RolesPage_ReOrderTableTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var name = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[1]"));
            name.Click();
            Assert.True(name.Enabled);
            Assert.True(name.Displayed);
            Assert.AreEqual(name.Text, "Name");
            var NameSortMessage = name.GetAttribute("aria-label");
            var message = "Name: activate to sort column ascending";
            Assert.AreEqual(NameSortMessage,message);

            var displayName = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[2]"));
            displayName.Click();
            Assert.True(displayName.Enabled);
            Assert.True(displayName.Displayed);
            Assert.AreEqual(displayName.Text, "Display Name");
            var DisplayNameSortMessage = displayName.GetAttribute("aria-label");
            var DisplayNamemessage = "Display Name: activate to sort column descending";
            Assert.AreEqual(DisplayNameSortMessage, DisplayNamemessage);

            var tenant = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[3]"));
            tenant.Click();
            Assert.True(tenant.Enabled);
            Assert.True(tenant.Displayed);
            Assert.AreEqual(tenant.Text, "Tenant");
            var TenantSortMessage = tenant.GetAttribute("aria-label");
            var TenantMessage = "Tenant: activate to sort column descending";
            Assert.AreEqual(TenantSortMessage, TenantMessage);

            var agencyName = driver.FindElement
               (By.XPath("//*[@id=\"roleTable\"]/thead/tr/th[4]"));
            agencyName.Click();
            Assert.True(agencyName.Enabled);
            Assert.True(agencyName.Displayed);
            Assert.AreEqual(agencyName.Text, "Agency Name");
            var agencyNameSortMessage = agencyName.GetAttribute("aria-label");
            var agencyMessage = "Agency Name: activate to sort column descending";
            Assert.AreEqual(agencyNameSortMessage, agencyMessage);
        }

        [Test]
        public void RolesPage_EditAssetIconTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[3]/td[6]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var roleNameLabel = driver.FindElement
               (By.XPath("//*[@id=\"edit-user-details\"]/div[1]/div/div/div/label"));
            roleNameLabel.Click();
            Assert.True(roleNameLabel.Enabled);
            Assert.True(roleNameLabel.Displayed);
            Assert.AreEqual(roleNameLabel.Text, "Role Name");

            var roleNameInpout = driver.FindElement(By.Id("rolename"));
            var requiredField = roleNameInpout.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(roleNameInpout.Enabled);
            var roleNameMinLength = roleNameInpout.GetAttribute("minlength");
            var roleNameMaxLength = roleNameInpout.GetAttribute("maxlength");
            Assert.AreEqual(roleNameMinLength, "2");
            Assert.AreEqual(roleNameMaxLength, "32");

            var displayNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[2]/div/div/div/label"));
            displayNameLabel.Click();
            Assert.True(displayNameLabel.Enabled);
            Assert.True(displayNameLabel.Displayed);
            Assert.AreEqual(displayNameLabel.Text, "Display Name");

            var displayNameInput = driver.FindElement(By.Id("displayname"));
            Assert.True(displayNameInput.Enabled);
            var displayNameminLength = displayNameInput.GetAttribute("minlength");
            var displayNamemaxLength = displayNameInput.GetAttribute("maxlength");
            Assert.AreEqual(displayNameminLength, "2");
            Assert.AreEqual(displayNamemaxLength, "32");

            var roleDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"edit-user-details\"]/div[3]/div/div/div/label"));
            roleDescriptionLabel.Click();
            Assert.True(roleDescriptionLabel.Enabled);
            Assert.True(roleDescriptionLabel.Displayed);
            Assert.AreEqual(roleDescriptionLabel.Text, "Role description");

            var roleDescriptionInput = driver.FindElement(By.Id("role-description"));
            Assert.True(roleDescriptionInput.Enabled);
            var descripotionminLength = displayNameInput.GetAttribute("minlength");
            var descriptionmaxLength = displayNameInput.GetAttribute("maxlength");
            Assert.AreEqual(descripotionminLength, "2");
            Assert.AreEqual(descriptionmaxLength, "32");
        }

        // all input must be disabled
        [Test]
        public void RolesPage_EditRoleForAdmin()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var editRoleForAdmin = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[1]"));
            editRoleForAdmin.Click();

            var roleName = driver.FindElement(By.Id("rolename"));
            var requiredField = roleName.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.False(!roleName.Enabled);
        }

        [Test]
        public void RolesPage_EditRolesPermissionsTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var editRoleIcon = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[1]"));
            editRoleIcon.Click();

            var permsissionsBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div/div/div[2]/form/ul/li[2]/a"));
            permsissionsBtn.Click();
            Assert.AreEqual(permsissionsBtn.Text, "Permissions");
            Assert.True(permsissionsBtn.Enabled);
            Assert.True(permsissionsBtn.Displayed);

            var saveBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div/div/div[3]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "button");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div/div/div[3]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "button");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void RolesPage_DeleteIConTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"roleTable\"]/tbody/tr[1]/td[6]/a[2]"));
            deleteIcon.Click();
            Assert.AreEqual("Delete", deleteIcon.GetAttribute("title"));
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);

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
        public void RolesPage_PaginationTest()
        {
            // to open roles page
            RolesPage_WhenClickOnRolesOption_MustOpenRolesPage();

            var nextBtn = driver.FindElement(By.Id("roleTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("roleTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();
        }
    }
}
