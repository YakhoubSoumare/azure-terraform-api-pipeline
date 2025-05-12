# Azure CLI Guide for .NET API & SQL on Azure

## Login to Azure
Logs into the Azure account in the browser.

```bash
    az login
```
This will prompt a browser window to open for authentication.

If need to specify a particular tenant ID, use:
```bash
    az login --tenant <tenant_id>
```

Search for tenant properties in azure portal to find the `tenant ID`


## View Subscription
```bash
    az account show
    az account list --output table
```


## View Subscription
```bash
    az account set --subscription "<subscription-name-or-id>"
```


## Show the Web App (App Service)
```bash
    az webapp show --name <app-name> --resource-group <resource-group>
```

## Generating Azure Credentials for GitHub Actions
```bash
    az ad sp create-for-rbac --name "github-deploy" --role contributor --scopes /subscriptions/<your-subscription-id> --sdk-auth
```

- This command creates a service principal that authenticates with Azure. `--name` sets a custom name, and `--role contributor` grants resource management rights (excluding user/role control). 
- `--scopes` limits access to a specific subscription, and `--sdk-auth` outputs credentials in a GitHub Actions–compatible JSON format.
- Copy the output into a GitHub secret named `AZURE_CREDENTIALS` to enable authentication in your workflows.

## Deploy App Code via ZIP
```bash
    az webapp deployment source config-zip \
        --resource-group <resource-group> \
        --name <app-name> \
        --src <path-to-your-zip-file>
```


## View App Settings Configuration
```bash
    az webapp config appsettings list \
        --name <app-name> \
        --resource-group <resource-group>
```


## View Connection Strings Configuration
```bash
    az webapp config connection-string list \
        --name <app-name> \
        --resource-group <resource-group>
```


## View Azure SQL Server Firewall Rules
```bash
    az sql server firewall-rule list \
        --name <sql-server-name> \
        --resource-group <resource-group>
```


## Add Client IP to Azure SQL Firewall
```bash
    az sql server firewall-rule create \
        --resource-group <resource-group> \
        --server <sql-server-name> \
        --name AllowMyIP \
        --start-ip-address <your-ip> \
        --end-ip-address <your-ip>
```


## Delete a Firewall Rule
```bash
    az sql server firewall-rule delete \
        --resource-group <resource-group> \
        --server <sql-server-name> \
        --name AllowMyIP
```