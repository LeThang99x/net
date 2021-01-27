using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static string RandomString(int n)
        {
            string s = "jksbkdnfjjnavjkasfbn13274";
            List<char> list = new List<char>(16);
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int index = random.Next(s.Length);
              //  Console.WriteLine(index);
              //  Console.WriteLine(s[index]);
                list.Add(s[index]);
            }
            return string.Join("", list);
        }
        static void Main(string[] args)
        {
            string filename = "bsdkgbs.jbg";
            Console.WriteLine(filename.Substring(filename.LastIndexOf('.')));
            Console.WriteLine(RandomString(32) + filename.Substring(filename.LastIndexOf('.')));
        }
    }
}
