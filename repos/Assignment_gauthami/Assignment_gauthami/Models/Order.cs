using System.ComponentModel.DataAnnotations;

namespace Assignment_gauthami.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Guid OrderBy { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public bool IsActive { get; set; }
        public Guid CustomerId { get; internal set; }
    }

    public enum OrderStatus
    {
        Active = 1,
        Inactive = 2
    }



}
