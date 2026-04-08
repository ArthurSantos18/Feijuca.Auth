using Feijuca.Auth.Application.Requests.Group;
using LiteBus.Commands.Abstractions;
using Mattioli.Configurations.Models;

namespace Feijuca.Auth.Application.Commands.Group
{
    public record UpdateGroupNameCommand(Guid GroupId, UpdateGroupNameRequest Request) : ICommand<Result<bool>>;
}
