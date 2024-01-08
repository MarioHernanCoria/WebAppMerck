using Microsoft.EntityFrameworkCore;
using WebAppMerck.Modelos.Models.Entities;

namespace WebAppMerck.DataAccess.Data.DatabaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Usuario>().HasData(
            //        new
            //        {
            //            Id = "1",
            //            Email = "admin@admin.com",
            //            Clave = "admin",
            //            AccessFailedCount = 0,
            //            EmailConfirmed = true,
            //            LockoutEnabled = false,
            //            PhoneNumberConfirmed = true,
            //            TwoFactorEnabled = false,
            //        },
            //    new
            //    {
            //        Id = "2",
            //        Email = "usuario@gmail.com",
            //        Clave = "usuario",
            //        AccessFailedCount = 0,
            //        EmailConfirmed = true,
            //        LockoutEnabled = false,
            //        PhoneNumberConfirmed = true,
            //        TwoFactorEnabled = false,
            //    });
        }
    }
}
