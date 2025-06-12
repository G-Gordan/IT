copy *.prg c:\clip5\bin
cd\
cd clip5\bin
clipper %1
if not errorlevel 1 rtlink file %1
del *.prg
del *.obj
copy %1.exe c:\gordan\progprg
del %1.exe
cd\ 
cd c:\gordan\progprg

