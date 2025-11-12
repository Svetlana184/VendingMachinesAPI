using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Services
{
   
    public class PaymentSystemService : IService<PaymentSystem>
    {
        private readonly VendingMachinesContext context;
        public PaymentSystemService(VendingMachinesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PaymentSystem>> GetAll()
        {
            return await context.PaymentSystems.ToListAsync();
        }

        public async Task<PaymentSystem> GetById(int id_)
        {
            return await context.PaymentSystems.FindAsync(id_);
        }


        public async Task Create(PaymentSystem product)

        {
            await context.PaymentSystems.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.PaymentSystems.FindAsync(id);
            if (product != null)
            {
                context.PaymentSystems.Remove(product);
                await context.SaveChangesAsync();
            }
        }




        public async Task Update(PaymentSystem product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
