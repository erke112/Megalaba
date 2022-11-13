using System.IO.MemoryMappedFiles;
using System.Reflection.PortableExecutable;

namespace Megalaba_Console
{
    internal class Program
    {
        static Type com1 = Type.GetTypeFromProgID("Megalaba_COM.ComClass1");
        static dynamic com1Instance = Activator.CreateInstance(com1);

        //static MemoryMappedFile memory;
        static void Main(string[] args)
        {
            while (true)
            {
                while (true)
                {
                    if (com1Instance.IsReady())
                    {
                        Console.WriteLine("Ready!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not ready!");
                    }
                    Thread.Sleep(1000);
                }
                Console.WriteLine("\tMake your choise\n1. Rock  2. Paper  3. Scissors");
                int choise;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out choise))
                    {
                        if (choise > 0 && choise < 4)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong choise!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong choise!");
                    }
                }
                if (choise == 1)
                {
                    com1Instance.SendData(0x11);
                }
                else if (choise == 2)
                {
                    com1Instance.SendData(0x12);
                }
                else if (choise == 3)
                {
                    com1Instance.SendData(0x13);
                }
                bool[] flag;
                while (true)
                {
                    flag = com1Instance.IsChoisesMade();
                    if (flag[0] == false) { Console.WriteLine("Waiting for second player..."); Thread.Sleep(2000); }
                    else
                    {
                        if (flag[2] == true) { Console.WriteLine("Draw!"); break; }
                        else
                            if (flag[1] == true) { Console.WriteLine("You win!"); break; }
                        else
                                if (flag[1] == false) { Console.WriteLine("You lose!"); break; }
                        else Console.WriteLine("Error!");
                    }
                }
            }

        }
    }
}