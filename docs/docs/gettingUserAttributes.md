### ⚙️ Endpoint specification  

##### Method: GET
##### Path: /users-attributes
##### Summary:

Returns the attributes associated with a specific user in the realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | User attributes retrieved successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Query params

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| username | query | The username of the user whose attributes will be retrieved. | Yes | string |


### 📝 How to Use the Endpoint

1. **Query params**:
   - Specify the `username` of the user you want to retrieve attributes for. Example:

   `GET /api/v1/users-attributes?username=john.doe`