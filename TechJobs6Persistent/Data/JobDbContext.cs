﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.Controllers;

namespace TechJobs6Persistent.Data
{
	public class JobDbContext : DbContext
	{
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Employer>? Employers { get; set; }
        public DbSet<Skill>? Skills { get; set; }

        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //connecting job and employer (one to many)

            modelBuilder.Entity<Job>()
                .HasOne(p => p.Employer)
                .WithMany(b => b.Jobs);

            //connecting jobs to skills (many to many)
            modelBuilder.Entity<Job>()
                .HasMany(s => s.Skills)
                .WithMany(s => s.Jobs)
                .UsingEntity(j => j.ToTable("JobSkills"));
        }
    }
}
