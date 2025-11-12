using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI.Models

{
    public class SeedData
    {
        public static void SeedDatabase(VendingMachinesContext context)
        {
            context.Database.Migrate();
            if (context.Users.Count() == 0)
            {
                User user_start = new User()
                {
                    Surname = "start",
                    FirstName = "user",
                    Role = "admin",
                    Login = "start_user",
                    Password = "1234"
                };
                context.Users.Add(user_start);
                context.SaveChanges();
            }
        }
    }
    

}
