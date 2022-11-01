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

        }
    }
}