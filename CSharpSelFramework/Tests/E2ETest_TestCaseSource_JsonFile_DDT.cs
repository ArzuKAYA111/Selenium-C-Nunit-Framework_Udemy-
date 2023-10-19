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
    class E2ETest_TestCaseSource_JsonFile_DDT :Base
    {
        public static IEnumerable<TestCaseData> AddTestDataConfig( )

            {

            yield return new TestCaseData(getDataParser().extractData("username"),getDataParser().extractData("password"),getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"),getDataParser().extractData("password"),getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"),getDataParser().extractData("password_wrong"),getDataParser().extractDataArray("products"));
            }

        [Test,]  // [Test, TestCaseSource("AddTestDataConfig")] can be like that with only one annotation
        [TestCaseSource("AddTestDataConfig")]


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
            //  Assert.AreEqual(products, actualProducts);
            Assert.That(products,Is.EqualTo(actualProducts));




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
