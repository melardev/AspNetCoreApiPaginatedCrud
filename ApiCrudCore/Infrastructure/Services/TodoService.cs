using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCrudCore.Data;
using ApiCrudCore.Entities;
using ApiCrudCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiCrudCore.Infrastructure.Services
{
    public class TodoService
    {
        private readonly ApplicationDbContext _context;

        public TodoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tuple<int, List<Todo>>> FetchMany(int page = 1, int pageSize = 5,
            TodoShow show = TodoShow.All)
        {
            // Retrieve hwo many articles with our criteria(All, Completed or Pending)
            int offset = (page - 1) * pageSize;
            IQueryable<Todo> queryable = null;

            if (show == TodoShow.Completed)
            {
                queryable = _context.Todos.Where(t => t.Completed);
            }
            else if (show == TodoShow.Pending)
            {
                queryable = _context.Todos.Where(t => !t.Completed);
            }

            int totalCount;
            List<Todo> todos;
            if (queryable != null)
            {
                // for complete/pending
                totalCount = await queryable.CountAsync();
                todos = await queryable.Skip(offset).Take(pageSize).Select(t => new Todo
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Completed = t.Completed,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt
                }).ToListAsync();
            }
            else
            {
                // for show all
                totalCount = await _context.Todos.CountAsync();
                todos = await _context.Todos.Skip(offset).Take(pageSize).ToListAsync();
            }


            return Tuple.Create(totalCount, todos);
        }


        /// <summary>  
        /// Return a To do object 
        /// </summary>  
        /// <param name="todoId"></param>  
        /// <returns></returns>  
        public async Task<Todo> Get(int todoId) => await _context.Todos.FindAsync(todoId);

        public async Task CreateTodo(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> Update(int id, Todo todoFromUserInput)
        {
            Todo todoFromDb = _context.Todos.First(t => t.Id == id);
            todoFromDb.Title = todoFromUserInput.Title;

            if (todoFromUserInput.Description != null)
                todoFromDb.Description = todoFromUserInput.Description;

            todoFromDb.Completed = todoFromUserInput.Completed;

            _context.Entry(todoFromDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return todoFromDb;
        }

        /// <summary>  
        /// Deletes a To do
        /// </summary>  
        /// <param name="todoId"></param>  
        /// <returns></returns> 
        public EntityEntry<Todo> Delete(int todoId)
        {
            EntityEntry<Todo> result = _context.Todos.Remove(Get(todoId).Result);
            _context.SaveChangesAsync();
            return result;
        }

        public async Task DeleteAll()
        {
            _context.Todos.RemoveRange(_context.Todos);
            await _context.SaveChangesAsync();
        }
    }
}