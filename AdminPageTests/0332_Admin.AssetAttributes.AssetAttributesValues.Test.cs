using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAssetAttributesAssetAttribuetValueTest : IDisposable
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
        public void AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage()
        {
            // to click on adminstration option
            AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist();

            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            assetAttributesOption.Click();

            var assetAttributeValuesOptions = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[3]/a/span"));
            assetAttributeValuesOptions.Click();
        }

        [Test]
        public void AssetAttributesValuesPage_PageTitleTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("Asset Attribute Values", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void AssetAttributesValuesPage_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

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
        public void AssetAttributesValuesPage_DataTableLengthTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetAtrributeLabelsTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetAttributesValuesPage_CreateBtnTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
            Assert.AreEqual("Create", createBtn.Text);
            Assert.True(createBtn.Displayed);
            Assert.True(createBtn.Enabled);
        }

        [Test]
        public void AssetAttributesValuesPage_CreateFormTest()
        {
            // to open create form 
            AssetAttributesValuesPage_CreateBtnTest();

            var assetAttributeValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[1]/div/div/div/label"));
            assetAttributeValueLabel.Click();
            Assert.True(assetAttributeValueLabel.Enabled);
            Assert.True(assetAttributeValueLabel.Displayed);
            Assert.AreEqual(assetAttributeValueLabel.Text, "Asset Attribute Value");

            var assetAttributeValueInput = driver.FindElement(By.Id("AssetAttributeLabel"));
            var requiredField = assetAttributeValueInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetAttributeValueInput.Enabled);
            Assert.True(assetAttributeValueInput.Displayed);
            assetAttributeValueInput.SendKeys("Test Name");

            var assetAttributesDropdownlist = driver.FindElement(By.Id("department"));
            var selectedAssetAttributesValue = new SelectElement(assetAttributesDropdownlist);
            selectedAssetAttributesValue.SelectByIndex(1);
            

            var assetAttributesShowrtValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[2]/div/div/div/label"));
            assetAttributesShowrtValueLabel.Click();
            Assert.True(assetAttributesShowrtValueLabel.Enabled);
            Assert.True(assetAttributesShowrtValueLabel.Displayed);
            Assert.AreEqual(assetAttributesShowrtValueLabel.Text, "Asset Attribute Short Value");

            var assetAttributesShowrtValueInput = driver.FindElement(By.Id("AssetattributeShortLable"));
            Assert.True(assetAttributesShowrtValueInput.Enabled);
            Assert.True(assetAttributesShowrtValueInput.Displayed);
            assetAttributesShowrtValueInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetAttributeValuesPage_DataTableFilterTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");
            Assert.IsTrue(searchLabel.Displayed);

            var searchInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable_filter\"]/label/input"));
            searchInput.SendKeys("Code");
            Assert.True(searchLabel.Enabled);
            Assert.IsTrue(searchInput.Displayed);
        }

        [Test]
        public void AssetAttributesValuePage_ReOrderTableTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var assetAttributesValue = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[1]"));
            assetAttributesValue.Click();
            Assert.True(assetAttributesValue.Enabled);
            Assert.True(assetAttributesValue.Displayed);
            Assert.AreEqual(assetAttributesValue.Text, "Asset Attribute Values");

            var assetAttribbutesShowrtValues = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[2]"));
            assetAttribbutesShowrtValues.Click();
            Assert.True(assetAttribbutesShowrtValues.Enabled);
            Assert.True(assetAttribbutesShowrtValues.Displayed);
            Assert.AreEqual(assetAttribbutesShowrtValues.Text, "Asset Attribute Short Value");

            var assetAttribuesName = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[3]"));
            assetAttribuesName.Click();
            Assert.True(assetAttribuesName.Enabled);
            Assert.True(assetAttribuesName.Displayed);
            Assert.AreEqual(assetAttribuesName.Text, "Asset Attribute Name");

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/thead/tr/th[4]"));
            Assert.AreEqual(action.Text, "Actions");
            Assert.True(assetAttribbutesShowrtValues.Enabled);
        }

        [Test]
        public void AssetAttributesValuePage_EditAssetIconTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var assetAttributeValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[1]/div/div/div/label"));
            assetAttributeValueLabel.Click();
            Assert.True(assetAttributeValueLabel.Enabled);
            Assert.True(assetAttributeValueLabel.Displayed);
            Assert.AreEqual(assetAttributeValueLabel.Text, "Asset Attribute Value");

            var assetAttributeValueInput = driver.FindElement(By.Id("AssetAttributeLabel"));
            var requiredField = assetAttributeValueInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetAttributeValueInput.Enabled);
            Assert.True(assetAttributeValueInput.Displayed);
            assetAttributeValueInput.SendKeys("Test Name");

            var assetAttributesDropdownlist = driver.FindElement(By.Id("department"));
            var selectedAssetAttributesValue = new SelectElement(assetAttributesDropdownlist);
            selectedAssetAttributesValue.SelectByIndex(1);


            var assetAttributesShowrtValueLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[2]/div/div/div/label"));
            assetAttributesShowrtValueLabel.Click();
            Assert.True(assetAttributesShowrtValueLabel.Enabled);
            Assert.True(assetAttributesShowrtValueLabel.Displayed);
            Assert.AreEqual(assetAttributesShowrtValueLabel.Text, "Asset Attribute Short Value");

            var assetAttributesShowrtValueInput = driver.FindElement(By.Id("AssetattributeShortLable"));
            Assert.True(assetAttributesShowrtValueInput.Enabled);
            Assert.True(assetAttributesShowrtValueInput.Displayed);
            assetAttributesShowrtValueInput.SendKeys("Test");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetAttributelabelEditModel\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetAttributesValuesPage_DeleteIConTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetAtrributeLabelsTable\"]/tbody/tr[1]/td[4]/a[2]"));
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
        public void AssetAttributesValuesPage_PaginationTest()
        {
            // to open asset attributes values page
            AssetAttributesValuePage_WhenClickOnAssignAttribute_MustOpenAssignAttributesPage();

            var nextBtn = driver.FindElement(By.Id("AssetAtrributeLabelsTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetAtrributeLabelsTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();
        }
    }
}
