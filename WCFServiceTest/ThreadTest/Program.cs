using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KDIT.QPAL.Models;
using ThreadTest.ServiceReference;

namespace ThreadTest
{
    /*
     *  守护进程
     */
    class Program
    {
        private static readonly ServiceClient s = new ServiceClient();

        static void Main(string[] args)
        {

            var db = new WebDatabase();
            var comm = db.Commodities.ToList();
            var i = 1;
            while (true)
            {
                try
                {
                    var obj = getList();
                    var j = 0;
                    foreach (var data in obj)
                    {
                        var c = comm.FirstOrDefault(x => x.Id == data.CommodityId);
                        db.OrderForms.Add(new Store_OrderForm
                        {
                            CustomerId = data.CustomerId,
                            Code = data.GUID,
                            OrderDate = data.DoTime,
                            Details = new List<Store_OrderFormDetail>()
                            {
                                new Store_OrderFormDetail
                                {
                                    Amount = 1,
                                    CommodityId = data.CommodityId,
                                    //////可以无视
                                    Name = c.Name,
                                    BegTime = c.BegTime,
                                    Category = c.Category,
                                    Content = c.Content,
                                    CreateTime = DateTime.Now,
                                    EndTime = c.EndTime,
                                    ModifyTime = DateTime.Now,
                                    PictureUrl = c.Picture,
                                    Point = c.Point,
                                    Price = c.Price,
                                    Property = c.Property,
                                    OrginalPrice = c.OrginalPrice
                                }
                            },
                            //////可以无视
                            CreateTime = DateTime.Now,
                            IsDeal = false,
                            ModifyTime = DateTime.Now,
                            DealCodeUrl = "",

                        });

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
