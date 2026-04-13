### ⚙️ Endpoint specification  

##### Method: PATCH
##### Path: /groups/{id}/update-group-name
##### Summary:

Update the name of an existing group from the specified Keycloak realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | Group name updated successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Path params

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path | The unique identifier of the group to be updated. | Yes | Guid |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| name | body | The new name for the specified group. | Yes | string |


### 📝 How to Use the Endpoint

1. **Path params**:
   - You must specify the `id` of the group whose name will be updated.

2. **Body**:
   - Provide the new name for the group. Example:

	```json
	{
        "name": "new-group-name"
    }
	```