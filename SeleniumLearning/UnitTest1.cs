namespace SeleniumLearning
    {
    public class Tests
        {
        [SetUp]// any prerequest things setting up under that tag
        public void Setup( )
            {
            TestContext.Progress.WriteLine("SetupMethod execution");

            }

        [Test]
        public void Test1( )
            {
            TestContext.Progress.WriteLine("SetupMethod executionThis is test 1 ");
            }
        [Test]
        public void Test2( )
            {
            TestContext.Progress.WriteLine("This is test 2");

            }


        [TearDown]
        public void CloseBrowser( )
            {
            TestContext.Progress.WriteLine("Thear down method");

            }

        }
    }