### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /clients-scopes
##### Summary:

Creates a new client scope in the realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | Client scope created successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| name | body | The name of the client scope to be created. | Yes | string |
| description | body | A brief description of the client scope. | Yes | string |
| includeInTokenScope | body | Indicates whether this scope should be included in the token scope. | Yes | boolean |


### 📝 How to Use the Endpoint

1. **Body**:
   - Provide the details for the new client scope. Example:

	```json
	{
        "name": "read:users",
        "description": "Grants read access to user data",
        "includeInTokenScope": true
    }
	```