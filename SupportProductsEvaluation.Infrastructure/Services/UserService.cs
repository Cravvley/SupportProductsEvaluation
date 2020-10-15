using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Get(string id)
        {
            var userEntity = await _userRepository.Get(id);
            if (userEntity == null)
            {
                throw new ArgumentNullException("user doesn't exist");
            }

            return userEntity; 
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null)
                        => await _userRepository.GetAll(filter);

        public async Task Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user doesn't exist");
            }

            await _userRepository.Update(user);
        }
    }
}
