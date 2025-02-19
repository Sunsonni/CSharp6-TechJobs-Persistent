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
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many (Employer to Jobs)
            modelBuilder.Entity<Job>().HasOne(p => p.Employer).WithMany(b => b.Jobs).HasForeignKey(e => e.EmployerId);

            //Many to many (Skills to Jobs)
            modelBuilder.Entity<Job>().HasMany(p => p.Skills).WithMany(b => b.Jobs).UsingEntity(a => a.ToTable("JobSkills"));
           
            base.OnModelCreating(modelBuilder);

        }
    }
}
