namespace firstback.user
{
    public interface IUserService
    {
        Task<IEnumerable<UserRoleDTO>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<int> CreateUserAsync(UserDTO user);
        Task UpdateUserAsync(int id, UserDTO user);
        Task DeleteUserAsync(int id);
    }
}