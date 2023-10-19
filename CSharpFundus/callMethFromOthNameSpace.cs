


namespace CSharpFundus
    {
    internal class callMethFromOthNameSpace
        {
        static void Main(string[] args)
            {
            ConsoleApp2.Program obj = new ConsoleApp2.Program();
            obj.PrgmApp2();
            }
        }

    namespace ConsoleApp2
        {
        internal class Program
            {
            public void PrgmApp2( )
                {
                Console.WriteLine("PrgmApp2 is being executed");
                }
            }
        }
    }