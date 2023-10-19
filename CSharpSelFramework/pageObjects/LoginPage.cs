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
	class LoginPage
		{
		private IWebDriver driver;
		public LoginPage(IWebDriver driver)
			{

			//Initializing the diver  so we registor driver into that class
			this.driver= driver;

			// all class members will initilaize with driver
			PageFactory.InitElements(driver,this); 

			}


	

		[FindsBy(How = How.Id,Using = "username")]
		private IWebElement username;

        [FindsBy(How = How.Id,Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath,Using = ( "//div[@class='form-group'][5]/label/span/input" ))]

        public IWebElement checkBoxBtn;

        [FindsBy(How = How.XPath,Using = ( "//input[@value='Sign In']" ))]

        public IWebElement signInBtn;


        public ProductsPage validLogin(string user,string pass )
            {

            username.Clear();
            username.SendKeys(user);
            password.Clear();
            password.SendKeys(pass);
            checkBoxBtn.Click();
            signInBtn.Click();

            // to use login steps and continue to action on Products page we created ProductsPage bject in that method and returned that object
            // So when we call validLogin() method in test class that will perform login actions and allows us to reach ProductPage  object
            return new ProductsPage(driver);


            }





       


        [FindsBy(How = How.PartialLinkText,Using = ( "Checkout" ))]

        public IWebElement chkOutBtn;

        public IWebElement chkOutBtn_( )
            {
            return chkOutBtn;

            }










        }
    }
