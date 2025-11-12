using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
    public class ServiceService : IService<Service>
    {
        private readonly VendingMachinesContext context;
        public ServiceService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await context.Services.ToListAsync();
        }

        public async Task<Service> GetById(int id_)
        {
            return await context.Services.FindAsync(id_);
        }

        public async Task Create(Service product)
        {
            await context.Services.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Services.FindAsync(id);
            if (product != null)
            {
                context.Services.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Service product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
