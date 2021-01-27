using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class Helper
    {
        public static string RandomString(int n)
        {
            string s = "jksbkdnfjjnavjkasfbn13274";
            List<char> list = new List<char>(n);
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
    }
}
