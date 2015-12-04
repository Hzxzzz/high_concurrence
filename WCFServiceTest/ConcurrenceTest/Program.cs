using System;
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
            var _dt1 = DateTime.Now;
            Parallel.ForEach(testPhone, (data, state, index) =>
            {
                client.GetAsync(baseurl + 5);
                client.GetAsync(baseurl + 6);
                client.GetAsync(baseurl + 7);
                client.GetAsync(baseurl + 8);
                client.GetAsync(baseurl + 9);
                Console.WriteLine(string.Format("{0} done", index));
            });

            var _dt2 = DateTime.Now;
            Console.WriteLine((TimeSpan)(_dt2 - _dt1));
            Console.ReadKey();
        }
    }
}
