### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /configs/existing-realm
##### Summary:

Use this endpoint when you already have a realm and wish to configure Feijuca Auth inside it.

##### Responses
| Code | Description |
| ---- | ----------- |
| 201 | Configuration applied to the existing realm successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| realmAdminUser.username | body | The username of the realm administrator. | Yes | string |
| realmAdminUser.password | body | The password of the realm administrator. | Yes | string |
| client.clientId | body | The client ID to be used for authentication. | Yes | string |
| clientSecret.clientSecret | body | The secret associated with the client. | Yes | string |
| serverSettings.url | body | The base URL of the Keycloak server. | Yes | string |
| realm.name | body | The name of the existing realm to be configured. | Yes | string |
| realm.issuer | body | The issuer URL of the realm. | No | string |


### 📝 How to Use the Endpoint

1. **Body**:
   - Provide the full configuration object targeting an existing realm. Example:

	```json
	{
        "realmAdminUser": {
            "username": "admin",
            "password": "Admin@123"
        },
        "client": {
            "clientId": "feijuca-client"
        },
        "clientSecret": {
            "clientSecret": "my-secret-value"
        },
        "serverSettings": {
            "url": "https://keycloak.example.com"
        },
        "realm": {
            "name": "my-existing-realm",
            "issuer": "https://keycloak.example.com/realms/my-existing-realm"
        }
    }
	```