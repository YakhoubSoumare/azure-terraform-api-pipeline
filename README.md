# Azure API Deployment with Terraform and GitHub Actions
This project is a simple .NET 8 Web API deployed to Azure. It demonstrates infrastructure management using Terraform (executed locally), creation of Azure resources, and deployment automation with GitHub Actions.

## Features
- Scaffolded .NET Web API
- Deployed to Azure Web App
- Infrastructure defined with Terraform
- Deployment pipeline using GitHub Actions
- Support for CI via optional unit testing

## Project Structure
- api/ – API source code
- terraform/ – Terraform configuration files
- .github/workflows/ – GitHub Actions workflow for deployment

## CI/CD Pipeline
The GitHub Actions workflow:
- Restores dependencies
- Builds the application
- Publishes the app for deployment
- Authenticates to Azure using a service principal
- Deploys to Azure Web App

Tests are currently commented out but can be enabled for full CI support.

Trigger: runs on push to the main branch.

## Requirements
- Azure subscription
- Azure service principal with contributor access
- GitHub secret: AZURE_CREDENTIALS (JSON output from az ad sp create-for-rbac)

## Terraform
Terraform is used to manage Azure infrastructure. Resources were created directly in code.

In this project, Terraform is executed **locally**. This ensures full control over infrastructure changes and allows testing before deployment.

While the GitHub Actions workflow handles application deployment, it does **not** apply infrastructure changes automatically.
You can optionally extend the workflow to include `terraform init`, `plan`, and `apply` if you want full automation.
This separation keeps infrastructure management and application deployment clearly decoupled.

## Usage
1. Clone this repository
2. Configure AZURE_CREDENTIALS secret in your GitHub repo
3. Push to main branch to trigger the workflow
4. Run Terraform to manage infrastructure
