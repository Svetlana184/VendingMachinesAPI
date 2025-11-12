using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace VendingMachinesAPI.Services
{
    public class CompanyService : IService<Company>
    {
        private readonly VendingMachinesContext context;
        public CompanyService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await context.Companies.ToListAsync();
        }

        public async Task<Company> GetById(int id_)
        {
            return await context.Companies.FindAsync(id_);
        }


        public async Task Create(Company product)

        {
            await context.Companies.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Companies.FindAsync(id);
            if (product != null)
            {
                context.Companies.Remove(product);
                await context.SaveChangesAsync();
            }
        }




        public async Task Update(Company product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
