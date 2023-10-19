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
   class ProductsPage
        {

       private IWebDriver driver;

        public ProductsPage(IWebDriver driver)
            {
            this.driver=driver;
            PageFactory.InitElements(driver,this);

            }




        /*If we need to use locator  just like >>>> By.PartialLinkText("Checkout") not total WebElement like  >>>>> driver.FindElement(By(....)
        We should create << By.PartialLinkText("Checkout") >>>  part as a variable using BY  like below then we create a public method to use them in methods etc.
*/
        By checkOut = By.PartialLinkText("Checkout");
        public By checkOut_( )
            {
            return checkOut;
            }

        By cardTitle = By.CssSelector(".card-title a");

        public By cardTitle_( )
            {
            return cardTitle;
            }


        By addToCart = By.CssSelector(".card-footer button");
        public By addToCart_( )
            {
            return addToCart;
            }


       

        public void waitForPageDisplay( )
            {
            WebDriverWait expWait = new WebDriverWait(driver,TimeSpan.FromSeconds(8));
            expWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(checkOut_()));

            }


        [FindsBy(How = How.TagName,Using = "app-card")]
        private IList<IWebElement> cards;

        public IList<IWebElement> cards_( )
            {
            return cards;
            }

       


        [FindsBy(How = How.PartialLinkText,Using = "Checkout")]
        private IWebElement checkoutBtn;

        public CheckOutPage checkout_( )
            {
             checkoutBtn.Click();

            return new CheckOutPage(driver);
            }






        }
    }
