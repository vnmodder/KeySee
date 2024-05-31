cd squirrel-be

del /s /q .\publish\*

dotnet publish -p:PublishProfile=Staging --output .\publish

del /s /q .\publish\web.config

%systemroot%\system32\inetsrv\appcmd stop apppool /apppool.name:"api.squirrel.io.vn"

for /R "C:\Host\Squirrel\api.squirrel.io.vn" %%f in (*.*) do (
    if /I not "%%~nxf"=="web.config" del /s /f /q "%%f"
)

for /f %%d in ('dir /ad /b C:\Host\Squirrel\api.squirrel.io.vn') do (
    rd /s /q "C:\Host\Squirrel\api.squirrel.io.vn\%%d"
)

robocopy .\publish C:\Host\Squirrel\api.squirrel.io.vn /E

%systemroot%\system32\inetsrv\appcmd start apppool /apppool.name:"api.squirrel.io.vn"

exit 0 