namespace LinkedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);


            int pop = stack.Pop();
        }
    }
}
