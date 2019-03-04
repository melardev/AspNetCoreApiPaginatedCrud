using System.Collections.Generic;
using ApiCrudCore.Dtos.Responses.Shared;
using ApiCrudCore.Entities;
using ApiCrudCore.Models;

namespace ApiCrudCore.Dtos.Responses.Todos
{
    public class TodoListResponse : PagedDto
    {
        public IEnumerable<TodoDto> Todos { get; set; }
//    public int SortBy {get; set;}


        public static TodoListResponse Build(List<Todo> todos, string basePath,
            int currentPage, int pageSize, int totalItemCount)
        {
            List<TodoDto> todoDtos = new List<TodoDto>(todos.Count);

            foreach (var todo in todos)
                todoDtos.Add(TodoDto.Build(todo));


            return new TodoListResponse
            {
                PageMeta = new PageMeta(todos.Count, basePath, currentPage: currentPage, pageSize: pageSize,
                    totalItemCount: totalItemCount),
                Todos = todoDtos
            };
        }
    }
}