using System;
using ApiCrudCore.Dtos.Responses.Shared;
using ApiCrudCore.Entities;

namespace ApiCrudCore.Dtos.Responses.Todos
{
    public class TodoDetailsDto : SuccessResponse
    {
        public static TodoDetailsDto Build(Todo todo)
        {
            return new TodoDetailsDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Completed = todo.Completed,
                CreatedAt = todo.CreatedAt,
                UpdatedAt = todo.UpdatedAt
            };
        }

        public bool Completed { get; set; }

        public int Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }
    }
}