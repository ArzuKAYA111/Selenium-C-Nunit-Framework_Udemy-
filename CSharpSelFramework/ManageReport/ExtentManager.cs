using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Interfaces;

namespace CSharpSelFramework.ManageReport
    {
    public class ExtentManag:ITestAction
        {

        public ExtentReports extent;
        public ExtentTest test;
        public String reportPath;
        public String reportFileName;
        public String ScreenShotName;
      

        public ActionTargets Targets => throw new NotImplementedException();

        public void BeforeTest(ITest test)
            {
          string className=  test.ClassName;

            string MethodName = test.MethodName;
           
            
            
            }

        public void AfterTest(ITest test)
            {



           



            }
        }
    }
