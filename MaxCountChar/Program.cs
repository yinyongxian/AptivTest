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
                Console.WriteLine($"出现次数最多的字符是{key}-次数{max}");
            }
        }
    }
}
