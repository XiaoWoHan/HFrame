using HCommon.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisHelper.Insert("KKK", "1234");
            var aaa = RedisHelper.Get("123");
            var aaab = RedisHelper.Get("KKK");
            Console.WriteLine(aaa);
            Console.WriteLine(aaab);
            Console.ReadLine();
        }
    }
}
