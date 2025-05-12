#### Initialize Terraform:
```bash
    terraform init
```

#### Check the execution plan:
```bash
    terraform plan
```

#### Apply the configuration:
```bash
    terraform apply
```

#### Check terraform state:
```bash
    terraform state list
```

#### List the output:
```bash
    terraform output -json
```

#### Decode unicode sequence in eg. password:
```bash
    $raw = '"password-output-value"'  # include surrounding quotes
    $json = ConvertFrom-Json $raw
    $json
```

#### Import existing resource groug:
```bash
    terraform import azurerm_resource_group.rg /subscriptions/{subscription_id}/resourceGroups/taskmanagement_group
```
- Replace {subscription_id} with the actual Azure subscription ID.terraform import. 


##### Import Existing App Service into Terraform
```bash
    terraform import azurerm_app_service.api "/subscriptions/{subscription_id}/resourceGroups/taskmanagement_group/providers/Microsoft.Web/sites/taskmanagement"
```

- This tells Terraform: ***“Hey, I already have this app in Azure — start managing it.”***