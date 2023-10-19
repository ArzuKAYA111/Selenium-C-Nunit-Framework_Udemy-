using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
    {
    class ConfirmationPage
        {
        IWebDriver driver;

        public ConfirmationPage(IWebDriver driver)
            {
            this.driver=driver;
            PageFactory.InitElements(driver,this);

            }

        By CountryLinkText = By.LinkText("India");

        public By ContLinkText_()
            {
          return CountryLinkText;
            }
     

        [FindsBy(How = How.Id,Using = "country")]
        private IWebElement countryTextBar;

        public void countryTextB_(string countryText)
            {
            countryTextBar.SendKeys(countryText);
            }




        public void waitUntlCountyTextVisble( )
            {
            WebDriverWait expWait = new WebDriverWait(driver,TimeSpan.FromSeconds(8));

            expWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ContLinkText_()));

            }



        [FindsBy(How = How.LinkText,Using = "India")]
        private IWebElement countryLinkText;

        public void countryLinkText_()
            {
           countryLinkText.Click();
            }

        [FindsBy(How = How.CssSelector,Using = "label[for*='checkbox2']")]
        private IWebElement checkBox;

        public void checkBox_( )
            {
            checkBox.Click();
            }



        [FindsBy(How = How.CssSelector,Using = "[value='Purchase']")]
        private IWebElement purches;

        public void purches_( )
            {
            purches.Click();
            }




        [FindsBy(How = How.CssSelector,Using = ".alert-success")]
        private IWebElement succesAlert;

        public string succesAlert_( )
            {
         return   succesAlert.Text;
            }





        }
    }
