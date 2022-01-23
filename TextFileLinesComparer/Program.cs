using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextFileLinesComparer
{
    class Program
    {
        static List<string> list1 = new List<string>();
        static List<string> list2 = new List<string>();

        static List<string> onlyList1 = new List<string>();
        static List<string> onlyList2 = new List<string>();
        static List<string> bothLists = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Text File Lines Comparer!\n\n");
          
            Console.WriteLine("Path to list 1: ");
            string path1 = Console.ReadLine();
            StreamReader sr1 = new StreamReader(path1);
            while (!sr1.EndOfStream)
            {
                list1.Add(sr1.ReadLine());
            }
            sr1.Close();

            Console.WriteLine("Path to list 2: ");
            string path2 = Console.ReadLine();
            StreamReader sr2 = new StreamReader(path2);
            while (!sr2.EndOfStream)
            {
                list2.Add(sr2.ReadLine());
            }
            sr2.Close();

            while (list1.Count > 0)
            {
                string item = list1[0];
                int index = list2.IndexOf(item);
                if (index > -1)
                {
                    list1.RemoveAt(0);
                    list2.RemoveAt(index);
                    bothLists.Add(item);
                }
                else
                {
                    list1.RemoveAt(0);
                    onlyList1.Add(item);
                }
            }

            while (list2.Count > 1)
            {
                string item = list2[0];
                int index = list1.IndexOf(item);
                if (index > -1)
                {
                    list2.RemoveAt(0);
                    list1.RemoveAt(index);
                    bothLists.Add(item);
                }
                else
                {
                    list2.RemoveAt(0);
                    onlyList2.Add(item);
                }
            }

            StreamWriter sw1 = new StreamWriter("only1.txt");
            foreach (var item in onlyList1)
            {
                sw1.WriteLine(item);
            }
            sw1.Close();

            StreamWriter sw2 = new StreamWriter("only2.txt");
            foreach (var item in onlyList2)
            {
                sw2.WriteLine(item);
            }
            sw2.Close();

            StreamWriter swb = new StreamWriter("both.txt");
            foreach (var item in bothLists)
            {
                swb.WriteLine(item);
            }
            swb.Close();

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
