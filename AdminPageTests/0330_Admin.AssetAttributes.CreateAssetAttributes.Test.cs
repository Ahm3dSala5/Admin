using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAssetAttributesCreateAssetAttributesTest : IDisposable
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
            var administrationOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();
        }

        [Test]
        public void CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage()
        {
            // to click on adminstration option
            AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist();

            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            assetAttributesOption.Click();

            var createAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[1]/a/span/span"));
            createAttributesOption.Click();
        }

        [Test]
        public void CreateAssetPage_PageTitleTest()
        {
            // to open create attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("Asset Attribute", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void CreateAttributesPage_AssetAttributesBtnTest()
        {
            // to click on adminstration option
            AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist();

            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var assetAttributesOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            assetAttributesOption.Click();
            Assert.AreEqual(assetAttributesOption.Text, "Asset Attributes");
            Assert.True(assetAttributesOption.Enabled);
            Assert.True(assetAttributesOption.Displayed);

            var assetAttributesIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/i[1]"));
            assetAttributesIcon.Click();
            Assert.True(assetAttributesIcon.Displayed);
        }

        [Test]
        public void AssetSubClass_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var dashbaordBtn = driver.FindElement(
               By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            var assetClassUrl = driver.Url;
            dashbaordBtn.Click();
            var dashbaordUrl = driver.Url;

            Assert.AreNotEqual(dashbaordUrl, assetClassUrl);
        }

        [Test]
        public void CreateAssetAttributesPage_DashboradBtnTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var dashbaordBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.True(dashbaordBtn.Enabled);
            Assert.True(dashbaordBtn.Displayed);
            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
        }

        [Test]
        public void CreateAssetAttributesPage_DataTableLengthTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetAttributesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void CreateAssetAttributesPage_DataTableFilterTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
        }

        [Test]
        public void CreateAssetAttributesPage_ReOrderPageTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var attributesName = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[1]"));
            attributesName.Click();
            Assert.True(attributesName.Enabled);
            Assert.True(attributesName.Displayed);
            Assert.AreEqual(attributesName.Text, "Attribute Name");

            var assetClassDescitption = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[2]"));
            assetClassDescitption.Click();
            Assert.True(assetClassDescitption.Enabled);
            Assert.True(assetClassDescitption.Displayed);
            Assert.AreEqual(assetClassDescitption.Text, "Attribute Units");

            var attributeDataType = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[3]"));
            attributeDataType.Click();
            Assert.True(attributeDataType.Enabled);
            Assert.True(attributeDataType.Displayed);
            Assert.AreEqual(attributeDataType.Text, "Attribute DataType");

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[4]"));
            Assert.AreEqual(action.Text, "Actions");
            Assert.True(assetClassDescitption.Enabled);
        }

        [Test]
        public void CreateAssetAttributesPage_WhenClickOnCreateBtn_MustOpenCreateForm()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
        }

        [Test]
        public void CreateAssetAttributesPage_CreateBtnTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
            Assert.AreEqual("Create", createBtn.Text);
            Assert.True(createBtn.Displayed);
            Assert.True(createBtn.Enabled);
        }

        [Test]
        public void CreateAssetAttributesPage_CreateFormTest()
        {
            // to open create form
            CreateAssetAttributesPage_WhenClickOnCreateBtn_MustOpenCreateForm();

            var assetAttributesLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetAttributesLabel.Click();
            Assert.True(assetAttributesLabel.Enabled);
            Assert.True(assetAttributesLabel.Displayed);
            Assert.AreEqual(assetAttributesLabel.Text, "Asset Attribute");

            var assetAttributesInput = driver.FindElement(By.Id("AssetAttributeName"));
            var requiredField = assetAttributesInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetAttributesInput.Enabled);
            Assert.True(assetAttributesInput.Displayed);
            assetAttributesInput.SendKeys("Test Name");

            var assetUnit = driver.FindElement(By.Id("AssetAttributeUnits"));
            var selectedAssetUnit = new SelectElement(assetUnit);
            selectedAssetUnit.SelectByIndex(1);

            var attributeDataType = driver.FindElement(By.Id("AssetAttributeDataType"));
            var selectedAttributeDataType = new SelectElement(attributeDataType);
            selectedAttributeDataType.SelectByIndex(1);

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[4]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void CreateAssetAttributesPage_EditAssetTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var assetAttributesLabel = driver.FindElement
               (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[1]/div/div/div/label"));
            assetAttributesLabel.Click();
            Assert.True(assetAttributesLabel.Enabled);
            Assert.True(assetAttributesLabel.Displayed);
            Assert.AreEqual(assetAttributesLabel.Text, "Asset Attribute");

            var assetAttributesInput = driver.FindElement(By.Id("AssetAttributeName"));
            var requiredField = assetAttributesInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetAttributesInput.Enabled);
            Assert.True(assetAttributesInput.Displayed);
            assetAttributesInput.SendKeys("Test Name");

            var assetUnit = driver.FindElement(By.Id("AssetAttributeUnits"));
            var selectedAssetUnit = new SelectElement(assetUnit);
            selectedAssetUnit.SelectByIndex(1);

            var attributeDataType = driver.FindElement(By.Id("AssetAttributeDataType"));
            var selectedAttributeDataType = new SelectElement(attributeDataType);
            selectedAttributeDataType.SelectByIndex(1);

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[4]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributeCreateModal\"]/form/div[5]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void CreateAssetAttributesPage_DeleteAssetTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[1]/td[4]/a[2]"));
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
        public void CreateAssetAttributesPage_PaginateTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var nextBtn = driver.FindElement(By.Id("AssetAttributesTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetAttributesTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();

            var pageNum = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_paginate\"]/span/a[1]"));
            pageNum.Click();
            Assert.True(pageNum.Enabled);
            Assert.True(pageNum.Displayed);
        }

        [Test]
        public void CreateAssetAttributesPage_ViewIconTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var viewIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[4]/td[4]/a[1]"));
            viewIcon.Click();

            var backBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/p/a[1]"));
            Assert.AreEqual("Back", backBtn.Text);
            Assert.True(backBtn.Displayed);
            Assert.True(backBtn.Enabled);

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            Assert.AreEqual("Create", createBtn.Text);
            Assert.True(createBtn.Displayed);
            Assert.True(createBtn.Enabled);
        }

        [Test]
        public void CreateAssetAttributesPage_ViewIconTableLengthTests()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var viewIcon = driver.FindElement
               (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[4]/td[4]/a[1]"));
            viewIcon.Click();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetAttributesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void CreateAssetAttributes_ViewIconTableFilter()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();
            var viewIcon = driver.FindElement
              (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[4]/td[4]/a[1]"));
            viewIcon.Click();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
        }

        [Test]
        public void CreateAssetAttributes_ViewIconTableReOrder()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var viewIcon = driver.FindElement
              (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[4]/td[4]/a[1]"));
            viewIcon.Click();

            var attributesCode = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[1]"));
            attributesCode.Click();
            Assert.True(attributesCode.Enabled);
            Assert.True(attributesCode.Displayed);
            Assert.AreEqual(attributesCode.Text, "Attribute Code");

            var attributeValue = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[2]"));
            attributeValue.Click();
            Assert.True(attributeValue.Enabled);
            Assert.True(attributeValue.Displayed);
            Assert.AreEqual(attributeValue.Text, "Attribute Value");

            var attributeShortValue = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[3]"));
            attributeShortValue.Click();
            Assert.True(attributeShortValue.Enabled);
            Assert.True(attributeShortValue.Displayed);
            Assert.AreEqual(attributeShortValue.Text, "Attribute Short Value");

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributesTable\"]/thead/tr/th[4]"));
            Assert.AreEqual(action.Text, "Actions");
            Assert.True(attributeValue.Enabled);
        }

        [Test]
        public void CreateAssetAttributes_ViewIcon_PaginateTest()
        {
            // to open create asset attributes page
            CreateAttributes_WhenClickOnCreateAttributesBtn_MustOpenPage();

            var viewIcon = driver.FindElement
              (By.XPath("//*[@id=\"AssetAttributesTable\"]/tbody/tr[4]/td[4]/a[1]"));
            viewIcon.Click();
        }
    }
}
