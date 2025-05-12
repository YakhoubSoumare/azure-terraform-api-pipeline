# Defines the required provider and its version
terraform {
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
            version = "~> 3.80.0"
        }
    }
    
    # Ensure Terraform version compatibility
    required_version = ">= 1.11.2"
}

# Configure the Azure provider
provider "azurerm" {
    features {} # Enables access to Azure resources
    skip_provider_registration = true       # Needed for student subscription to avoid blocked provider errors
}

# required_providers ensures we are using the azurerm provider for managing Azure resources.

# features {} is required but can later be customized (e.g., to prevent accidental deletions).