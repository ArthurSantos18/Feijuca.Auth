### ⚙️ Endpoint specification  

##### Method: GET
##### Path: /clients-scopes
##### Summary:

Retrieves all client scopes registered in the realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | List of client scopes retrieved successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |


### 📝 How to Use the Endpoint

1. **No parameters required**:
   - Simply call the endpoint with a valid Bearer token to retrieve all client scopes in the realm.