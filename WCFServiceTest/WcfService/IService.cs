using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService”。
    /// <summary>
    /// 对外公用接口
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IService
    {
        /// <summary>
        /// 用于IPC使用的监听方法
        /// </summary>
        [OperationContract]
        void Lister();
        /// <summary>
        /// 彺内存订单列表内添加订单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool OrderFormBehavior(int customerId, int commodityId);
        /// <summary>
        /// 改变当前内存订单的状态
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [OperationContract]
        bool ChangeOrderFormState(string guid);
        /// <summary>
        /// 获取当前所有商品及库存
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommodityModel> GetCommodity();
        /// <summary>
        /// 获取所有没操作过的订单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<OrderFormModel> GetOrderFormList();
        /// <summary>
        /// 所有商品库存强行初始化，预留功能
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool StokInit();
    }

    /// <summary>
    /// 单例订单模型
    /// </summary>
    public static class StaticOrderForm
    {
        private static List<OrderFormModel> List;
        /// <summary>
        /// 初始化
        /// </summary>
        static StaticOrderForm()
        {
            List = new List<OrderFormModel>();
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <returns></returns>
        public static bool OrderFormBehavior(int customerId, int commodityId)
        {
            // 简单判断内存库存是否充足
            if (StaticCommodity.GetStok(commodityId) <= 0)
            {
                // 滚粗
                return false;
            }
            // 虚拟库存充足情况下减少
            StaticCommodity.ChangeStok(commodityId);
            // 将该订单插入缓存列表
            lock (List)
            {
                List.Add(new OrderFormModel
                {
                    GUID = Guid.NewGuid().ToString(),
                    CustomerId = customerId,
                    CommodityId = commodityId,
                    DoTime = DateTime.Now,
                    IsExecute = false
                });
            }
            // 返回
            return true;
        }
        /// <summary>
        /// 改变当前内存订单的状态
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static bool ChangeOrderFormState(string guid)
        {
            try
            {
                lock (List)
                {
                    List.FirstOrDefault(x => x.GUID == guid).IsExecute = true;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 获取所有没操作过的订单
        /// </summary>
        /// <returns></returns>
        public static List<OrderFormModel> GetOrderFormList()
        {
            lock (List)
            {
                return List.Where(x => !x.IsExecute).ToList();
            }
        }
    }
    /// <summary>
    /// 单例商品库存模型
    /// </summary>
    public static class StaticCommodity
    {
        private static List<CommodityModel> List;
        static StaticCommodity()
        {
            List = new List<CommodityModel>();
            Init();
        }
        /// <summary>
        /// 初始化商品与商品库存
        /// </summary>
        public static void Init()
        {
            using (var x = DBHelper.ExecuteReader("SELECT * FROM Store_Commodity"))
            {
                while (x.Read())
                {
                    lock (List)
                    {
                        List.Add(new CommodityModel
                        {
                            CommodityId = Convert.ToInt32(x["Id"]),
                            Stok = Convert.ToInt32(x["Stok"])
                        });
                    }
                }
            }
        }
        /// <summary>
        /// 获取当前所有库存
        /// </summary>
        /// <returns></returns>
        public static List<CommodityModel> GetCommodity()
        {
            return List;
        }
        /// <summary>
        /// 根据商品编号获取当前库存
        /// </summary>
        /// <param name="commodityId"></param>
        /// <returns></returns>
        public static int GetStok(int commodityId)
        {
            var obj = List.FirstOrDefault(x => x.CommodityId == commodityId);
            return obj != null ? obj.Stok : 0;
        }
        /// <summary>
        /// 锁定并减少当前商品库存
        /// </summary>
        /// <param name="commodityId"></param>
        public static void ChangeStok(int commodityId)
        {
            lock (List)
            {
                List.FirstOrDefault(x => x.CommodityId == commodityId).Stok =
                    List.FirstOrDefault(x => x.CommodityId == commodityId).Stok - 1;
            }
        }
    }

    /// <summary>
    /// 订单模型
    /// </summary>
    public class OrderFormModel
    {
        // 唯一编号
        public string GUID { get; set; }
        // 当前用户编号
        public int CustomerId { get; set; }
        // 当前商品编号
        public int CommodityId { get; set; }
        // 是否被操作
        public bool IsExecute { get; set; }
        // 抢购时间
        public DateTime DoTime { get; set; }
    }
    /// <summary>
    /// 库存模型
    /// </summary>
    public class CommodityModel
    {
        // 当前商品编号
        public int CommodityId { get; set; }
        // 当前库存
        public int Stok { get; set; }

    }
}
