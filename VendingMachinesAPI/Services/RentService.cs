using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
    public class RentService : IService<Rent>
    {
        private readonly VendingMachinesContext context;
        public RentService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await context.Rents.ToListAsync();
        }

        public async Task<Rent> GetById(int id_)
        {
            return await context.Rents.FindAsync(id_);
        }

        public async Task Create(Rent product)
        {
            await context.Rents.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Rents.FindAsync(id);
            if (product != null)
            {
                context.Rents.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Rent product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
