if(!(test-path ((get-location).path + '\assets'))) {
	return;
}

$assets = get-childItem -path 'assets'
$webPath = (Get-Item -path '*.Web').fullName

foreach($item in $assets)
{
	Copy-Item $item.FullName -destination $webPath -recurse -force
}