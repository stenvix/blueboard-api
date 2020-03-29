using System.Data;
using System.Threading.Tasks;
using BlueBoard.Persistence.Abstractions.Entities;

namespace BlueBoard.Persistence.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsUserExistsAsync(IDbConnection connection, string email);
        Task<UserEntity> CreateUserAsync(IDbConnection connection, string email);
        Task<UserEntity> FindByEmailAsync(IDbConnection connection, string email);
        Task<UserEntity> FindById(IDbConnection connection, int id);
        Task<UserEntity> Update(IDbConnection connection, UserEntity entity);
    }
}
