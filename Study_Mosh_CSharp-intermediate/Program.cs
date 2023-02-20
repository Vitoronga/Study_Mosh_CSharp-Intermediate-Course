using System.Xml;

namespace Study_Mosh_CSharp_intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine("\nPrograms available:" +
                                "\n1. Sec2_Ex1.Start()" +
                                "\n2. Sec2_Ex2.Start()" +
                                "\n3. Sec4_Ex1.Start()" +
                                "\n4. Sec5_Ex1to2.Start()" +
                                "\n5. Sec6_Ex1.Start()" +
                                "\n10. ExperimentsSection2.Start()" +
                                "\n11. ExperimentsSection4.Start()" +

                                "\n\nType the desired program number:"
                                );
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Sec2_Ex1.Start();
                        break;

                    case "2":
                        Sec2_Ex2.Start();
                        break;

                    case "3":
                        Sec4_Ex1.Start();
                        break;

                    case "4":
                        Sec5_Ex1to2.Start();
                        break;

                    case "5":
                        Sec6_Ex1.Start();
                        break;

                    case "10":
                        ExperimentsSection2.Start();
                        break;

                    case "11":
                        ExperimentsSection4.Start();
                        break;

                    default:
                        return;
                }
            }
        }
    }
}