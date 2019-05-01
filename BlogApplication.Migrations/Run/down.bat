setlocal
set PATH=%0\..\..\..\packages\FluentMigrator.Tools.1.6.2\tools\x86\40
migrate.exe -t rollback -c "BlogApplication" -a "../bin/Debug/BlogApplication.Migrations.dll" -db SqlServer2012
pause 0