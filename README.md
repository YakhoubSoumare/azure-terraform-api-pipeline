# Azure API Deployment with Terraform and GitHub Actions

This project contains a .NET 8 Web API deployed to Azure. It demonstrates infrastructure management using Terraform (executed locally), creation of Azure resources, and deployment automation with GitHub Actions.

## Features
- .NET 8 Web API structure
- Hosted on Azure Web App (Windows)
- Infrastructure defined using Terraform
- CI/CD pipeline using GitHub Actions
- Optional support for unit testing

## Project Structure
- `api/` – Source code for the Web API
- `terraform/` – Terraform configuration files for infrastructure
- `.github/workflows/` – GitHub Actions deployment workflow

## API Endpoint
The deployed application is a REST API. No HTML interface is served from the root URL `/`.

To access the API:
```
https://<app-name>.azurewebsites.net/api/TaskItems
```
Example (for current configuration):
```
https://taskmanagement-api-development.azurewebsites.net/api/TaskItems
```

Calling the root URL (`/`) returns HTTP 404, which is expected unless a specific route is added.

## CI/CD Pipeline

The GitHub Actions workflow:
- Restores NuGet dependencies
- Builds the .NET application
- Publishes the application to a folder
- Authenticates to Azure using a service principal
- Deploys the published output to Azure Web App

The workflow triggers on push to the `main` branch.

Unit test execution is included in the workflow file but commented out. It can be enabled if full CI is required.

## Requirements
- Azure subscription
- Azure service principal with contributor access
- GitHub repository secret: `AZURE_CREDENTIALS` (JSON from `az ad sp create-for-rbac`)

## Terraform

Terraform is used to define and manage Azure infrastructure. Configuration is executed locally to ensure control over changes.

The GitHub Actions workflow **does not** apply Terraform changes. This separation keeps application deployment and infrastructure management decoupled.

Optionally, the workflow can be extended to include `terraform init`, `plan`, and `apply` for full automation.

## Usage
1. Clone the repository
2. Add `AZURE_CREDENTIALS` as a secret in the GitHub repository
3. Push to the `main` branch to trigger the workflow
4. Run Terraform locally to manage infrastructure