using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
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
            if (userEntity is null)
            {
                throw new ArgumentNullException("user doesn't exist");
            }

            return userEntity;
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null)
                        => await _userRepository.GetAll(filter);

        public async Task<bool> Lock(string userId, bool lockUser)
        {
            var user = await _userRepository.Get(userId);
            if (user is null)
            {
                throw new ArgumentNullException("user doesn't exist");
            }

            if (lockUser)
            {

                user.LockoutEnd = DateTime.Now.AddYears(1000);
                await _userRepository.Update(user);

                return true;
            }

            user.LockoutEnd = DateTime.Now;
            await _userRepository.Update(user);

            return false;
        }

        public async Task<IList<User>> GetPaginated(Expression<Func<User, bool>> filter = null, int pageSize = 1, int productPage = 1)
        {
            if (filter is null)
            {
                return await _userRepository.GetPaginated(p => true, pageSize, productPage);
            }

            return await _userRepository.GetPaginated(filter, pageSize, productPage);
        }

    }
}
