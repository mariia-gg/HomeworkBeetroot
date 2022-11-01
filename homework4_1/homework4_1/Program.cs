namespace homework4_1_methods_
{
    /////  HOMEWORK4_1
    /*internal class HOMEWORK4_1
    {
        public static int GetMaxValue(int FirstParameter, int SecondParameter)
        {
            if (FirstParameter > SecondParameter)
            {
                Console.WriteLine($"The First Parameter greater = {FirstParameter}");
                return FirstParameter;
            }
            if (SecondParameter > FirstParameter)
            {
                Console.WriteLine($"The Second Parameter greater = {SecondParameter}");
                return SecondParameter;
            }
            else
            {
                throw new Exception("The parameters are identical");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter value for first parameter:\t");
            int FirstParameter = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter value for second parameter:\t");
            int SecondParameter = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMaxValue(FirstParameter, SecondParameter));
        }
    }
        ///////// HOMEWORK4_2////////// 
        internal class Homework4_2
        {
            public static int GetMaxValue(int FirstParameter, int SecondParameter)
            {
                if (FirstParameter < SecondParameter)
                {
                    Console.WriteLine($"The First Parameter lower than Second Parameter  = {SecondParameter}");
                    return FirstParameter;
                }
                if (SecondParameter < FirstParameter)
                {
                    Console.WriteLine($"The Second Parameter lower than First Parameter = {FirstParameter}");
                    return SecondParameter;
                }
                else
                {
                    throw new Exception("The parameters are identical");
                }
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Enter value for first parameter:\t");
                int FirstParameter = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter value for second parameter:\t");
                int SecondParameter = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMaxValue(FirstParameter, SecondParameter));

                Console.ReadKey(); 
            }
        }
    */
    /////////HOMEWORK4_3////////
    internal class Homework4_3
    {
        static bool TrySumIfOdd(int x, int y)
        {
            int sum = x + y;
            if ((sum % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter y");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("Result: " + TrySumIfOdd(x, y));
        }
    }
    //////  HOMEWORK4_4 //// 
    public class OverloadMethod
    {
        public int Method1(int param1, int param2, int param3)
        {
            return param1 + param2 + param3;
        }

        public string Method1(string param1, string param2, string param3, string param4)
        {
            return param1 + param2 + param3 + param4;
        }

        static void Main(string[] args)
        {
            var overload = new OverloadMethod();
            var res1 = overload.Method1(56, 34, 76);
            var res2 = overload.Method1("Have ", "a ", "nice", " day! ");
            Console.WriteLine(res1.ToString());
            Console.WriteLine(res2.ToString());

        }
    }


}
