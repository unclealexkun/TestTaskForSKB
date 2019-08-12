using System;
using System.Collections.Generic;
using System.Linq;

namespace OlimpicGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            if (line != null)
            {
                int number = line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).First();
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    int[] stones = readLine.Split(new []{' ','\t','\n','\r'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    var groupA = new List<int>();
                    var groupB = new List<int>();

                    for (int i = 0; i < number; i++)
                    {
                        int max = stones.Max();
                
                        if (groupA.Sum() >= groupB.Sum()) groupB.Add(max);
                        else groupA.Add(max);

                        int[] temp = stones.Where(x => x < max).ToArray();
                        stones = temp;
                    }

                    Console.Write(Math.Abs(groupA.Sum()-groupB.Sum()));
                    //TODO: Проблемы с удалением дублирующего элемента, а так же переработать алгоритм для 6 элементов 1 4 5 6 7 9 даёт не 0, а 2 
                }
            }
        }
    }
}
