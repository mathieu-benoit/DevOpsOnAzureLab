#Powershell script to add a 'CanNotDelete' lock on an Azure Resource Group.
#Note: If the lock already exists, it won't generate an error and won't create a duplicated entry neither.

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName,
    [string] $LockName = 'DoNotDeleteLock'
)

#Login-AzureRmAccount;
#Select-AzureRmSubscription -SubscriptionId $SubscriptionId;
New-AzureRMResourceLock -LockName $LockName -LockLevel CanNotDelete -ResourceGroupName $ResourceGroupName -Force;