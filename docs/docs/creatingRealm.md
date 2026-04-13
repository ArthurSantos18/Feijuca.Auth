### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /realms
##### Summary:

Creates a new realm on Keycloak.

##### Responses
| Code | Description |
| ---- | ----------- |
| 201 | Realm created successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| name | body | The name of the new realm to be created. | Yes | string |
| description | body | A brief description of the new realm. | No | string |


### 📝 How to Use the Endpoint

1. **Body**:
   - Provide the name and an optional description for the new realm. Example:

	```json
	{
        "name": "my-new-realm",
        "description": "Realm for the production environment"
    }
	```