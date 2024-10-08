using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(
                orderId => orderId.Value,
                dbId => OrderId.Of(dbId));
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired();
            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);
            builder.ComplexProperty(
                o => o.OrderName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
                });
            builder.ComplexProperty(
                o => o.ShippingAddress, addresBuilder =>
                {
                    addresBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.EmailAddres)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                    addresBuilder.Property(a => a.Country)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.State)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
                });
            builder.ComplexProperty(
                o => o.BillingAddress, addresBuilder =>
                {
                    addresBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.EmailAddres)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                    addresBuilder.Property(a => a.Country)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.State)
                    .HasMaxLength(50)
                    .IsRequired();

                    addresBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
                });
            builder.ComplexProperty(
                o => o.Payment, paymentBuilder =>
                {
                    paymentBuilder.Property(a => a.CardNumber)
                    .HasMaxLength(50)
                    .IsRequired();

                    paymentBuilder.Property(a => a.CardName)
                    .HasMaxLength(24)
                    .IsRequired();

                    paymentBuilder.Property(a => a.Expiration)
                    .HasMaxLength(10)
                    .IsRequired();

                    paymentBuilder.Property(a => a.CVV)
                    .HasMaxLength(3)
                    .IsRequired();

                    paymentBuilder.Property(a => a.PaymentMethod);
                });
            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(
                    s => s.ToString(),
                    dbStasus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStasus));
        }
    }
}
