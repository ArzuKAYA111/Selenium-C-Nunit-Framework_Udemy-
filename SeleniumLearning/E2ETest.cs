using AngleSharp.Text;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
    {
     class E2ETest:CommonMethods
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
        public void EndToEndFlow() {
            driver.Url=Url;


            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("learning");


            //  Locate check box using CSSAdapter Selector
           IList<IWebElement> radBtn = driver.FindElements(By.CssSelector("input[type='radio']"));


            foreach (IWebElement btn in radBtn)
                {
                TestContext.Progress.WriteLine("BUTTON TYPE "+btn.GetAttribute("value"));
                if (btn.GetAttribute("value").Equals("Admin"))
                    {
                    btn.Click();
                    }
                }

            //Syntax tagName.ClassValue
            IWebElement stDD = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement slc = new SelectElement(stDD);
              slc.SelectByText("Consultant");

            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();


            // explicit wait for checkout link visible
               expWait(driver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));


            //  PRODUCT WE WANT TO SELECT
            String[] expectedProducts = {"iphone X","Blackberry" };
            String[] actualProducts = new string[2];

                      //Locate the products cards in applicaton to select iphoe X and blacberry

                      IList<IWebElement> ActProdcts= driver.FindElements(By.TagName("app-card"));

               foreach (IWebElement Appproduct in ActProdcts)
                   {
                /*   //  driver.FindElement(By.CssSelector("app-card h4 a"));
                   TestContext.Progress.WriteLine(" PRODUCTS "+Appproduct.FindElement(By.CssSelector("app-card h4 a")).Text);*/

                if (expectedProducts.Contains(Appproduct.FindElement(By.CssSelector(".card-title a")).Text))
                    {
                    //Istedigim product olunca ADD Button'a tikla 

                    Appproduct.FindElement(By.CssSelector(".card-footer button")).Click();
                    }

                TestContext.Progress.WriteLine( " PRODUCTS " +Appproduct.FindElement(By.CssSelector(".card-title a")).Text);


                   }


              driver.FindElement(By.PartialLinkText("Checkout")).Click();


  // 37. Lecture da yaptiklari
     // Burada card'a ekledigi productlari alip array list e store ediyor Expected ile verfy ediyor


  //Getting products in card and storing them into the  actualProducts list

            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for (int i = 0; i<checkoutCards.Count; i++)

                {
                actualProducts[i]=checkoutCards[i].Text;


                }
            Assert.That(expectedProducts,Is.EqualTo(actualProducts));

// 38. Lecture da yaptiklari
 // Burada card'a ekledigi productlari alip array list e store ediyor


            //Locating Checkout button and clicking 
            driver.FindElement(By.CssSelector(".btn-success")).Click();


//Burada country adi girmesi gerekiyor bu da auto suggestion Drop down 

         //Text bar'i locate edip country'nin ilk 3 harfini giriyor
            driver.FindElement(By.Id("country")).SendKeys("ind");

            //To load suggestion country name need to wait a dding wait here.

            expWait(driver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
       
             // India visible olana kadar bekleyip ona  tikliyor
            driver.FindElement(By.LinkText("India")).Click();

// Checkbox var onu tiklamasi gerkiyor
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();

//Locating purchase button and click
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
//Alma isi tamamlaninca gelen text'i alip alma isleminin tamamlandigini verfy ediyor
            String confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success",confirText);





























            }





        [TearDown]

        public void CloseBrowser( )
            {

            driver.Close();

            }

        }
    }
