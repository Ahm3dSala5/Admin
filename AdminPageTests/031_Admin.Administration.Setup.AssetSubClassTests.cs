using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAdministrationSetupAssetSubClassTests : IDisposable
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
        public void administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage()
        {
            // to open administration page 
            AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist();

            // open Setup dropdownlist
            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var assetSubClasses = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[2]/a/span/span"));
            assetSubClasses.Click();
        }

        [Test]
        public void AssetSubClassPage_PageTitleTest()
        {
            // to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("Asset Sub Classes", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void AssetSubClass_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

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
            // to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var dashbaordBtn = driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.True(dashbaordBtn.Enabled);
            Assert.True(dashbaordBtn.Displayed);
            Assert.AreEqual(dashbaordBtn.Text, "Dashboard");
        }

        [Test]
        public void AssetSubClassPage_WhenCLickOnCreateBtn_MustOpenCreateForm()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
        }

        [Test]
        public void AssetSubClass_CreateFormTest()
        {
            // to open create form
            AssetSubClassPage_WhenCLickOnCreateBtn_MustOpenCreateForm();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[1]/div/div/div/label"));
            assetSubClassLabel.Click();
            Assert.True(assetSubClassLabel.Enabled);
            Assert.True(assetSubClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("SubClassName"));
            var requiredField = assetClassInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetSubClass_FilterTest()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var assetClassLabel = driver.FindElement(By.Id("assetclassbuid"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");

            var assetClassDropdownlist = driver.FindElement(By.Id("AssetClassId"));
            var selectedAssetClass = new SelectElement(assetClassDropdownlist);
            selectedAssetClass.SelectByIndex(1);
            Assert.True(assetClassDropdownlist.Enabled);
            Assert.True(assetClassDropdownlist.Displayed);
        }
        
        [Test]
        public void AssetSubClass_DataTableLengthTest()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("AssetSubClassesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void AssetSubClassPage_DataTableFilterTest()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var searchLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable_filter\"]/label"));
            searchLabel.Click();
            Assert.True(searchLabel.Enabled);
            Assert.AreEqual(searchLabel.Text, "Search:");

            var searchInput = driver.FindElement
                (By.Id("WebPagesTableFilter"));
            searchInput.SendKeys("Test");
            Assert.True(searchLabel.Enabled);
        }

        [Test]
        public void AssetSubClass_ReOrderPageTest()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var assetClasseName = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/thead/tr/th[1]"));
            assetClasseName.Click();
            Assert.True(assetClasseName.Enabled);
            Assert.True(assetClasseName.Displayed);
            Assert.AreEqual(assetClasseName.Text, "Asset Class Name");

            var assetSubClassName = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/thead/tr/th[2]"));
            assetSubClassName.Click();
            Assert.True(assetSubClassName.Enabled);
            Assert.True(assetSubClassName.Displayed);
            Assert.AreEqual(assetSubClassName.Text, "Asset Subclass Name");

            var action = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/thead/tr/th[3]"));
            Assert.AreEqual(action.Text, "Actions");
            Assert.True(assetSubClassName.Enabled);
        }

        [Test]
        public void AssetSubClass_EditAssetTest()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/tbody/tr[1]/td[3]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var assetSubClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[1]/div/div/div/label"));
            assetSubClassLabel.Click();
            Assert.True(assetSubClassLabel.Enabled);
            Assert.True(assetSubClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("SubClassName"));
            var requiredField = assetClassInput.GetAttribute("required");
            Assert.AreEqual(requiredField, "true");
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            assetClassInput.SendKeys("Test Name");

            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");

            var assetClass = driver.FindElement(By.Id("AssetClassId"));
            var selectedClass = new SelectElement(assetClass);
            selectedClass.SelectByIndex(1);

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassCreateModal\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetClass_DeleteAssetTest()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassesTable\"]/tbody/tr[1]/td[3]/a[2]"));
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
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
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void AssetSubClass_PaginateTest()
        {
            //  to open asset sub class page
            administrationPage_WhenClickOnAssetSubClasses_MustOpenAssetSubClassPage();

            var nextBtn = driver.FindElement(By.Id("AssetSubClassesTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("AssetSubClassesTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();
        }
    }
}
