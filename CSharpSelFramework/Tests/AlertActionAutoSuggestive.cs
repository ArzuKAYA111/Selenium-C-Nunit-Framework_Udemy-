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
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace CSharpSelFramework.Tests
    {
    [Parallelizable(ParallelScope.Children)]
    class AlertActionAutoSuggestive :Base
        {


        [Test]

        public void frames( )

            {
            driver.Value.Url="https://rahulshettyacademy.com/AutomationPractice/";



            //1- scroll to farme
            IWebElement frameScroll = driver.Value.FindElement(By.Id("courses-iframe"));

            IJavaScriptExecutor js = ( IJavaScriptExecutor )driver.Value;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",frameScroll);


            //2- switch to frame using id, name or  index

            driver.Value.SwitchTo().Frame("courses-iframe");

            // after switch the frame we can perform all normal action on elements in that frame using driver
            driver.Value.FindElement(By.LinkText("All Access Plan")).Click();
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector("h1")).Text);

            //3-To come back to regular page from the Frame
            driver.Value.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector("h1")).Text);

            }

        [Test]
        public void test_Alert( )

            {

            driver.Value.Url="https://rahulshettyacademy.com/AutomationPractice/";

            string name = "Arzu";

            //Entering data into the text bar 
            driver.Value.FindElement(By.CssSelector("#name")).SendKeys(name);

            //Clicking the confirm button/ than a pop up displays on windows(Whis has OK And Cancel Buttons)
            driver.Value.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();

            //  To get text writing on the pop up Use ......>driver.SwitchTo().Alert().Text
            string alertText = driver.Value.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine($"Alert : {alertText}");

            //  To accept or Cancel pop up Use ......> driver.SwitchTo().Alert().Accept();  or    driver.SwitchTo().Alert().Dismiss();

            driver.Value.SwitchTo().Alert().Accept();
            //   driver.SwitchTo().Alert().Dismiss();


            //  driver.SwitchTo().Alert().SendKeys("hello");

            //  Asserting after sending a name if alert text contains that name or not
            StringAssert.Contains(name,alertText);


            }


        [Test]
        public void test_AutoSuggestiveDropDowns( )

            {
            driver.Value.Url="https://rahulshettyacademy.com/AutomationPractice/";
           


            //1- Locating input boc and sending  country name
            driver.Value.FindElement(By.Id("autocomplete")).SendKeys("ind");
            WebDriverWait expWait = new WebDriverWait(driver.Value,TimeSpan.FromSeconds(5)); ;


            IList<IWebElement> options = driver.Value.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
                {
                if (option.Text.Equals("India"))

                    {
                    option.Click();
                    }

                }
            //After select the country (india ) Checking if the india ia present in the text bar
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.Id("autocomplete")).GetAttribute("value"));

            }


        [Test]
        public void test_Actions( )

            {

            //      driver.Url = "https://rahulshettyacademy.com";


            Actions a = new Actions(driver.Value);



            /*   a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();

               a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();*/


            driver.Value.Url="https://demoqa.com/droppable/";
            a.DragAndDrop(driver.Value.FindElement(By.Id("draggable")),driver.Value.FindElement(By.Id("droppable"))).Perform();

            }


        }
    }
