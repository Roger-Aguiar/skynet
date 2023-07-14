namespace Skynet2.Skynet.Shared
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL("server=localhost;database=identity_appointments;user=root;password=983453069");
    }
}
