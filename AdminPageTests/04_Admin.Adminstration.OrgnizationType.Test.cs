using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAdminstrationOrgnizationTypeTest : IDisposable
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
        public void OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage()
        {
            // to click on adminstration option
            AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist();

            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var orgnizationTypeOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[5]/a/span/span"));
            orgnizationTypeOption.Click();
        }

        [Test]
        public void AssetAttributesSortingPage_PageTitleTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("Organization Types", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void OrgnizationTypePage_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

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
        public void OrgnizationTypePage_DataTableLengthTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable_length\"]/label"));
            Assert.True(showLabel.Text.Contains("Show"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("OrganizationTypesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }

        [Test]
        public void OrgnizationTypePage_CreateBtnTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var createBtn = driver.FindElement(By.Id("btnCreate"));
            createBtn.Click();
            Assert.AreEqual("Create", createBtn.Text);
            Assert.True(createBtn.Displayed);
            Assert.True(createBtn.Enabled);
        }

        [Test]
        public void OrgnizationTypePage_CreateFormTest()
        {
            // to open create form 
            OrgnizationTypePage_CreateBtnTest();

            var orgnizationTypeLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/div/div/label"));
            orgnizationTypeLabel.Click();
            Assert.True(orgnizationTypeLabel.Enabled);
            Assert.True(orgnizationTypeLabel.Displayed);
            Assert.AreEqual(orgnizationTypeLabel.Text, "Organization Type");

            var orgnizationTypeInput = driver.FindElement(By.Id("OrgType"));
            Assert.True(orgnizationTypeInput.Enabled);
            Assert.True(orgnizationTypeInput.Displayed);
            orgnizationTypeInput.SendKeys("Test Name");
            var requiredOrgnizationType = orgnizationTypeInput.GetAttribute("data-val-required");
            Assert.AreEqual(requiredOrgnizationType, "The OrgType field is required.");


            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");
            var requiredDescriptionLength = descriptionInput.GetAttribute("data-val-length");
            Assert.AreEqual(requiredDescriptionLength,
                "The field Description must be a string with a maximum length of 500.");

            var isActive = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[3]/div/div/div/label"));
            Assert.AreEqual(isActive.Text,"Is Active");
            Assert.True(isActive.Displayed);
            Assert.True(isActive.Enabled);
            isActive.Click();

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void OrginizationTypePage_DataTableLengthTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var showLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable_filter\"]/label"));
            Assert.True(showLabel.Text.Contains("Search:"));
            Assert.True(showLabel.Enabled);
            Assert.True(showLabel.Displayed);
            showLabel.Click();

            var showValue = driver.FindElement(By.Name("OrganizationTypesTable_length"));
            Assert.True(showValue.Enabled);
            Assert.True(showValue.Displayed);
            var selectedValue = new SelectElement(showValue);
            selectedValue.SelectByIndex(1);
        }


        [Test]
        public void OrgnizationTypePage_ReOrderTableTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var orgnizationType = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[1]"));
            orgnizationType.Click();
            Assert.True(orgnizationType.Enabled);
            Assert.True(orgnizationType.Displayed);
            Assert.AreEqual(orgnizationType.Text, "Organization Type");

            var description = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[2]"));
            description.Click();
            Assert.True(description.Enabled);
            Assert.True(description.Displayed);
            Assert.AreEqual(description.Text, "Description");

            var Active = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[3]"));
            Active.Click();
            Assert.True(Active.Enabled);
            Assert.True(Active.Displayed);
            Assert.AreEqual(Active.Text, "Active?");

            var action = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/thead/tr/th[4]"));
            Assert.AreEqual(action.Text, "Actions");
            Assert.True(description.Enabled);
        }

        [Test]
        public void OrgnizationTypePage_EditAssetIconTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var editIcon = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[1]"));
            editIcon.Click();
            Assert.AreEqual("Edit", editIcon.GetAttribute("title"));
            Assert.True(editIcon.Enabled);
            Assert.True(editIcon.Displayed);

            var orgnizationTypeLabel = driver.FindElement
               (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[1]/div/div/div/label"));
            orgnizationTypeLabel.Click();
            Assert.True(orgnizationTypeLabel.Enabled);
            Assert.True(orgnizationTypeLabel.Displayed);
            Assert.AreEqual(orgnizationTypeLabel.Text, "Organization Type");

            var orgnizationTypeInput = driver.FindElement(By.Id("OrgType"));
            Assert.True(orgnizationTypeInput.Enabled);
            Assert.True(orgnizationTypeInput.Displayed);
            orgnizationTypeInput.SendKeys("Test Name");
            var requiredOrgnizationType = orgnizationTypeInput.GetAttribute("data-val-required");
            Assert.AreEqual(requiredOrgnizationType, "The OrgType field is required.");


            var descriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[2]/div/div/div/label"));
            descriptionLabel.Click();
            Assert.True(descriptionLabel.Enabled);
            Assert.True(descriptionLabel.Displayed);
            Assert.AreEqual(descriptionLabel.Text, "Description");

            var descriptionInput = driver.FindElement(By.Id("Description"));
            Assert.True(descriptionInput.Enabled);
            Assert.True(descriptionInput.Displayed);
            descriptionInput.SendKeys("Test");
            var requiredDescriptionLength = descriptionInput.GetAttribute("data-val-length");
            Assert.AreEqual(requiredDescriptionLength,
                "The field Description must be a string with a maximum length of 500.");

            var isActive = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[3]/div/div/div/label"));
            Assert.AreEqual(isActive.Text, "Is Active");
            Assert.True(isActive.Displayed);
            Assert.True(isActive.Enabled);
            isActive.Click();

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[1]"));
            var saveBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(saveBtn.Text, "Save");
            Assert.True(saveBtn.Enabled);
            Assert.True(saveBtn.Displayed);

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"OrgCreateModal\"]/form/div[4]/button[2]"));
            var cancelBtnType = saveBtn.GetAttribute("type");
            Assert.AreEqual(saveBtnType, "submit");
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.True(cancelBtn.Enabled);
            Assert.True(cancelBtn.Displayed);
        }

        [Test]
        public void OrgnizationTypePage_DeleteIConTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var deleteIcon = driver.FindElement
                (By.XPath("//*[@id=\"OrganizationTypesTable\"]/tbody/tr[1]/td[4]/a[2]"));
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
        public void OrgnizationTypePage_PaginationTest()
        {
            // to open orgnization type page
            OrginizationTypePage_WhenClickOrgnizationOption_MustOpenOrgnizationTypePage();

            var nextBtn = driver.FindElement(By.Id("OrganizationTypesTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.True(nextBtn.Enabled);
            Assert.True(nextBtn.Displayed);
            nextBtn.Click();

            var previoustBtn = driver.FindElement(By.Id("OrganizationTypesTable_previous"));
            Assert.AreEqual(previoustBtn.Text, "Previous");
            Assert.True(previoustBtn.Enabled);
            Assert.True(previoustBtn.Displayed);
            previoustBtn.Click();
        }
    }
}
