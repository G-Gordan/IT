copy *.prg c:\gordan\clipper\bin
cd\
cd gordan\clipper\bin
clipper %1
if not errorlevel 1 rtlink file %1
cd\
cd c:\gordan\vezba
