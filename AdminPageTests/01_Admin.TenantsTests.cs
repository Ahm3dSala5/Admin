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
        public void Tenants_WhenClickOnHiAdmin_MustShowingLogoutOption()
        {
            var HiAdmin = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            HiAdmin.Click();

            Assert.AreEqual(HiAdmin.Text, "HI,");
            Assert.True(HiAdmin.Displayed);
            Assert.True(HiAdmin.Enabled);
        }

        [Test]
        public void TenantsPage_HiAdminParagraph()
        {
            var HiAdminOption = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            HiAdminOption.Click();
            Assert.True(HiAdminOption.Displayed);
            Assert.True(HiAdminOption.Enabled);
        }

        [Test]
        public void TenantsPage_LogoutBtnTest()
        {
            // to click on hi admin btn
            TenantsPage_HiAdminParagraph();

            var LogoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/div/div/div/div/ul/li[4]/a"));

            Assert.AreEqual(LogoutBtn.Text,"Logout");
            Assert.True(LogoutBtn.Displayed);
            Assert.True(LogoutBtn.Enabled);
        }

        [Test]
        public void TenantsPage_WhenClickOnLogoutBtn_MustGoToSiginInPage()
        {
            // to click on hi admin btn
            TenantsPage_HiAdminParagraph();

            var LogoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/div/div/div/div/ul/li[4]/a"));
            var AdmintUrl = driver.Url;
            LogoutBtn.Click();
            var SignInUrl = driver.Url;
            Assert.AreNotEqual(AdmintUrl,SignInUrl);
        }

        [Test]
        public void TenantsPage_OpenPage()
        {
            var TenantsBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[1]/a/span/span"));
            TenantsBtn.Click();
        }

        [Test]
        public void TenantsPage_SubHeaderTitleTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Tenants");
        }

        [Test]
        public void TenantsPage_DashboardNavigationLinkTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

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
        public void TenantsPage_AssetClassNavigationLinkTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var tenants = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(tenants.Enabled);
            Assert.True(tenants.Displayed);
            Assert.AreEqual(tenants.Text, "Tenants");
            Assert.AreEqual(tenants.GetAttribute("class"), "m-nav__link-text");
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
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void TenantsPage_DataTableLengthTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("TenantTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
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
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");
            Assert.IsTrue(searchLabel.Displayed);

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
        }

        [Test]
        public void TenantsPage_CreateBtnTest()
        {
            // for go to tenants page
            TenantsPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.AreEqual(createBtn.Text, "Create");
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
        }


        [Test]
        public void TenantsPage_WhenClickOnCreateBtn_MustOpenCreateForm()
        {
            // for go to tenants page
            TenantsPage_OpenPage();
            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
        }

        [Test]
        public void TenantsPage_CreateFormTest()
        {
            // for open create form
            TenantsPage_WhenClickOnCreateBtn_MustOpenCreateForm();

            var tenencyNameLabel = driver.FindElement
               (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/label"));
            Assert.True(tenencyNameLabel.Enabled);
            tenencyNameLabel.Click();

            var tenencyNameInput = driver.FindElement(By.Name("TenancyName"));
            tenencyNameInput.SendKeys("tenency Name Test");
            Assert.AreEqual(tenencyNameInput.GetAttribute("Required"), "true");
            Assert.True(tenencyNameInput.Enabled);
            Assert.True(tenencyNameInput.Displayed);

            var NameLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/label"));
            Assert.True(NameLabel.Displayed);
            Assert.True(NameLabel.Enabled);
            Assert.AreEqual(NameLabel.Text, "Name");
            NameLabel.Click();

            var nameInput = driver.FindElement(By.Name("Name"));
            nameInput.SendKeys("Name Test");
            Assert.AreEqual(nameInput.GetAttribute("Required"), "true");
            Assert.True(nameInput.Enabled);
            Assert.True(nameInput.Displayed);

            var Tier = driver.FindElement(By.Name("Tier"));
            var selectedTier = new SelectElement(Tier);
            selectedTier.SelectByIndex(0);
            Assert.AreEqual(Tier.GetAttribute("Required"), "true");

            var isActiveLabel = driver.FindElement
               (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/div/label"));
            Assert.True(isActiveLabel.Displayed);
            Assert.True(isActiveLabel.Enabled);
            Assert.AreEqual(isActiveLabel.Text, "Is Active");
            isActiveLabel.Click();

            var isActiveInput = driver.FindElement(By.Id("isactive"));
            Assert.AreEqual(isActiveLabel.GetAttribute("for"), isActiveInput.GetAttribute("id"));
            isActiveInput.Click();

            var adminEmailAddress = driver.FindElement
                (By.Name("AdminEmailAddress"));
            Assert.True(adminEmailAddress.Enabled);
            adminEmailAddress.SendKeys("Test Admin Email Address");

            var defualtPasswordMessage = driver.FindElement(By.XPath("//*[@id=\"OrgCreateModal\"]/form/p"));
            Assert.AreEqual(defualtPasswordMessage.Text, "Default password is 123qwe");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);

        }

        [Test]
        public void TenantsPageTest_ReOrderTableTest()
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
        public void TenentsPage_EditIconTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();
            
            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[5]/td[6]/a[1]"));
            editIcon.Click();
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);
            Assert.AreEqual(editIcon.GetAttribute("title"), "Edit");

            var tenencyNameLabel = driver.FindElement
             (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/label"));
            Assert.True(tenencyNameLabel.Enabled);
            tenencyNameLabel.Click();

            var tenencyNameInput = driver.FindElement(By.Name("TenancyName"));
            tenencyNameInput.SendKeys("tenency Name Test");
            Assert.AreEqual(tenencyNameInput.GetAttribute("Required"), "true");
            Assert.True(tenencyNameInput.Enabled);
            Assert.True(tenencyNameInput.Displayed);

            var NameLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/label"));
            Assert.True(NameLabel.Displayed);
            Assert.True(NameLabel.Enabled);
            Assert.AreEqual(NameLabel.Text, "Name");
            NameLabel.Click();

            var nameInput = driver.FindElement(By.Name("Name"));
            nameInput.SendKeys("Name Test");
            Assert.AreEqual(nameInput.GetAttribute("Required"), "true");
            Assert.True(nameInput.Enabled);
            Assert.True(nameInput.Displayed);

            var Tier = driver.FindElement(By.Name("Tier"));
            var selectedTier = new SelectElement(Tier);
            selectedTier.SelectByIndex(0);
            Assert.AreEqual(Tier.GetAttribute("Required"), "true");

            var isActiveInput = driver.FindElement(By.Id("isactive"));
            isActiveInput.Click();

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void TenentsPage_DeleteIConTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[6]/a[2]"));
            deleteIcon.Click();
            Assert.AreEqual("Delete", deleteIcon.GetAttribute("title"));
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);

            var confirmWindo = driver.FindElement(By.XPath("/html/body/div[4]/div/div[1]"));
            Assert.True(confirmWindo.Enabled);

            var warninigMessage = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div[2]"));
            Assert.AreEqual(warninigMessage.Text, "Are you sure?");

            string deleteMessage = "If you delete the tenant,user of this teant will be deleted";
            var deleteMessageText = driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]"));
            Assert.AreEqual(deleteMessage,deleteMessageText.Text);

            var yesBtn = driver.FindElement
                (By.XPath("/html/body/div[4]/div/div[4]/div[2]/button"));
            Assert.AreEqual(yesBtn.Text, "Yes");
            Assert.True(yesBtn.Enabled);
            Assert.True(yesBtn.Displayed);

            var cancelBtn = driver.FindElement(
                By.XPath("/html/body/div[4]/div/div[4]/div[1]/button"));
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void TenantsPage_UserLoginIconTest()
        {
            // to open tenancy page
            TenantsPage_OpenPage();

            var loginUserIcon = driver.FindElement
                (By.XPath("//*[@id=\"TenantTable\"]/tbody/tr[1]/td[1]/a"));
            Assert.True(loginUserIcon.Displayed);
            Assert.True(loginUserIcon.Enabled);
            loginUserIcon.Click();

            var title = loginUserIcon.GetAttribute("title");
            Assert.AreEqual(title, "User Login");

            var UserLoginHeader = driver.FindElement(By.XPath("//*[@id=\"UserModal\"]/div/div/div[1]/h4"));
            var userLoginHeader = "Select a user";
            Assert.AreEqual(UserLoginHeader.Text, userLoginHeader);

            var searchLabel = driver.FindElement(By.XPath("//*[@id=\"UserTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.True(searchLabel.Displayed);

            var searchInput = driver.FindElement(By.XPath("//*[@id=\"UserTable_filter\"]/label/input"));
            searchInput.SendKeys("TestSearch");
            Assert.True(searchInput.Enabled);
            Assert.True(searchInput.Displayed);

            Assert.AreEqual(searchLabel.Text, "Search:");

            var showDropdownlist = driver.FindElement(By.XPath("//*[@id=\"UserTable_length\"]/label"));
            Assert.True(showDropdownlist.Enabled);
            Assert.True(showDropdownlist.Displayed);
            showDropdownlist.SendKeys("25");
            showDropdownlist.Click();

            var PrevisouBtn = driver.FindElement(By.Id("UserTable_previous"));
            Assert.True(PrevisouBtn.Enabled);
            Assert.True(PrevisouBtn.Displayed);
            PrevisouBtn.Click();
            Assert.AreEqual(PrevisouBtn.Text, "Previous");


            var nextBtn = driver.FindElement(By.Id("UserTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();
            Assert.AreEqual(nextBtn.Text, "Next");

            var XIcon = driver.FindElement(By.Id("closeButton"));
            Assert.True(XIcon.Enabled);
            Assert.True(XIcon.Displayed);
            XIcon.Click();
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
