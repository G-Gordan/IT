CLEAR
SELECT 1
USE ccc
m_upis:="D"
DO WHILE m_upis="D"
 CLEAR SCREEN
 @ 2,30   SAY "U P I S   P O D A T A K A   U   B A Z U  CCC !"
 m_art := 0
 m_ozn := 0
 m_kol := 0
 @ 10,2   SAY "Upis polja ATR n-10" GET m_art PICTURE " 9999999999";
          VALID(m_art # 0)
 @ 11,2   SAY "Upis polja OZN n-1"  GET m_ozn PICTURE "9";
          VALID(m_ozn # 0)
 @ 12,2   SAY "Upis polja KOL n-9_3"  GET m_kol PICTURE "99999999.999";
          VALID(m_kol # 0)
 READ
 APPEND BLANK
 REPLACE  art WITH m_art, ozn WITH m_ozn, kol WITH m_kol
 @ 15,2   SAY "Nastavljate upis (D/N?)" GET m_upis;
          PICTURE "!" VALID(m_upis $ "DdNn")
 READ
 ENDDO
@ 0,0 CLEAR
USE
QUIT




