using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
    public class UserService : IService<User>
    {
        private readonly VendingMachinesContext context;
        public UserService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id_)
        {
            return await context.Users.FindAsync(id_);
        }

        public async Task Create(User product)
        {
            await context.Users.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Users.FindAsync(id);
            if (product != null)
            {
                context.Users.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(User product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
