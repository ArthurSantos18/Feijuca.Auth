using Feijuca.Auth.Common.Errors;
using Feijuca.Auth.Domain.Interfaces;
using Feijuca.Auth.Providers;
using LiteBus.Commands.Abstractions;
using Mattioli.Configurations.Models;

namespace Feijuca.Auth.Application.Commands.Group
{
    public class UpdateGroupCommandHandler(IGroupRepository _groupRepository, ITenantProvider tenantProvider) : ICommandHandler<UpdateGroupCommand, Result<bool>>
    {
        public async Task<Result<bool>> HandleAsync(UpdateGroupCommand request, CancellationToken cancellationToken = default)
        {
            var groups = await _groupRepository.GetAllAsync(tenantProvider.Tenant.Name, cancellationToken);

            if (groups.IsFailure)
            {
                return Result<bool>.Failure(GroupErrors.GetGroupsError);
            }

            var group = groups.Data.FirstOrDefault(g => g.Id == request.GroupId.ToString());

            if (group is null)
            {
                return Result<bool>.Failure(GroupErrors.NotFoundError);
            }

            group.Name = request.Request.Name;

            var result = await _groupRepository.UpdateAsync(group, tenantProvider.Tenant.Name, cancellationToken);

            if (result.IsSuccess)
            {
                return Result<bool>.Success(true);
            }

            return Result<bool>.Failure(result.Error);
        }
    }
}
