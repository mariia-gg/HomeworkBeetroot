namespace homework6
{
    internal class Homework6
    {
       public static void ComparingMethod(string sentence1, string sentence2)
        {
            for(int i = 0; i< sentence1.Length; i++  )
            {
                  if (sentence1 == sentence2)
                    {
                        Console.WriteLine("Sentences equal ");
                      
                    }
                    else
                    {
                        Console.WriteLine("Sentences aren't equal ");
                      
                    }
                
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sentenses: ");
            string sentence1 = Console.ReadLine();
            string sentence2 = Console.ReadLine();
            // Console.WriteLine(sentence1);
            //Console.WriteLine(sentence2);
            ComparingMethod(sentence1, sentence2);
        }
    }
}