using System;


namespace SeleniumLearning
    {
    class SeleniumFirst
        {
       IWebDriver driver;
       IWebDriver driverFF;
       IWebDriver driverME;

        [SetUp]
        public void StartBrowser()
            {
            /*
     Ho we invoke chrome browser into test Selenium 
    provided an interface called Web Driver, which will help you to invok Chrome browser,you have to create class out of it.

            GetUrl, click vs methods comming from Webdriver interface but implementing by ChromeDriver itself

            Selenium cannot directly communicate with any browser.
            There are tools like Cyprus Play Right, which are recently released, and that they have a way to communicate but selenium use some proxy server in between. To do that comminication we have to download one Chrome driver file.( chromedriver.exe file) WE need to install WebDriver MAnager package

  Add to project WebDriverManger from Nuget Maneger Package part

directly with browser
*/
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

            driver = new ChromeDriver();
            driverFF=new FirefoxDriver();
            driverME=new EdgeDriver();

            //Maximize the page 
            driver.Manage().Window.Maximize();
            driverFF.Manage().Window.Minimize();
            driverME.Manage().Window.Minimize();
            }

        [Test]
        public void Test1( )
            {
            driver.Url="https://rahulshettyacademy.com/";
            driverFF.Url="https://rahulshettyacademy.com/";
            driverME.Url="https://rahulshettyacademy.com/";


            //Getting title of the site/Page
            string title = driver.Title;
            TestContext.Progress.WriteLine("Chrome Title of the site "+title);
            
            //to get Url of the side also used drver.Url
            string url = driver.Url;
            TestContext.Progress.WriteLine("Chrome Url of the site "+url);
          
            //.......................

            //Getting title of the site/Page
            string titleF = driver.Title;
            TestContext.Progress.WriteLine("Firefox Title of the site "+titleF);

            //to get Url of the side also used drver.Url
            string urlF = driver.Url;
            TestContext.Progress.WriteLine("Firefox Url of the site "+urlF);

            //............................

            //Getting title of the site/Page
            string titleME = driver.Title;
            TestContext.Progress.WriteLine("Microsoft Ege Title F of the site "+titleME);

            //to get Url of the side also used drver.Url
            string urlME = driver.Url;
            TestContext.Progress.WriteLine("Microsoft Ege Url F of the site "+urlME);
            }


        [TearDown]
        public void CloseBrowser( )
            {
     
            driver.Close();
            driverFF.Close();
            driverME.Close();
            }


        }
    }
