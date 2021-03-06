using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BlueBoard.Module.Identity.Repositories.Entities;
using BlueBoard.Persistence.Abstractions.Entities;

namespace BlueBoard.Module.Identity.Repositories
{
    internal interface IUserRepository
    {
        Task<bool> IsUserExistsAsync(IDbConnection connection, string email);

        Task<IEnumerable<UserEntity>> GetAllAsync(IDbConnection connection, long[] usersIds);

        Task<UserEntity> CreateUserAsync(IDbConnection connection, string email, long? createdBy = null);

        Task<UserEntity> FindByEmailAsync(IDbConnection connection, string email);

        Task<UserEntity> FindById(IDbConnection connection, long id);

        Task<UserEntity> Update(IDbConnection connection, UserEntity entity, long updatedBy);

        Task<IEnumerable<UserEntity>> SearchByQueryAsync(IDbConnection connection, string query);
    }
}
