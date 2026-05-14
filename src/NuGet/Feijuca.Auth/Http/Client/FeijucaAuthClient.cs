using Feijuca.Auth.Errors;
using Feijuca.Auth.Http.Requests;
using Feijuca.Auth.Http.Responses;
using Mattioli.Configurations.Http;
using Mattioli.Configurations.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Feijuca.Auth.Http.Client
{
    public class FeijucaAuthClient(HttpClient httpClient) : BaseHttpClient(httpClient), IFeijucaAuthClient
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly JsonSerializerOptions _serializer = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public async Task<Result<TokenDetailsResponse>> AuthenticateUserAsync(string tenant, string username, string password, CancellationToken cancellationToken)
        {
            IncludeTenantHeader(tenant);

            var result = await PostAsync<LoginUserRequest, TokenDetailsResponse>("users/login", new LoginUserRequest(username, password), cancellationToken);

            if (string.IsNullOrEmpty(result.AccessToken))
            {
                return Result<TokenDetailsResponse>.Failure(FeijucaErrors.GenerateTokenError);
            }

            return Result<TokenDetailsResponse>.Success(result);
        }

        public async Task<Result<UserResponse>> GetUserAsync(string tenant, string userame, string jwtToken, CancellationToken cancellationToken)
        {
            IncludeTenantHeader(tenant);

            var url = $"users?Usernames={userame}";
            var result = await GetAsync<PagedResult<UserResponse>>(url, jwtToken, cancellationToken);

            if (result.TotalResults == 0)
            {
                return Result<UserResponse>.Failure(FeijucaErrors.GetUserErrors);
            }

            var user = result?.Results.FirstOrDefault(x => x.Email == userame);

            return Result<UserResponse>.Success(user!);
        }

        public async Task<Result<PagedResult<UserResponse>>> GetUsersAsync(string tenant, int maxUsers, string jwtToken, CancellationToken cancellationToken)
        {
            IncludeTenantHeader(tenant);

            var url = $"users?PageFilter.Page=1&PageFilter.PageSize={maxUsers}";
            var result = await GetAsync<PagedResult<UserResponse>>(url, jwtToken, cancellationToken);

            if (result.TotalResults <= 1)
            {
                return Result<PagedResult<UserResponse>>.Failure(FeijucaErrors.GetUserErrors);
            }

            return Result<PagedResult<UserResponse>>.Success(result);
        }

        public async Task<Result<IEnumerable<GroupResponse>>> GetGroupsAsync(string tenant, string jwtToken, CancellationToken cancellationToken)
        {
            IncludeTenantHeader(tenant);

            var result = await GetAsync<IEnumerable<GroupResponse>>("groups", jwtToken, cancellationToken);

            if (!result.Any())
            {
                return Result<IEnumerable<GroupResponse>>.Failure(FeijucaErrors.GetGroupErrors);
            }

            return Result<IEnumerable<GroupResponse>>.Success(result);
        }

        public async Task<Result<PagedResult<UserGroupResponse>>> GetGroupUsersAsync(string groupId, string jwtToken, CancellationToken cancellationToken)
        {
            var result = await GetAsync<PagedResult<UserGroupResponse>>($"groups/users?groupId={groupId}", jwtToken, cancellationToken);

            if (!result.Results.Any())
            {
                return Result<PagedResult<UserGroupResponse>>.Failure(FeijucaErrors.GetGroupUsersErrors);
            }

            return Result<PagedResult<UserGroupResponse>>.Success(result);
        }

        public async Task<Result<IEnumerable<RealmResponse>>> GetRealmsAsync(string jwtToken, CancellationToken cancellationToken)
        {
            var result = await GetAsync<IEnumerable<RealmResponse>>("realms", jwtToken, cancellationToken);

            if (!result.Any())
            {
                return Result<IEnumerable<RealmResponse>>.Failure(FeijucaErrors.GetGroupErrors);
            }

            return Result<IEnumerable<RealmResponse>>.Success(result);
        }

        public async Task<Result<string>> CreateGroupAsync(CreateGroupRequest request, string jwtToken, CancellationToken cancellationToken)
        {
            IncludeAuthorizationHeader(jwtToken);

            var response = await _httpClient.PostAsJsonAsync("groups", request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            
            if (!response.IsSuccessStatusCode) 
            {
                var error = JsonSerializer.Deserialize<Error>(content, _serializer);
                return Result<string>.Failure(error ?? FeijucaErrors.CreateGroupError); 
            }

            return Result<string>.Success(content ?? "");
        }

        public async Task<Result<Guid>> CreateUserAsync(CreateUserRequest request, string tenant, CancellationToken cancellationToken)
        {
            IncludeTenantHeader(tenant);

            var response = await _httpClient.PostAsJsonAsync("users", request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(content, _serializer);
                return Result<Guid>.Failure(error ?? FeijucaErrors.CreateUserError);
            }

            var result = JsonSerializer.Deserialize<Guid>(content, _serializer);

            return Result<Guid>.Success(result);
        }

        public async Task<Result> AddUserToGroupAsync(AddUserToGroupRequest request, string jwtToken, CancellationToken cancellationToken)
        {
            IncludeAuthorizationHeader(jwtToken);

            var response = await _httpClient.PostAsJsonAsync("groups/users", request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(content, _serializer);
                return Result.Failure(error ?? FeijucaErrors.AddUserToGroupError);
            }

            return Result.Success();
        }

        private void IncludeAuthorizationHeader(string jwtToken)
        {
            if(!string.IsNullOrEmpty(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
        }

        private void IncludeTenantHeader(string tenant)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                if (_httpClient.DefaultRequestHeaders.Contains("Tenant"))
                {
                    _httpClient.DefaultRequestHeaders.Remove("Tenant");
                }

                _httpClient.DefaultRequestHeaders.Add("Tenant", tenant);
            }
        }
    }
}
