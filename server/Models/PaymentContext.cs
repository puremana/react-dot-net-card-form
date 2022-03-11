using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace server.Models
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; } = null!;
    }
}