using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
    public class SaleService : IService<Sale>
    {
        private readonly VendingMachinesContext context;
        public SaleService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Sale>> GetAll()
        {
            return await context.Sales.ToListAsync();
        }

        public async Task<Sale> GetById(int id_)
        {
            return await context.Sales.FindAsync(id_);
        }

        public async Task Create(Sale product)
        {
            await context.Sales.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Sales.FindAsync(id);
            if (product != null)
            {
                context.Sales.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Sale product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
