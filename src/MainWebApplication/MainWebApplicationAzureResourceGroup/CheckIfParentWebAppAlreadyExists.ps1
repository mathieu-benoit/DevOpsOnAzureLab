#Powershell script to set the value of the 'ParentWebAppAlreadyExists' VSTS variable.
#If the WebApp exists, set the variable to false ; otherwise to true.

Param(
    [string] [Parameter(Mandatory=$true)] $WebAppName
)

#Login-AzureRmAccount;
#Select-AzureRmSubscription -SubscriptionId $SubscriptionId;
$webApp = Get-AzureRMWebApp -Name $WebAppName;
if ($webApp -ne $null) {
    Write-Output ("##vso[task.setvariable variable=ParentWebAppAlreadyExists;]false");
}
else{
    Write-Output ("##vso[task.setvariable variable=ParentWebAppAlreadyExists;]true");
}