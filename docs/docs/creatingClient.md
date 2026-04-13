### ⚙️ Endpoint specification

##### Method: POST

##### Path: /clients

##### Summary:

Adds a new client in the specified Keycloak realm.

##### Responses

| Code | Description                                                                                           |
| ---- | ----------------------------------------------------------------------------------------------------- |
| 201  | The operation was successful, and the new role was created.                                           |
| 400  | The request was invalid or could not be processed.                                                    |
| 401  | The request lacks valid authentication credentials.                                                   |
| 403  | The request was understood, but the server is refusing to fulfill it due to insufficient permissions. |
| 500  | An internal server error occurred during the processing of the request.                               |


##### Body definition

| Name        | Located in | Description                                                                                    | Required | Schema |
| ----------- | ---------- | ---------------------------------------------------------------------------------------------- | -------- | ------ |
| clientId    | body       | The clientId related to the unique identifier of the client and normaly its a name. | Yes      | string   |
| description | body       | The description is related to information for that client.                                       | Yes      | string |
| urls | body       | The urls are related to information for that client.                                       | Yes      | strings array |

### 📝 How to Use the Endpoint

1. **Tenant Identification**:

   - The term _tenant_ in Feijuca represents the **realm name** within Keycloak where you’ll be performing actions.
   - You dont need to specify the tenant itself, feijuca knows your tenant by extracting it from your JWT Access Token that you pass in `Authorization` header.

2. **Body**:

   - After setting up the header, inform a valid body to insert a user. Example:

   ```json
   {
     "clientId": "name-of-your-client",
     "description": "description of your client",
     "urls": [
        "https://your-feijuca-url"
     ]
   }
   ```
