using core.DTOs;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IStoreOwnerConversationService
    {
        Task AddConversationAsync(StoreOwnerConversation conversation);
        Task<List<StoreOwnerConversationDto>> GetAllConversationsAsync();
        Task<StoreOwnerConversationDto?> GetConversationByIdAsync(int id);//מחזיר ע"פ מזהה של שיחה
        Task<List<StoreOwnerConversationDto?>> GetConversationByStoreOwnerIdAsync(int storeOwnerId);
    }
}
