CLEAR
p_kljniz:="STR(art)+nza+STR(knt)+STR(ozn)+STR(kol)"
p_brznak:=0
p_brznak:=LEN(p_kljniz)
p_radklj:=" "
FOR i3:=1 TO p_brznak
 p_kljniz:=" "
 p_znak:=" "
 p_oimklj:=" "
 p_kljniz:=LEFT(p_kljniz,p_brznak)
 p_znak:=RIGHT(p_kljniz,1)
 IF p_znak == ")"
  *** Da uzme sve u zagradi ***
  DO WHILE .T.
   * Uzmi sve u zagradi ! *
