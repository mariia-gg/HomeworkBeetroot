using System;
using System.Collections;

namespace Mystack
{
    internal class Program
    {
    static void Main(string[] args)
    {
          CreatingStack();
          Console.WriteLine();
          ArrayCreating(); 
    }

    public static void CreatingStack()
    {
         Stack<int> myStack = new Stack<int>();

         myStack.Push(1);   
         myStack.Push(2);
         myStack.Push(3);  
         myStack.Push(4);  
         myStack.Push(5);      

         Console.WriteLine("The initial stack: ");    
         foreach (var number in myStack)
         {
             Console.Write(number + ",");
         }   

         Console.WriteLine();
            
         Console.WriteLine("Peek in the stack:{0} ", myStack.Peek());

         Console.WriteLine("Pop in the stack:{0} ", myStack.Pop());

         foreach(var number in myStack)
         {
             Console.Write(number + ",");
         }

         Console.WriteLine();
         Console.WriteLine("Number of elements: "); 
         Console.WriteLine(myStack.Count);

         myStack.Clear();
        }

        public static void ArrayCreating()
        {
            Stack myStack1 = new Stack();

            myStack1.Push("Lazy cat, ");

            Array mySuperPuperArray = Array.CreateInstance(typeof(string), 15);

            mySuperPuperArray.SetValue("", 0);
            mySuperPuperArray.SetValue("have", 1);
            mySuperPuperArray.SetValue("a", 2);
            mySuperPuperArray.SetValue("nice", 3);
            mySuperPuperArray.SetValue("day", 4);

            Console.WriteLine("My super puper Array:");

            PrintValues(mySuperPuperArray, ' ');

            Console.WriteLine();
            Console.WriteLine("Adding  CopyToArray");

            myStack1.CopyTo(mySuperPuperArray, 0);

            PrintValues(mySuperPuperArray, ' ');
        }

        public static void PrintValues(Array myArr, char mySeparator)
        {
            foreach (Object myObj in myArr)
            {
                Console.Write("{0}{1}", mySeparator, myObj);
            }
            Console.WriteLine();
        }

    }
}