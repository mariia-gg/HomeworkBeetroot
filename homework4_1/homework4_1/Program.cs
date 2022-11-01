namespace homework4_1_methods_
{
    /////  HOMEWORK4_1
    internal class HOMEWORK4_1
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


    

}
