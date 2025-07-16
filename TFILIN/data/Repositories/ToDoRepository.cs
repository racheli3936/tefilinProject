using core.DTOs;
using core.IRepositories;
using core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class ToDoRepository:IToDoRepository
    {
        private readonly DataContext _context;

        public ToDoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _context.Todo.ToListAsync();
        }

        //public async Task<ToDo> GetByIdAsync(int id)
        //{
        //    return await _context.Todo.FindAsync(id);
        //}

        //public async Task CreateAsync(ToDo toDoPost)
        //{
        //    await _context.Todo.AddAsync(toDoPost);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(ToDo toDoPost)
        //{
        //    _context.Todo.Update(toDoPost);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var toDoPost = await GetByIdAsync(id);
        //    if (toDoPost != null)
        //    {
        //        _context.Todo.Remove(toDoPost);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
