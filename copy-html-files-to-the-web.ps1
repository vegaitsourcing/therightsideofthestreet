$html = Get-ChildItem -directory 'html'
$web = Get-Item -path '*.Web'
$skip = "_templates", "README.md", "robots.txt", "node_modules"

foreach($item in $html)
{
	if($skip -contains $item.Name)
	{
		continue;
	}
	Copy-Item $item.FullName -destination $web.FullName -recurse -force
}