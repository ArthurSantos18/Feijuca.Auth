using System;
using System.Collections.Generic;
using System.Text;

namespace Feijuca.Auth.Http.Requests
{
    public record AddUserToGroupRequest(Guid UserId, Guid GroupId);
}
