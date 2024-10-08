namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("58cc4949-eec6-4de2-86e7-033c546291aa")),"Ahsan","ahsan@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("58cc4949-eec6-4de2-86e7-033c546291ab")),"Ahmad","ahmad@gmail.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("78736c0c-b9a2-4b69-8075-8b0b62d9c8a7")),"Sumsong S12",100),
                Product.Create(ProductId.Of(new Guid("0191dc0b-50c7-4b67-8a1b-8b1c6551d851")),"Sumsong F12",700),
                Product.Create(ProductId.Of(new Guid("6eaa68ca-6f49-42ad-bb20-b160ea60cc82")),"Sumsong F102",100),
                Product.Create(ProductId.Of(new Guid("0191dc08-0b01-4d69-a825-c9310d5b349a")),"Sumsong F13",700)
            };

        public static IEnumerable<Order> OrderandItems
        {
            get
            {
                var address1 = Address.Of("Ahsan", "Ullah", "ahsan@gmail.com", "Road 1", "Bangladesh", "Khulna", "9000");
                var address2 = Address.Of("Ahmad", "Ullah", "ahmad@gmail.com", "Road 1", "Bangladesh", "Khulna", "9000");

                var payment1 = Payment.Of("Ahsan", "5555555555555555", "12/28", "123", 1);
                var payment2 = Payment.Of("Ahmad", "4444444444444444", "11/29", "234", 2);

                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("58cc4949-eec6-4de2-86e7-033c546291aa")),
                    OrderName.Of("Ord_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1
                    );
                order1.Add(ProductId.Of(new Guid("78736c0c-b9a2-4b69-8075-8b0b62d9c8a7")),2, 100);
                order1.Add(ProductId.Of(new Guid("0191dc0b-50c7-4b67-8a1b-8b1c6551d851")), 1, 700);

                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("58cc4949-eec6-4de2-86e7-033c546291ab")),
                    OrderName.Of("Ord_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2
                    );
                order2.Add(ProductId.Of(new Guid("6eaa68ca-6f49-42ad-bb20-b160ea60cc82")), 2, 100);
                order2.Add(ProductId.Of(new Guid("0191dc08-0b01-4d69-a825-c9310d5b349a")), 1, 700);

                return new List<Order> { order1, order2 };
            }
        }
    }
}
