using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace CSharpFundus
    {
      class Program:Program4// we inherit program4 class to program class using : sign between class mnames
        {
        /*
         Class method should be inside a class and  outside of the main method block 
         */
        public void getData()
            {
            Console.WriteLine("I am inside the class method");
            }
        static void Main(string[] args)
            {

            //getData();// ITargetBlock belongs to class so we need to create class object to call that method

            Program obj=new Program();//object of the class 
            obj.getData();

            obj.SetData();    //We access setData method and name variable through the program
         string  name= obj.name= "test"; //class object. Because of the inheritance case

            Console.WriteLine($"Name from parent class {name}");

             Debug.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            int a = 4;
            Console.WriteLine("Number is "+a); 
            Console.WriteLine($"Number is {a}");

            string s = "arzu";
            Console.WriteLine("Name is "+ s); 
            Console.WriteLine($"Name is  {s}");

            // if we do Not know the data type(For Example example we are expecting from database) we can use var keyword to create a vaiable

            var age = 23;
            //    age="twenty three";// ONCE we asign a valuE for a var type variable we then we can not asign different type value fort hat variable.


            /*
             if we declare a data as dynamic data type we can asign any type value to that variable. Also we can reasign that variable with other data type value
          
             */
            dynamic height = 13.2;
            Console.WriteLine($" Height is {height} ");
            height="thirteen point two";

            Console.WriteLine($" Height is {height} ");


           



            }
        }
    }