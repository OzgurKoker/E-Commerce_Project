using ETicaretApp.DAL;
using ETicaretApp.Entities;


namespace Proje.Models
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ETicaretAppContext>();
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            RegisterDate = DateTime.Now,
                            Email = "admin@gmail.com",
                            Password = "123456",
                            Role = "Admin",
                            State = true
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
