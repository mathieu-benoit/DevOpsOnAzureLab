#Powershell script to remove a 'CanNotDelete' lock on an Azure Resource Group.

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName,
    [string] $LockName = 'DoNotDeleteLock'
)

#Login-AzureRmAccount;
#Select-AzureRmSubscription -SubscriptionId $SubscriptionId;
Remove-AzureRmResourceLock -LockName $LockName -ResourceGroupName $ResourceGroupName -Force;