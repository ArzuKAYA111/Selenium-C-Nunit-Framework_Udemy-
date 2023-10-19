using AngleSharp.Css.Parser;
using AngleSharp.Dom;
using CSharpSelFramework.utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace CSharpSelFramework.Tests
    {
    [Parallelizable(ParallelScope.Children)]
    class HandlStaticDD :Base
        {

        WebDriverWait expWait;    //"C:\Users\fizik\UdemySeleniumC#Course\CSharpSelFramework\CSharpSelFramework.csproj"

        [Test]
        public void DropDown( )
            {
            // Handling multiple radio button

            //Locate lement Using XPAth
            IList<IWebElement> radBtn = driver.Value.FindElements(By.XPath("//input[@type='radio']"));

            /* //  Locate lement using CSSAdapter Selector
             IList<IWebElement> radBtn = driver.FindElements(By.CssSelector("input[type='radio']"));*/

            foreach (IWebElement btn in radBtn)
                {
                TestContext.Progress.WriteLine("BUTTON TYPE "+btn.GetAttribute("value"));
                if (btn.GetAttribute("value").Equals("user"))
                    {

                    btn.Click();
                    Assert.That(btn.Selected,Is.True);

                    }
                }
            expWait = new WebDriverWait(driver.Value,TimeSpan.FromSeconds(5));

            // Handling Popup 

            IList<IWebElement> pupUp = driver.Value.FindElements(By.CssSelector("button[type='button']"));


            foreach (IWebElement p in pupUp)
                {
             

                expWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(p));


                TestContext.Progress.WriteLine("Pup Up "+p.GetAttribute("id"));

                if (p.GetAttribute("id").Equals("cancelBtn"))
                    {

                    p.Click();


                    }
                }

            //Syntax tagName.ClassValue
            IWebElement stDD = driver.Value.FindElement(By.CssSelector("select.form-control"));

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



     
        }
    }
