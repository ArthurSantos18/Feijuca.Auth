using System;
using System.Collections.Generic;
using System.Text;

namespace Feijuca.Auth.Http.Requests
{
    public record CreateUserRequest(
              string Username, 
              string Password,
              string Email,
              string FirstName,
              string LastName,
              Dictionary<string, string[]> Attributes);
}
