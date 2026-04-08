### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /configs/new-realm
##### Summary:

Use this endpoint when you do not have a realm yet and wish to configure Feijuca Auth by creating a new realm.

##### Responses
| Code | Description |
| ---- | ----------- |
| 201 | Configuration applied and new realm created successfully. |
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
| realm.name | body | The name of the new realm to be created. | Yes | string |
| realm.issuer | body | The issuer URL of the new realm. | No | string |


### 📝 How to Use the Endpoint

1. **Body**:
   - Provide the full configuration object. A new realm will be created using the given settings. Example:

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
            "name": "my-new-realm",
            "issuer": "https://keycloak.example.com/realms/my-new-realm"
        }
    }
	```