using System.Collections.Generic;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service.svc.cs，然后开始调试。
    public class Service : IService
    {
        public void Lister()
        {

        }
        public bool OrderFormBehavior(int customerId, int commodityId)
        {
            return StaticOrderForm.OrderFormBehavior(customerId, commodityId);
        }

        public bool ChangeOrderFormState(string guid)
        {
            return StaticOrderForm.ChangeOrderFormState(guid);
        }

        public List<OrderFormModel> GetOrderFormList()
        {
            return StaticOrderForm.GetOrderFormList();
        }

        public bool StokInit()
        {
            try
            {
                StaticCommodity.Init();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<CommodityModel> GetCommodity()
        {
            return StaticCommodity.GetCommodity();
        }
    }
}
