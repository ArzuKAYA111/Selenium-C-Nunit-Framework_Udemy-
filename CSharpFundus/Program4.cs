using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundus
    {
    class Program4
        {

        public string name;
        public string surname;

        public Program4(string name,string Surname )
            {

            this.name=name;
            this.surname=Surname;
            }

        public void getName( )
            {

            Console.WriteLine("My Name is "+ name+" "+surname);

            }

        public void SetData()
            {

            Console.WriteLine("I am from Parent class");

            }
      public  static void Main(string[] args)
            {

            Program4 p4= new Program4("Arzu","Kaya");
            p4.getName( );


            }
        }
    }
