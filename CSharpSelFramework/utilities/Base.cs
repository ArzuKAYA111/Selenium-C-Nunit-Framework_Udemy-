
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CSharpSelFramework.ManageReport;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;


namespace CSharpSelFramework.utilities
    {
    class Base              
        {
               String browserName;
        public ExtentReports extent;
        public ExtentTest test;
        public String reportPath;

        string folderName;
        string folderPath;
        public String reportFileName;
        public String ScreenShotName;

        string projectDirectory;
        ExtentSparkReporter htmlReporter;


     

        // public IWebDriver driver;
        // basically ThreadLocal class will help us to create a separate driver tread. So all different test will run with different treads

        // public IWebDriver driver;
        //  public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

              public  ThreadLocal<IWebDriver>   driver = new ThreadLocal<IWebDriver>();

        [SetUp]// Runs before and each test in project at the run time 
        public void StartBrowser( )
            {

            test=extent.CreateTest(TestContext.CurrentContext.Test.Name);

            // below code is used To control/run tests from commandline 
            browserName=TestContext.Parameters["browserName"];
             
            //If we do not run tests from commandline or we do not chance browser at run time fro commandline browserName will be null so browser will get from config file. 
            if ( browserName == null )
                {
                //Using Configuration Manager class we rad the configuration file to get browser 
                //from Configuration Manager using AappSettings property  
                browserName=ConfigurationManager.AppSettings["browser"];
                }

            // We called initBrowser Method
            initBrowser(browserName);


            //Maximize the browser 
            driver.Value.Manage().Window.Maximize();


            // IMPLICIT WAIT

            driver.Value.Manage().Timeouts().ImplicitWait=TimeSpan.FromMilliseconds(3000);

            //Hits the URL
            driver.Value.Url=ConfigurationManager.AppSettings["url"];

            }


        public IWebDriver getDriver( )

            {
            return driver.Value;
            }


        public void initBrowser(string browsName)
            {
            switch (browsName.ToLower())
                {

                case "chrome":

                    //Initializing the ChromeBrowser
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value=new ChromeDriver();
                    break;


                case "firefox":

                    //Initializing the Firefox
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value=new FirefoxDriver();
                    break;

                case "edge":

                    //Initializing the Edge
                   new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value=new EdgeDriver();
                    break;

                }

            }


        //We created a method this will give us object of the  JsonReader class 
        public static JsonReader getDataParser( )
            {
            return new JsonReader();
            }


        //report file
        [OneTimeSetUp] // This runs just one time 
              public void SetupReport( )

                    {


                    // Define the folder name you want to create
                    folderName="Reports";


                    DateTime time = DateTime.Now;

                    string workingDirectory = Environment.CurrentDirectory;// gets the full path of the current directory (Here utilities is the working diroctry because this class in the utilities folder)
                                                                           // we need to go one step back which is the project directory(Project rooot path) ) to do that we wrote the below statement
                    projectDirectory=Directory.GetParent(workingDirectory).Parent.Parent.FullName;


                    // Combine the root directory path with the folder name
                    folderPath=Path.Combine(projectDirectory,folderName);

                    try
                        {
                        // Check if the folder already exists
                        if (!Directory.Exists(folderPath))
                            {
                            // Create the folder
                            Directory.CreateDirectory(folderPath);

                    string testClasNAme = TestContext.CurrentContext.Test.Name;
                    reportFileName=@"//"+testClasNAme+time.Date.ToString("D")+".html";

                            htmlReporter = new ExtentSparkReporter(folderPath+reportFileName);
                         /*  extent=new ExtentReports();
                            extent.AttachReporter(htmlReporter);
                            extent.AddSystemInfo("Host Name","Local host");
                            extent.AddSystemInfo("Environment","QA");
                            extent.AddSystemInfo("Username","Rahul Shetty");*/

                            Console.WriteLine($"Folder '{folderName}' created in the project's root directory.");
                            }
                        else
                            {
                            Console.WriteLine($"Folder '{folderName}' already exists in the project's root directory.");

                            reportFileName="//TestsReport_"+time.Date.ToString("D")+".html";

                            htmlReporter = new ExtentSparkReporter(folderPath+reportFileName);
                          /*  extent=new ExtentReports();
                            extent.AttachReporter(htmlReporter);
                            extent.AddSystemInfo("Host Name","Local host");
                            extent.AddSystemInfo("Environment","QA");
                            extent.AddSystemInfo("Username","Rahul Shetty");*/


                            }
                        }
                    catch (Exception ex)
                        {
                        Console.WriteLine($"An error occurred while creating the folder: {ex.Message}");
                        }
                    extent=new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Host Name","Local host");
                    extent.AddSystemInfo("Environment","QA");
                    extent.AddSystemInfo("Username","Rahul Shetty");

                    }
        

       


            [TearDown]

        public void AfterTest( )
            {


            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

          

            DateTime time = DateTime.Now;


            // String fileName = "Screenshot_"+time.Date.ToString("M_d_y_h_mm_ss")+".png";
            ScreenShotName= "Screenshot_"+time.Date.ToString("G")+".png";

            if (status==TestStatus.Failed)
                {

               test.Fail("Test failed",( AventStack.ExtentReports.Model.Media )TakeScreenShot.captureScreenShot(driver.Value,ScreenShotName));
                test.Log(Status.Fail,"test failed with logtrace"+stackTrace);

                }
            else if (status==TestStatus.Passed)
                {

                }




            extent.Flush();
            driver.Value.Dispose();

            }




        [OneTimeTearDown]
        public void OneTimeTearDown( )
            {
            if (driver.IsValueCreated)
                {
                driver.Value.Quit();
                driver.Dispose();
                }
            }



        }
    }
