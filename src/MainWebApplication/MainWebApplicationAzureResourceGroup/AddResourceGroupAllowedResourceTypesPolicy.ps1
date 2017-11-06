#Powershell script to add a 'AllowedResourceTypes' policy on an Azure Resource Group.
#Note: If the policy already exists, it won't generate an error and won't create a duplicated entry neither.

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName
)

$allowedResourceTypesPolicy = '{
    "if": {
        "not": {
            "field": "type",
            "in": "[parameters(''allowedResourceTypes'')]"
        }
    },
    "then": {
        "effect": "deny"
    }
}';
$resourceTypesAllowedParameter = '{
    "allowedResourceTypes": {
        "type": "array",
        "metadata": {
          "description": "The list of resource types that can be specified when deploying any resources in this resource group.",
          "strongType": "type",
          "displayName": "Allowed resource types"
        }
    }
}';

#Login-AzureRmAccount;
#Select-AzureRmSubscription -SubscriptionId $SubscriptionId;

$definition = New-AzureRmPolicyDefinition -Name ResourceTypes -Description "Policy to specify resource types for any resources in this resource group." -Policy $allowedResourceTypesPolicy -Parameter $resourceTypesAllowedParameter;
$resourceGroup = Get-AzureRmResourceGroup -Name $ResourceGroupName;
$allowedResourceTypesArrayValue = @("microsoft.insights/components", "Microsoft.Web/serverFarms", "Microsoft.Web/sites", "Microsoft.Web/sites/slots", "Microsoft.Insights/alertrules", "Microsoft.Authorization/policyassignments");
$allowedResourceTypesParameterObject = @{"allowedResourceTypes"=$allowedResourceTypesArrayValue};
New-AzureRMPolicyAssignment -Name AllowedResourceTypesAssignment -Scope $resourceGroup.ResourceId -PolicyDefinition $definition -PolicyParameterObject $allowedResourceTypesParameterObject;