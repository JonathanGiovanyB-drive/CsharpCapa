using Bogus;
using Capacitacion.Domain.Categories;
using Capacitacion.Domain.Products;
using Capacitacion.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Api.Extensions;

public static class DataSeed
{
    public static async Task SeedCapacitacionProducto(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<CapacitacionDbContext>();
            if (!context.Set<Category>().Any())
            {
                var categoryComputadoras = Category.Create("Computadora");
                var categoryTelefono = Category.Create("TELEFONO");
                context.AddRange(new List<Category> { categoryComputadoras, categoryTelefono });
                await context.SaveChangesAsync();
            }
            if (!context.Set<Product>().Any())
            {
                var computadora = await context.Set<Category>().Where(x => x.Name == "COMPUTADORA").FirstOrDefaultAsync();
                var telefono = await context.Set<Category>().Where(x => x.Name == "TELEFONO").FirstOrDefaultAsync();

                var faker = new Faker();
                List<Product> products = new();
                var defaultValue = 10000;
                for (var i = 1; i <= 10; i++)
                {
                    products.Add(
                        Product.Create(
                            faker.Commerce.Product(),
                            100.00m,
                            faker.Commerce.ProductDescription(),
                            $"img_{i}.jpg",
                            faker.Hashids.Encode(defaultValue, i * 1000),
                            i > 5 ? computadora!.Id : telefono!.Id
                        )
                    );
                }
                context.AddRange(products);
                await context.SaveChangesAsync();

            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<CapacitacionDbContext>();
            logger.LogError(ex.Message);
        }

    }
}