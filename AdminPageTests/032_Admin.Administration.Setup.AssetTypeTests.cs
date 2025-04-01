using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAdministrationSetupAssetTypeTests : IDisposable
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
        public void AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist()
        {
            var administrationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationBtn.Click();
        }

        [Test]
        public void AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage()
        {
            // to open administration page 
            AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist();

            // open Setup dropdownlist
            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var assetTypeBtn = driver.FindElement
               (By.XPath(" //*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[3]/a/span/span"));
            assetTypeBtn.Click();
        }

        [Test]
        public void AssetSubClassPage_PageTitleTest()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("Asset Types", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void AssetSubClass_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

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
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var dashbaordBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.True(dashbaordBtn.Enabled);
            Assert.True(dashbaordBtn.Displayed);
            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
        }

        [Test]
        public void AssetType_DataTableLengthTest()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetTypeTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetTypePage_DataTableFilterTest()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_filter\"]/label/input"));
            searchInput.SendKeys("Test");
            Assert.True(searchLabel.Enabled);
        }

        [Test]
        public void AssetType_AssetClassFilterTest()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");

            var assetclassValue = driver.FindElement
                (By.Name("AssetClassId"));
            var selectedAssetClass = new SelectElement(assetclassValue);
            selectedAssetClass.SelectByIndex(1);

            var searchBtn = driver.FindElement(By.Id("btnSearch"));
            Assert.AreEqual(searchBtn.Text,"Search");
            Assert.True(searchBtn.Enabled);
            Assert.True(searchBtn.Displayed);
            searchBtn.Click();
        }


        [Test]
        public void AssetTypePage_WhenClickOnCreateBtn_MustOpenCreateForm()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();
            var createBtn = driver.FindElement(By.XPath("//*[@id=\"btnCreate\"]"));
            createBtn.Click();
        }

        [Test]
        public void AssetSubClass_CreateFormTest()
        {
            // to open create form
            AssetTypePage_WhenClickOnCreateBtn_MustOpenCreateForm();

            var assetTypeNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetTypeNameLabel.Click();
            Assert.True(assetTypeNameLabel.Enabled);
            Assert.True(assetTypeNameLabel.Displayed);

            var assetTypeNameInput = driver.FindElement(By.Id("AssetTypeName"));
            var requiredField = assetTypeNameInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetTypeNameInput.Enabled);
            Assert.True(assetTypeNameInput.Displayed);
            assetTypeNameInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("AssetTypesDesc"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            //var assetSubClass = driver.FindElement(By.Id("AssetSubClassIdDropdown"));
            //var selectedAssetSubClass = new SelectElement(assetSubClass);
            //selectedAssetSubClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetType_EditAssetTest()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var assetTypeNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetTypeNameLabel.Click();
            Assert.True(assetTypeNameLabel.Enabled);
            Assert.True(assetTypeNameLabel.Displayed);

            var assetTypeNameInput = driver.FindElement(By.Id("AssetTypeName"));
            var requiredField = assetTypeNameInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetTypeNameInput.Enabled);
            Assert.True(assetTypeNameInput.Displayed);
            assetTypeNameInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("AssetTypesDesc"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            //var assetSubClass = driver.FindElement(By.Id("AssetSubClassIdDropdown"));
            //var selectedAssetSubClass = new SelectElement(assetSubClass);
            //selectedAssetSubClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetType_DeleteAssetTest()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable\"]/tbody/tr[1]/td[4]/a[2]"));
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
            Assert.True(deleteIcon.Enabled);
            Assert.True(deleteIcon.Displayed);
            deleteIcon.Click();

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
        public void AssetType_PaginateTest()
        {
            // to open asset type page
            AdministrationOption_WhenClickOnAssetTypeOption_MustOpneAssetTypePage();

            var nextBtn = driver.FindElement(By.Id("AssetTypeTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetTypeTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();

            var pageNum = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeTable_paginate\"]/span/a[1]"));
            pageNum.Click();
            Assert.True(pageNum.Enabled);
            Assert.True(pageNum.Displayed);
        }
    }
}
