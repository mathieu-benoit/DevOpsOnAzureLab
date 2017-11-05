#Powershell script to add a 'AllowedLocations' policy on an Azure Resource Group.
#Note: If the policy already exists, it won't generate an error and won't create a duplicated entry neither.

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName,
    [string] $Location = 'eastus'
)

$allowedLocationsPolicy = '{
    "if": {
        "not": {
            "field": "location",
            "in": "[parameters(''allowedLocations'')]"
        }
    },
    "then": {
        "effect": "Deny"
    }
}';
$allowedLocationsParameter = '{
    "allowedLocations": {
        "type": "array",
        "metadata": {
          "description": "The list of locations that can be specified when deploying any resources in this resource group.",
          "strongType": "location",
          "displayName": "Allowed locations"
        }
    }
}';

#Login-AzureRmAccount;
#Select-AzureRmSubscription -SubscriptionId $SubscriptionId;

$definition = New-AzureRmPolicyDefinition -Name ResourcesLocations -Description "Policy to specify locations for any resources in this resource group." -Policy $allowedLocationsPolicy -Parameter $allowedLocationsParameter;
$resourceGroup = Get-AzureRmResourceGroup -Name $ResourceGroupName;
$allowedLocationsArrayValue = @($Location);
$allowedLocationsParameterObject = @{"allowedLocations"=$allowedLocationsArrayValue};
New-AzureRMPolicyAssignment -Name AllowedLocationsAssignment -Scope $resourceGroup.ResourceId -PolicyDefinition $definition -PolicyParameterObject $allowedLocationsParameterObject;