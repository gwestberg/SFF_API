using Microsoft.EntityFrameworkCore;
using SFF_API.Models;

namespace SFF_API.Context
{
    public class RentalServiceContext: DbContext
    {
        public RentalServiceContext(DbContextOptions<RentalServiceContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Trivia> Trivias { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        //Exempel på om man vill ändra på ex. entiteter, föredras framför konventioner och Data-annonations
        //Sådana här kommandon görs före man migrerar för att funktionaliteten ska komma med, annars behöver man ändra
        //och det gör man enklast genom att ta bort migrationsfoldern
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //När man skriver en review måste man ange en "grade"
            modelBuilder.Entity<Review>().Property(r => r.Grade).IsRequired();
            //När man lägger till en film måste man ha en titel, titeln måste vara unik för att undvika dubletter
            //och man måste ange om filmen är digital eller inte
            modelBuilder.Entity<Movie>().Property(m => m.Title).IsRequired();
            modelBuilder.Entity<Movie>().HasIndex(m => m.Title).IsUnique();
            modelBuilder.Entity<Movie>().Property(m => m.IsDigital).IsRequired();
            //Studions namn krävs
            modelBuilder.Entity<Studio>().Property(s => s.Name).IsRequired();
            //Id:et till filmen måste finnas
            modelBuilder.Entity<Trivia>().Property(s => s.MovieId).IsRequired();
            //Kombinationen studioid och movie id måste vara unikt,
            //detta för att förhindra att en studio lånar fler av varje film.
            modelBuilder.Entity<Rental>().HasIndex(m => new { m.MovieId, m.StudioId }).IsUnique();

        }
    }
}
