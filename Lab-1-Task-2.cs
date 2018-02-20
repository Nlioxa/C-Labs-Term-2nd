using System;
using System.Collections;
using System.Linq;

namespace newTest
{ 
    class Program
    { 
        static void EnterArray(out string[][] array)
        {
            Console.Write("First dimension size >>> ");
            int rowsNum = Int32.Parse(Console.ReadLine());
            Console.Write("Second dimension max size >>> ");
            int colsNum = Int32.Parse(Console.ReadLine());
            array = new string[rowsNum][];
            for(int i = 0; i < rowsNum; i++)
            {
                Console.Write("{0}:\t", i + 1);
                string[] buff = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                array[i] = buff.Take(colsNum).ToArray();                
            }
        }

        static void ShowArray(string[][] array)
        {
            int rowsNum = array.GetLength(0);
            for(int i = 0; i < rowsNum; i++)
            {
                Console.Write("{0}:\t", i + 1);
                foreach(var el in array[i])
                {
                    Console.Write("{0}\t", el);
                }
                Console.WriteLine();
            }
        }

        static ArrayList ToOneDimension(string[][] array)
        {
            ArrayList temp = new ArrayList();
            foreach (var el in array)
            {
                foreach (var subEl in el)
                {
                    temp.Add(subEl);
                }
            }
            return temp;
        }
        
        static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }

        static void Main()
        {
            string[][] array;
            //EnterArray(out array);
            //ShowArray(array);

            char key = Console.ReadKey(true).KeyChar;
            switch(key)
            {
                case '1':
                    EnterArray(out array);
                    int rank = array.Length;
                    if (rank > 1) rank = 2;
                    int length = 0;
                    foreach(var el in array)
                    {
                        length += el.Length;
                    }
                    Console.WriteLine("RANK >>> {0}\nLENGHT >>> {1}", rank, length);
                    ShowArray(array);
                    break;
                case '2':
                    EnterArray(out array);
                    var clone = (string[][])array.Clone();
                    ShowArray(clone);
                    break;
                case '3':
                    EnterArray(out array);
                    var buff = ToOneDimension(array);
                    buff.Sort();
                    PrintValues(buff);
                    break;
                case '4':
                    EnterArray(out array);
                    buff = ToOneDimension(array);
                    int sum = 0;
                    foreach(var el in buff)
                    {
                        sum += Int32.Parse(el.ToString());
                    }
                    Console.WriteLine("Sum: {0}", sum);
                    break;
                case '5':
                    EnterArray(out array);
                    buff = ToOneDimension(array);
                    buff.Sort();
                    PrintValues(buff);
                    Console.Write("El to insert: ");
                    string element = Console.ReadLine();
                    int index = buff.BinarySearch(element);
                    buff.Insert(- 1 - index, element);
                    PrintValues(buff);
                    break;
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
