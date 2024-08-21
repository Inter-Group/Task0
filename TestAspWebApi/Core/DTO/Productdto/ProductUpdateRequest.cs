using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Productdto
{
    public class ProductUpdateRequest
    {
        public string ProductName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
