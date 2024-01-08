using Microsoft.EntityFrameworkCore;

namespace WebAppMerck.DataAccess.Data.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}
