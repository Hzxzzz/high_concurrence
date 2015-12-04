using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using KDIT.QPAL.Models;
using TestThread.ServiceReference1;

/*
 *  守护进程
 */
namespace TestThread
{

    class Program
    {
        private static readonly ServiceClient s = new ServiceClient();

        static void Main(string[] args)
        {

            var db = new WebDatabase();
            var i = 1;
            while (true)
            {
                try
                {
                    var obj = getList();
                    var j = 0;
                    foreach (var data in obj)
                    {
                        db.EventHistory.Add(new Event_History
                        {
                            CustomerId = data.CustomerId,
                            IP = data.CommodityId.ToString(),
                            //////已下可以无视
                            CreateTime = DateTime.Now,
                            EventId = 1,
                            ModifyTime = DateTime.Now
                        });
                        var l = db.EventLotteries.FirstOrDefault(x => x.Id == data.CommodityId);
                        l.DayCount = l.DayCount - 1;
                        setList(data.GUID);
                        j++;
                        //Console.WriteLine(data.GUID + ",当前用户秒杀是否成功：" + data.succeed);
                    }
                    db.SaveChanges();

                    Console.WriteLine(string.Format("当前共处理了：{0}次", j));
                    Console.WriteLine(string.Format("本次操作为第{0}次", i));
                    Thread.Sleep(500);
                    i++;
                }
                catch
                {
                    continue;
                }

            }

        }

        public static List<OrderFormModel> getList()
        {
            return s.GetOrderFormList().ToList();
        }
        public static void setList(string guid)
        {
            s.ChangeOrderFormState(guid);
        }
    }
}
