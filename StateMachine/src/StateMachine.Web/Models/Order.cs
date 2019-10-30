using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StateMachine.Web.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        public Order(long orderId, string orderName, string orderNo, double price)
        {
            OrderId = orderId;
            OrderName = orderName;
            OrderNo = orderNo;
            Price = price;
            CreateDate = DateTime.Now;
            InitOrderState();
        }

        /// <summary>
        /// 订单Id
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 订单名称
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 订单价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState OrderState { get; private set; }

        /// <summary>
        /// 初始订单状态
        /// </summary>
        public void InitOrderState()
        {
            OrderState = OrderState.OrderCreated;
        }

        /// <summary>
        /// 设置订单状态
        /// </summary>
        /// <param name="orderState"></param>
        public void SetOrderState(OrderState orderState)
        {
            OrderState = orderState;
        }
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderState
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        OrderInvalided = 0,

        /// <summary>
        /// 已创建
        /// </summary>
        [Description("已创建")]
        OrderCreated = 3,

        /// <summary>
        /// 待支付
        /// </summary>
        [Description("待支付")]
        OrderPendingPay = 6,

        /// <summary>
        /// 待配送
        /// </summary>
        [Description("待配送")]
        OrderPendingSend = 9,

        /// <summary>
        /// 待收货
        /// </summary>
        [Description("待收货")]
        OrderPendingSign = 12,

        /// <summary>
        /// 待退款
        /// </summary>
        [Description("待退款")]
        OrderPendingRefund = 15,

        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        OrderCompleted = 18,
    }
}
