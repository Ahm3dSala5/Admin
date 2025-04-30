using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V130.DOM;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
    public class AdminAdministrationSetupAssetClassesTests : IDisposable
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
        public void AssetClassesPage_AdministratioOptionTest()
        {
            // test adminstration option
            var administrationOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();
            Assert.True(administrationOption.Displayed);
            Assert.True(administrationOption.Enabled);
            Assert.AreEqual("Administration",administrationOption.Text);
            administrationOption.Click();

            string Icon = "m-menu__link-icon flaticon-cogwheel";
            var administrationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[1]"));
            Assert.True(administrationIcon.Displayed);
            Assert.True(administrationIcon.Enabled);
            Assert.AreEqual(administrationIcon.GetAttribute("class"),Icon);

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
            Assert.AreEqual(administrationOptionTitle.GetAttribute("class"),"title");
        }


        [Test]
        public void AssetClassesPage_SetupOptionTest()
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
            Assert.AreEqual(setupOption.GetAttribute("custom-data"),"Setup");
            Assert.AreEqual(setupOption.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(setupOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");
            setupOption.Click();

            string Icon = "m-menu__link-icon flaticon-cogwheel";
            var setupOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/i[1]"));
            Assert.True(setupOptionIcon.Displayed);
            Assert.True(setupOptionIcon.Enabled);
            Assert.AreEqual(setupOptionIcon.GetAttribute("class"),Icon);

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
            Assert.AreEqual(setupOptionTitle.Text,"Setup");
            Assert.AreEqual(setupOptionTitle.GetAttribute("class"),"title");
        }

        [Test]
        public void AssetClassesPage_AssetClassesOtionTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetClassesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[1]/a"));
            Assert.IsTrue(assetClassesOption.Enabled);
            Assert.IsTrue(assetClassesOption.Displayed);
            Assert.AreEqual(assetClassesOption.GetAttribute("target"),"_self");
            Assert.AreEqual(assetClassesOption.GetAttribute("custom-data"),"Asset Classes");
            Assert.AreEqual(assetClassesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(assetClassesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetClasses");

            var assetClassesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[1]/a/i"));
            Assert.IsTrue(assetClassesOptionIcon.Enabled);
            Assert.IsTrue(assetClassesOptionIcon.Displayed);
            Assert.AreEqual(assetClassesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var assetClassOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[1]/a/span/span"));
            Assert.IsTrue(assetClassOptionTitle.Enabled);
            Assert.IsTrue(assetClassOptionTitle.Displayed);
            Assert.AreEqual(assetClassOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetClassPage_OpenPage()
        {
            var administrationOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetClassOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[1]/a/span/span"));
            assetClassOption.Click();
        }

        [Test]
        public void AssetClassPage_TopBarUserNameTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

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
        public void AssetClassPage_LogoutBtnTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

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
        public void AssetClassPage_SubHeaderTitleTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text,"Asset Classes");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void AssetClassPage_DashboardNavigationLinkTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var dashboardNavLink = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.True(dashboardNavLink.Enabled);
            Assert.True(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");

            var urlBeforeClick = driver.Url;
            dashboardNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick,urlBeforeClick);
        }

        [Test]
        public void AssetClassPage_AssetClassNavigationLinkTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var assetClassesNavLink = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(assetClassesNavLink.Enabled);
            Assert.True(assetClassesNavLink.Displayed);
            Assert.AreEqual(assetClassesNavLink.Text, "Asset Classes");
            Assert.AreEqual(assetClassesNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void AssetClassPage_SeperatorBetweenNavigationLinksTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(seperator.Enabled);
            Assert.IsTrue(seperator.Displayed);
            Assert.AreEqual(seperator.Text,">");
            Assert.AreEqual(seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AssetClassPage_DataTableFilterTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchLabel.Displayed);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable_filter\"]/label/input"));
            searchInput.SendKeys("Test");
            Assert.IsTrue(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
            Assert.AreEqual(searchInput.GetAttribute("type"),"search");
            Assert.AreEqual(searchInput.GetAttribute("aria-controls"), "AssetClassesTable");
        }

        [Test]
        public void AssetClassPage_DataTableLengthTests()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable_length\"]/label"));
            showLabel.Click();
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            Assert.True(showLabel.Text.Contains("Show"));

            var showValue = driver.FindElement(By.Name("AssetClassesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            Assert.AreEqual(showValue.GetAttribute("aria-controls"), "AssetClassesTable");

            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetClassPage_CreateBtnTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual(createBtn.Text, "Create");
            Assert.AreEqual(createBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");
        }

        [Test]
        public void AssetClassPage_CreateFormTest()
        {
            // to open Asset Class Page
            AssetClassPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();

            var assetClassesLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[1]/div/div/div/label"));
            Assert.True(assetClassesLabel.Enabled);
            Assert.True(assetClassesLabel.Displayed);
            Assert.AreEqual(assetClassesLabel.Text,"Asset Classes");
            Assert.AreEqual(assetClassesLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassesLabel.GetAttribute("class"),"form-label");
            assetClassesLabel.Click();

            var assetClassInput = driver.FindElement(By.Id("ClassName"));
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("type"),"text");
            Assert.AreEqual(assetClassInput.GetAttribute("required"),"true");
            Assert.AreEqual(assetClassInput.GetAttribute("maxlength"),"255");
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-length-max"),"255");
            Assert.AreEqual(assetClassInput.GetAttribute("class"),"validate form-control");
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-length"), "The field ClassName must be a string with a maximum length of 255.");
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("class"),"form-label-default ");

            var descriptionInput = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            Assert.AreEqual(descriptionInput.GetAttribute("maxlength"),"255");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length-max"),"255");
            Assert.AreEqual(descriptionInput.GetAttribute("class"),"validate form-control");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length"), "The field Description must be a string with a maximum length of 255.");
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[1]"));
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text,"Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"),"submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[2]"));
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void AssetClassPage_AssetClassesTableTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var tableColumns = driver.FindElements(By.Id("AssetClassesTable"));
            foreach(var column in tableColumns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var assetClasseName = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/thead/tr/th[1]"));
            Assert.True(assetClasseName.Enabled);
            Assert.True(assetClasseName.Displayed);
            Assert.AreEqual(assetClasseName.Text, "Asset Class Name");
            Assert.AreEqual(assetClasseName.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(assetClasseName.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(assetClasseName.GetAttribute("aria-controls"), "AssetClassesTable");
            Assert.AreEqual(assetClasseName.GetAttribute("aria-label"), "Asset Class Name: activate to sort column descending");
            assetClasseName.Click();

            var assetClassDescitption = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/thead/tr/th[2]"));
            Assert.True(assetClassDescitption.Enabled);
            Assert.True(assetClassDescitption.Displayed);
            Assert.AreEqual(assetClassDescitption.Text, "Asset Class Description");
            Assert.AreEqual(assetClassDescitption.GetAttribute("class"), "sorting");
            Assert.AreEqual(assetClassDescitption.GetAttribute("aria-controls"), "AssetClassesTable");
            Assert.AreEqual(assetClassDescitption.GetAttribute("aria-label"), "Asset Class Description: activate to sort column ascending");
            assetClassDescitption.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/thead/tr/th[3]"));
            Assert.True(Actions.Enabled);
            Assert.True(Actions.Displayed);
            Assert.AreEqual(Actions.Text, "Actions");
            Assert.AreEqual(Actions.GetAttribute("aria-label"), "Actions");
            Assert.AreEqual(Actions.GetAttribute("class"), "sorting_disabled");
        }

        [Test]
        public void AssetClassPage_EditIconTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var editIcon = driver.FindElement
               (By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[1]"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.IsTrue(editIcon.GetAttribute("onclick").Contains("editAssetClass"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[1]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-edit");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void AssetClassPage_EditIconFormTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[1]"));
            editIcon.Click();

            var assetClassesLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[1]/div/div/div/label"));
            Assert.IsTrue(assetClassesLabel.Enabled);
            Assert.IsTrue(assetClassesLabel.Displayed);
            Assert.AreEqual(assetClassesLabel.Text, "Asset Classes");
            Assert.AreEqual(assetClassesLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetClassesLabel.GetAttribute("class"), "form-label");

            var assetClassInput = driver.FindElement(By.Id("ClassName"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("type"), "text");
            Assert.AreEqual(assetClassInput.GetAttribute("required"), "true");
            Assert.AreEqual(assetClassInput.GetAttribute("maxlength"), "255");
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-length-max"), "255");
            Assert.AreEqual(assetClassInput.GetAttribute("class"), "validate form-control");
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-length"), "The field ClassName must be a string with a maximum length of 255.");
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[2]/div/div/div/label"));
            Assert.IsTrue(descriptionLabel.Enabled);
            Assert.IsTrue(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(descriptionLabel.GetAttribute("class"), "form-label-default ");

            var descriptionInput = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            Assert.IsTrue(descriptionInput.Enabled);
            Assert.IsTrue(descriptionInput.Displayed);
        
            Assert.AreEqual(descriptionInput.GetAttribute("maxlength"), "255");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length-max"), "255");
            Assert.AreEqual(descriptionInput.GetAttribute("class"), "validate form-control");
            Assert.AreEqual(descriptionInput.GetAttribute("data-val-length"), "The field Description must be a string with a maximum length of 255.");
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[1]"));
            Assert.IsTrue(saveBtn.Enabled);
            Assert.IsTrue(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[2]"));
            Assert.IsTrue(cancelBtn.Enabled);
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void AssetClassPage_DeleteIconTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[2]"));
            deleteIcon.Click();
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
            Assert.IsTrue(deleteIcon.GetAttribute("onclick").Contains("deleteAssetClass"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[2]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-trash");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void AssetClassPage_DeleteIconFormTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[2]"));
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
        public void AssetClassPage_PaginateTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("AssetClassesTable_next"));
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text,"Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"),"AssetClassesTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetClassesTable_previous"));
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            Assert.AreEqual(previoustBtn.Text,"Previous");
            Assert.AreEqual(previoustBtn.GetAttribute("aria-controls"),"AssetClassesTable");
            Assert.AreEqual(previoustBtn.GetAttribute("class"), "paginate_button previous disabled");
            previoustBtn.Click();

            var pages = driver.FindElements(By.Id("AssetClassesTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void AssetClassesPage_DataTableInfoTest()
        {
            // to open asset class page 
            AssetClassPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("AssetClassesTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void AssetClassPage_CopyRightTest()
        {
            // to open asset class page 
            AssetClassPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text,("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void AssetClassesPage_MinimizeToggleBtnTest()
        {
            // to open asset class page 
            AssetClassPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
