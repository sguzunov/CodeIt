using CodeIt.Services.Data.Contracts;
using System;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using Bytes2you.Validation;

namespace CodeIt.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IEfRepository<User> usersRepository;

        public UsersService(IEfRepository<User> usersRepository)
        {
            Guard.WhenArgument(usersRepository, nameof(usersRepository)).IsNull().Throw();

            this.usersRepository = usersRepository;
        }

        public User GetById(string id)
        {
            var user = this.usersRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentException($"User with id = {id} is not found!");
            }

            return user;
        }
    }
}
