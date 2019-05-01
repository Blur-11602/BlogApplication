setlocal
set PATH=%0\..\..\..\packages\FluentMigrator.Tools.1.6.2\tools\x86\40
migrate.exe -c "BlogApplication" -a "../bin/Debug/BlogApplication.Migrations.dll" -db SqlServer2012 --profile=Development
pause 0