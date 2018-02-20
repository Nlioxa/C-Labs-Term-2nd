using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_1_Task_3
{
    class Program
    {
        static void PrintValues(IEnumerable collection)
        {
            IEnumerator enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.Write(" {0}", enumerator.Current);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int ArrSize = 10;

            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            switch(pressedKey)
            {
                case ConsoleKey.D1:
                    Random rand = new Random();
                    ArrayList newList = new ArrayList();
                    for (int j = 0; j < ArrSize; j++)
                    {
                        newList.Add(rand.Next() % 100);
                    }
                    PrintValues(newList);
                    break;
                case ConsoleKey.D2:
                    SortedList sortedList = new SortedList();
                    sortedList.Add("first", "Mark");
                    sortedList.Add("second", "Steven");
                    var indexValue = sortedList.GetByIndex(0);
                    Console.WriteLine("\tindex\tkey\telement\n\t{0}\t{1}\t{2}", 0, sortedList.GetKey(0), sortedList.GetByIndex(0));
                    break;
                case ConsoleKey.D3:
                    Stack stack = new Stack(3);
                    stack.Push("first");
                    stack.Push("second");
                    stack.Push("third");
                    PrintValues(stack);
                    Console.WriteLine(stack.Peek());
                    break;
                case ConsoleKey.D4:
                    Dictionary<string, int> digitalDictionary =
                        new Dictionary<string, int>();
                    digitalDictionary.Add("1", 1);
                    digitalDictionary.Add("2", 2);
                    digitalDictionary.Add("3", 3);
                    digitalDictionary["0"] = 0;

                    Console.Write("Enter key value: >>> ");
                    int value;
                    string key = Console.ReadLine();
                    if (digitalDictionary.TryGetValue(key, out value))
                    {
                        Console.WriteLine("Key: {0}\tValue: {1}", key, value);
                    }
                    else
                    {
                        Console.WriteLine("Key - {0} - doesn't exist");
                    }
                    break;
                case ConsoleKey.D5:
                    //enter a sentence
                    string sentence = Console.ReadLine();
                    //split the sentence up into words
                    string[] words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //count the number of words
                    int wordsCount = words.Length;
                    Console.WriteLine("Words count: >>> {0}", wordsCount);
                    //find the longest word in the sentence
                    string longestWord = "";
                    foreach(var el in words)
                    {
                        //if current word is longer than the longest
                        //assign it to the longest
                        if (el.Length > longestWord.Length)
                        {
                            longestWord = el;
                        }
                    }
                    Console.WriteLine("The longest word: >>> {0}", longestWord);
                    //insert blank spaces into the longest word
                    int i = 0;
                    List<char> buff = new List<char>();
                    foreach(var el in longestWord)
                    {                        
                        //copy the next symbol into the buff List container
                        buff.Add(longestWord[i]);
                        //if the 'i' position is paired
                        //insert two blank spaces into the word
                        if ((i + 1) % 2 == 0 && i < longestWord.Length - 1)
                        {
                            buff.Add('_');
                            buff.Add('_');
                        }
                        i++;
                    }
                    string extendedWord = string.Concat(buff);
                    //output edited word to console
                    Console.WriteLine("Edited word: {0}", extendedWord);
                    break;
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
