using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options) { }

        //(instalacja narzedzia 1/2)        dotnet new tool-manifest
        //(instalacja narzedzia 2/2)        dotnet tool install dotnet-ef --version 5.0.17
        //(tworzenie migracji)              dotnet ef migrations add Init --output-dir "Data/Migrations"
        //(tworzenie pliku bazy danych))    dotnet ef database update

    }
}
