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
    class E2ETest_TestCaseSource_DDT :Base
    {
        public static IEnumerable<TestCaseData> AddTestDataConfig( )
            {
            yield return new TestCaseData("rahulshettyacademy","learning","iphone X","Blackberry");
            yield return new TestCaseData("rahulshettyacademy","learning","iphone X","Blackberry");
            yield return new TestCaseData("rahulshettyacademy","learning","iphone X","Blackberry");

            }
        /*
 TestCaseData();   is a class which help us to create set of datas(Test data for our test) like below sets
yield return:      Bu method bu data setlerin hepsini sira ile donmeli normalde bir method birden fazla data donmez C# ta bunu saglayan yield keyworddur.
IEnumerable :      This is an interface in C# it is useful to collect all data 
Static            [TestCaseSource()] attribute referring to astatic methodlar so we do method as static
****  Burada method TestCaseData type data return yapiyor.

         */

        [Test,]  // [Test, TestCaseSource("AddTestDataConfig")] can be like that with only one annotation
        [TestCaseSource("AddTestDataConfig")]


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
          //  Assert.AreEqual(expectedProducts, actualProducts);
            Assert.That(expectedProducts, Is.EqualTo(actualProducts));




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
