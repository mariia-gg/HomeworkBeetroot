using System.Text;
namespace homework6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string 1: ");
            string string1 = Console.ReadLine();

            Console.WriteLine("Enter string 1: ");
            string string2 = Console.ReadLine();

            Console.WriteLine(Compare(string1, string2));

            Console.WriteLine("Homework 2 ");

            Console.WriteLine("Enter string");
            string str = Console.ReadLine();
            AnalyzeSring(str);

            Console.WriteLine("Homework 3 ");
            Console.WriteLine("Enter string");
            string str1 = Console.ReadLine(); 
            SortMethod(str1);

            Console.WriteLine("Homework 4 ");
            Console.WriteLine("Enter string");
            string str2 = Console.ReadLine();

            var duplicateArray = Duplicate(str2);
            foreach (char i in duplicateArray)
            {
                Console.Write($"{i}");
            }
        }
        //HM1
        static bool Compare(string string1, string string2)
        {
            bool result = string1 == string2;
            return result;
        }
        //HM2
        static void AnalyzeSring(string str)
        {
            StringBuilder alphabetic = new StringBuilder();
            StringBuilder numeric = new StringBuilder();
            StringBuilder symbols = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                    numeric.Append(str[i]);
                else if ((str[i] >= 'A' &&
                         str[i] <= 'Z') ||
                         (str[i] >= 'a' &&
                          str[i] <= 'z'))
                    alphabetic.Append(str[i]);
                else
                    symbols.Append(str[i]);
            }

            Console.WriteLine($"Alphabetic {alphabetic} =  {alphabetic.Length} ");
            Console.WriteLine($"Numeric {numeric} = {numeric.Length}");
            Console.WriteLine($"Symbols {symbols} = {symbols.Length}");
        }
        //HM3 
        static void SortMethod(string str1)
        {
            char[] chars = str1.ToLower().ToCharArray();
            Array.Sort(chars);

            Console.WriteLine(chars);     
        }
 
        //HM4
        static char[] Duplicate(string  str2)
        {
            char[] charArray = str2.ToLower().ToCharArray();
            string duplicates = " ";
            for (int i = 0; i < charArray.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < charArray.Length; j++)
                {
                    if (charArray[i] == charArray[j])
                    {
                        count++;
                        if (count >= 2)
                        {
                            if (!Char.IsWhiteSpace(charArray[j]) && !duplicates.Contains(charArray[i]))
                            {
                                duplicates += charArray[j].ToString();
                            }
                        }
                    }
                }
            }
            char[] duplicateArray = duplicates.ToCharArray();
            return duplicateArray;
        }
    }
}

