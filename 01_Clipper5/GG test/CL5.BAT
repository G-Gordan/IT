cls
C:
cd C:\clipper5\bin
copy n:\GORDAN\%1.prg
call setc
call cl %1
copy %1.exe n:\GORDAN
del %1.exe
del %1.obj
n:
cd n:\GORDAN
