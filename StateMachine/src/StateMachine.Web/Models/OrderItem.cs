using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StateMachine.Web.Models
{
    /// <summary>
    /// 订单项
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 订单项名称
        /// </summary>
        public string OrderItemName { get; set; }

        /// <summary>
        /// 订单项价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 订单项状态
        /// </summary>
        public OrderItemState OrderItemState { get; private set; }

        /// <summary>
        /// 初始订单项状态
        /// </summary>
        public void InitOrderItemState()
        {
            OrderItemState = OrderItemState.OrderItemCreated;
        }

        /// <summary>
        /// 设置订单项状态
        /// </summary>
        /// <param name="orderItemState"></param>
        public void SetOrderItemState(OrderItemState orderItemState)
        {
            OrderItemState = orderItemState;
        }
    }

    /// <summary>
    /// 订单项状态
    /// </summary>
    public enum OrderItemState
    {
        [Description("无效")]
        OrderItemInvalided = 0,

        [Description("已创建")]
        OrderItemCreated = 3,

        [Description("待支付")]
        OrderItemPendingPay = 6,

        [Description("待配送")]
        OrderItemPendingSend = 9,

        [Description("待收货")]
        OrderItemPendingSign = 12,

        [Description("待退款")]
        OrderItemPendingRefund = 15,

        [Description("已完成")]
        OrderItemCompleted = 18,
    }
}
