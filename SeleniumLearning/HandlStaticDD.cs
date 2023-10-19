using AngleSharp.Css.Parser;
using AngleSharp.Dom;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.DevTools.V115.CSS;
using OpenQA.Selenium.Support.UI;
using System;


namespace SeleniumLearning
    {
    internal class HandlStaticDD: CommonMethods
     { 

    IWebDriver driver;
   
 
    string Url = "https://rahulshettyacademy.com/loginpagePractise/";

        [SetUp]
    public void StartBrowser( )
        {
      
            //Initializing the ChromeBrowser
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver=new ChromeDriver();
     
        //Maximize the browser 
        driver.Manage().Window.Maximize();


       // IMPLICIT WAIT
        
           driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromMilliseconds(3000);

            //Hits the URL
            driver.Url=Url;

            }

        [Test]
        public void DropDown( )
            {
           // Handling multiple radio button

            //Locate lement Using XPAth
            IList<IWebElement> radBtn = driver.FindElements(By.XPath("//input[@type='radio']"));

           /* //  Locate lement using CSSAdapter Selector
            IList<IWebElement> radBtn = driver.FindElements(By.CssSelector("input[type='radio']"));*/

            foreach (IWebElement btn in radBtn)
                {
                TestContext.Progress.WriteLine("BUTTON TYPE "+btn.GetAttribute("value"));
                if (btn.GetAttribute("value").Equals("user"))
                    {

                    btn.Click();
                    Assert.That(btn.Selected, Is.True);

                    }
                }
            

            // Handling Popup 

            IList<IWebElement> pupUp = driver.FindElements(By.CssSelector("button[type='button']"));
       

            foreach (IWebElement p in pupUp)
                {
                elmToBeClikbl(driver,p);
                TestContext.Progress.WriteLine("Pup Up "+p.GetAttribute("id"));

                if (p.GetAttribute("id").Equals("cancelBtn"))
                    {

                    p.Click();
                    

                    }
                }

           

            /*
             Handling Static DD
            1- Locate the element
            2- Create   SelectElement   class object and Pass the element into that object constructor

            3- Using that object reference Call one of the method below 
             SelectByIndex()
             SelectByText()
             SelectByValue()

             */
            //Syntax tagName.ClassValue
            IWebElement stDD = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement slc = new SelectElement(stDD);

            /*slc.SelectByText("Student");
           slc.SelectByText("Teacher");
           slc.SelectByText("Consultant");

           slc.SelectByValue("stud");
           slc.SelectByValue("teach");
           slc.SelectByValue("consult");

            slc.SelectByIndex(0);
            slc.SelectByIndex(1);*/
            slc.SelectByIndex(2);

 

            }



        [TearDown]
        public void CloseBrowser( )
            {
          
          //  driver.Close();
       
            }
        }
    }
