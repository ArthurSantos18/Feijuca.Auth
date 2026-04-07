   ### ⚙️ Endpoint specification  

##### Method: PUT
##### Path: /user/{id}/reset-password
##### Summary:

Updates the password for a specific user within a tenant context.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | Password updated successfully. |
| 400 | The request was invalid, such as incorrect credentials. |
| 500 | An internal server error occurred while processing the request. |

##### Query params

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | query | The unique identifier of the user to be updated. | Yes | Guid |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| newPassword | body | The new password for specified user. | Yes | string |  


### 📝 How to Use the Endpoint

1. **Query params**:
   - You must specify the id of the user that will have the password updated to proceed.


2. **Body**:
   - After setting up the query params, inform a valid body to update the password. Example:  

	```json
	{
        "newPassword": "João@123"
    }
	```