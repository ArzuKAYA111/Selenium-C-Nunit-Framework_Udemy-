using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CSharpSelFramework.utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.ManageReport
    {
     class TakeScreenShot:Base
        {
        public static object captureScreenShot(IWebDriver driver,String screenShotName)

            {

            ITakesScreenshot ts = ( ITakesScreenshot )driver;// Casting driver intothe screenshot mode
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,screenShotName).Build();



            }


    





        }
    }
