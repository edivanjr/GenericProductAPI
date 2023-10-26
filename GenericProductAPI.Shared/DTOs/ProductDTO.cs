using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProductAPI.Shared.DTOs
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string ProductDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime FabricationDate { get; set; }
        public DateTime ValidDate { get; set; }
        public long SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public long SupplierCNPJ { get; set; }
    }
}
