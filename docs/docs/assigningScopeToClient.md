### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /clients-scopes/assign-to-client
##### Summary:

Adds a client scope to a specific client in the realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 202 | Client scope successfully assigned to the client. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | body | The identifier of the client to which the scope will be assigned. | Yes | string |
| clientScopeId | body | The identifier of the client scope to be assigned. | Yes | string |
| isOpticionalScope | body | Indicates whether the scope is optional for the client. | Yes | boolean |


### 📝 How to Use the Endpoint

1. **Body**:
   - Provide the client ID, the scope ID, and whether the scope is optional. Example:

	```json
	{
        "clientId": "my-client",
        "clientScopeId": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        "isOpticionalScope": false
    }
	```