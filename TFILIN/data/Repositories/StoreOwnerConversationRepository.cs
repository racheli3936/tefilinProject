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
     public class StoreOwnerConversationRepository:IStoreOwnerConversationRepository
    {
        private readonly DataContext _context;

        public StoreOwnerConversationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddConversationAsync(StoreOwnerConversation conversation)
        {
            await _context.StoreOwnerConversations.AddAsync(conversation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoreOwnerConversation>> GetAllConversationsAsync()
        {
            return await _context.StoreOwnerConversations
                .Include(c => c.ToDoVisits).Include(c=>c.StatusCall)
                .ToListAsync();
        }

        public async Task<StoreOwnerConversation?> GetConversationByIdAsync(int id)
        {
            return await _context.StoreOwnerConversations
                .Include(c => c.ToDoVisits).Include(c=>c.StatusCall)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<StoreOwnerConversation>> GetConversationsByStoreOwnerIdAsync(int storeOwnerId)
        {
            return await _context.StoreOwnerConversations
                .Include(c => c.ToDoVisits).Include(c=>c.StatusCall)
                .Where(c => c.StoreOwnerId == storeOwnerId)
                .ToListAsync();
        }
    }
}
