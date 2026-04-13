### 🔗 Built-in Feijuca HTTP Client

To wrap things up, Feijuca provides an internal HTTP client that simplifies communication with its own endpoints — no need to manually configure `HttpRequestMessage`, serialization, or headers.

### Why Use It?

Imagine that, from within your application, you need to call Feijuca endpoints (e.g., to authenticate a user or fetch user data). Instead of building the entire HTTP plumbing manually, you can use the provided `FeijucaAuthClient`, which abstracts this logic in a clean and reusable way.

You can check out the interface directly here:  
🔗 [IFeijucaAuthClient.cs](https://github.com/fmattioli/Feijuca.Auth/blob/main/src/NuGet/Feijuca.Auth/Http/Client/IFeijucaAuthClient.cs)

### Available Methods

Currently, the following methods are available:

```csharp
Task<Result<TokenDetailsResponse>> AuthenticateUserAsync(string tenant, string username, string password, CancellationToken cancellationToken);

Task<Result<PagedResult<UserResponse>>> GetUsersAsync(string tenant, int maxUsers, string jwtToken, CancellationToken cancellationToken);

Task<Result<UserResponse>> GetUserAsync(string tenant, string userame, string jwtToken, CancellationToken cancellationToken);

Task<Result<IEnumerable<GroupResponse>>> GetGroupsAsync(string tenant, string jwtToken, CancellationToken cancellationToken);

Task<Result<IEnumerable<RealmResponse>>> GetRealmsAsync(string jwtToken, CancellationToken cancellationToken);
```

All of them return a Result<T> object, allowing you to handle the result cleanly. If the request is successful, the Data property will contain the response payload.

Use Cases:

- **AuthenticateUserAsync**: Authenticates a user using their username and password, returning a valid JWT token if the credentials are correct.

- **GetUsersAsync**: Fetches a paginated list of users, using the maxUsers parameter (similar to a SELECT TOP query).

- **GetUserAsync**: Returns the user information for a given username.

- **GetGroupsAsync**: Returns a list of groups taht exists in the provided tenant.

- **GetUserAsync**: Returns a list of realms that exists in Keycloak.

This HTTP client is especially useful for internal services and APIs that need to integrate with Feijuca without reimplementing authentication logic or duplicating request handling code.

Feel free to extend the client based on your own application needs — the pattern is already in place.