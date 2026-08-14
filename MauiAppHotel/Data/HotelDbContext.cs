using Microsoft.EntityFrameworkCore;
using MauiAppHotel.Models;

namespace MauiAppHotel.Data;

public class HotelDbContext : DbContext
{
    public DbSet<Hospedagem> Hospedagens { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        string caminhoBanco = Path.Combine(
            FileSystem.AppDataDirectory,
            "MauiAppHotel.db3");

        optionsBuilder.UseSqlite(
            $"Filename={caminhoBanco}");
    }
}