using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_intermediate
{
    internal class Sec4_Ex1
    {
        public static void Start()
        {
            StackClass stack = new StackClass();
            stack.Push(1);
            stack.Push(100);
            Console.WriteLine(stack.Pop());
            stack.Push(4242);
            stack.Push("Hello");
            stack.Push("World!");
            stack.Push('a');
            Console.WriteLine(stack.Pop());
            stack.Push(54.123f);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            stack.Push(true);
            stack.Push(0);
            Console.WriteLine(stack.Pop());

            Console.WriteLine("Remaining values:");
            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }
    }

    internal class StackClass
    {
        private ArrayList stackList = new ArrayList();
        public int Count { get { return stackList.Count; } }

        public void Push(object value)
        {
            if (value == null) throw new InvalidOperationException();

            stackList.Add(value);
        }

        public object Pop()
        {
            if (Count == 0) throw new InvalidOperationException();

            int index = stackList.Count - 1;
            object value = stackList[index];
            stackList.RemoveAt(index);
            return value;
        }

        public void Clear()
        {
            stackList.Clear();
        }
    }
}
