@echo off

REM Find the local IPv4 Address
set IP=
for /f "tokens=2 delims=:" %%A in ('ipconfig ^| findstr /R "IPv4"') do (
    set IP=%%A
    goto :done
)
:done
set IP=%IP:~1%

echo Detected IP: %IP%
echo Starting Simulator
REM Activate your virtual environment
call venv\Scripts\activate.bat

REM Run using uvicorn with SSL and Auto-Reload enabled
REM Replace 'simulator' with your actual main python filename if it is different
python -m uvicorn QRPH:app --host %IP% --port 8000 --ssl-keyfile .\key.pem --ssl-certfile .\cert.pem --reload

pause