using Core.DTO.Categorydto;
using Core.Models;
﻿using Core.DTO.Productdto;


namespace Core.DTO.Categorydto
{
    public class CategoryUpdateRequest
    {
        public string CatgegoryName { get; set; } = string.Empty;
        public IEnumerable<ProductDTO>? Products { get; set; }
    }

}


