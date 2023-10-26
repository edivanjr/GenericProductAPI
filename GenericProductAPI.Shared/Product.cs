using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProductAPI.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductDescription { get; set; }
        public string IsActive { get; set; }
        public DateTime FabricationDate { get; set; }
        public DateTime ValidDate { get; set; }
        public long SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public long SupplierCNPJ { get; set; }
    }
}
