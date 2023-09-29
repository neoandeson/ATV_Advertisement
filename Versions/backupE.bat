@echo off
for /f "tokens=1-3 delims=/ " %%i in ("%date%") do (
     set day=%%i
     set month=%%j
     set year=%%k
)
set backupPath=E:/ATVData/Backup/atv_%day%_%month%_%year%.bak
SQLCMD -E -S QUANGCAO01\SQLEXPRESSATV2 -Q "BACKUP DATABASE ATV TO DISK='%backupPath%'"
echo BACKUP_SUCCESSFULLY
cmd /k