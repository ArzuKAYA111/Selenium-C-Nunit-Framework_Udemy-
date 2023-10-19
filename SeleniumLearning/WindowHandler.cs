using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
    {
    internal class WindowHandler
        {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser( )

            {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver=new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url="https://rahulshettyacademy.com/loginpagePractise/";


            }
        [Test]
        public void WindowHandle( )

            {
/*
        Handling Child Windows Using Selenium

        ( When we click on a link that link open(Take us to another window) a new tag/page) we need to switch that window and make action on it.

*** Each window has a unique String ID
    
            Driver Switchs  to window by ID, By Name or By Index
** 0 index is parent window.
 
 */

            String email = "mentor@rahulshettyacademy.com";

            String parentWindowId = driver.CurrentWindowHandle;


  //Locating the blinking link on current window
            driver.FindElement(By.ClassName("blinkingText")).Click();

    //Finding Numbers of opened window

            int windwCount = driver.WindowHandles.Count;
            TestContext.Progress.WriteLine($"Number of windows window Count {windwCount}" );


//Assert.AreEqual(2,driver.WindowHandles.Count);//1
               Assert.That(driver.WindowHandles.Count,Is.EqualTo(2));//1

            //0 index parent window , 1 index child window 
            //Getting the child window name  using ....>>    driver.WindowHandles[1];

            String childWindowName = driver.WindowHandles[1];

            driver.SwitchTo().Window(childWindowName);

 //Locate the  red sentence in second window and getting the text and printing
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

//Getting the red text from child window
            String text = driver.FindElement(By.CssSelector(".red")).Text;

/*
  Buradan asagidaki kisimda ikinci windowdan aldigi cumleden sadece mail'i alip 
main window'a gidip orada user name  kismina sendKeys ile gonderiyor.

 */

   // Please email us at mentor @rahulshettyacademy.com with below template to receive response

            String[] splittedText = text.Split("at");

            String[] trimmedString = splittedText[1].Trim().Split(" ");

            Assert.That(email,Is.EqualTo(trimmedString[0]));

            driver.SwitchTo().Window(parentWindowId);

            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);



            }
        public void CloseBrowser( )
            {

            driver.Close();

            }

        }
    }
