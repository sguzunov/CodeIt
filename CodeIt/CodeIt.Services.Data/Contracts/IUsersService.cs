using CodeIt.Data.Models;
using System;

namespace CodeIt.Services.Data.Contracts
{
    public interface IUsersService : IDataService
    {
        User GetById(string id);
    }
}
