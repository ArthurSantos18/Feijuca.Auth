namespace Feijuca.Auth.Http.Responses
{
    public record RoleResponse(Guid Id, string Name, string Description, bool Composite, bool ClientRole, string ContainerId);
}
