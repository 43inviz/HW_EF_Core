using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_27_08_1_
{
    internal class RequestManager
    {

        public DbContextOptions<ApplicationContext> GetConectionOptions() 
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("path.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionsBuilder.UseSqlServer(connectionString).Options;
            
        }

        public void AddData() {
            using (ApplicationContext db = new ApplicationContext(GetConectionOptions()))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                List<Trains> trains = new List<Trains> {
                new Trains
                {
                    
                    WagonCount = 20,
                    EmployeeCount = 25,
                    BossSurname = "Petrov",
                    Milleage = 12353.12,
                    TrainType = "high speed "
                },

                new Trains
                {
                  
                    WagonCount = 15,
                    EmployeeCount = 20,
                    BossSurname = "Ivanov",
                    Milleage = 99898.8,
                    TrainType = "electric"


                }
            };

                db.Trains.AddRange(trains);
                db.SaveChanges();
            }
        }


        public List<Trains> GetTrains()
        {
            using (ApplicationContext db = new ApplicationContext(GetConectionOptions()))
            {
                return db.Trains.ToList();
            }

        }

        public  Trains GetTrainById(int id)
        {
            try
            {

                using (ApplicationContext db = new ApplicationContext(GetConectionOptions()))
                {
                    return db.Trains.FirstOrDefault(t => t.id == id);
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void  AddTrain(Trains train)
        {
            using (ApplicationContext db = new ApplicationContext(GetConectionOptions()))
            {
                db.Add(train);
                db.SaveChanges();
            }
        }

        public void DeleteTrainById(int id)
        {
            using (ApplicationContext db = new ApplicationContext(GetConectionOptions()))
            {
                db.Trains.Remove(GetTrainById(id));
                db.SaveChanges();
            }
        }


        public void UpdateTrain(Trains train)
        {
            using (ApplicationContext db = new ApplicationContext(GetConectionOptions()))
            {
                db.Trains.Update(train);
                db.SaveChanges();
            }
        }
    }
}
