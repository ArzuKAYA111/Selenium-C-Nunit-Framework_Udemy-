using AngleSharp.Css.Parser;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
    {
    internal class SortWebTables
        {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser( )

            {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver=new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url="https://rahulshettyacademy.com/seleniumPractise/#/offers";



            }

        [Test]

        public void SortTable( )

            {
            ArrayList a = new ArrayList();

            //There is a static DD which has Select tag locate that DD
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");


            // step 1 - Get all veggie/fruit names into arraylist A
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in veggies)
                {
                a.Add(veggie.Text);


                }

            //step 2- Sort this arraylist  -A

            foreach (String element in a)
                {
                TestContext.Progress.WriteLine(element);
                }

            TestContext.Progress.WriteLine("After sorting");
            a.Sort();
            foreach (String element in a)
                {
                TestContext.Progress.WriteLine(element);
                }



            //step 3 - go and click column to sort veggies

            //XPath ile
            driver.FindElement(By.XPath("//th[contains(@aria-label , 'fruit name')]")).Click();    
            
           // CssSelector  ile 
           /* driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();*/

          //  th[aria-label*='fruit name'] ....>.. Buradaki * in anlami attributeun valusunun tamami alinmayacak partial alinacak

            //step 4- Get all veggie names into arraylist B Aftter sort

            ArrayList b = new ArrayList();

            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in sortedVeggies)
                {
                b.Add(veggie.Text);


                }

            //4 Assert arraylist A to B = equal
           // Assert.AreEqual(a,b);
            Assert.That(a,Is.EqualTo(b));


            }

        [TearDown]

        public void CloseBrowser( )
            {

               driver.Close();

            }

        }
    }
