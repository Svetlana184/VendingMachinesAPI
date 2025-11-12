using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
   
    public class MachineService : IService<Machine>
    {
        private readonly VendingMachinesContext context;
        public MachineService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Machine>> GetAll()
        {
            return await context.Machines.ToListAsync();
        }

        public async Task<Machine> GetById(int id_)
        {
            return await context.Machines.FindAsync(id_);
        }


        public async Task Create(Machine product)

        {
            await context.Machines.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Machines.FindAsync(id);
            if (product != null)
            {
                context.Machines.Remove(product);
                await context.SaveChangesAsync();
            }
        }




        public async Task Update(Machine product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
