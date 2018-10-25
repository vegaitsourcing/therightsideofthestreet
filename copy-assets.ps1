param( 
	[string]$solutionDir
)

if(!(test-path $solutionDir)) {
	write-host ("Solution directory not found. Check path " + $solutionDir)
	return;
}

$web = Get-Item -path ($solutionDir + '\*.Web')
$assets = $solutionDir + '\assets'
if(!(test-path $assets)) {
	new-item -itemType directory -force -path $assets
} else {
	remove-item ($assets + '\*') -recurse
}

$itemsToCopy = "js", "css", "media"
foreach($item in get-childItem -path $web.fullName) {
	if($itemsToCopy -contains $item.name) {
		copy-item $item.fullName -destination $assets -recurse -force
	}
}