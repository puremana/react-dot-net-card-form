#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentContext _context;

        public PaymentsController(PaymentContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(long id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // // PUT: api/Payments/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutPayment(long id, Payment payment)
        // {
        //     if (id != payment.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(payment).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!PaymentExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            // Custom Validation
            // Name no greater than 50 characters
            if (!(payment.Name.Length > 0 && payment.Name.Length <= 50)) {
                return BadRequest("Invalid name.");
            }

            // Card is only digits && is between 8 and 19 in length
            // if (!(payment.Card.All(char.IsDigit) && payment.Card.Length >= 8 && payment.Card.Length <= 19)) {
            //     return BadRequest("Invalid Card Number.");
            // }
            // CVC is only digit and 3 characters in length
            if (!(payment.CVC.All(char.IsDigit) && payment.CVC.Length == 3)) {
                return BadRequest("Invalid CVC.");
            }
            // Check expiry is in future
            DateTime today = DateTime.Now;
            if (!(DateTime.Compare(payment.Expiry, today) > 0)) {
                return BadRequest("Invalid expiry.");
            }

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
        }

        // // DELETE: api/Payments/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePayment(long id)
        // {
        //     var payment = await _context.Payments.FindAsync(id);
        //     if (payment == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Payments.Remove(payment);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool PaymentExists(long id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
