using Mattioli.Configurations.Http;
using Mattioli.Configurations.Models;
using Feijuca.Auth.Http.Responses;
using Feijuca.Auth.Http.Requests;

namespace Feijuca.Auth.Http.Client;

public interface IFeijucaAuthClient
{
    Task<Result<TokenDetailsResponse>> AuthenticateUserAsync(string tenant, string username, string password, CancellationToken cancellationToken);
    Task<Result<PagedResult<UserResponse>>> GetUsersAsync(string tenant, int maxUsers, string jwtToken, CancellationToken cancellationToken);
    Task<Result<UserResponse>> GetUserAsync(string tenant, string userame, string jwtToken, CancellationToken cancellationToken);
    Task<Result<IEnumerable<GroupResponse>>> GetGroupsAsync(string tenant, string jwtToken, CancellationToken cancellationToken);
    Task<Result<PagedResult<UserGroupResponse>>> GetGroupUsersAsync(string groupId, string jwtToken, CancellationToken cancellationToken);
    Task<Result<IEnumerable<RealmResponse>>> GetRealmsAsync(string jwtToken, CancellationToken cancellationToken);
    Task<Result<string>> CreateGroupAsync(CreateGroupRequest request, string jwtToken, CancellationToken cancellationToken);
    Task<Result<Guid>> CreateUserAsync(CreateUserRequest request, string tenant, CancellationToken cancellationToken);
    Task<Result> AddUserToGroupAsync(AddUserToGroupRequest request, string jwtToken, CancellationToken cancellationToken);
}
