using AngleSharp.Css.Parser;
using OpenQA.Selenium.Support.UI;
using System;


namespace SeleniumLearning
    {
    internal class Locators { 

    IWebDriver driver;
   
 
    string Url = "https://rahulshettyacademy.com/loginpagePractise/";


        // ID, Name,ClassName,TagName, LinkText, Partial Link Text,XPath, CSS Selector

        [SetUp]
    public void StartBrowser( )
        {
      
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver=new ChromeDriver();
     
        //Maximize the page 
        driver.Manage().Window.Maximize();


            /*  IMPLICIT WAIT
             
             Implicit Wait is a global wait  it is applied globally to the driver.
             if you put implicit wait of five seconds, then that will be applied to the each and every step of your entire program (Step of WebDriver).
.
            By default it waits up to five seconds, If it find the element before the specified time then it will resume execution, 
             */

           driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromMilliseconds(3000);


            }

        [Test]
        public void Test1( )
            {
            driver.Url=Url;
           

            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("123456");
            //...............................................................

        
            //Working with checkbox

            // using XPATH
            /* IWebElement chcBox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
             chcBox.Click();*/

            //If there is no attribute like class ,id, type etc we can write xpat using unic parent

            /*    IWebElement checBox = driver.FindElement(By.XPath("//div[@class='form-group'][5]/label//input"));
                checBox.Click();*/
            //..................................................................
            // using CSS Selector
            //CssSelector selectorda;

            /*         eger id attribute'u kullaniyorsak locator'i
                         # idValue seklindeyazabiliriz
             Ex:  #terms

                    eger Class attribute'u kullaniyorsak locator'i
                        .classValue seklindeyazabiliriz

            Ex:  .form-group
                      eger Parenttan child'a dogru locator yaziyor ise xPathte kullandigimiz // yerine sadece bosluk birakiyoruz'

                   Ex: div[class='form-group'] span input    or
                       div[class='form-group'] #terms      
                         
       Ex:     Anoyther example if there are more than one child with same attribute 
            div[class='form-group'] span:nth-child(1)
            .form-group span:nth-child(1)


             */

            IWebElement checBox = driver.FindElement(By.CssSelector("div[class='form-group'] #terms"));
            checBox.Click();

    //.................................................................................
           
            //css Selector 
            //tagname[attribute='value']
            //  driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            //xPath 
            //    //tagname[@attribute='value'



            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();


            /*
         Explicit WAIT
         To perform explicit wait to specific web elements firt we need to creat WebDriverWait class object that comes from Seleium Support package

        T perform explicit wait we need to instal (SeleniumExtras Package from NuGet manager )

         SeleniumExtras help us to support explicit wait for our selenium project.


            We created explicit wait to wait the driver until Error message displayed before performing assertion.
         */
            WebDriverWait expWait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));

            expWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")),"Sign In"));


            //   Text  almada sorun oldu sonra bak

            // to getting text from the dom we use    Text   property
            String errMsg = driver.FindElement(By.CssSelector("div[class='alert alert-danger col-md-12']")).Text;

        TestContext.Progress.WriteLine("Error Message "+ errMsg);
            
// Getting a link url 
         IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            
            string linkURL=link.GetAttribute("href");
            TestContext.Progress.WriteLine("link URL "+linkURL);

            String expectedURL = "https://rahulshettyacademy.com/documents-request";

         //   Assert.AreEqual(expectedURL, linkURL);
            Assert.That(expectedURL,Is.EqualTo( linkURL));


           


            }



        [TearDown]
        public void CloseBrowser( )
            {
          
            driver.Close();
         //   driverFF.Close();
         //   driverME.Close();
            }
        }
    }
