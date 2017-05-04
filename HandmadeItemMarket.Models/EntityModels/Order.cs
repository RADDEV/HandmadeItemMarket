using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandmadeItemMarket.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public ApplicationUser Seller { get; set; }
        public ApplicationUser Buyer { get; set; }
        public DateTime OrderedOn { get; set; }
        [Required]
        public string FullAddress { get; set; }
        public string AditionalInfo { get; set; }
    }
}
