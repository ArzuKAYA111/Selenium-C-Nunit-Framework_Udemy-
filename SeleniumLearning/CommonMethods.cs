using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
    {
    internal class CommonMethods
        {
   
        public static WebDriverWait expWait(IWebDriver driver)
            {
            WebDriverWait expWait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
        return    expWait;

            }


        public void TextToBePresent(IWebDriver driver, IWebElement webElm,string cond)
            {

            expWait(driver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webElm,cond));


            }


        public static void elmToBeClikbl(IWebDriver driver,IWebElement webElm)
            {

            expWait(driver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElm));


            }
       

        }
    }
