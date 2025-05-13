# Define the Azure region
variable "resource_group_location" {
  type        = string
  default     = "swedencentral" # Closest Azure region for better latency
  description = "Location of the resource group."
}

# Prefix for resource group name, ensuring uniqueness
variable "resource_group_name_prefix" {
  type        = string
  description = "Prefix of the resource group name, ensuring uniqueness."
  default     = "rg"
}

# Administrator username for the SQL logical server (kept sensitive)
variable "admin_username" {
  type        = string
  description = "The administrator username of the SQL logical server."
  sensitive   = true
}

# Administrator password for the SQL logical server (kept sensitive)
variable "admin_password" {
  type        = string
  description = "The administrator password of the SQL logical server."
  sensitive   = true
  default     = null
}

# Length of the generated password (minimum length)
variable "password_length" {
  type        = number
  description = "Length of the generated password."
  default     = 10    # Ensures a default length of 10
}

# Define the environment (development, production, etc.)
variable "environment" {
  type        = string
  description = "The environment for deployment (e.g., development, production)"
  default     = "development"  # Default to development
}

# Allowed IPs
variable "appservice_outbound_ips" {
  type        = list(string)
  description = "List of outbound IPs from App Service that need access to the SQL Server."
}

# Name of Database
variable "sql_db_name" {
  type        = string
  description = "The name of the SQL Database."
}

variable "dotnet_version" {
  type        = string
  description = "The .NET version to run in App Service"
  default     = "v6.0"
}

variable "app_service_plan_sku_size" {
  type        = string
  description = "SKU size for App Service Plan"
  default     = "F1"
}

variable "connection_string_value" {
  type        = string
  description = "Connection string for the App Service"
  sensitive   = true
}