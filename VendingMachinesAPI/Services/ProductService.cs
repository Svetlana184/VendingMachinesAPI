using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
  
    public class ProductService : IService<Product>
    {
        private readonly VendingMachinesContext context;
        public ProductService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id_)
        {
            return await context.Products.FindAsync(id_);
        }


        public async Task Create(Product product)

        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }




        public async Task Update(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
