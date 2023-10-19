using Assignment_gauthami.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_gauthami.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppDbContext : ControllerBase
    {

        private static List<Customer> customers = new List<Customer>();

        public IEnumerable<object> Orders { get; internal set; }

        [HttpPost("/createCustomer")]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer customer)
        {
            customer.UserId = Guid.NewGuid();
            customers.Add(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.UserId }, customer);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return Ok(customers);
        }

        [HttpPost("updateCustomer/{id}")]
        public ActionResult<Customer> UpdateCustomer(Guid id, [FromBody] Customer updatedCustomer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.UserId == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Username = updatedCustomer.Username;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.LastName = updatedCustomer.LastName;
            existingCustomer.IsActive = updatedCustomer.IsActive;

            return Ok(existingCustomer);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCustomer(Guid id)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.UserId == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            customers.Remove(existingCustomer);
            return NoContent();
        }

        [HttpGet("{id}/active-orders")]
        public ActionResult<IEnumerable<Order>> GetActiveOrdersByCustomer(Guid id)
        {

            var orders = new List<Order>
         {
             new Order { OrderId = Guid.NewGuid(), OrderStatus = OrderStatus.Active, CustomerId = id },
             new Order { OrderId = Guid.NewGuid(), OrderStatus = OrderStatus.Active, CustomerId = id },
             new Order { OrderId = Guid.NewGuid(), OrderStatus = OrderStatus.Inactive, CustomerId = id }
         };

            var activeOrders = orders.Where(o => o.OrderStatus == OrderStatus.Active).ToList();
            return Ok(activeOrders);
        }

        internal IDisposable CreateConnection()
        {
            throw new NotImplementedException();
        }
    }






}

