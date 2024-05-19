cd squirrel-be

del /s /q .\publish\*

dotnet publish -p:PublishProfile=Staging --output .\publish

%systemroot%\system32\inetsrv\appcmd stop apppool /apppool.name:"api.squirrel.io.vn"

del /s /q C:\Host\Squirrel\api.squirrel.io.vn\*.!web.config

robocopy .\publish C:\Host\Squirrel\api.squirrel.io.vn /E /XF web.config

%systemroot%\system32\inetsrv\appcmd start apppool /apppool.name:"api.squirrel.io.vn"