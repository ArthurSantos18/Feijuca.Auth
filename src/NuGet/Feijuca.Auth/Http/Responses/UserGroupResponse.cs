namespace Feijuca.Auth.Http.Responses;

public record UserGroupResponse(GroupResponse Group, IEnumerable<UserResponse> Users);
