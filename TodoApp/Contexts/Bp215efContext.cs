using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Contexts;

public partial class Bp215efContext : DbContext
{
    public Bp215efContext()
    {
    }

    public Bp215efContext(DbContextOptions<Bp215efContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BP215EF;Trusted_Connection=True;TrustServerCertificate=True");
        optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information).EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
