using Feijuca.Auth.Application.Requests.Group;
using LiteBus.Commands.Abstractions;
using Mattioli.Configurations.Models;

namespace Feijuca.Auth.Application.Commands.Group
{
    public record UpdateGroupCommand(Guid GroupId, UpdateGroupRequest Request) : ICommand<Result<bool>>;
}
