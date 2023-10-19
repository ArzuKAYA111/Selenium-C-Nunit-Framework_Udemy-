using CSharpSelFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.Tests
    {
    [Parallelizable(ParallelScope.Children)]
    class WindowHandler :Base
        {

        [Test, Category("Smoke")]
        public void WindowHandle( )

            {
            /*  
  
                        Driver Switchs  to window by ID, By Name or By Index
            ** 0 index is parent window.

             */

            string email = "mentor@rahulshettyacademy.com";

            string parentWindowId = driver.Value.CurrentWindowHandle;


            //Locating the blinking link on current window
            driver.Value.FindElement(By.ClassName("blinkingText")).Click();

            //Finding Numbers of opened window

            int windwCount = driver.Value.WindowHandles.Count;
            TestContext.Progress.WriteLine($"Number of windows window Count {windwCount}");


            Assert.AreEqual(2,driver.Value.WindowHandles.Count);//1

            //0 index parent window , 1 index child window 
            //Getting the child window name  using ....>>    driver.WindowHandles[1];

            string childWindowName = driver.Value.WindowHandles[1];

            driver.Value.SwitchTo().Window(childWindowName);

            //Locate the  red sentence in second window and getting the text and printing
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector(".red")).Text);

            //Getting the red text from child window
            string text = driver.Value.FindElement(By.CssSelector(".red")).Text;

    

            // Please email us at mentor @rahulshettyacademy.com with below template to receive response

            string[] splittedText = text.Split("at");

            string[] trimmedString = splittedText[1].Trim().Split(" ");

            // Assert.AreEqual(email,trimmedString[0]);
            Assert.That(email,Is.EqualTo(trimmedString[0]));

            driver.Value.SwitchTo().Window(parentWindowId);

            driver.Value.FindElement(By.Id("username")).SendKeys(trimmedString[0]);



            }
       

        }
    }
