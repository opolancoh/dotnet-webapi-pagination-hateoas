using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetWebApiPaginationHateoas.Data.Entities;


namespace DotNetWebApiPaginationHateoas.Data
{
    public class FakeDataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new HobbyDbContext(
                      serviceProvider
                      .GetRequiredService<DbContextOptions<HobbyDbContext>>());

            if (context.Hobbies.Any()) { return; }

            var hobbies = new List<Hobby>
            {
                new Hobby{ Name = "Cooking", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Listening to Music", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Drinking Beer", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Playing Guitar", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Blogging", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Vlogging", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Travelling", CreatedAt = DateTime.Now },
            };

            context.Hobbies.AddRange(hobbies);

            context.SaveChanges();
        }
    }
}