namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }
            session.Store<Product>(GetPreConfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sumsong A14",
                Description = "Description A14",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "Sumsong A14.jpg",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sumsong N70",
                Description = "Description N70",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "Sumsong N70.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sumsong N71",
                Description = "Description N71",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "Sumsong N71.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sumsong F102",
                Description = "Description F102",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "Sumsong F102.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "OPPO 7A",
                Description = "Description OPPO 7A",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "OPPO 7A.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "iPhone 13",
                Description = "Description iPhone 13",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "iPhone 13.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "iPhone 14 Pro",
                Description = "Description iPhone 14 Pro",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "iPhone 14 Pro.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "OPPO Y370",
                Description = "Description OPPO Y370",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "OPPO Y370.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sumsong S12",
                Description = "Description Sumsong S12",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "Sumsong S12.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "MicroMax M1",
                Description = "Description MicroMax M1",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "MicroMax M1.png",
                Price = 100
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "MicroMax M2",
                Description = "Description MicroMax M2",
                Category = new List<string> { "Smart Phone" },
                ImageFile = "MicroMax M2.png",
                Price = 100
            }
        };
    }
}
