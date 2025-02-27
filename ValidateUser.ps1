param (
	[string]$username,
	[string]$password
)

Import-Module ActiveDirectory

try{
	# Send username and password

	$credential = New-Object System.Management.Automation.PSCredential ($username, $password)

	# Connect to AD

	$contextType = [System.DirectoryServices.AccountManagement.ContextType]::Domain
	$principalContext = New-Object System.DirectoryServices.AccountManagement.PrincipalContext($contextType)
	$isValid = $principalContext.ValidateCredentials($username, $password)

	return $isValid

} catch {
	return $false
}