using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Delegate
{
    class Program
    {
        delegate string removestr(string data);

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
            
            Console.WriteLine("Введите текст:\n");
            string text = Console.ReadLine();
            Console.WriteLine("Предложение с заменой ' ' - > '-':");
            string data = method1(text);
            Console.WriteLine(data);
            data = method1(data);
            Console.WriteLine("Предложение с заменой '-' - > ' ':");
            Console.WriteLine(data);
            //Console.WriteLine();
            Console.ReadKey();
        
        }
    }
}
