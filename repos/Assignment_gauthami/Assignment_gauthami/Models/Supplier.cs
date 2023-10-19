using System.ComponentModel.DataAnnotations;

namespace Assignment_gauthami.Models
{
    public class Supplier
    {
        [Key]
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
