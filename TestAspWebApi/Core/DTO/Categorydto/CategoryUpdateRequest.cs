using Core.DTO.Categorydto;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using Core.DTO.Productdto;


namespace Core.DTO.Categorydto
{
    public class CategoryUpdateRequest
    {
        public string CatgegoryName { get; set; } = string.Empty;
        public IEnumerable<ProductDTO>? Products { get; set; }
    }

}


