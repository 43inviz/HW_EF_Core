using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HW_27_08_Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("path.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;


            //add single
            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var menu = new Menu
                {
                    Name = "Гороховый суп",
                    Weight = 1.2
                };

                db.Menus.Add(menu);
                db.SaveChanges();


            }






            //add range
            using (ApplicationContext db = new ApplicationContext(options))
            {


                var menu1 = new Menu
                {
                    Name = "Омлет",
                    Weight = 0.3
                };

                var menu2 = new Menu
                {
                    Name = "Торт",
                    Weight = 0.4

                };

                db.Menus.AddRange(new[] { menu1, menu2 });
                db.SaveChanges();
            }


            //get range
            using (ApplicationContext db = new ApplicationContext(options))
            {


                List<Menu> resList = db.Menus.ToList();

                foreach (var el in resList)
                {
                    Console.WriteLine(el);
                }
            }

            //get Soup
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var result = db.Menus.FirstOrDefault(e => e.Name.Contains("Суп"));
                Console.WriteLine(result);
            }


            //get by ID
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var result = db.Menus.FirstOrDefault(e => e.Id == 2);
                Console.WriteLine(result);
            }

            //get last
            using (ApplicationContext db = new ApplicationContext(options))
            {

                
                var result = db.Menus.OrderBy(e=>e.Id).LastOrDefault();
                Console.WriteLine(result);
            }
        }
    }
}
