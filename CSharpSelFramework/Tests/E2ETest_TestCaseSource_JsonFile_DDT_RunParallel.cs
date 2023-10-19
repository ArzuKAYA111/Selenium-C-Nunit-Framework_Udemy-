using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using CSharpSelFramework.utilities;
using CSharpSelFramework.pageObjects;
using NUnit.Framework.Internal;
using OpenQA.Selenium.DevTools;
using NUnit.Framework;

namespace CSharpSelFramework.Tests
{
    
    [Parallelizable(ParallelScope.Self)]   
    class E2ETest_TestCaseSource_JsonFile_DDT_RunParallel :Base
    {
        public static IEnumerable<TestCaseData> AddTestDataConfig( )

            {

            yield return new TestCaseData(getDataParser().extractData("username"),getDataParser().extractData("password"),getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"),getDataParser().extractData("password"),getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"),getDataParser().extractData("password_wrong"),getDataParser().extractDataArray("products"));
          
            }
        
        [Test,Category("Regression")]  // [Test, TestCaseSource("AddTestDataConfig")] can be like that with only one annotation
        [TestCaseSource("AddTestDataConfig")]

        [Parallelizable(ParallelScope.All)]

        public void EndToEndFlow(string username,string Password,string[] products)
        {
            //diver comming from Base  Class
            LoginPage lg = new LoginPage( driver.Value);
            //calling  validLogin( ) method from LoginPage class that will perform login actions and allows us to reach ProductPage  object
       
            ProductsPage prdctsPage=lg.validLogin(username,Password);

            prdctsPage.waitForPageDisplay();


            // String[] products = { products };
            string[] actualProducts = new string[2];


            IList<IWebElement> ActProdcts = prdctsPage.cards_();

            foreach (IWebElement Appproduct in ActProdcts)
            {
                
                if (products.Contains(Appproduct.FindElement(prdctsPage.cardTitle_()).Text))
                {

                    Appproduct.FindElement(prdctsPage.addToCart_()).Click();
                }

                TestContext.Progress.WriteLine(" PRODUCTS " + Appproduct.FindElement(prdctsPage.cardTitle_()).Text);

            }




            CheckOutPage checkOutPage= prdctsPage.checkout_();


            IList<IWebElement> checkoutCards =checkOutPage.CheckOutCards_();

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;


            }
         // Assert.AreEqual(products, actualProducts);
          Assert.That(products,Is.EqualTo( actualProducts));




            ConfirmationPage confmPackage= checkOutPage.CheckOutBtn_();

           confmPackage.countryTextB_("ind");

           confmPackage. waitUntlCountyTextVisble();

            confmPackage.countryLinkText_();

            confmPackage.checkBox_();

            confmPackage.purches_();

            string confirText = confmPackage.succesAlert_();

            StringAssert.Contains("Success", confirText);

        }


      // WE added ThAT TEST TO DO PARALLEL TESTTNG WITH 2 TEST METHODS IN A CLASS
        [Test, Category("Smoke")]
        public void LocatorsIdentification( )

            {

            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.Value.FindElement(By.Name("password")).SendKeys("123456");
            //css selector & xpath
            //  tagname[attribute ='value']
            //    #id  #terms  - class name -> css .classname
            //    driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            //    //tagName[@attribute = 'value']

            // CSS - .text-info span:nth-child(1) input
            //xpath - //label[@class='text-info']/span/input

            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver.Value,TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
           .TextToBePresentInElementValue(driver.Value.FindElement(By.Id("signInBtn")),"Sign In"));

            String errorMessage = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);


            }




















        }
    }
