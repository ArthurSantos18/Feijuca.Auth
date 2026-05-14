namespace Feijuca.Auth.Http.Responses
{
    public record GroupRolesResponse(string Id, string Client, IEnumerable<RoleResponse> Mappings);
}
