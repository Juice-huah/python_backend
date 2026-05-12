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
echo Starting Both Simulators...

REM Start the FIRST server (QRPH) in a new window on Port 8000
start "QRPH Simulator" cmd /k "call venv\Scripts\activate.bat && python -m uvicorn QRPH:app --host %IP% --port 8000 --ssl-keyfile .\key.pem --ssl-certfile .\cert.pem --reload"

REM Start the SECOND server (Interop) in a new window on Port 8001
start "Interop Simulator" cmd /k "call venv\Scripts\activate.bat && python -m uvicorn Interop:app --host %IP% --port 8001 --ssl-keyfile .\key.pem --ssl-certfile .\cert.pem --reload"

echo Servers are booting up in separate windows!
pause