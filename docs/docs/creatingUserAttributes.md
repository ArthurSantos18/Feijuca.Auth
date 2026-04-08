### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /users-attributes
##### Summary:

Adds new attributes to an existing user in the specified Keycloak realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 201 | Attributes added to the user successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Query params

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| username | query | The username of the user who will receive the new attributes. | Yes | string |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| attributes | body | A key-value map where each key is an attribute name and the value is a list of attribute values. | Yes | object |


### 📝 How to Use the Endpoint

1. **Query params**:
   - Specify the `username` of the target user as a query parameter.

2. **Body**:
   - Provide the attributes map to be added to the user. Example:

	```json
	{
        "attributes": {
            "department": ["engineering"],
            "location": ["São Paulo"]
        }
    }
	```