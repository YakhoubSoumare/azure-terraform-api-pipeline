# Defines the required provider and its version
terraform {
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
            version = "~> 3.0.2"
        }
    }
    
    # Ensure Terraform version compatibility
    required_version = ">= 1.11.2"
}

# Configure the Azure provider
provider "azurerm" {
    features {} # Enables access to Azure resources
}

# required_providers ensures we are using the azurerm provider for managing Azure resources.

# features {} is required but can later be customized (e.g., to prevent accidental deletions).