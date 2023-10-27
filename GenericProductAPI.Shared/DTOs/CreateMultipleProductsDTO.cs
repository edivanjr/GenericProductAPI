using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProductAPI.Shared.DTOs
{
    public class CreateMultipleProductsDTO
    {
        public List<CreateProductDTO> Products { get; set; }
    }
}
