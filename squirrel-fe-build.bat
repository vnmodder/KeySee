git checkout main
cd squirrel-fe
call npm -g install
call npm run build

for /R "C:\Host\Squirrel\squirrel.io.vn" %%f in (*.*) do (
    if /I not "%%~nxf"=="web.config" del /s /f /q "%%f"
)

for /f %%d in ('dir /ad /b C:\Host\Squirrel\squirrel.io.vn') do (
    rd /s /q "C:\Host\Squirrel\squirrel.io.vn\%%d"
)

robocopy dist C:\Host\Squirrel\squirrel.io.vn\ /E