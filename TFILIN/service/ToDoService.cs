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
    public class ToDoService:IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository toDoRepository,IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<List<ToDoDto>> GetAllAsync()
        {
            var todos= await _toDoRepository.GetAllAsync();
            List<ToDoDto> todosDto = _mapper.Map<List<ToDoDto>>(todos);
            return todosDto;
        }

        //public async Task<ToDo> GetByIdAsync(int id)
        //{
        //    return await _toDoRepository.GetByIdAsync(id);
        //}

        //public async Task CreateAsync(ToDo toDoPost)
        //{
        //    await _toDoRepository.CreateAsync(toDoPost);
        //}

        //public async Task UpdateAsync(ToDo toDoPost)
        //{
        //    await _toDoRepository.UpdateAsync(toDoPost);
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    await _toDoRepository.DeleteAsync(id);
        //}
    }
}

