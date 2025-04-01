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
        public void  AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayDropownlist()
        {
            var administrationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationBtn.Click();
        }

        [Test]
        public void AdministrationOptionsTest()
        {
            // test adminstration option
            var administrationOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();
            Assert.True(administrationOption.Displayed);
            Assert.True(administrationOption.Enabled);
            Assert.AreEqual("Administration",administrationOption.Text);
            administrationOption.Click();

            var administrationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[1]"));
            Assert.True(administrationIcon.Displayed);
            Assert.True(administrationIcon.Enabled);

            var administrationArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[2]"));
            Assert.True(administrationArrow.Displayed);
            Assert.True(administrationArrow.Enabled);
        }


        [Test]
        public void AdministrationPage_WhenClickOnSetupOption_MustOpenDropdownlist()
        {
            // to open administration page 
             AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayDropownlist();

            var setupBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();
        }

        [Test]
        public void AdministrationOption_TestSetupOption()
        {
            // to click on adminstration options
            AdministrationPage_WhenClickOnSetupOption_MustOpenDropdownlist();

            var setupOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();
            Assert.True(setupOption.Displayed);
            Assert.True(setupOption.Enabled);
            Assert.AreEqual("Setup", setupOption.Text);
            setupOption.Click();

            var setupIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/i[1]"));
            Assert.True(setupIcon.Displayed);
            Assert.True(setupIcon.Enabled);

            var setupArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/i[2]"));
            Assert.True(setupArrow.Displayed);
            Assert.True(setupArrow.Enabled);
        }

        [Test]
        public void AssetClassPage_DataTableFilter()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

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
        public void AdministrationOption_WhenClickOnAssetClass_MustOpenPage()
        {
            // to click on adminstration options
            AdministrationOption_WhenClickOnAdministrationBtn_MustDisplayDropownlist();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetClass = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[1]/a/span/span"));
            assetClass.Click();
        }

        [Test]
        public void AssetClassPage_PageTitleTest()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("Asset Classes", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void AssetClass_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

             var dashbaordBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            var assetClassUrl = driver.Url;
            dashbaordBtn.Click();
            var dashbaordUrl = driver.Url;

            Assert.AreNotEqual(dashbaordUrl, assetClassUrl);
        }

        [Test]
        public void AssetClassPage_DashboradBtnTest()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

            var dashbaordBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.True(dashbaordBtn.Enabled);
            Assert.True(dashbaordBtn.Displayed);
            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
        }

        public void AssetClass_WhenClickOnCreateBtn_MustOpenCreateForm()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
        }


        [Test]
        public void AssetClass_CreateBtnTest()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.True(createBtn.Enabled);
            Assert.True(createBtn.Displayed);
            Assert.AreEqual(createBtn.Text, "Create");
        }

        [Test]
        public void AssetClass_CreateFormTest()
        {
            // to open create form
            AssetClass_WhenClickOnCreateBtn_MustOpenCreateForm();

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
        public void AssetClass_DataTableLengthTests()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

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
        public void AssetClass_ReOrderPageTest()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

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
        public void AssetClass_EditAssetTest()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

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
        public void AssetClass_DeleteAssetTest()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

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
        public void AssetClass_PaginateTest()
        {
            // to open asset class page
            AdministrationOption_WhenClickOnAssetClass_MustOpenPage();

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
    }
}
