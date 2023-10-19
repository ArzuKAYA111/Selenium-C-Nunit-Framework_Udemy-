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
    [Parallelizable(ParallelScope.Children)]
    class E2ETest_TestCase_DDT :Base
    {
   

        [Test]

        /*[TestCase("rahulshettyacademy","learning","iphone X","Blackberry")] anantotion ve can drive data from that part into test method if we do that anatotion multiple times we do Data Driven Test
         */
        [TestCase("rahulshettyacademy","learning","iphone X","Blackberry")]
        /*[TestCase("rahulshettyacademy","learn","iphone X","Blackberry")]  //negative test password yanlis
        [TestCase("rahulshetty","learning","iphone X","Blackberry")]  //negative test  username yanlis
*/


        public void EndToEndFlow(string username,string Password,string prodck1,string prodck2)
        {
            //diver comming from Base  Class
            LoginPage lg = new LoginPage( driver.Value);
            //calling  validLogin( ) method from LoginPage class that will perform login actions and allows us to reach ProductPage  object
       
            ProductsPage prdctsPage=lg.validLogin(username,Password);

            prdctsPage.waitForPageDisplay();

         
            string[] expectedProducts = { prodck1,prodck2 };
            string[] actualProducts = new string[2];


            IList<IWebElement> ActProdcts = prdctsPage.cards_();

            foreach (IWebElement Appproduct in ActProdcts)
            {
                
                if (expectedProducts.Contains(Appproduct.FindElement(prdctsPage.cardTitle_()).Text))
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
           // Assert.AreEqual(expectedProducts, actualProducts);
            Assert.That(expectedProducts,Is.EqualTo( actualProducts));




            ConfirmationPage confmPackage= checkOutPage.CheckOutBtn_();

           confmPackage.countryTextB_("ind");

           confmPackage. waitUntlCountyTextVisble();

            confmPackage.countryLinkText_();

            confmPackage.checkBox_();

            confmPackage.purches_();

            string confirText = confmPackage.succesAlert_();

            StringAssert.Contains("Success", confirText);

        }



    }
}
