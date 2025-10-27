using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace VendingMachinesAPI.Services
{
    public class MachineService : IService<Machine>
    {
        private readonly VendingMachinesContext machinesContext;
        public MachineService(VendingMachinesContext context)
        {
            this.machinesContext = context;
        }

        public async Task<IEnumerable<Machine>> GetAll()
        {
            return await machinesContext.Machines.ToListAsync();
        }

        public async Task<Machine> GetById(int id_)
        {
            return await machinesContext.Machines.FindAsync(id_);
        }


        public async Task Create(Machine product)

        {
            await machinesContext.Machines.AddAsync(product);
            await machinesContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await machinesContext.Machines.FindAsync(id);
            if (product != null)
            {
                machinesContext.Machines.Remove(product);
                await machinesContext.SaveChangesAsync();
            }
        }

        public async Task Update(Machine product)
        {
            machinesContext.Entry(product).State = EntityState.Modified;
            machinesContext.Update(product);
            await machinesContext.SaveChangesAsync();
        }

    }
}
