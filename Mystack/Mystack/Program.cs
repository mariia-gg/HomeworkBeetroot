using System;
using System.Collections;

namespace Mystack
{
    internal class Program
    {
    static void Main(string[] args)
    {
        CreatingStack(); 
    }

    public static void CreatingStack()
    {       
        Stack<int> myStack = new Stack<int>();
        
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);
        myStack.Push(5);
     
        foreach(var number in myStack)
        {
             Console.Write(number + ",");
        }
        }

    }
}