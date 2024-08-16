using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CatgegoryName { get; set; } = string.Empty;
        public IEnumerable<Product> Product { get; set; } = new List<Product>() { };
    }
}
