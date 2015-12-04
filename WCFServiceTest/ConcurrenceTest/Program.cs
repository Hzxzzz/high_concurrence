using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConcurrenceTest
{  
    /*
     *  并发进程
     */
    class Program
    {
        static void Main(string[] args)
        {
            const string baseurl = "http://localhost:16937/Test/TestBehavior?Id=";
            var client = new HttpClient();
            string[] testPhone = new string[5000];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(testPhone, (data, state, index) =>
            {
                client.GetAsync(baseurl + 5);
                client.GetAsync(baseurl + 6);
                client.GetAsync(baseurl + 7);
                client.GetAsync(baseurl + 8);
                client.GetAsync(baseurl + 9);
                Console.WriteLine(string.Format("{0} done", index));
            });
            sw.Stop();
            Console.WriteLine(string.Format("总计用时{0}毫秒", sw.ElapsedMilliseconds));
            Console.ReadKey();
        }
    }
}
