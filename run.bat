@echo off

set IP=
for /f "tokens=2 delims=:" %%A in ('ipconfig ^| findstr /R "IPv4"') do (
    set IP=%%A
    goto :done
)
:done
set IP=%IP:~1%

echo Detected IP: %IP%

python -m fastapi dev simulator.py --host %IP% --port 8000
pause