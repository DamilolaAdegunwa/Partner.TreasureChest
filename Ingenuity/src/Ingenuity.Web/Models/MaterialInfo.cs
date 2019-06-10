using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class MaterialInfo
    {
        /// <summary>
        /// ��ʶ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// ԭ��������
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// ʹ������
        /// </summary>
        public int UseCount { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// ���״̬
        /// </summary>
        public int CompleteStatus { get; set; }

        [NotMapped]
        public string T_CompleteStatus
        {
            get
            {
                return Enum.GetName(typeof(CompleteStatusEnum), CompleteStatus);
            }
        }

        [NotMapped]
        public string OrderName { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }

    public enum CompleteStatusEnum : int
    {
        ���ӹ� = 0,
        ���ӹ� = 1,
        �ӹ���� = 2
    }
}