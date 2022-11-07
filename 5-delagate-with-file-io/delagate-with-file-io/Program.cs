using System;
using System.Reflection.Metadata;

namespace Delegate
{
    delegate void FileIO(string path);

    class Program
    {
        public static void WriteToFile(string path)
        {
            Console.WriteLine("Enter a msg: ");
            string msg = Console.ReadLine();
                StreamWriter sw=new StreamWriter(path);
                sw.WriteLine(msg);
                sw.Close();
                Console.WriteLine("--- Data Added to File ---");
        }
        public static void ReadFromFile( string path)
        {
            try
            {
                StreamReader sr = File.OpenText(path);
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }
            catch
            {
                Console.WriteLine("File Not Found");
            }
        }
        static void Main(string[] args)
        {
            string path = @"A:\MBM\message.txt";
            Console.WriteLine("\n\nEnter your option\n 1: Write to file\n " +
                "2 : Read From File\n 3 : Quit");
            int c = Convert.ToInt32(Console.ReadLine());

            switch (c)
            {
                case 1:
                    FileIO f1 = new FileIO(WriteToFile);
                    f1(path);
                    Console.ReadKey();
                    break;
                case 2:
                    FileIO f2 = new FileIO(ReadFromFile);
            
                    f2(path);
                    Console.ReadKey();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}