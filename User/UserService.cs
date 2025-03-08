using BackendProject.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace firstback.user
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserRoleDTO>> GetUsersAsync()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();

            return _mapper.Map<IEnumerable<UserRoleDTO>>(users);
        }

        public async Task<UserRoleDTO?> GetUserByIdAsync(int id)
        {
             var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id); 

             return _mapper.Map<UserRoleDTO>(user);
        }

        public async Task<int> CreateUserAsync(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task UpdateUserAsync(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _mapper.Map(userDTO, user);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}