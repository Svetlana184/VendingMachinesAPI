using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
    public class ProductInMachineService : IService<ProductInMachine>
    {
        private readonly VendingMachinesContext context;
        public ProductInMachineService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductInMachine>> GetAll()
        {
            return await context.ProductInMachines.ToListAsync();
        }

        public async Task<ProductInMachine> GetById(int id_)
        {
            return await context.ProductInMachines.FindAsync(id_);
        }

        public async Task Create(ProductInMachine product)
        {
            await context.ProductInMachines.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.ProductInMachines.FindAsync(id);
            if (product != null)
            {
                context.ProductInMachines.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(ProductInMachine product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
