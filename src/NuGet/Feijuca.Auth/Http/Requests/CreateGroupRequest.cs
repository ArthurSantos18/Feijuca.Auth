namespace Feijuca.Auth.Http.Requests
{
    public record CreateGroupRequest(string Name, Dictionary<string, string[]> Attributes);
}
