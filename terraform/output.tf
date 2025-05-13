# This outputs the generated resource group name in the console after deployment.


# Output for the resource group
output "resource_group_name" {
  value = azurerm_resource_group.rg.name
}

# Output for SQL Server name
output "sql_server_name" {
  value = azurerm_mssql_server.server.name
}

output "sql_admin_username" {
  value     = var.admin_username
  sensitive = true
}

# Output for the sensitive admin password (using the generated or provided one)
output "sql_admin_password" {
  sensitive = true
  value     = local.admin_password
}

output "sql_connection_string" {
  description = "Full connection string to the Azure SQL database"
  value = format(
    "Server=tcp:%s.database.windows.net,1433;Initial Catalog=%s;Persist Security Info=False;User ID=%s;Password=%s;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
    azurerm_mssql_server.server.name,
    azurerm_mssql_database.db.name,
    var.admin_username,
    local.admin_password
  )
  sensitive = true
}

output "web_app_url" {
  value = azurerm_windows_web_app.web_app.default_hostname
  description = "The default URL of the deployed web app"
}

# Sensitive outputs: admin username, password, connection string, and web app url.
# These values are required for application configuration and are built or retrieved from Terraform-managed resources.
# Use the command `terraform output <name>` to retrieve them after `terraform apply`.
# Sensitive values will be redacted in console output but are accessible programmatically.