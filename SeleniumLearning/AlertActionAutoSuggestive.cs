using NUnit.Framework.Constraints;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
    {
    internal class AlertActionAutoSuggestive:CommonMethods
        {
        IWebDriver driver;
        [SetUp]

        public void StartBrowser( )

            {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver=new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url="https://rahulshettyacademy.com/AutomationPractice/";


            }


        [Test]

        public void frames( )

            {
            /*  
   1-  First we need to scroll down to the frame
            To Scroll Up or down  we use IJavaScript Executer  interface 

           Locate the frame (click on farame part inspect and find(Controll F then write iframe) a tag like iframe tah using tags, attribute locate the frame)
            
        Create an object by casting driver to te JavaScriptExecuter 

        Using that object reference call methods from the JavaScript Executer interface

2- To work in a frame first we need to switch that frame
   after switch the frame we can perform all normal action on elements in that frame using driver

3- While driver inside the frame we can not ferform action on main Page
    To come back to main page from the Frame we need to use  
            driver.SwitchTo().DefaultContent();

 Also, We can not go from one frame to the another frame directly. First we need to switch to DefaultContent() the we need to switch another frame

              */

            //1- scroll to farme
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
           
            IJavaScriptExecutor js = ( IJavaScriptExecutor )driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",frameScroll);


   //2- switch to frame using id, name or  index
          
            driver.SwitchTo().Frame("courses-iframe");

// after switch the frame we can perform all normal action on elements in that frame using driver
          driver.FindElement(By.LinkText("All Access Plan")).Click();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);

 //3-To come back to regular page from the Frame
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);

            }

        [Test]
        public void test_Alert( )

            {
            /*
             this section, switch to alert example.
           in there there iswindows pup up not web/browser pup up
            selenium automates only the browser, so selenium cannot identify any windows pup up 
            how do you automate windows alert/pop up?

             selenium have introduced a new class called Alert, which help
us to do that.

             */

            String name = "Arzu";

//Entering data into the text bar 
         driver.FindElement(By.CssSelector("#name")).SendKeys(name);

//Clicking the confirm button/ than a pop up displays on windows(Whis has OK And Cancel Buttons)
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();

    //  To get text writing on the pop up Use ......>driver.SwitchTo().Alert().Text
            String alertText = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine($"Alert : {alertText}");

   //  To accept or Cancel pop up Use ......> driver.SwitchTo().Alert().Accept();  or    driver.SwitchTo().Alert().Dismiss();

            driver.SwitchTo().Alert().Accept();
            //   driver.SwitchTo().Alert().Dismiss();

  //Some times we need to provide more info while handling alert we need to send text to the aler how do that? 

            //  driver.SwitchTo().Alert().SendKeys("hello");

    //  Asserting after sending a name if alert text contains that name or not
           StringAssert.Contains(name,alertText);

         
            }


        [Test]
        public void test_AutoSuggestiveDropDowns( )

            {
            //Handling Auto Suggestive Dynamic DropDowns
      /*
   Burada text box var ve ulke ismi enter yapmaya basladiginda muhtemel ulke isimleri otomatik olarak cikiyor. Bu cikan muhtemel ulkelerden kendi istedigimizi bulup Click yapmamiz lazim.      
           
        3 harf yazdiktan sonra suggestionlar geliyor
       */
  //1- Locating input boc and sending  country name
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            expWait(driver);

   //2-  ind yainca li Tagli uc tane suggestion cikiyor. ama ulke isimleri child olan div tagli ksimda isimleri handl etmek icin ortak olan className 'i kullanarak CSS ile locate ediyor  "(".ui-menu-item div" 

            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
                {
                if (option.Text.Equals("India"))

                    {
                    option.Click();
                    }

                }
//After select the country (india ) Checking if the india ia present in the text bar
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));

            }


        [Test]
        public void test_Actions( )

            {
/*
 Burada Bir yere tikladigimizda secmek icin birden fazla secenek iceren bir pop up ortaya ciktiginda ne yapariz onu test ediyoruz

   Bu Browser pup up oluyor ve inspect yapilip element locate edilebiyor.
 */
      //      driver.Url = "https://rahulshettyacademy.com";

   // 1- Create Action class object and bass the driver to that object constructor

            Actions a = new Actions(driver);

            //2-  Using action class objct variable call the that class methods and pass the element loacater in that method as a parameter.

            // 3-Do not for get the call Perform() method at the end of the satement.

     /*        a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();*/

    //Ex For Darg and Drop Action 
            //using action clas object calling DragAndDrop() Methods from Action class and passing draggable element locator and dropple element locater into that method then calling Perform() method 

            driver.Url="https://demoqa.com/droppable/";
            a.DragAndDrop(driver.FindElement(By.Id("draggable")),driver.FindElement(By.Id("droppable"))).Perform();

            }


        [TearDown]

        public void CloseBrowser( )
            {

            driver.Close();

            }

        }
    }
