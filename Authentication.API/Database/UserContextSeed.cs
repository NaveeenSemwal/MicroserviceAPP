using AuthenticationService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AuthenticationService.Database
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// After this you need to Add the migration i.e  Add-Migration SeedInitialData
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    RoleId = 1,
                    Name = "Admin",
                    Description = "Administrator"
                },
                new Role()
                {
                    RoleId = 2,
                    Name = "Employee",
                    Description = "Employee"
                },
                new Role()
                {
                    RoleId = 3,
                    Name = "User",
                    Description = "User"
                }
                );

            modelBuilder.Entity<User>().HasData(
            new User()
            {
                UserId = 1,
                Username = "admin",
                Password = "123",
                Name = "Administrator",
                Address = "New Delhi",
                ContactNo = "978776654",
                CreatedDate = DateTime.Now
            },
            new User()
            {
                UserId = 2,
                Username = "emp",
                Password = "123",
                Name = "Employee",
                Address = "New Delhi",
                ContactNo = "978776654",
                CreatedDate = DateTime.Now
            },
            new User()
            {
                UserId = 3,
                Username = "user",
                Password = "123",
                Name = "User",
                Address = "New Delhi",
                ContactNo = "978776654",
                CreatedDate = DateTime.Now
            }
              );

            modelBuilder.Entity<UserRoles>().HasData(
           new UserRoles()
           {
               UserId = 1,
               RoleId = 1
           },
           new UserRoles()
           {
               UserId = 2,
               RoleId = 2
           },
           new UserRoles()
           {
               UserId = 3,
               RoleId = 3
           }
            );
        }
    }

    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
