using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
    public class ContractService : IService<Contract>
    {
        private readonly VendingMachinesContext context;
        public ContractService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Contract>> GetAll()
        {
            return await context.Contracts.ToListAsync();
        }

        public async Task<Contract> GetById(int id_)
        {
            return await context.Contracts.FindAsync(id_);
        }


        public async Task Create(Contract product)

        {
            await context.Contracts.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Contracts.FindAsync(id);
            if (product != null)
            {
                context.Contracts.Remove(product);
                await context.SaveChangesAsync();
            }
        }




        public async Task Update(Contract product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
