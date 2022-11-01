namespace Homework3_1_Conditional_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///// HOMEWORK3_1///////
            /* Console.WriteLine("Enter x ");
             int x = int.Parse(Console.ReadLine());
             Console.WriteLine("Enter y");
            int y = int.Parse(Console.ReadLine()); */
         
            const int x = 1;
            const int y = 4;
            Console.WriteLine($"X={x}\nY={y}");
            Console.WriteLine();

            int sum = 0;

            for (int i = x; i <= y; i++)
            {
                sum = sum + i;
            }
            if (x == y)
            {
                sum = x;
            }
            Console.WriteLine($"Sum={sum}");

            //// HOMEWORK3_2 //// 
         
              Console.WriteLine("Enter num1 value");
              int num1 = int.Parse(Console.ReadLine()); 

              Console.WriteLine("Enter num2  value");
              int num2 = int.Parse(Console.ReadLine());

              bool PlanA = num1 >= num2;
              bool PlanB = num1 <= num2;
              for (int i =num1; i <= num1; i ++ )

              {
                  if (PlanA)
                  {
                      Console.WriteLine($"x > y\n{num1}>{num2}");
                      continue; 
                  }
                  else if (!PlanA)
                  {
                      Console.WriteLine($"x < y\n{num1}<{num2}");
                      Console.WriteLine("Invalid input");
                      break;
                  }

              }
          
            ///Or in another way also homework 3_2///
            Console.WriteLine("Please write your impressions of the film ");
            string impression1 = Console.ReadLine();
            string impression2 = Console.ReadLine();
            while (true)
            {
                if (impression2 == "bad")
                {
                    Console.WriteLine("Invalid imput");
                    break;
                }

            }
        }
    }
}