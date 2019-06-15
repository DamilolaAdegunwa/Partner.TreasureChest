using KnockoutJS.Core;
using KnockoutJS.Core.Books;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.ViewModels
{
    [Serializable]
    public class CartItemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cartId")]
        public int CartId { get; set; }

        [JsonProperty(PropertyName = "bookId")]
        public int BookId { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        [Display(Name = "数量")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity must be greate than 0")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "book")]
        public virtual BookViewModel Book { get; set; }
    }
}
