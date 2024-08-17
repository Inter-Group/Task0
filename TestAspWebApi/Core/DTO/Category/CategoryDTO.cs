using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Category
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CatgegoryName { get; set; } = string.Empty;
        public IEnumerable<Product> Products { get; set; }
    }
}
