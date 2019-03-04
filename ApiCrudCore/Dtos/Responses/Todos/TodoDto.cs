using System;
using ApiCrudCore.Entities;

namespace ApiCrudCore.Dtos.Responses.Todos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }
        public bool Completed { get; set; }

        public static TodoDto Build(Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Completed = todo.Completed,
                CreatedAt = todo.CreatedAt,
                UpdatedAt = todo.UpdatedAt
            };
        }
    }
}