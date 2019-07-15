using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTodoItemList();
        Task<TodoItem> GetTodoItemById(long id);
        Task CreateTodoItem(TodoItem item);
        Task EditTodoItem(TodoItem item);
        Task DeleteTodoItem(TodoItem item);
    }
}
