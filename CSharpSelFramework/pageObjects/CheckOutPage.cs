using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
    {
     class CheckOutPage
        {

        IWebDriver driver;
public CheckOutPage(IWebDriver driver)
            {
            this.driver=driver;
            PageFactory.InitElements(driver, this);

            }


        /*  IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

              for (int i = 0; i<checkoutCards.Count; i++)

              {
                  actualProducts[i] = checkoutCards[i].Text;


              }
  */
        [FindsBy(How = How.CssSelector,Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        public IList<IWebElement> CheckOutCards_()
            {
            return checkoutCards;
            }

        /*  driver.FindElement(By.CssSelector(".btn-success")).Click();

             driver.FindElement(By.Id("country")).SendKeys("ind");

 */

        [FindsBy(How = How.CssSelector,Using = ".btn-success")]
        private IWebElement checkoutBtn;

        public ConfirmationPage CheckOutBtn_( )
            {
            checkoutBtn.Click();

            return new ConfirmationPage(driver);
            }




        }

    }
