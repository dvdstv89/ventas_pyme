using Microsoft.EntityFrameworkCore;
using ventasPymes.api.Model.Productos;

namespace ventasPymes.api.Data
{
    internal static  class ApplicationDbContextSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new ApplicationDbContext(
            //    serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            //{
               // if (context.Drones.Any() || context.Medications.Any())
               // {
               //     return;
               // }

               // context.Drones.AddRange(
               //     new Drone { SerialNumber = "DRN001", Model = DroneModel.Lightweight, WeightLimit = 100, BatteryCapacity = 80, State = DroneState.IDLE },
               //     new Drone { SerialNumber = "DRN002", Model = DroneModel.Lightweight, WeightLimit = 175, BatteryCapacity = 70, State = DroneState.LOADED },                   
               // );

               // context.Medications.AddRange(
               //     new Medication { Code = "MED001", Name = "MedicationA", Weight = 80, Image = new byte[] { 255, 255, 255, 255 } },
               //     new Medication { Code = "MED002", Name = "MedicationB", Weight = 60, Image = new byte[] { 255, 255, 255, 255 } },                   
               // );

               // context.DroneMedication.AddRange(
               //     new DroneMedication { DroneSerialNumber = "DRN002", MedicationCode = "MED001", Count = 1 },
               //     new DroneMedication { DroneSerialNumber = "DRN002", MedicationCode = "MED002", Count = 1 }
               //);

            //    context.SaveChanges();
            //}
        }
    }
}
