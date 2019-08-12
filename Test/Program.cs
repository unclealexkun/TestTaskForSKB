using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Classes;

namespace Test
{
    class Program
    {
        public struct Words
        {
            public string Word { get; set; }
            public int Frequency { get; set; }
        }
        static void Main(string[] args)
        {
            //var trie = new ConcurrentTrie<int>();
            var trie = new Trie<int>();

            var numberWords = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).First();
            var reference = new Words[numberWords];

            for (int i = 0; i < numberWords; i++)
            {
                var readLine = Console.ReadLine();
                var word = readLine.Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries).First();
                var frequency =
                    int.Parse(
                        readLine.Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries).Last());
                trie.Add(word, i);
                reference[i].Word = word;
                reference[i].Frequency = frequency;
            }

            var numberInput = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).First();

            var inputWords = new List<string>();
            for (int i = 0; i < numberInput; i++)
            {
                inputWords.Add(Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).First());
            }

            var inputWordArray = inputWords.ToArray();
            for (int i = 0; i < inputWordArray.Length; i++)
            {
                var result = trie.Retrieve(inputWordArray[i]).Take(10).ToArray();

                var dictionary = result.ToDictionary(r => reference[r].Word, r => reference[r].Frequency).OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).ToArray();

                if (i != 0) Console.WriteLine();
                for (int j = 0; j < dictionary.Length; j++)
                {
                    if (((j + 1) == result.Length) && ((i + 1) == inputWordArray.Length)) Console.Write(dictionary[j].Key);
                    else Console.WriteLine(dictionary[j].Key);
                }
            }
        }
    } 
}
