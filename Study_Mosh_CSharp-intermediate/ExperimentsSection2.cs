using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_intermediate
{
    internal class ExperimentsSection2
    {
        public static void Start()
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine(Calculator.Add(1, 5));
            Console.WriteLine(Calculator.Add(0, 4, 2, 6, 7, 3));
            Console.WriteLine(Calculator.Add(1));
            Console.WriteLine(Calculator.Add());

            var person = new Person()
            {
                FirstName = "Test",
                LastName = "Test",
                Id = 1,
            };

            Console.WriteLine(person.Id + ": " + person.FirstName + " " + person.LastName);
        }

        class Calculator
        {
            public static int Add(params int[] values)
            {
                int sum = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    sum += values[i];
                }

                return sum;
            }
        }

        class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }


            public float Salary { get; set; }

        }
    }
}
