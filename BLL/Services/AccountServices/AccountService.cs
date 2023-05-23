using AutoMapper;
using BLL.DTOs;
using Identity.Entities;
using Identity.Repositories.AccountRepositories;
using Microsoft.Extensions.Logging;
using System.Text;

namespace BLL.Services.AccountServices
{
    internal class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private IMapper _mapper;
        private ILogger<IAccountService> _logger;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, ILogger<IAccountService> logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var result = await _accountRepository.LoginAsync(email, password);

            if(!result.Succeeded)
            {
                _logger.LogError("");
                throw new Exception();
            }

            return true;
        }

        public async Task LogoutAsync()
            => await _accountRepository.LogoutAsync();


        public async Task<bool> RegisterAsync(UserDTO user, string password, string role)
        {
            var mapperModel = _mapper.Map<ApplicationUser>(user);
            mapperModel.UserName = user.Email;

            var result = await _accountRepository.RegisterAsync(mapperModel, password, role);

            if(!result.Succeeded)
            {
                var errors = new StringBuilder(16);
                result.Errors.ToList().ForEach(i => errors.Append(i.Description));

                _logger.LogError(errors.ToString());
                throw new Exception(errors.ToString());
            }

            return true;
        }
    }
}
