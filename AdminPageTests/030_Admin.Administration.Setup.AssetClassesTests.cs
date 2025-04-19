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
        public void AssetClassPage_SubHeaderTitleTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text,"Asset Classes");
        }

        [Test]
        public void AssetClassPage_DashboardNavigationLinkTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var dashbaordBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.True(dashbaordBtn.Enabled);
            Assert.True(dashbaordBtn.Displayed);
            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
            Assert.AreEqual(dashbaordBtn.GetAttribute("class"), "m-nav__link-text");

            var urlBeforeClick = driver.Url;
            dashbaordBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlAfterClick,urlBeforeClick);
        }

        [Test]
        public void AssetClassPage_AssetClassNavigationLinkTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var assetClasses = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.True(assetClasses.Enabled);
            Assert.True(assetClasses.Displayed);
            Assert.AreEqual(assetClasses.Text, "Asset Classes");
            Assert.AreEqual(assetClasses.GetAttribute("class"), "m-nav__link-text");
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
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable_filter\"]/label/input"));
            searchInput.SendKeys("Test");
            Assert.True(searchLabel.Enabled);
        }

        [Test]
        public void AssetClassPage_DataTableLengthTests()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetClassesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetClassPage_WhenClickOnCreateBtn_MustOpenCreateForm()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
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
        }

        [Test]
        public void AssetClassPage_CreateFormTest()
        {
            // to open create form
            AssetClassPage_WhenClickOnCreateBtn_MustOpenCreateForm();

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[1]/div/div/div/label"));
            assetClassLabel.Click();
            Assert.True(assetClassLabel.Enabled);
            Assert.True(assetClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("ClassName"));
            var requiredField = assetClassInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text,"Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetClassPage_ReOrderPageTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var assetClasseName = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/thead/tr/th[1]"));
            assetClasseName.Click();
            Assert.True(assetClasseName.Enabled);
            Assert.True(assetClasseName.Displayed);
            Assert.AreEqual(assetClasseName.Text, "Asset Class Name");

            var assetClassDescitption = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/thead/tr/th[2]"));
            assetClassDescitption.Click();
            Assert.True(assetClassDescitption.Enabled);
            Assert.True(assetClassDescitption.Displayed);
            Assert.AreEqual(assetClassDescitption.Text, "Asset Class Description");

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/thead/tr/th[3]"));
            Assert.AreEqual(action.Text, "Actions");
            Assert.True(assetClassDescitption.Enabled);
        }

        [Test]
        public void AssetClassPage_EditAssetTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit",editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);


            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[1]/div/div/div/label"));
            assetClassLabel.Click();
            Assert.True(assetClassLabel.Enabled);
            Assert.True(assetClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("ClassName"));
            var requiredField = assetClassInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassCreateModal\"]/form/div[3]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetClassPage_DeleteAssetTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassesTable\"]/tbody/tr[1]/td[3]/a[2]"));
            Assert.AreEqual(deleteIcon.GetAttribute("title"),"Delete");
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            deleteIcon.Click();

            var confirmWindo = driver.FindElement(By.XPath("/html/body/div[4]/div"));
            Assert.True(confirmWindo.Displayed);

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
            Assert.AreEqual(cancelBtn.Text,"Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetClassPage_PaginateTest()
        {
            // to open asset class page
            AssetClassPage_OpenPage();

            var nextBtn = driver.FindElement(By.Id("AssetClassesTable_next"));
            Assert.AreEqual(nextBtn.Text,"Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetClassesTable_previous"));
            Assert.AreEqual(previoustBtn.Text,"Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();
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
