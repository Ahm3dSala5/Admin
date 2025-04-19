using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPageTests
{
    [TestFixture]
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
        public void AssetAttributeSortingPage_AdministratioOptionTest()
        {
            // test adminstration option
            var administrationOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();
            Assert.True(administrationOption.Displayed);
            Assert.True(administrationOption.Enabled);
            Assert.AreEqual("Administration", administrationOption.Text);
            administrationOption.Click();

            string Icon = "m-menu__link-icon flaticon-cogwheel";
            var administrationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[1]"));
            Assert.True(administrationIcon.Displayed);
            Assert.True(administrationIcon.Enabled);
            Assert.AreEqual(administrationIcon.GetAttribute("class"), Icon);

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
            Assert.AreEqual(administrationOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetAttributeSortingPage_SetupOptionTest()
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
            Assert.AreEqual(setupOption.GetAttribute("custom-data"), "Setup");
            Assert.AreEqual(setupOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(setupOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");
            setupOption.Click();

            string Icon = "m-menu__link-icon flaticon-cogwheel";
            var setupOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/i[1]"));
            Assert.True(setupOptionIcon.Displayed);
            Assert.True(setupOptionIcon.Enabled);
            Assert.AreEqual(setupOptionIcon.GetAttribute("class"), Icon);

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
            Assert.AreEqual(setupOptionTitle.Text, "Setup");
            Assert.AreEqual(setupOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetAttributeSortingPage_AssetAttributesOtionTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a"));
            assetAttributesOption.Click();
            Assert.IsTrue(assetAttributesOption.Enabled);
            Assert.IsTrue(assetAttributesOption.Displayed);
            Assert.AreEqual(assetAttributesOption.GetAttribute("custom-data"), "Asset Attributes");
            Assert.AreEqual(assetAttributesOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");
            Assert.AreEqual(assetAttributesOption.GetAttribute("href"), $"{driver.Url}#");

            var assetAttributesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/i[1]"));
            Assert.IsTrue(assetAttributesOptionIcon.Enabled);
            Assert.IsTrue(assetAttributesOptionIcon.Displayed);
            Assert.AreEqual(assetAttributesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var assetAttributesOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            Assert.IsTrue(assetAttributesOptionTitle.Enabled);
            Assert.IsTrue(assetAttributesOptionTitle.Displayed);
            Assert.AreEqual(assetAttributesOptionTitle.Text, "Asset Attributes");
            Assert.AreEqual(assetAttributesOptionTitle.GetAttribute("class"), "title");

            var assetAttributesArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/i[2]"));
            Assert.IsTrue(assetAttributesArrow.Enabled);
            Assert.IsTrue(assetAttributesArrow.Displayed);
            Assert.AreEqual(assetAttributesArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");
        }

        [Test]
        public void AssetAttributeSortingPage_AssetAttributeSortingOptionTest()
        {
            var administrationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupOption.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a"));
            assetAttributesOption.Click();

            var assetAttributeSortingOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[5]/a"));
            Assert.IsTrue(assetAttributeSortingOption.Enabled);
            Assert.AreEqual(assetAttributeSortingOption.GetAttribute("target"), "_self");
            Assert.AreEqual(assetAttributeSortingOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(assetAttributeSortingOption.GetAttribute("custom-data"), "Asset Attributes Sorting");
            Assert.AreEqual(assetAttributeSortingOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetAttributeSorting");

            var AssetAttributeSortingOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[5]/a/i"));
            Assert.IsTrue(AssetAttributeSortingOptionIcon.Enabled);
            Assert.IsTrue(AssetAttributeSortingOptionIcon.Displayed);
            Assert.AreEqual(AssetAttributeSortingOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var AssetAttributeSortingOptionTitle = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[5]/a/span/span"));
            Assert.IsTrue(AssetAttributeSortingOptionTitle.Enabled);
            Assert.IsTrue(AssetAttributeSortingOptionTitle.Displayed);
            Assert.AreEqual(AssetAttributeSortingOptionTitle.Text, "Asset Attributes Sorting");
            Assert.AreEqual(AssetAttributeSortingOptionTitle.GetAttribute("class"), "title");
        }

        [Test]
        public void AssetAttributesSortingPage_OpenPage()
        {
            var administrationOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            administrationOption.Click();

            var setupBtn = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/a/span/span"));
            setupBtn.Click();

            var assetAttributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/a/span/span"));
            assetAttributesOption.Click();

            var assetAttributeSortingOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li[1]/nav/ul/li[4]/nav/ul/li[5]/a"));
            assetAttributeSortingOption.Click();
        }

        [Test]
        public void AssetAttributeSortingPage_TopBarUserNameTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

            var username = driver.FindElement(By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/span[1]"));
            Assert.IsTrue(username.Enabled);
            Assert.IsTrue(username.Displayed);
            Assert.AreEqual(username.Text, "HI,");
            Assert.AreEqual(username.GetAttribute("class"), "m-topbar__username");

            var admin = driver.FindElement(By.Id("UserName"));
            Assert.IsTrue(admin.Enabled);
            Assert.IsTrue(admin.Displayed);
        }

        [Test]
        public void AssetAttributeSortingPage_LogoutBtnTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

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
        public void AssetAttributeSortingPage_SubHeaderTitleTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Asset Attribute Copy");
        }

        [Test]
        public void AssetAttributeSortingPage_AssetClassDropdownlistTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.True(assetClassLabel.Enabled);
            Assert.True(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"), "form-label");

            var assetClassInput = driver.FindElement(By.Id("AssetClassIdChange"));
            Assert.True(assetClassInput.Enabled);
            Assert.True(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("class"), "form-control form-line");
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-required"), "The ClassId field is required.");

            // to select some attributes class by it index
            var assetClassValue = new SelectElement(assetClassInput);
            assetClassValue.SelectByIndex(1);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassIdChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Choose Class");
        }

        [Test]
        public void AssetAttributeSortingPage_AssetSubClassDropdownlistTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.True(assetSubClassLabel.Enabled);
            Assert.True(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"), "form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"), "AssetSubClass");

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.True(assetSubClassInput.Enabled);
            Assert.True(assetSubClassInput.Displayed);
            Assert.AreEqual(assetSubClassInput.GetAttribute("class"), "form-control form-line");
            Assert.AreEqual(assetSubClassInput.GetAttribute("data-val-required"), "The SubClassId field is required.");

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "No Asset Subclass");
        }


        [Test]
        public void AssetAttributeSortingPage_AssetTypeTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

            var assetTypeInputLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeInputLabel.Text, "Asset Type");
            Assert.True(assetTypeInputLabel.Enabled);
            Assert.True(assetTypeInputLabel.Displayed);
            Assert.AreEqual(assetTypeInputLabel.GetAttribute("for"), "AssetType");
            Assert.AreEqual(assetTypeInputLabel.GetAttribute("class"), "form-label");

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.True(assetTypeInput.Enabled);
            Assert.True(assetTypeInput.Displayed);
            Assert.AreEqual(assetTypeInput.GetAttribute("class"), "form-control form-line");
            Assert.AreEqual(assetTypeInput.GetAttribute("data-val-required"), "The TypeId field is required.");

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "No Asset Types");
        }

        [Test]
        public void AssetAttributeSortingPage_CopyRightTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, ("2025 © CTDOT (Ver .)"));
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }

        [Test]
        public void AssetAttributeSortingPage_MinimizeToggleBtnTest()
        {
            // to open asset attributes Sorting page
            AssetAttributesSortingPage_OpenPage();

            var toggleIcon = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(toggleIcon.Enabled);
            Assert.IsTrue(toggleIcon.Displayed);
            Assert.AreEqual(toggleIcon.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(toggleIcon.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
        }
    }
}
