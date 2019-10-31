using Stateless;
using Stateless.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateMachine.Web.Models
{
    /// <summary>
    /// 订单管理类
    /// </summary>
    public class OrderManager
    {
        private readonly StateMachine<OrderState, OrderTrigger> orderStateMachine;

        public OrderManager(Order order)
        {
            //初始化状态机
            orderStateMachine = new StateMachine<OrderState, OrderTrigger>(() => order.OrderState, o => order.SetOrderState(o));
            ConfigureFlow();
        }

        private void ConfigureFlow()
        {
            //流程配置
            orderStateMachine.Configure(OrderState.OrderCreated)
                .Permit(OrderTrigger.Jump, OrderState.OrderPendingPay)
                .Permit(OrderTrigger.Cancel, OrderState.OrderInvalided);

            orderStateMachine.Configure(OrderState.OrderPendingPay)
                .Permit(OrderTrigger.Payment, OrderState.OrderPendingSend)
                .Permit(OrderTrigger.Cancel, OrderState.OrderInvalided);

            orderStateMachine.Configure(OrderState.OrderPendingSend)
                .Permit(OrderTrigger.Send, OrderState.OrderPendingSign)
                .Permit(OrderTrigger.Cancel, OrderState.OrderPendingRefund);

            orderStateMachine.Configure(OrderState.OrderPendingSign)
                .Permit(OrderTrigger.Sign, OrderState.OrderCompleted);

            orderStateMachine.Configure(OrderState.OrderPendingRefund)
                .Permit(OrderTrigger.Refund, OrderState.OrderInvalided);
        }

        public void TriggerOrderState(OrderTrigger orderTrigger)
        {
            orderStateMachine.Fire(orderTrigger);
        }

        /// <summary>
        /// 流程运行图
        /// </summary>
        /// <returns></returns>
        public string GetDotGraph()
        {
            return UmlDotGraph.Format(orderStateMachine.GetInfo());
        }
    }

    /// <summary>
    /// 针对订单的操作
    /// </summary>
    public enum OrderTrigger
    {
        /// <summary>
        /// 跳转
        /// </summary>
        Jump,

        /// <summary>
        /// 取消
        /// </summary>
        Cancel,

        /// <summary>
        /// 支付
        /// </summary>
        Payment,

        /// <summary>
        /// 配送
        /// </summary>
        Send,

        /// <summary>
        /// 签订
        /// </summary>
        Sign,

        /// <summary>
        /// 退款
        /// </summary>
        Refund,
    }
}
