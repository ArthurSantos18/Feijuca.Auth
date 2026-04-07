### 📦 Step 1: Install the NuGet Package

Start by installing the **Feijuca.Auth** package from NuGet:

```bash
dotnet add package Feijuca.Auth
```

You can also find it [on NuGet.org](https://www.nuget.org/packages/Feijuca.Auth).

This package contains all the necessary components to enable Keycloak-based authentication and authorization in your API.

---

### ⚙️ Step 2: Configure the `appsettings.json`

After installing the package, it's time to configure your `appsettings.json` file.

Here’s a minimal configuration example:

```json
  "FeijucaAuthConfiguration": {
		"KeycloakUrl": "https://keycloak-production.ul0sru.easypanel.host",
		"ApiUrl": "https://apis-feijuca-production.ul0sru.easypanel.host"
  }
```

- **KeycloakUrl**: The URL where Keycloak is running.
- **ApiUrl**: The URL where Feijuca.Auth.Api is running.

This section is required and will be passed to **Feijuca** when initializing the authentication layer.

---

### 🧩 Step 3: Register Feijuca in `Program.cs`

Now that your `appsettings.json` is configured, it's time to enable Feijuca in your application.


Inside your `Program.cs`, configure and the HttpClient regarding to the Feijuca.Auth API calls. You have only to inform the address.

```csharp
services.AddHttpClient<IFeijucaAuthClient, FeijucaAuthClient>(client =>
{
	client.BaseAddress = new Uri(settings.FeijucaAuthConfiguration.ApiUrl); // Get the URL from your appsettings.json
})
```

After, register the authentication services by calling the following extension method:

```csharp
builder.Services.AddApiAuthentication(settings.FeijucaAuthConfiguration)
```

This method will:

- Automatically register all necessary **JWT authentication** and **authorization** services.

> 💡 I recommend you create a class called Settings and map the appsettings.json on this class, you can merge your personal appsettings config.

---

### 🛡 Reviewing the Changes

With these simple changes, you'll be able to add a security layer to your API using **Feijuca.Auth**.  

For a practical example of how to configure it, check out this [sample Program.cs](https://github.com/fmattioli/Feijuca.Auth/blob/main/src/NuGet/Feijuca.Auth.Api.Tests/Program.cs) in the **Feijuca.Auth** repository on GitHub.

---

### 🔒 Next Steps: Protecting Your Endpoints

In the next step, we will dive deeper into securing your API endpoints.  
You will learn how to properly handle authentication and authorization by:

- Returning a **401 Unauthorized** response when the request contains an invalid or missing token, ensuring only authenticated users can access protected resources.
- Returning a **403 Forbidden** response when a user is authenticated but lacks the necessary permissions to access a particular endpoint, enforcing fine-grained access control.

Additionally, we'll explore best practices to implement these protections seamlessly in your .NET API using Feijuca.Auth, so you can provide a secure and robust experience for your users.

Let's go enhance your application's trustworthiness and with a easily way!
