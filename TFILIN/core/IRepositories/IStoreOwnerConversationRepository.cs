using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface IStoreOwnerConversationRepository
    {
        Task AddConversationAsync(StoreOwnerConversation conversation);
        Task<List<StoreOwnerConversation>> GetAllConversationsAsync();
        Task<StoreOwnerConversation?> GetConversationByIdAsync(int id);
        Task<List<StoreOwnerConversation>> GetConversationsByStoreOwnerIdAsync(int storeOwnerId);

    }
}
