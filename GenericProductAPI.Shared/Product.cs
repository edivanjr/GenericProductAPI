using GenericProductAPI.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProductAPI.Shared
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductDescription { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fabrication Date")]
        [Required(ErrorMessage = "Fabrication Date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FabricationDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Valid Date")]
        [Required(ErrorMessage = "Valid Date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateNotInPast(ErrorMessage = "Valid Date must be in the future.")]
        [DateNotGreaterThan("FabricationDate", ErrorMessage = "Valid Date must be after Fabrication Date.")]
        public DateTime ValidDate { get; set; }
        public long SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public long SupplierCNPJ { get; set; }
    }
}
