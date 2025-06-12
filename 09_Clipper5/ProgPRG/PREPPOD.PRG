CLEAR
CLEAR SCREEN
DO WHILE .T.
  IF LASTKEY() = 27
   USE
   CLEAR
   QUIT
  ENDIF
 @ 2,4 SAY "Prebacujem iz CCC u AAA !"
 SELECT 1
 USE ccc
 m_art1 := art
 SELECT 2
 USE aaa
 m_art2 := art
 IF m_art1 = m_art2
  REPLACE ozn WITH A->ozn
  REPLACE kol WITH A->kol
  SKIP
  IF EOF()
   @ 12,2 SAY "Baza 1 je prosla !"
   USE
   CLEAR
   QUIT
  ENDIF
  SELECT 1
  SKIP  
  IF EOF()
   @ 12,3 SAY "Baza 2 je prosla !"
   USE
   CLEAR
   QUIT
  ENDIF
 ENDIF
ENDDO
USE
CLEAR
QUIT
     

