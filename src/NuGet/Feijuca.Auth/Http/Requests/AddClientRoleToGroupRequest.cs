using System;
using System.Collections.Generic;
using System.Text;

namespace Feijuca.Auth.Http.Requests
{
    public record AddClientRoleToGroupRequest(string ClientId, Guid RoleId);
}
