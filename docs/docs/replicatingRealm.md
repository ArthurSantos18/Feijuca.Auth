### ⚙️ Endpoint specification  

##### Method: POST
##### Path: /realms/replicate
##### Summary:

Replicates clients, client scopes, and other configurations to another existing realm (tenant).

##### Responses
| Code | Description |
| ---- | ----------- |
| 200 | Realm configuration replicated successfully. |
| 400 | The request was invalid or could not be processed. |
| 500 | An internal server error occurred while processing the request. |

##### Body definition

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| tenant | body | The name of the target tenant (realm) to which the configuration will be replicated. | Yes | string |
| replicationConfigurationRequest.includeClients | body | Indicates whether clients should be replicated. | Yes | boolean |
| replicationConfigurationRequest.includeClientRoles | body | Indicates whether client roles should be replicated. | Yes | boolean |
| replicationConfigurationRequest.includeClientScopes | body | Indicates whether client scopes should be replicated. | Yes | boolean |
| replicationConfigurationRequest.createAdminGroupWithAllRulesAssociated | body | Indicates whether an admin group with all roles associated should be created. | Yes | boolean |
| replicationConfigurationRequest.adminUser.username | body | The username of the admin user for the target realm. | Yes | string |
| replicationConfigurationRequest.adminUser.password | body | The password of the admin user for the target realm. | Yes | string |


### 📝 How to Use the Endpoint

1. **Body**:
   - Specify the target tenant and what should be replicated. Example:

	```json
	{
        "tenant": "target-realm",
        "replicationConfigurationRequest": {
            "includeClients": true,
            "includeClientRoles": true,
            "includeClientScopes": true,
            "createAdminGroupWithAllRulesAssociated": true,
            "adminUser": {
                "username": "admin",
                "password": "Admin@123"
            }
        }
    }
	```