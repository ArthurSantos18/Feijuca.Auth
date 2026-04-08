### ⚙️ Endpoint specification  

##### Method: PATCH
##### Path: /users-attributes
##### Summary:

Updates existing attributes of a user in the specified Keycloak realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | User attributes updated successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Query params

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| username | query | The username of the user whose attributes will be updated. | Yes | string |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| attributes | body | A key-value map where each key is an attribute name and the value is a list of updated attribute values. | Yes | object |


### 📝 How to Use the Endpoint

1. **Query params**:
   - Specify the `username` of the target user as a query parameter.

2. **Body**:
   - Provide the attributes map with the updated values. Example:

	```json
	{
        "attributes": {
            "department": ["product"],
            "location": ["Campinas"]
        }
    }
	```