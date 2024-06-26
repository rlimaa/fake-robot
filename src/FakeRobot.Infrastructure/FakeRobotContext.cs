﻿using FakeRobot.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FakeRobot.Infrastructure;

public class FakeRobotContext : DbContext
{
    public FakeRobotContext(DbContextOptions<FakeRobotContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Executions>()
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();

    }

    public DbSet<Executions> RobotCommandRecords { get; set; }
}