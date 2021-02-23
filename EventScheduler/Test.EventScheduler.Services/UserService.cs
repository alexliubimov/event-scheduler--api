using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;
using Test.EventScheduler.DataAccess;
using Test.EventScheduler.DataAccess.Extensions;
using Test.EventScheduler.DataAccess.Models;
using Test.EventScheduler.Services.Exceptions;
using Test.EventScheduler.Services.Interfaces;

namespace Test.EventScheduler.Services
{
    public class UserService : IUserService
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public UserService(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateUser(CreateUserDto user)
        {
            var userEntity = await _context.Users.GetActiveUserByEmail(user.Email).FirstOrDefaultAsync();

            if (userEntity != null)
            {
                throw new InvalidActionException();
            }

            userEntity = _mapper.Map<User>(user);

            _context.Users.Add(userEntity);
            _context.Save();

            return userEntity.UserId;
        }

        public async Task DeleteUser(int userId)
        {
            var userEntity = await _context.Users.GetActiveUserById(userId).FirstOrDefaultAsync();

            if (userEntity == null)
            {
                throw new ItemNotFoundException();
            }

            userEntity.IsDeleted = true;

            _context.Save();
        }

        public async Task<UserDto> GetUser(int userId)
        {
            var userEntity = await _context.Users.GetActiveUserById(userId).FirstOrDefaultAsync();

            if (userEntity == null)
            {
                throw new ItemNotFoundException();
            }

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _context.Users.GetActiveUsers().ToListAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task UpdateUser(UpdateUserDto user)
        {
            var userEntity = await _context.Users.GetActiveUserById(user.UserId).FirstOrDefaultAsync();

            if (userEntity == null)
            {
                throw new ItemNotFoundException();
            }

            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;

            _context.Save();
        }
    }
}
