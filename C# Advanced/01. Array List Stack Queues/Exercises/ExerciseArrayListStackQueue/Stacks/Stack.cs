using System;
using System.Collections.Generic;

namespace Stacks
{
    public class Stack
    {
        public static void Main(string[] args)
        {
            //count - returns the number of elements in the collection
            Stack<int> myFirstStack = new Stack<int>();

            myFirstStack.Push(4);
            myFirstStack.Push(5);
            myFirstStack.Push(6);

            myFirstStack.Pop();
            myFirstStack.Pop();

            //checking the value of the last element but does not remove it 
            myFirstStack.Peek();

            foreach (var i in myFirstStack)
            {
                Console.WriteLine(i);
            }

            myFirstStack.ToArray();
        }
    }
}