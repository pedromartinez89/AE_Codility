using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Blogs.Models
{
    public class BlogsContext : DbContext
    {
        public DbSet<BlogEntity> BlogsEntities { get; set; }
        public DbSet<PostEntity> PostsEntities { get; set; }

        public BlogsContext(DbContextOptions<BlogsContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Set StudentName column size to 50
            modelBuilder.Entity<BlogEntity>()
                    .Property(p => p.Name)
                    .HasMaxLength(50);

            //var converterToString = new BoolToStringConverter("blog is not active", "blog is active");

            //modelBuilder.Entity<BlogEntity>().Property(e => e.IsActive).HasConversion(converterToString);

            modelBuilder.Entity<BlogEntity>()
            .Property(p => p.Name).IsRequired();
         

               var boolConverter = new ValueConverter<bool, string>(
                v => v ? "blog is active" : "blog is not active",
                v => (v == "blog is active") ? true : false);
            modelBuilder.Entity<BlogEntity>().Property(e => e.IsActive).HasConversion(boolConverter);

        }

        

        public override int SaveChanges()
        {

            //Any ValidationAttribute will be checked before sending the statement to the database.

            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                           || e.State == EntityState.Modified
                           select e.Entity;

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext,validateAllProperties:true);
            }
            return base.SaveChanges();
           
            
        }



    }
}

