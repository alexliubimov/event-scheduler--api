using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;

namespace Test.EventScheduler.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(int userId);
        Task<int> CreateUser(CreateUserDto user);
        Task UpdateUser(UpdateUserDto user);
        Task DeleteUser(int userId);
    }
}
