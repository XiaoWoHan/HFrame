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
            CacheHelper.Current.Add("123","KKK");
            var aaa= CacheHelper.Current.Get("123");
            Console.WriteLine(aaa);

            CacheHelper.Current.Add("1233", "KKK1");
            var bbb = CacheHelper.Current.Get("1233");
            Console.WriteLine(bbb);

            RedisHelper.Current.Add("123", "KKK");
            var aaa1 = RedisHelper.Current.Get("123");
            Console.WriteLine(aaa1);

            RedisHelper.Current.Add("1233", "KKK1");
            var bbb1 = RedisHelper.Current.Get("1233");
            Console.WriteLine(bbb1);
            Console.ReadLine();
        }
    }
}
