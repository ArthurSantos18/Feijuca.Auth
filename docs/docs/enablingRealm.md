### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /realms/enable
##### Summary:

Enables or disables an existing realm in Keycloak.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | Realm enable state updated successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| realm | body | The name of the realm to be enabled or disabled. | Yes | string |
| enable | body | Set to `true` to enable the realm, or `false` to disable it. | Yes | boolean |


### 📝 How to Use the Endpoint

1. **Body**:
   - Specify the realm name and the desired enabled state. Example:

	```json
	{
        "realm": "my-realm",
        "enable": true
    }
	```