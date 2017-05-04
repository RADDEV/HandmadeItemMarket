using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandmadeItemMarket.Models.ViewModels
{
    public class OrderVM
    {
        public DateTime OrderedOn { get; set; }
        [Required, MinLength(3)]
        public string ProductName { get; set; }
        [Required, MinLength(3)]
        public string FullAddress { get; set; }
        public string AditionalInfo { get; set; }
    }
}
