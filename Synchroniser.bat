@echo off
pushd %~dp0
git add .
set /p message="Message du commit: "
git commit -m "%message%"
git pull
git push
echo.   
echo     --------------------
echo     FIN DE LA SAUVEGARDE
echo     --------------------
echo.   
pause
