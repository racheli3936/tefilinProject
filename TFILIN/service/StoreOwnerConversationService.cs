using AutoMapper;
using core.DTOs;
using core.IRepositories;
using core.IServices;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class StoreOwnerConversationService:IStoreOwnerConversationService
    {
        private readonly IStoreOwnerConversationRepository _storeOwnerConversationRepository;
        private readonly IMapper _mapper;

        public StoreOwnerConversationService(IStoreOwnerConversationRepository storeOwnerConversationRepository,IMapper mapper)
        {
            _storeOwnerConversationRepository = storeOwnerConversationRepository;
            _mapper = mapper;
        }

        public async Task AddConversationAsync(StoreOwnerConversation conversation)
        {
            await _storeOwnerConversationRepository.AddConversationAsync(conversation);
        }

        public async Task<List<StoreOwnerConversationDto>> GetAllConversationsAsync()
        {
            var conversations= await _storeOwnerConversationRepository.GetAllConversationsAsync();
            var conversationsDto=_mapper.Map<List<StoreOwnerConversationDto>>(conversations);
            return conversationsDto;
         }

        public async Task<StoreOwnerConversationDto?> GetConversationByIdAsync(int id)//מחזיר ע"פ מזהה של שיחה
        {
            var conversation= await _storeOwnerConversationRepository.GetConversationByIdAsync(id);
            if(conversation==null) return null;
            var conversationDto=_mapper.Map<StoreOwnerConversationDto>(conversation);
            return conversationDto;
        }

        public async Task<List<StoreOwnerConversationDto?>> GetConversationByStoreOwnerIdAsync(int storeOwnerId)//מחזיר ע"פ מזהה של בעל עסק שאיתו דיברו
        {
            List<StoreOwnerConversation> conversation = await _storeOwnerConversationRepository.GetConversationsByStoreOwnerIdAsync(storeOwnerId);
            if (conversation == null) return null;
            List<StoreOwnerConversationDto> conversationDto = _mapper.Map<List<StoreOwnerConversationDto>>(conversation);
            return conversationDto;
        }
    }
}
