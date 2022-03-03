using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                    SeedMembershipTypes(context);

                if (!context.Roles.Any())
                    SeedRoles(context);

                if (!context.Customers.Any())
                     SeedCustomers(userManager);

                if (!context.Genre.Any())
                    SeedGenres(context);

                if (!context.Books.Any())
                    SeedBooks(context);

                context.SaveChanges();
            }
        }

        private static void SeedBooks(ApplicationDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    GenreId = 1,
                    Name = "test1",
                    AuthorName = "test test",
                    ReleaseDate = DateTime.Parse("10/01/2014"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 2
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Blur",
                    AuthorName = "John Writer",
                    ReleaseDate = DateTime.Parse("10/01/2013"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "The Office",
                    AuthorName = "Andy Berbard",
                    ReleaseDate = DateTime.Parse("17/03/2005"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "The Work",
                    AuthorName = "Heul Muel",
                    ReleaseDate = DateTime.Parse("10/01/2012"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Stardust",
                    AuthorName = "Sale veil",
                    ReleaseDate = DateTime.Parse("11/04/2012"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "The Sandiwch",
                    AuthorName = "Zofia Olia",
                    ReleaseDate = DateTime.Parse("10/01/2012"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "The O",
                    AuthorName = "Lo Vyyk",
                    ReleaseDate = DateTime.Parse("25/04/2016"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "The Walker",
                    AuthorName = "Lenovo Josh",
                    ReleaseDate = DateTime.Parse("12/05/2011"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                }
            );
        }

        private static void SeedGenres(ApplicationDbContext context)
        {
            context.Genre.AddRange(
                new Genre
                {
                    Id = 1,
                    Name = "Romance"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Criminal"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Sci - Fi"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Biography"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Thriller"
                },
                new Genre
                {
                    Id = 8,
                    Name = "Mystery"
                }
            );
        }

        private static void SeedCustomers(UserManager<Customer> userManager)
        {
            var hasher = new PasswordHasher<Customer>();

            var customer1 = new Customer
            {
                Name = "Dawid Sosin",
                Email = "dawid.sosin@gmail.com",
                NormalizedEmail = "dawid.sosin@gmail.com",
                UserName = "dawid.sosin@gmail.com",
                NormalizedUserName = "dawid.sosin@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "qwerty123!")
            };

  
            userManager.CreateAsync(customer1).Wait();
            userManager.AddToRoleAsync(customer1, "user").Wait();

            var customer2 = new Customer
            {
                Name = "Jooooe Doge",
                Email = "jooooe.doge@gmail.com",
                NormalizedEmail = "jooooe.doge@gmail.com",
                UserName = "jooooe.doge@gmail.com",
                NormalizedUserName = "jooooe.doge@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "test123!")
            };


            userManager.CreateAsync(customer2).Wait();
            userManager.AddToRoleAsync(customer2, "storemanager").Wait();

            var customer3 = new Customer
            {
                Name = "Ala Bala",
                Email = "ala.bala@gmail.com",
                NormalizedEmail = "ala.bala@gmail.com",
                UserName = "ala.bala@gmail.com",
                NormalizedUserName = "ala.bala@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "qwerty12356@")
            };


            userManager.CreateAsync(customer3).Wait();
            userManager.AddToRoleAsync(customer3, "owner").Wait();
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddRange(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "StoreManager",
                    NormalizedName = "storemanager"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Owner",
                    NormalizedName = "owner"
                }
            );

            context.SaveChanges();
        }

        private static void SeedMembershipTypes(ApplicationDbContext context)
        {
            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    Name = "Pay as You Go",
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "Monthly",
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    Name = "Quaterly",
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    Name = "Yearly",
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                }
            );

            context.SaveChanges();
        }
    }
}