using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxCountChar
{
    class Program
    {
        static void Main(string[] args)
        {
            const string str = @"jintiantianqihaoqinglang";
            DictionaryMethod(str);
            LinqMethod(str);

            Console.ReadKey();
        }

        private static void DictionaryMethod(string str)
        {
            var charArray = str.ToCharArray();
            var dictionary = new Dictionary<char, int>();
            foreach (var c in charArray)
            {
                dictionary[c] = dictionary.Keys.Contains(c) ? ++dictionary[c] : 1;
            }

            var max = dictionary.Values.Max();
            var keys = dictionary.Keys.Where(key => dictionary[key] == max);
            foreach (var key in keys)
            {
                Console.WriteLine($"出现次数最多的字符：{key} ~ 出现次数：{max}");
            }
        }

        private static void LinqMethod(string str)
        {
            var query =
                 (from c in str.ToCharArray()
                  group c by c into g
                  select new { g.Key, Count = g.Count() })
                 .ToList();
            var max = query.Max(item => item.Count);
            var gs = query.Where(g => g.Count == max);
            foreach (var g in gs)
            {
                Console.WriteLine($"出现次数最多的字符：{g.Key} ~ 出现次数：{max}");
            }
        }
    }
}
