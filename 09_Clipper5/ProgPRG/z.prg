
CLS
? "Aktivni direktorijum je: " + CURDIR()
*SUBSTR(CURDIR(),RAT("\",CURDIR()),-1)
INKEY(0)
QUIT
