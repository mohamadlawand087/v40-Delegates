using System;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var nb1 = 3; // int variables

            // PrintNumber(nb1);
            // MultiplyNumber(nb1);

            var firstDeleg = new FirstDelegate(PrintNumber);
            firstDeleg += MultiplyNumber;
            firstDeleg += AddNumber;
            firstDeleg += (x) => Console.WriteLine(x * 4);
            firstDeleg += (x) => Console.WriteLine(x - 9);

            // Shortcuts to delegates 
            // action = public delegate void action();

            Action action = PrintHello;
            action.Invoke();

            Action<int> action2 = MultiplyNumber;
            // action2 = public delegate void action2(int x); 

            Action<int, bool, double, decimal, string> action3 = (x,y,z,t,r) => Console.WriteLine("hi");

            Func<decimal, decimal, int> func1 = CalculateNb;
            var xyz = func1.Invoke(Convert.ToDecimal(2.1), Convert.ToDecimal(2.2));  
            Console.WriteLine($"The result of the func is {xyz}");
            func1 += (a,b) => 8;

            // func1 =  public delegate int func1(decimal x, decimal y);

            //firstDeleg(nb1);

            //firstDeleg.Invoke(nb1);

            //firstDeleg(nb1);

            //var secondDeleg = new FirstDelegate(MultiplyNumber);
            //DelegateHandler(secondDeleg);
            //DelegateHandler(firstDeleg);

            GenericDegelateHandler(firstDeleg);
        }

        public static int CalculateNb(decimal x, decimal y)
        {
            return Convert.ToInt32(x * y);
        }

        public static void PrintHello()
        {
            Console.WriteLine("Hello from action!");
        }

        public static void PrintNumber(int nb)
        {
            Console.WriteLine($"The number is: {nb}" );
        }

        public static void MultiplyNumber(int nb)
        {
            nb *= 2;
            Console.WriteLine($"The multiplay number is: {nb}" );
        }

        public static void AddNumber(int nb)
        {
            nb += 200;
            Console.WriteLine($"The addition number is: {nb}" );
        }

        public static void DelegateHandler(FirstDelegate deleg)
        {
            deleg -= MultiplyNumber;
            deleg -= (x) => Console.WriteLine(x - 9);


            deleg?.Invoke(23);
        }

        public static void GenericDegelateHandler(Delegate deleg)
        {
            deleg.DynamicInvoke(50);
        }
    }
}
