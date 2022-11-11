namespace homework4_1_methods_
{
    /////  HOMEWORK4_1
    public static class HOMEWORK4_1
    {
        static void Main(string[] args)
        { ////Homework 1 
            Console.WriteLine("Homework 1 : ");
            Console.WriteLine("Enter value for first parameter:\t");
            int FirstParameter = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value for second parameter:\t");
            int SecondParameter = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMaxValue(FirstParameter, SecondParameter));
            ///Homework 2 
            Console.WriteLine("Homework 2 : ");
            Console.WriteLine("Enter value for first parameter:\t");
            int FirstParam = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value for second parameter:\t");
            int SecondParam = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMinValue(FirstParam, SecondParam));
            ///Homework 3 
            Console.WriteLine("Homework 3 : ");
            int sum;
            Console.WriteLine("Enter x an y :  "); 
            int x = int.Parse(Console.ReadLine()); 
            int y = int.Parse(Console.ReadLine()); 

            bool result = TrySumIfOdd(x, y, out sum);
            Console.WriteLine(result);
            Console.WriteLine(sum);
            Console.ReadKey();
            ///Homework 4 extra task
            Console.WriteLine("Homework 4 : ");
            var overload = new Homework4.Overload();
            var res1 = overload.Method1(56, 34, 76);
            var res2 = overload.Method1("Have ", "a ", "nice", " day! ");
            Console.WriteLine(res1.ToString());
            Console.WriteLine(res2.ToString());
            /// Homework 5 extra task
            Console.WriteLine("Homework 5: ");
            Console.WriteLine("Enter word");
            string ret = Console.ReadLine();
            Console.WriteLine("Enter count of words");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(Repeat(ret, count));
        }
/// H1
        public static int GetMaxValue(int FirsParam, int SecondParam)
        {
             
            if (FirsParam < SecondParam)
            {
                Console.WriteLine($"The First Parameter lower than Second Parameter  = {SecondParam}");
                return SecondParam;
            }
            if (SecondParam < FirsParam)
            {
                Console.WriteLine($"The Second Parameter lower than First Parameter = {FirsParam}");
                return FirsParam;
            }
            else 
            {
                throw new Exception("The parameters are identical");
            }
        }
/// H2
        public static int GetMinValue(int FirstParam, int SecondParam)
        {
            if (FirstParam < SecondParam)
            {
                Console.WriteLine($"The First Parameter lower than Second Parameter  = {SecondParam}");
                return FirstParam;
            }
            if (SecondParam < FirstParam)
            {
                Console.WriteLine($"The Second Parameter lower than First Parameter = {FirstParam}");
                return SecondParam;
            }
            else
            {
                throw new Exception("The parameters are identical");
            }
        }
/// H3
        public static bool TrySumIfOdd(int x, int y, out int sum)
        {
            sum = x + y;
            if ((sum % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
///H4
            static int Method1(int param1, int param2, int param3)
            {
                return param1 + param2 + param3;
            }

            public static string Method2(string param1, string param2, string param3, string param4)
            {
                return param1 + param2 + param3 + param4;
            }
///H4
        public static string Repeat(this string str, int count)
        {
                string ret = Console.ReadLine();
                for (var x = 0; x < count; x++)
                {
                    ret += str;
                }

                return ret;
        }   
    } 
} 
 
    
    