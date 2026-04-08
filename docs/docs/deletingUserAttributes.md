### ⚙️ Endpoint specification  

##### Method: DELETE
##### Path: /users-attributes
##### Summary:

Deletes existing attributes from a user in the specified Keycloak realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | User attributes deleted successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Query params

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| username | query | The username of the user whose attributes will be deleted. | Yes | string |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| (array of strings) | body | A list of attribute key names to be removed from the user. | Yes | string[] |


### 📝 How to Use the Endpoint

1. **Query params**:
   - Specify the `username` of the target user as a query parameter.

2. **Body**:
   - Provide a list of attribute keys to be deleted from the user. Example:

	```json
	[
        "department",
        "location"
    ]
	```