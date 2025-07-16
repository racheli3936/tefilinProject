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
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            IEnumerable<User>users= await _userRepository.GetAllUsersAsync();
            IEnumerable<UserDto> usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }

        //public async Task<User> GetUserByIdAsync(int id)
        //{
        //    return await _userRepository.GetUserByIdAsync(id);
        //}

        //public async Task AddUserAsync(User user)
        //{
        //    await _userRepository.AddUserAsync(user);
        //}

        //public async Task UpdateUserAsync(User user)
        //{
        //    await _userRepository.UpdateUserAsync(user);
        //}

        //public async Task DeleteUserAsync(int id)
        //{
        //    await _userRepository.DeleteUserAsync(id);
        //}
    }
}
