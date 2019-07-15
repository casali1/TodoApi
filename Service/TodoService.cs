using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Service
{
    public class TodoService : ITodoService
    {
        private TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task CreateTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoItem(TodoItem item)
        {
            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task EditTodoItem(TodoItem item)
        {
            var oldItem = _context.TodoItems.Find(item.Id);
            _context.TodoItems.Remove(oldItem);
            await _context.SaveChangesAsync();

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> GetTodoItemById(long id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<List<TodoItem>> GetTodoItemList()
        {
            return await _context.TodoItems.ToListAsync();
        }
    }
}
