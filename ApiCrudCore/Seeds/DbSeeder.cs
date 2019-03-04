using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCrudCore.Data;
using ApiCrudCore.Entities;
using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudCore.Seeds
{
    public class DbSeeder
    {
        public static async Task Seed(ApplicationDbContext context)
        {
            await SeedTodos(context);
        }


        public static async Task SeedTodos(ApplicationDbContext context)
        {
            int todosCount = await context.Todos.CountAsync();
            int todosToSeed = 32;
            todosToSeed -= todosCount;
            if (todosToSeed > 0)
            {
                Console.WriteLine($"[+] Seeding ${todosToSeed} Todos");
                var faker = new Faker<Todo>()
                    .RuleFor(a => a.Title, f => String.Join(" ", f.Lorem.Words(f.Random.Int(2, 5))))
                    .RuleFor(a => a.Description, f => f.Lorem.Sentences(f.Random.Int(min: 1, max: 10)))
                    .RuleFor(t => t.Completed, f => f.Random.Bool(0.4f))
                    .RuleFor(a => a.CreatedAt, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now.AddDays(-1)))
                    .FinishWith(async (f, todoInstance) =>
                    {
                        todoInstance.UpdatedAt = f.Date.Between(start: todoInstance.CreatedAt, end: DateTime.Now);
                    });

                List<Todo> todos = faker.Generate(todosToSeed);
                await context.Todos.AddRangeAsync(todos);
                await context.SaveChangesAsync();
            }
        }
    }
}