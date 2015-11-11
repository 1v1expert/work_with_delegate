using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.IO;

namespace Delegate
{
    class Program
    {
        delegate string removestr(string data);
        
        static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        static string probl(string text)
        {
        File.WriteAllText(@"text.txt", text);


            Console.WriteLine();
           using (StreamReader r = File.OpenText(@"text.txt"))
           {
                    using (StreamWriter w = File.CreateText(@"move.txt"))
                    {
                        char c;
                        Console.WriteLine();
                        while (!r.EndOfStream)
                        {
                            c = (char)r.Read();
                            if (c == ' ') w.Write('-');
                            else
                                if (c == '-') w.Write(' ');
                                else
                                w.Write(c);
                        }

                        w.Close();
                       return text = File.ReadAllText(@"move.txt");
                    }
                    r.Close();
            }
           File.Delete(@"text.txt");
           File.Delete(@"move.txt");

        }

        static void Main(string[] args)
        {
            removestr method1 = new removestr(probl);
        link1:
            Gray();
                Console.WriteLine("Введите текст:\n");
                Red();
                string text = Console.ReadLine();
                if (text == "") 
                {
                    Console.WriteLine("Вы не вели текст !!\n");
                    goto link1;
                }
                else
                {
                    Gray();
                    Console.WriteLine();
                    Console.WriteLine("Предложение с заменой ' ' - > '-':");
                    string data = method1(text);
                    Green();
                    Console.WriteLine(data);
                    data = method1(data);
                    Gray();
                    Console.WriteLine("Предложение с заменой '-' - > ' ':");
                    Red();
                    Console.WriteLine();
                    Console.WriteLine(data);
                    Console.ReadKey();
                }
        
        }
    }
}
