using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    public class AdminAssetAttributesAssetAttribuetSortingTest : IDisposable
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
        public void AssetAttributesSortingPage_WhenClickOnAssignAttribute_MustOpenAssetAttributesCopyPage()
        {
            // to click on adminstration option
            AdministrationOption_WhenClickOnAdministrationOption_MustOpenDrodownlist();

            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            assetAttributesOption.Click();

            var assetAttributesSortingOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[5]/a/span/span"));
            assetAttributesSortingOption.Click();
        }

        [Test]
        public void AssetAttributesSortingPage_PageTitleTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_WhenClickOnAssignAttribute_MustOpenAssetAttributesCopyPage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual("Asset Attributes Sorting", title.Text);
            Assert.True(title.Displayed);
            Assert.True(title.Enabled);
        }

        [Test]
        public void AssetAttributesCopyPage_WhenClickOnDashboard_MustReturnToDashbaordPage()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_WhenClickOnAssignAttribute_MustOpenAssetAttributesCopyPage();

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
        public void AssetAttributesCopyPage_AssetClassDropdownlistTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_WhenClickOnAssignAttribute_MustOpenAssetAttributesCopyPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.True(assetClassLabel.Displayed);
            Assert.True(assetClassLabel.Enabled);

            var assetClassInput = driver.FindElement(By.Id("AssetClassIdChange"));
            var assetClassValue = new SelectElement(assetClassInput);
            assetClassValue.SelectByIndex(1);
            Assert.True(assetClassInput.Displayed);
            Assert.True(assetClassInput.Enabled);

            // for ensure message error are display when user not add any value
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-required"), "The ClassId field is required.");
        }

        [Test]
        public void AssetAttributesCopyPage_AssetSubClassDropdownlist()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_WhenClickOnAssignAttribute_MustOpenAssetAttributesCopyPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.True(assetSubClassLabel.Displayed);
            Assert.True(assetSubClassLabel.Enabled);

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.True(assetSubClassInput.Displayed);
            Assert.True(assetSubClassInput.Enabled);
            Assert.AreEqual(assetSubClassInput.GetAttribute("data-val-required"), "The SubClassId field is required.");
        }

        [Test]
        public void AssetAttributesCopyPage_AssetType()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_WhenClickOnAssignAttribute_MustOpenAssetAttributesCopyPage();

            var assetTypeInputLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeInputLabel.Text, "Asset Type");
            Assert.True(assetTypeInputLabel.Displayed);
            Assert.True(assetTypeInputLabel.Enabled);

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.True(assetTypeInput.Displayed);
            Assert.True(assetTypeInput.Enabled);
            Assert.AreEqual(assetTypeInput.GetAttribute("data-val-required"), "The TypeId field is required.");
        }
    }
}
