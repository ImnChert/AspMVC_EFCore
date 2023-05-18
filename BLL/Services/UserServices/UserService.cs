using AutoMapper;
using BLL.DTOs;
using Identity.Entities;
using Identity.Repositories.UserRepositories;
using Microsoft.Extensions.Logging;

namespace BLL.Services.UserServices
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        private ILogger<IUserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<IUserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> DeleteUserAsync(UserDTO user)
        {
            var mapperModel = _mapper.Map<ApplicationUser>(user);

            var result = await _userRepository.DeleteUserAsync(mapperModel);

            if(result is null)
            {
                _logger.LogError("");
                throw new Exception("");
            }

            return user;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();

            if(result is null)
            {
                _logger.LogError("");
                throw new Exception("");
            }

            var mapperModel = _mapper.Map<IEnumerable<UserDTO>>(result);

            return mapperModel;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);

            if(result is null)
            {
                _logger.LogError("");
                throw new Exception("");
            }

            var mapperModel = _mapper.Map<UserDTO>(result);

            return mapperModel;
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO user)
        {
            var mapperModel = _mapper.Map<ApplicationUser>(user);

            var result = await _userRepository.UpdateUserAsync(mapperModel);

            if(result is null)
            {
                _logger.LogError("");
                throw new Exception("");
            }

            return user;
        }

        public async Task<IEnumerable<string>> UserRolesAsync(UserDTO user)
        {
            var mapperModel = _mapper.Map<ApplicationUser>(user);

            var result = await _userRepository.UserRolesAsync(mapperModel);

            if(result.Count() == 0)
            {
                _logger.LogError("");
                throw new Exception("");
            }

            return result;
        }
    }
}
