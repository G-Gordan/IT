*************************************************
*** MATPOS  Za potrebe unosa materijalnog pos.***
*************************************************
CLEAR SCREEN
red=6
IF ! FILE("ddob.ntx")
  @red,10 SAY "indeksiranje DDOB po SFDOB"
  USE ddob
  INDEX ON sfdob TO ddob
ENDIF

IF ! FILE("dlok.ntx")
  red=red+1
  @red,10 SAY "indeksiranje DLOK po SFDOB"
  USE dlok
  INDEX ON sfdob TO dlok
ENDIF

IF ! FILE("dmat.ntx")
  red=red+1
  @red,10 SAY "indeksiranje DMAT po VK"
  USE dmat
  INDEX ON vk TO dmat
ENDIF

IF ! FILE("dour.ntx")
  red=red+1
  @red,10 SAY "indeksiranje DOUR po SFOUR"
  USE dour
  INDEX ON sfour TO dour
ENDIF

IF ! FILE("dstov.ntx")
  red=red+1
  @red,10 SAY "indeksiranje DSTOV po SFSTV"
  USE dstov
  INDEX ON sfstv TO dstov
ENDIF

IF ! FILE("grdati.ntx")
  red=red+1
  @red,10 SAY "indeksiranje GRDAT po NN"
  USE grdat
  INDEX ON nn TO grdati
ENDIF

IF ! FILE("u1dat.ntx")
  red=red+1
  @red,10 SAY "indeksiranje U1DAT po SFSTV+VK+BRDOK"
  USE u1dat
  INDEX ON STR(sfstv,3)+STR(vk,2)+STR(brdok,5) TO u1dat
ENDIF
set talk off
set bell off
set safety off
clear all
DO GL
clear
set color to /w
@  1,10 say 'ษออออออออออออออออออออออออออออออออออออออออออออออออออออออออออป'
@  2,10 say 'บ  ZTP Beograd - Sektor COK Beograd                        บ'
@  3,10 say 'บ                                                          บ'
@  4,10 say 'บ                                                          บ'
@  5,10 say 'บ                 U N O S    S L O G O V A                 บ'
@  6,10 say 'บ                                                          บ'
@  7,10 say 'บ                                                          บ'
@  8,10 say 'บ                                                          บ'
@  9,10 say 'บ                                                          บ'
@ 10,10 say 'บ                   K R A J    P O S L A                   บ'
@ 11,10 say 'บ                                                          บ'
@ 12,10 say 'บ                                                          บ'
@ 13,10 say 'บ                                                          บ'
@ 14,10 say 'บ                                                          บ'
@ 15,10 say 'บ                                                          บ'
@ 16,10 say 'บ                                                          บ'
@ 17,10 say 'บ                                                          บ'
@ 18,10 say 'บ                                                          บ'
@ 19,10 say 'บ                                                          บ'
@ 20,10 say 'ศออออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ'
set color to w

****************************************************
***  Glavni program za materijalno poslovanje    ***
****************************************************
PROCEDURE GL
set talk off
set bell off
set safety off
set scoreboard on
clear all
*---------------------------------------------------
select 5
* datoteka za uputstvo za rad
use matuput
****************************************************
declare TAB35[8]
TAB35[1]=899
TAB35[2]=614
TAB35[3]=650
TAB35[4]=655
TAB35[5]=699
TAB35[6]=799
TAB35[7]=800
TAB35[8]=040
declare TAB911[14]
TAB911[1]= 199
TAB911[2]= 299
TAB911[3]= 399
TAB911[4]= 499
TAB911[5]= 599
TAB911[6]= 604
TAB911[7]= 614
TAB911[8]= 650
TAB911[9]= 699
TAB911[10]=707
TAB911[11]=899
TAB911[12]=799
TAB911[13]=800
TAB911[14]=041
public in,ost,TAB35,TAB911,mmesto
ost=' '
public pol1,prevoz,porez,carina,matbr,vrdor
****************************************************
clear
set color to /w
@  1,10 say 'ษออออออออออออออออออออออออออออออออออออออออออออออออออออออออออป'
@  2,10 say 'บ  ZTP Beograd - Sektor COK Beograd                        บ'
@  3,10 say 'บ                                                          บ'
@  4,10 say 'บ                                                          บ'
@  5,10 say 'บ                  U N O S   S L O G O V A                 บ'
@  6,10 say 'บ                                                          บ'
@  7,10 say 'บ                                                          บ'
@  8,10 say 'บ                                                          บ'
@  9,10 say 'บ                                                          บ'
@ 10,10 say 'บ              M  A  T  E  R  I  J  A  L  N  O             บ'
@ 11,10 say 'บ                                                          บ'
@ 12,10 say 'บ                                                          บ'
@ 13,10 say 'บ                P  O  S  L  O  V  A  N J  E               บ'
@ 14,10 say 'บ                                                          บ'
@ 15,10 say 'บ                                                          บ'
@ 16,10 say 'บ                                                          บ'
@ 17,10 say 'บ                                                          บ'
@ 18,10 say 'บ                                                          บ'
@ 19,10 say 'บ                                                          บ'
@ 20,10 say 'ศออออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ'
set color to w
 do cekaj
Rad1 = .T.
store ' ' to f1
do while Rad1
 *---------------------------------------------------------
 select 1
 * datoteka za unos slogova
 use u1dat
 pack
 brsl=lastrec()
*-----
 if brsl<4000
  *--- moze jos da unosi - ima mesta na disketi
  ind40=0
 else
  *--- nema vise unosa - mora da konvertuje banku
  ind40=1
 endif
*-----

 clear
 f1 = ' '
 if ind40=1
  ?? chr(7)
  set color to /w
  @ 21,10 say '  U banku MATERIJALNOG POSLOVANJA je upisano 4000 slogova   '
  @ 22,10 say '        Izvrsi KONVERZIJU u sekvencijalnu datoteku          '
  set color to w
 endif
 do FTL1
 Rad10 = .T.
 do while Rad10
   read
   Rad10 = .F.
   do case
    case f1 = '1'
     if ind40=1
      *--- nema vise unosa - mora da konvertuje banku
      exit
     endif
     *** unos slogova
     do CC1
    case f1 = '2'
     *** ispravka gresaka
     do CC2
    case f1 = '3'
     *** stampanje liste pogresnih slogova
     do CC3
    case f1 = '4'
     *** konvertovanje u .txt datoteku i brisanje banke
     @ 21,01 clear
     select 1
     use u1dat
     go bottom
     brsl = recno()
     if eof()
        *** nema slogova u U1DAT.DBF
        ?? chr(7)
        set color to /w
        @ 22,16 say ' Banka je PRAZNA ! Proveri ________.TXT file ! '
        set color to w
        do cekaj
     else
      *** ima slogova u U1DAT.DBF
      ?? chr(7)
      I=0
      STRVREME=TIME()
      @ 21,10 say 'START: '+STRVREME
      do while .t.
       *** formiraj jedinstveno ime TXT datoteke
       store '     ' to DATTXT
       DATTXT='M'+substr(DTOC(DATE()),4,2)+substr(TIME(),4,2)
       *** formirano je neko ime za TXT datoteku
       DAT=upper(trim(DATTXT))+'.TXT'
       if file ('&DAT')
          *** duplo ime TXT datoteke
          I=I+1
          VREME=TIME()
          @ 21,30 say 'VREME: '+VREME
          if i>600
           *** proslo tri minuta !
           ?? chr(7)
           ?? chr(7)
           set color to /w
           @ 22,29 say ' KONVERTOVANJE NIJE USPELO ! OBRISI DISK PA PONOVI '
           @ 24,29 say ' ENTER (ฤู)    '
           set color to w
           ?? chr(7)
           DIRKA=0
           do while DIRKA <> 13
            DIRKA=inkey()
           enddo
           exit
          else
           *** probaj jos
           loop
          endif
       else
          *** ime TXT datoteke je jedinstveno
          ?? chr(7)
          set color to /w
          @ 22,29 say ' Ukupno unetih slogova: '+str(BRSL,4)+' '
          @ 22,60 say ' '+DAT
          @ 22,10 say ' '+chr(25)+' konvertujem '+chr(25)+' '
          set color to w
          set talk on
          copy to &DATTXT sdf
          set talk off
          ?? chr(7)
          set color to /w
     @ 24,10 say '      PREPISI POTREBNE PODATKE I PRITISNI ENTER  (ฤู)      '
          set color to w
          DIRKA=0
          do while DIRKA <> 13
           DIRKA=inkey()
          enddo
          zap
          exit
        endif
      enddo
     endif
     Rad1 = .F.
    case f1 = '5'
     *** uputstvo za rad
     select 5
     use matuput
     do UPUT

    case f1 = '6'
     *** unos novog stovarista ili lokomotive
     do UNSTVLOK

    case f1 = '7'
     *** kraj posla
     Rad1 = .F.
    otherwise
     ?? chr(7)
     *** pogresan izbor
     set color to /w
     @ 22,18 say ' Moguci izbor je 1,2,3,4,5 ili 6 -> kraj '
     set color to w
     do cekaj
     @ 22,1 clear
     f1 = ' '
     @ 19,43 get f1 picture '!'
     Rad10 = .T.
    endcase f1
  enddo Rad10
enddo Rad1
RETURN
*
PROCEDURE CEKAJ
*** Omogucuje zastoj prikaza na ekranu
?? inkey(3)
*STORE 1 TO X
*DO WHILE X < 700
*   X = X + 1
*ENDDO
RETURN
*
PROCEDURE UPUT
************** UPUTSTVO:  Za potrebe listanja uputstva za unos      ***
CLEAR
SET COLOR TO /W
@ 1,3  SAY '          U P U T S T V O   Z A   U N O S   P O D A T A K A'
@ 1,62 SAY '           '
SET COLOR TO W
GO TOP
DO WHILE .NOT. EOF()
   *** prikazuje slogove sve dok ne dodje do kraja datoteke
   @ 3,1 CLEAR
   k=2
   DO WHILE .NOT. EOF() .AND. k<22
      *** prikazuje 20 redova po ekranu
      @ k+1,1 SAY red
      SKIP
      k=k+1
   ENDDO
SET COLOR TO /W
@ 24,4 SAY ' SCROLL: gore () , dole () ,'
@ 24,33 SAY ' P-pocetak , K-kraj a ENTER za prekid ! '
SET COLOR TO W
DIRKA=0
DO WHILE .T.
   DIRKA=inkey()
   DO CASE
    CASE DIRKA=13
      EXIT
    CASE DIRKA=5  .or. DIRKA=56
      SKIP -30
      EXIT
    CASE DIRKA=24 .or. DIRKA=50
      SKIP -10
      EXIT
    CASE DIRKA=80 .or. DIRKA=112
      GO TOP
      EXIT
    CASE DIRKA=75 .or. DIRKA=107
      GO BOTTOM
      SKIP -10
      EXIT
    OTHERWISE
      LOOP
   ENDCASE
ENDDO
IF DIRKA=13
   EXIT
ENDIF
ENDDO
RETURN
*
PROCEDURE FTL1
******************** FTL1.PRG  (primarni menu-tovarni list)
@  1,10 say 'ษออออออออออออออออออออออออออออออออออออออออออออออออออออออออออป'
@  2,10 say 'บ       M A T E R I J A L N O    P O S L O V A N J E       บ'
@  3,10 say 'ฬออออออออออออออออออออออออออออออออออออออออออออออออออออออออออน'
@  4,10 say 'บ                    Izbor  poslova:                       บ'
@  5,10 say 'บ                                                          บ'
@  6,10 say 'บ              ( 1 ) UNOS SLOGOVA ( uneto:      )          บ'
@  7,10 say 'บ                                                          บ'
@  8,10 say 'บ              ( 2 ) ISPRAVKA / BRISANJE SLOGOVA           บ'
@  9,10 say 'บ                                                          บ'
@ 10,10 say 'บ              ( 3 ) STAMPANJE SLOGOVA                     บ'
@ 11,10 say 'บ                                                          บ'
@ 12,10 say 'บ              ( 4 ) KRAJ OBRADE MATERIJALNOG POSLOVANJA   บ'
@ 13,10 say 'บ                    (konvertovanje,brisanje)              บ'
@ 14,10 say 'บ                                                          บ'
@ 15,10 say 'บ              ( 5 ) UPUTSTVO ZA RAD                       บ'
@ 16,10 say 'บ                                                          บ'
@ 17,10 say 'บ              ( 6 ) UNOS LOKOMOTIVA I STOVARISTA          บ'
@ 18,10 say 'บ                                                          บ'
@ 19,10 say 'บ              ( 7 ) Kraj  posla                           บ'
@ 20,10 say 'บ                                                          บ'
@ 21,10 say 'บ                    Tvoj izbor:' get f1 picture '!'
@ 21,69 say 'บ'
@ 22,10 say 'ศออออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ'
@  6,53 say str(brsl,4)
RETURN
*
PROCEDURE FTL2
******************** FTL2.PRG  (primarni menu-ispravke gresaka)
@  1,10 say 'ษออออออออออออออออออออออออออออออออออออออออออออออออออออออออออป'
@  2,10 say 'บ       M A T E R I J A L N O    P O S L O V A N J E       บ'
@  3,10 say 'ฬอออออออออออออออ ISPRAVKA / BRISANJE SLOGOVA ออออออออออออออน'
@  4,10 say 'บ                                                          บ'
@  5,10 say 'บ                    Izbor  poslova:                       บ'
@  6,10 say 'บ                                                          บ'
@  7,10 say 'บ              ( 1 ) AUTOMATSKO LISTANJE NEISPRAVNIH       บ'
@  8,10 say 'บ                    SLOGOVA I ISPRAVKA / BRISANJE         บ'
@  9,10 say 'บ                                                          บ'
@ 10,10 say 'บ                                                          บ'
@ 11,10 say 'บ              ( 2 ) PRIKAZ SLOGA PO UNETOM REDNOM         บ'
@ 12,10 say 'บ                    BROJU SLOGA I ISPRAVKA / BRISANJE     บ'
@ 13,10 say 'บ                                                          บ'
@ 14,10 say 'บ                                                          บ'
@ 15,10 say 'บ              ( 6 ) KRAJ POSLA                            บ'
@ 16,10 say 'บ                                                          บ'
@ 17,10 say 'บ                                                          บ'
@ 18,10 say 'บ                                                          บ'
@ 19,10 say 'บ                    Tvoj izbor:' get f2 picture '!'
@ 19,69 say 'บ'
@ 20,10 say 'ศออออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ'
RETURN
*
PROCEDURE FTL3
******************** FTL3.PRG  (primarni menu-stampanje slogova)
@  1,10 say 'ษออออออออออออออออออออออออออออออออออออออออออออออออออออออออออป'
@  2,10 say 'บ       M A T E R I J A L N O    P O S L O V A N J E       บ'
@  3,10 say 'ฬอออออออออออออออออออ STAMPANJE SLOGOVA ออออออออออออออออออออน'
@  4,10 say 'บ                                                          บ'
@  5,10 say 'บ                    Izbor  poslova:                       บ'
@  6,10 say 'บ                                                          บ'
@  7,10 say 'บ              ( 1 ) STAMPANJE                             บ'
@  8,10 say 'บ                    NEISPRAVNIH SLOGOVA                   บ'
@  9,10 say 'บ                                                          บ'
@ 10,10 say 'บ                                                          บ'
@ 11,10 say 'บ              ( 2 ) STAMPANJE SVIH                        บ'
@ 12,10 say 'บ                    (ISPRAVNIH I NEISPRAVNIH) SLOGOVA     บ'
@ 13,10 say 'บ                                                          บ'
@ 14,10 say 'บ                                                          บ'
@ 15,10 say 'บ              ( 6 ) KRAJ POSLA                            บ'
@ 16,10 say 'บ                                                          บ'
@ 17,10 say 'บ                                                          บ'
@ 18,10 say 'บ                                                          บ'
@ 19,10 say 'บ                    Tvoj izbor:' get f3 picture '!'
@ 19,69 say 'บ'
@ 20,10 say 'ศออออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ'
RETURN
*
*********************************************************************
PROCEDURE CC1
select 3
* datoteka za mesto unosa
use mesto
*--- 1) unos slogova
      clear
      select 1
      rad9=.t.
   f=chr(24)
   s=chr(26)
      i24=1
      zto=0
      mvk=0
      msfour=0
      msfstv=0
      msfdob=0
      mbrdok=0
      mmesec=0
      mmesto=SPACE(4)
      mmesto=C->mesto

*--- ZTO - mora da bude ispravno
      do while .T.
       @ 01,03 say 'ZTO - ' get zto picture '9'
       read
       if 1<=zto .and. zto<=4
        exit
       else
        ? chr(7)
        set color to /w
        @ 23,01 say ' ZTO MORA BITI IZMEDJU 1 I 4 '
        set color to w
        loop
       endif
      enddo
      @ 23,01 clear
*---
      sfstv1=0
  *------------------------- unos jednog dokumenta
      do while rad9
         select 1
         use u1dat
         append blank
         bsl=recno()
         if bsl > 4000
          *--- uneto je dovoljno slogova za 1 punu disketu - konvertuj
          delete
          pack
          ind40=1
          exit
         endif
         @ 01,40 say 'SLOG BROJ '+str(bsl,5)
         @ 01,74 say mmesto
*-------------------------------
         fun=chr(24)
         @ 5,1 say ' '
  do while .t.
   *--- unos zaglavlja sa eventualnim ispravkama
     gres=' '
*--- VK - mora da bude ispravno
         do while .T.
          vk1='  '
          @ 03,01 say 'VK ' get vk1 picture '!9'
          read
          if substr(vk1,1,1) $ 'Kk0123456789'
           *--- 1. pozicija u vk je ispravno uneta
           if substr(vk1,1,1) $ 'Kk'
            *--- kraj unosa
            exit
           endif
          else
           *--- 1. pozicija u vk nije ispravno uneta
           loop
          endif
          replace vk with val(vk1)
          in='n'
          do KTABV
          if in='n'
           *--- nije pronadjen u tabeli
           loop
          else
           *--- nadjen u tabeli
           exit
          endif
         enddo
         @ 22,01 clear
*---
         if substr(vk1,1,1) $ 'Kk'
          *--- kraj unosa
          delete
          pack
          exit
         endif
*--- VK je unet ispravno, idemo dalje ...
         if vk=mvk
          replace sfour with msfour,sfstv with msfstv,sfdob with msfdob,;
                  brdok with mbrdok,mesec with mmesec,mesto with mmesto
         else
          sfstv1=0
         endif
         if vk=24 .and. i24=2
          gres=gres1
         else
          gres1=' '
          do MZAGZ
         *if zto=1
         * replace sfour with 899
         *endif
          do MZAGG
         endif
   *---------------------
   DO CFUN1 WITH 5,1
   if fun=chr(24)
    *--- nema ispravki
    @ 5,1 say s
    GRESZ=trim(gres)
    exit
   else
    *--- ima ispravki
    @ 5,1 say f
    loop
   endif
   *---------------------
  enddo
  if substr(vk1,1,1) $ 'Kk'
   *--- prekid unosa
   exit
  endif
*-------------------------------
*--- unos stavki ---------------
         do MREDZ
         red=10
         ima='D'
       do while red<22
*--------------------------------------
       @ red,5 say ' '
       fun=chr(26)
  do while .t.
   *--- unos stavki i eventualne ispravke
        gres=' '
          osn2=' '
          do case
           case vk=1.or.vk=2.or.vk=3.or.vk=4.or.vk=5.or.;
                vk=30.or.(vk=24.and.i24=2)
                osn1='0'
           case vk=10.or.vk=11.or.vk=12.or.vk=13.or.vk=14.or.;
                vk=20.or.vk=21.or.vk=23.or.(vk=24.and.i24=1)
                osn1='1'
           otherwise
                osn1=' '
          endcase
          osnn=osn1+osn2
          replace osn with osnn
  *--- OSN - ne mora da bude ispravan
          i=0
          do while .T.
           i=i+1
           @ red,07 get osn
           read
           osn1=substr(osn,1,1)
           osn2=substr(osn,2,1)
           if ( osn1 $ 'Kk' .and. osn2 $ ' 0123456789' ) .or. ;
              ( osn1 $ '0123456789' .and. osn2 $ '0123456789' )
              *--- 1. i 2. cifra osnova je ispravna
              if   osn1 $ 'Kk'
               *--- nece vise da unosi ...
               exit
              else
               *--- proveri OSN
               in='n'
               do KOSN with in
               if in='n'
                *--- neispravan osn
                if i=3
                 *--- neka ide dalje
                 gres=trim(gres)+'O'
                 exit
                else
                 *--- neka se popravi
                 loop
                endif
               else
                *--- ispravan osn
                exit
               endif
              endif
           else
              *--- 1. i/iil 2. cifra osnova nije ispravna
              ?? chr(7)
              loop
           endif
          enddo
          @ 22,01 clear
  *---
          if osn1 $ 'Kk'
           *--- nece vise da unosi
           red=99
           delete
           pack
           @ 6,1 clear
           exit
          endif
          *--- nastavlja sa unosom stavki
          do MREDG
   DO CFUN2 WITH red,5
   if fun=' '
    *--- hoce da ispravlja stavku
    @ red,5 say s
    loop
   else
    *--- ide na sledecu stavku
    @ red,5 say ' '
    GRESS=trim(gres)
    exit
   endif
  enddo
  if osn1 $ 'Kk'
   *--- prekida unos stavki
   exit
  endif
*--------------------------------------
          gres=trim(GRESZ)+trim(GRESS)
          replace greska with gres,ostatak with ost,slnum with recno(),;
                  mesto with mmesto
          append blank
          bsl=recno()
          if bsl > 4000
           *--- uneto je dovoljno slogova za 1 punu disketu - konvertuj
           delete
           pack
           ind40=1
           rad9=.f.
           exit
          endif
          replace vk with mvk,sfour with msfour,sfstv with msfstv,;
                 sfdob with msfdob,brdok with mbrdok,mesec with mmesec,;
                 mesto with mmesto
          gres=gres1
          @ 01,40 say 'SLOG BROJ '+str(bsl,5)
          red=red+1
          if red=22
           red=10
           @ 10,1 clear
          endif
         enddo red
         @ 23,05 clear
         if vk=24 .and. i24=2
          replace vk with mvk
         endif
      enddo rad9
      close databases
RETURN
*
PROCEDURE CC2
*--- 2) ispravka/brisanje slogova
do while .t.
        clear
        f2=' '
        do FTL2
        do while .t.
         read
         if ( f2='1' .or. f2='2' .or. f2='6' )
          *--- ispravan izbor
          exit
         else
          *--- neispravan izbor
          ?? chr(7)
          set color to /w
          @ 22,19 say '  Moguci izbor je  1,2  ili  6 -> kraj  '
          set color to w
          do cekaj
          f2=' '
          @ 22,01 clear
          @ 19,43 get f2 picture '!'
          loop
         endif
        enddo
 if f2 <> '6'
  *--- izbor je 1,2 -> radi ...
        select 1
        use u1dat
        do case
           case f2='1'
            *--- listanje datoteke neispravnih i ispravka
                go top
                locate for greska <> ' '
                if .not.eof()
                   rad9=.t.
                else
                   rad9=.f.
                   ?? chr(7)
                   set color to /w
                   @ 22,20 say ' U DATOTECI NEMA NEISPRAVNIH SLOGOVA '
                   set color to w
                   do CEKAJ
                   clear
                endif
           case f2='2'
            *--- prikaz slogova po rednim brojevima
                rad9=.t.
                bsl1=lastrec()
                bsl=0
                do PROCRBS
        endcase
        i24=1
        do while rad9
           @ 01,01 clear
           bsl=recno()
           @ 01,40 say 'SLOG BROJ '+str(bsl,4)
           @ 03,01 say 'VK  ' + str(vk,2)
           fun=chr(24)
           do MZAGZ
           set color to /w
           @ 01,50 say str(bsl,4)
           @ 03,05 say str(vk,2)
           @ 03,16 say str(sfour,3)
           @ 03,28 say str(sfstv,3)
           sfdob1=str(sfdob,6)
           if vk=20
              @ 03,45 say substr(sfdob1,4,3)
           else
              @ 03,42 say sfdob1
           endif
           @ 03,61 say str(brdok,5)
           @ 03,76 say str(mesec,2)
           set color to w
           if vk=24
              if substr(ostatak,10,30) = space(21)
                 i24=2
              else
                 i24=1
              endif
           endif
           do MREDZ
           do MREDG2
           if greska=' '
            *--- ovaj slog je ispravan
            if deleted()
             poruka=' OVAJ SLOG JE ISPRAVAN - VEC JE OBRISAN '
            else
             poruka=' OVAJ SLOG JE ISPRAVAN '
            endif
           else
            *--- ovaj slog nije ispravan
            if deleted()
             poruka=' OVAJ SLOG NIJE ISPRAVAN - VEC JE OBRISAN '
            else
             poruka=' OVAJ SLOG NIJE ISPRAVAN '
            endif
           endif
           set color to /w
           @ 22,01 say PORUKA
           set color to w
           abi='A'
           @ 12,10 say 'ZELITE LI DA OVAJ SLOG :'
           @ 14,10 say '       - AZURIRATE   (A)'
           @ 16,10 say '       - BRISETE     (B)'
           @ 18,10 say '       - IGNORISETE  (I)'
           do while .t.
              @ 20,10 say 'VAS IZBOR JE : ' get abi
              read
              if upper(abi)='A' .or. upper(abi)='B'.or. upper(abi)='I'
                 exit
              endif
           enddo
           do case
              case upper(abi)='A'
                   if F2="1"  &&-automatski neispravne
                    do ISPGR
                   else  &&-po broju ispravne/neispravne
                    do ISPGR2
                   endif
              case upper(abi)='B'
                   delete
              otherwise
           endcase
           dane='D'
           @ 23,01 say 'ZELITE LI DA NASTAVITE ISPRAVKU SLOGOVA (D/N) ?'
           do while .t.
            @ 23,49 get dane
            read
            if dane $ 'DdNn'
             *--- ispravan izbor
             exit
            else
             *--- pogresan izbor
             ?? chr(7)
             loop
            endif
           enddo
           if upper(dane)='N'
              rad9=.f.
           else
            *--- Da-hoce da nastavi sa ispravkom
              if f2='1'
                 continue
                 if eof()
                    rad9=.f.
                    @ 1,1 clear
                    set color to /w
                    @ 12,25 say ' STIGLI STE DO KRAJA DATOTEKE '
                    set color to w
                    do CEKAJ
                 endif
              else
                 do PROCRBS
              endif
           endif
        enddo rad9
        close databases
 else
  exit
 endif
enddo
RETURN
*
PROCEDURE CC3
do while .t.
 clear
 f3=' '
 do FTL3
 do while .t.
  read
  if ( f3='1' .or. f3='2' .or. f3='6' )
   *--- ispravan izbor
   exit
  else
   *--- neispravan izbor
   ?? chr(7)
   set color to /w
   @ 22,19 say '  Moguci izbor je  1,2  ili  6 -> kraj  '
   set color to w
   do cekaj
   f3=' '
   @ 22,01 clear
   @ 19,43 get f3 picture '!'
   loop
   endif
  enddo
  if f3='1'
   *--- stampanje pogresnih slogova
   do CC31
  endif
  if f3='2'
   *--- stampanje ispravnih i pogresnih slogova
   do CC32
  endif
  if f3='6'
   *--- kraj stampanja
   exit
  endif
enddo
RETURN
*
PROCEDURE CC31
*--- 3.1) stampanje neispravnih slogova
       clear
       *--- datoteka za smestanje pogresnih slogova
        select 2
        use GRDAT
        zap
       *--- datoteka unetih slogova (pogresni i ispravni)
        select 1
        use U1DAT
        locate for GRESKA # ' '
        if eof()
         clear
         set color to /w
         @ 15,20 say ' U DATOTECI NEMA NEISPRAVNIH SLOGOVA '
         set color to w
         do CEKAJ
         clear
         return
        endif
        set color to /w
        @ 12,25 say '                            '
        @ 13,25 say ' SACEKAJ  -  R A D I M  !!! '
        @ 14,25 say '                            '
        set color to w
        go top  &&-U1DAT
        do while ! eof()
         if GRESKA=" "
          skip
          loop
         endif
         *-pogresan -> spremi ga za stampu (prepisi u GRDAT)
         bslt=recno()
         vk1=str(vk,2)
         sfour1=str(sfour,3)
         sfstv1=str(sfstv,3)
         sfdob1=str(sfdob,6)
         brdok1=str(brdok,5)
         mesec1=str(mesec,2)
         ourz=' '
         stvz=' '
         dobz='   '
         bdokz='  '
         mesz=' '
         sgr=substr(greska,1,1)
         i=1
         ostg=' '
         ostgz=' '
         do while sgr # ' '
          *--- oznaci sva pogresna polja
          ost1=' '
          ostz1=' '
          do case
             case sgr='1' .or. sgr='2'
                  ourz='***'
             case sgr='S'
                  stvz='***'
             case sgr='W'
                  ourz='***'
                  stvz='***'
             case sgr='X' .or. sgr='L' .or. sgr='T'.or. sgr='D'
                  dobz='******'
             case sgr='B'
                  bdokz='*****'
             case sgr='M'
                  mesz='**'
             case sgr='O'
                  ost1='***'+osn+'**'
                  ostz1='*OSNOV*'
             case sgr='I'
                  ost1='*'+str(broj,10)+'*'
                  ostz1='*BROJ IZ IM*'
             case sgr='K'
                  ost1='*'+str(kol,8)+'*'
                  ostz1='*KOLICINA*'
             case sgr='F'
                  ost1='*'+substr(ostatak,1,11)+'*'  &&-9+2
                  ostz1='* FAKTURNA*'
             case sgr='Z'
                  ost1='*'+substr(ostatak,12,7)+'*' &&-pomereno +2
                  ostz1='* PREVOZ*'
             case sgr='E'
                  if vk=12
                   ost1='*'+substr(ostatak,12,7)+'*'  &&+2
                  else
                   ost1='*'+substr(ostatak,19,7)+'*'  &&+2
                  endif
                  ostz1='* POREZ *'
             case sgr='C'
                  ost1='*'+substr(ostatak,26,8)+'*'  &&+2
                  ostz1='* CARINA *'
             case sgr='R'
                  ost1='*'+substr(ostatak,1,11)+'*'  &&-9+2
                  ostz1='*KONTO RAD*'
             case sgr='P'
                  ost1='*'+substr(ostatak,1,11)+'*'  &&-9+2
                  ostz1='* PROSECNA*'
             case sgr='J'
                  ost1='*'+substr(ostatak,1,11)+'*'  &&-9+2
                  ostz1='* PRODAJNA*'
             case sgr='G'
                  ost1='*'+substr(ostatak,19,7)+'*'  &&+2
                  ostz1='*VRE.DOR*'
          endcase
          ostg=trim(ostg)+ost1
          ostgz=trim(ostgz)+ostz1
          i=i+1
          sgr=substr(greska,i,1)
         enddo
         *--- prepis izdvojenog,pogresnog sloga u DATGR
         select 2  &&-GRDAT
         append blank
         *--- prepis podataka iz sloga
         replace nn with bslt,brslog with str(bslt,5),vk with vk1,;
            sfour with sfour1,sfstv with sfstv1,sfdob with sfdob1,;
            brdok with brdok1,mesec with mesec1,ostatak with ostg,;
            mesto with mmesto
         append blank
         *--- upis poruka o greskama
         replace nn with bslt,brslog with '     ',vk with '  ',;
              sfour with ourz,sfstv with stvz,sfdob with dobz,;
              brdok with bdokz,mesec with mesz,ostatak with ostgz,;
              mesto with mmesto
         select 1  &&-U1DAT
         skip
        enddo
        *--- odstampaj izdvojene pogresne slogove,ili ne
        ?? chr(7)
        select 2
        use GRDAT
        brojgr=lastrec()/2
        set color to /w
        @ 15,25 say '                            '
        @ 16,25 say ' UKUPNO POGRESNIH:   '+str(brojgr,4)+'   '
        @ 17,25 say '                            '
@ 20,10 say '  Ukljuci stampac (ako nije ukljucen), podesi papir i ako  '
@ 21,10 say ' zelis stampu pritisni  ENTER , inace pritisni  ESC  dirku '
        set color to w
        DIRKA=0
        do while (DIRKA<>13 .and. DIRKA<>27)
         DIRKA=inkey()
        enddo
        if DIRKA=13
         *--- ENTER(13) - hoce da odstampa listu
         clear
         set console off
         report form IZVES to print
         set console on
        endif
close databases
RETURN
*
PROCEDURE CC32
*--- 3.2) stampanje svih (ispravnih i neispravnih) slogova
       clear
       *--- datoteka unetih slogova (pogresni i ispravni)
        select 2
        use U1SORT
        zap
        select 1
        use U1DAT
        brojsv=lastrec()
        if brojsv>0
         *--- ima slogova u datoteci U1DAT
         set color to /w
         @ 12,25 say '                            '
         @ 13,25 say ' SACEKAJ  -  R A D I M  !!! '
         @ 14,25 say '                            '
         set color to w
         index on str(SFSTV,3)+str(VK,2)+str(BRDOK,5) to U1DAT
         use U1DAT index U1DAT
         do while ! eof()
          ASLOG=recno()
          select 2  &&-U1sort
          append blank
          replace VK with A->VK,SFOUR with A->SFOUR,SFSTV with A->SFSTV,;
            SFDOB with A->SFDOB,BRDOK with A->BRDOK,MESEC with A->MESEC,;
            OSN with A->OSN,BROJ with A->BROJ,KOL with A->KOL,;
            OSTATAK with A->OSTATAK,GRESKA with A->GRESKA,SLNUM with ASLOG
          select 1  &&-U1dat
          skip
         enddo
         ?? chr(7)
         set color to /w
         @ 15,25 say '                            '
         @ 16,25 say ' UKUPNO SLOGOVA :    '+str(brojsv,4)+'   '
         @ 17,25 say '                            '
@ 20,10 say '  Ukljuci stampac (ako nije ukljucen), podesi papir i ako  '
@ 21,10 say ' zelis stampu pritisni  ENTER , inace pritisni  ESC  dirku '
         set color to w
         DIRKA=0
         do while (DIRKA<>13 .and. DIRKA<>27)
            DIRKA=inkey()
         enddo
         if DIRKA=13
          *--- ENTER(13) - hoce da odstampa listu
          clear
          select 2
          use U1SORT
          set console off
          report form IZVSVI to print
          set console on
         endif
        else
         *--- nema slogova u datoteci U1DAT
         set color to /w
         @ 15,20 say ' U DATOTECI NEMA NEISPRAVNIH SLOGOVA '
         set color to w
        endif
close databases
RETURN
*
*********************************************************************
PROCEDURE UPSTVLOK







RETURN
*********************************************************************
PROCEDURE MZAGG
if zto=1
 *--- SFOUR - ne mora da bude ispravna,0-u+i
  *do KUSL with 0,03,16,'sfour',899,899,'1','NA SIFRA OUR-a - POTVRDI '
   do KUSL35 with 0,03,16,'sfour',614,899,'1','NA SIFRA OUR-a - POTVRDI '
 *--- SFSTV - ne mora da bude ispravna,0-u+i
   do K1   with 0
 *---
else
 *--- SFOUR,SFSTV - ne moraju da budu ispravni
   do KM10OD with 0,'W'
 *---
endif
*
mvk=vk
msfour=sfour
msfstv=sfstv
*
do case
   case vk=2.or.vk=3.or.vk=4.or.vk=9.or.vk=10.or.vk=14
  *--- SFDOB(PRVI I DRUGI DEO BROJA) - ne mora da bude ispravna,0-u+i
    do KBROJ with 0
      msfdob=sfdob
  *---
   case vk=11
  *--- SFDOB(SERIJA I BR.VUC.VOZILA) - ne mora da bude ispravna,0-u+i
    do K3   with 0
      msfdob=sfdob
  *---
   case vk=20
  *--- SFSTV(DRUGO STOVARISTE) - ne mora da bude ispravna,0-u+i
   *do K4  with 0
    do K44  with 0
    msfdob=sfdob
  *---
   case vk=1
  *--- SFDOB(SIFRA DOBAVLJACA) - ne mora da bude ispravna,0-u+i
    do K5   with 0
      msfdob=sfdob
  *---
   otherwise
      @ 03,42 get sfdob
      read
      msfdob=sfdob
endcase
*--- BRDOK - ne mora da bude ispravna,0-u+i
  do KUSL with 0,3,61,'brdok',1,99999,'B', ;
               'AN BROJ DOKUMENTA - POTVRDI '
   mbrdok=brdok
*--- MESEC - ne mora da bude ispravna,0-u+i
  do KUSL with 0,3,76,'mesec',1,12,'M', ;
               'AN MESEC - POTVRDI '
   mmesec=mesec
*---
   gres1=gres
RETURN
*********************************************************
PROCEDURE MZAGZ
J=chr(220)
DVA=J+J
TRI=DVA+J
CET=TRI+J
PET=TRI+J+J
SEST=PET+J
SEDAM=SEST+J
OSAM=SEDAM+J
DEVET=OSAM+J
DESET=DEVET+J
if fun<>' '
 *** prvi put se unosi slog (nije ispravka)
 @ 03,07 say '  SIFRA  '+TRI+'  SIFRA  '+TRI
 @ 04,04 say '1 2  OOURA  3 5  STOV.  6 8           9   14 '
 @ 03,54 say 'BROJ   '+PET+'   MESEC  '+DVA
 do case
         case vk=12
               @ 04,50 say ' OTPREMN.'
          case vk=11
               @ 04,50 say 'IZVADNICE'
          case vk=20
               @ 04,50 say 'SPROVODN.'
          case vk=23 .or.vk=24
               @ 04,50 say 'ZAPISNIKA'
          otherwise
               @ 04,50 say 'DOKUMENTA'
       endcase
       @ 04,61 say '15 19'
       @ 04,74 say '20 21'
       do case
          case vk=2.or.vk=3.or.vk=4.or.vk=5.or.vk=9.or.vk=10.or. ;
               vk=13.or.vk=14 .or.vk=22
               @ 03,33 say '   BROJ  '+SEST
               @ 04,33 say '        '
          case vk=11
               @ 03,33 say '  SERIJA '+SEST
               @ 04,33 say '  I BROJ'
          case vk=12 .or.vk=21
               @ 03,33 say '  SIFRA  '+SEST
               @ 04,33 say 'PRIMAOCA'
          case vk=20
               @ 03,33 say '  SIFRA     '+TRI
               @ 04,33 say ' STOVAR.'
          case vk=23
               @ 03,33 say 'IZVODJAC '+SEST
               @ 04,33 say ' RADOVA'
          otherwise
               @ 03,33 say ' SIFRA   '+SEST
               @ 04,33 say 'DOBAVLJ.'
       endcase
else
 *** ispravka vec unetog sloga
 set color to /w
 @ 03,16 say str(SFOUR,3)
 @ 03,28 say str(SFSTV,3)
 if vk=20
  @ 03,45 say SFDOB picture "999"
 else
  @ 03,42 say str(SFDOB,6)
 endif
 @ 03,61 say str(BRDOK,5)
 @ 03,76 say str(MESEC,2)
 set color to w
endif
RETURN
***********************************************
PROCEDURE MREDZ
  @ 07,05 say 'OSNOV'
  @ 07,14 say 'BROJ IZ '
  @ 07,26 say 'KOLICINA '
  @ 08,07 say 'U.'
  @ 08,14 say 'IMENIKA'
  @ 09,05 say '22 23'
  @ 09,13 say '24      33'
  @ 09,26 say '34    41'
  do case
     case vk=1 .or. vk=30
          @ 07,37 say '------NABAVNA      VREDNOST------'
          @ 07,70 say 'CARINA'
          @ 08,38 say 'FAKTURNA'
          @ 08,50 say 'PREVOZ'
          @ 08,60 say 'POREZ'
          @ 09,37 say '42     52'
          @ 09,49 say '53   59'
          @ 09,59 say '60   66'
          @ 09,69 say '67    74'
     case vk=2 .or. vk=4 .or. vk=10 .or. vk=14
          @ 06,38 say '   KONTO RADA'
          @ 07,38 say 'SEME KONTIRANJA'
          @ 08,38 say '    TROSKOVA    '
          @ 09,41 say '42     52'
     case vk=3
          @ 07,40 say 'PROSECNA VREDNOST'
          @ 08,40 say '     DINARA      '
          @ 09,43 say '42     52'
     case vk=5 .or. vk=13 .or. vk=20 .or. vk=22 .or. vk=9
     case vk=11
          @ 06,38 say '  KONTO RADA'
          @ 06,60 say 'MATICNI'
          @ 07,38 say 'SEME KONTIRANJA'
          @ 07,60 say ' BROJ'
          @ 08,38 say '  TROSKOVA    '
          @ 08,60 say 'M.VODJE'
          @ 09,41 say '42     52'
          @ 09,60 say '53  56'
     case vk=12
          @ 07,40 say 'PRODAJNA VREDNOST'
          @ 07,60 say 'POREZ NA PROM.'
          @ 09,43 say '42     52'
          @ 09,63 say '53     59'
     case vk=21
          @ 07,40 say 'PRODAJNA VREDNOST'
          @ 08,40 say '     DINARA      '
          @ 09,43 say '42     52'
     case vk=23
          @ 07,40 say 'PROSECNA VREDNOST'
          @ 07,60 say '   PREVOZ'
          @ 09,43 say '42     52'
          @ 09,63 say '53   59'
     case vk=24
         @ 07,39 say 'PROSECNA VREDNOST'
         @ 09,43 say '42     52'
         if i24=2
            i24=1
         else
             @ 07,57 say ' PREVOZ'
             @ 07,69 say 'VRED.DORADE'
             @ 09,60 say '53 59'
             @ 09,71 say '60 66'
             i24=2
         endif
  endcase
RETURN
*********************************************************************
PROCEDURE MREDG
J=chr(220)
DVA=J+J
TRI=DVA+J
CET=TRI+J
PET=TRI+J+J
SEST=PET+J
SEDAM=SEST+J
OSAM=SEDAM+J
DEVET=OSAM+J
DESET=DEVET+J
JEDAN=DESET+J
if fun=chr(26)
 *--- prvi put unosi stavku (nema ispravke)
 @ red,13 say DESET+'   '+OSAM
 do case
  case vk=1 .or. vk=30
   @ red,37 say JEDAN+' '+SEDAM+'   '+SEDAM+'   '+OSAM
  case vk=2 .or. vk=4 .or. vk=10 .or. vk=14
   @ red,41 say JEDAN
  case vk=3
   @ red,43 say JEDAN
  case vk=11
   @ red,41 say JEDAN
   @ red,61 say CET
  case vk=12
   @ red,43 say JEDAN
   @ red,63 say SEDAM
  case vk=21
   @ red,43 say JEDAN
  case vk=23
   @ red,43 say JEDAN
   @ red,63 say SEDAM
  case vk=24
   if i24=2
    @ red,43 say JEDAN
    @ red,60 say SEDAM
    @ red,71 say SEDAM
   else
    @ red,43 say JEDAN
   endif
  otherwise
 endcase
else
 *--- ispravka vec unete stavke
 set color to /w
 @ red,13 say str(BROJ,10)
 @ red,26 say str(KOL,8)
 do case
  case vk=1 .or. vk=30
   @ red,37 say str(POL1,11)
   @ red,49 say str(PREVOZ,7)
   @ red,59 say str(POREZ,7)
   @ red,69 say str(CARINA,8)
  case vk=2 .or. vk=4 .or. vk=10 .or. vk=14
   @ red,41 say str(POL1,11)
  case vk=3
   @ red,43 say str(POL1,11)
  case vk=11
   @ red,41 say str(POL1,11)
   @ red,61 say str(MATBR,4)
  case vk=12
   @ red,43 say str(POL1,11)
   @ red,63 say str(POREZ,7)
  case vk=21
   @ red,43 say str(POL1,11)
  case vk=23
   @ red,43 say str(POL1,11)
   @ red,63 say str(PREVOZ,7)
  case vk=24
   if i24=2
    @ red,43 say str(POL1,11)
    @ red,60 say str(PREVOZ,7)
    @ red,71 say str(VRDOR,7)
   else
    @ red,43 say str(POL1,11)
   endif
  otherwise
 endcase
 set color to w
endif
*--- BROJ - ne mora da bude ispravan,0-u+i
  do KM10B with 0,red
*--- KOL - ne mora da bude ispravan,0-unos
if VK=10
    if substr(str(BROJ,10),1,1)="3"
     do KUSL with 0,red,26,'kol',1,999999,'K',;
                  'NA KOLICINA - MORA BITI 0-999999 - POTVRDI '
    else
     do KUSL with 0,red,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
    endif
else
     do KUSL with 0,red,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
endif
*---
  do case
    case vk=1 .or. vk=30
     if fun=chr(26)  &&-1.unos
      pol1=0
      prevoz=0
      porez=0
      carina=0
     endif
     do KPOL1 with 0,red,37,'F',;
              'NA FAKTURNA VREDNOST - MORA BITI > 0 - POTVRDI '
     if vk=30
 *--- PREVOZ - ne mora da bude ispravan
      i=0
      do while .t.
       i=i+1
       @ red,49 get prevoz picture '9999999'
       read
       if prevoz <> 0
        *--- neispravan prevoz
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVAN PREVOZ - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'Z'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan prevoz
        exit
       endif
      enddo
      @ 22,01 clear
 *--- POREZ - ne mora da bude ispravan
      i=0
      do while .t.
       i=i+1
       @ red,59 get porez picture '9999999'
       read
       if porez <> 0
        *--- neispravan porez
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVAN POREZ - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'E'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan porez
        exit
       endif
      enddo
      @ 22,01 clear
 *--- CARINA - ne mora da bude ispravna
      i=0
      do while .t.
       i=i+1
       @ red,69 get carina picture '99999999'
       read
       if carina <> 0
        *--- neispravna carina
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVNA CARINA - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'C'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravna carina
        exit
       endif
      enddo
      @ 22,01 clear
 *---
     else
      *--- vk=1
      @ red,49 get prevoz picture '9999999'
      @ red,59 get porez picture '9999999'
      @ red,69 get carina picture '99999999'
      read
     endif
     ost=str(pol1,11)+str(prevoz,7)+str(porez,7)+str(carina,8)
    case vk=2 .or. vk=4 .or. vk=10 .or. vk=14
     if fun=chr(26)  &&-1.unos
      pol1=0
     endif
     do KPOL1 with 0,red,41,'R',;
              'AN KONTO RADA SEME KONTIRANJA TROSKOVA - POTVRDI '
     ost=str(pol1,11)
    case vk=3
     if fun=chr(26)  &&-1.unos
      pol1=0
     endif
     do KPOL1 with 0,red,43,'P',;
              'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
     ost=str(pol1,11)
    case vk=11
     if fun=chr(26)  &&-1.unos
      pol1=0
      matbr=0
     endif
     do KPOL1 with 0,red,41,'R',;
              'AN KONTO RADA SEME KONTIRANJA TROSKOVA- POTVRDI '
     @ red,61 get matbr picture '9999'
     read
     ost=str(pol1,11)+str(matbr,4)
    case vk=12
     if fun=chr(26)  &&-1.unos
      pol1=0
      porez=0
     endif
     do KPOL1 with 0,red,43,'J',;
              'NA PRODAJNA VREDNOST - MORA BITI > 0 - POTVRDI '
     @ red,63 get porez picture '9999999'
     read
     ost=str(pol1,11)+str(porez,7)
    case vk=21
     if fun=chr(26)  &&-1.unos
      pol1=0
     endif
     do KPOL1 with 0,red,43,'J',;
              'NA PRODAJNA VREDNOST - MORA BITI > 0 - POTVRDI '
     ost=str(pol1,11)
    case vk=23
     if fun=chr(26)  &&-1.unos
      pol1=0
      prevoz=0
     endif
     do KPOL1 with 0,red,43,'P',;
              'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
     @ red,63 get prevoz picture '9999999'
     read
     ost=str(pol1,11)+str(prevoz,7)
    case vk=24
     if i24=2
      if fun=chr(26)  &&-1.unos
       pol1=0
       prevoz=0
       vrdor=0
      endif
      do KPOL1 with 0,red,43,'P',;
               'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
      @ red,60 get prevoz picture '9999999'
      read
 *--- VRDOR - ne mora da bude ispravna
      i=0
      do while .t.
       i=i+1
       @ red,71 get vrdor picture '9999999'
       read
       if vrdor = 0
        *--- neispravan vrdor
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVNA VREDNOST DORADE - MORA BITI > 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'G'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan vrdor
        exit
       endif
      enddo
      @ 22,01 clear
 *---
      ost=str(pol1,11)+str(prevoz,7)+str(vrdor,7)
     else
      if fun=chr(26)  &&-1.unos
       pol1=0
      endif
      do KPOL1 with 0,red,43,'P',;
               'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
      read
      ost=str(pol1,11)
     endif
    otherwise
     ost=' '
 endcase
RETURN
*********************************************************************
PROCEDURE MREDG2
 set color to /w
 @ 10,07 say osn
 @ 10,13 say str(broj,10)
 @ 10,26 say str(kol,8)
  do case
     case vk=1 .or. vk=30
          faktvr=substr(ostatak,1,11)
          prevoz=substr(ostatak,12,7)
          porez=substr(ostatak,19,7)
          carina=substr(ostatak,26,8)
          @ 10,37 say faktvr
          @ 10,49 say prevoz
          @ 10,59 say porez
          @ 10,69 say carina
     case vk=2 .or. vk=4 .or. vk=10 .or. vk=14
          krada=substr(ostatak,1,11)
          @ 10,41 say krada
     case vk=3
          prosvr=substr(ostatak,1,11)
          @ 10,43 say prosvr
     case vk=5 .or. vk=13 .or. vk=20 .or. vk=22 .or. vk=9
     case vk=11
          krada=substr(ostatak,1,11)
          matbr=substr(ostatak,12,4)
          @ 10,41 say krada
          @ 10,61 say matbr
     case vk=12
          prodvr=substr(ostatak,1,11)
          porez=substr(ostatak,12,7)
          @ 10,43 say prodvr
          @ 10,63 say porez
     case vk=21
          prodvr=substr(ostatak,1,11)
          @ 10,43 say prodvr
     case vk=23
          prosvr=substr(ostatak,1,11)
          prevoz=substr(ostatak,12,7)
          @ 10,43 say prosvr
          @ 10,63 say prevoz
     case vk=24
          prosvr=substr(ostatak,1,11)
          @ 10,43 say prosvr
          if i24=2
             prevoz=substr(ostatak,12,7)
             vrdor=substr(ostatak,19,7)
             @ 10,60 say prevoz
             @ 10,71 say vrdor
          endif
  endcase
  set color to w
RETURN
*********************************************************
PROCEDURE K1
parameters c
select 2
use DSTOV index DSTOV
select 1
use u1dat
goto bsl
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka + unos
  i=i-1
  c=0
 else
  *--- unos + ispravka
  @ 03,28 get SFSTV
  read
 endif
 set relation to SFSTV into DSTOV
 if SFSTV=b->SFSTV .and. SFSTV # 0
  *--- kontrolisani podatak je ispravan
  exit
 else
  *--- kontrolisani podatak nije ispravan
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVNA SIFRA STOVARISTA - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'S'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
*********************************************************
PROCEDURE K2
parameters c
select 2
use DOUR index DOUR
select 1
use u1dat
goto bsl
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka + unos
  i=i-1
  c=0
 else
  *--- unos + ispravka
  @ 03,16 get SFOUR
  read
 endif
 set relation to SFOUR into DOUR
 if SFOUR=b->SFOUR .and. SFOUR # 0
  *--- kontrolisani podatak je ispravan
  exit
 else
  *--- kontrolisani podatak nije ispravan
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVNA SIFRA OUR-a - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'2'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
*********************************************************
PROCEDURE K3
parameters c
select 2
use DLOK index DLOK
select 1
use u1dat
goto bsl
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka + unos
  i=i-1
  c=0
 else
  *--- unos + ispravka
  @ 03,42 get SFDOB
  read
 endif
 set relation to SFDOB into DLOK
 if SFDOB=b->SFDOB .and. SFDOB # 0
  *--- kontrolisani podatak je ispravan
  exit
 else
  *--- kontrolisani podatak nije ispravan
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVNA SERIJA I BROJ VUCNOG VOZILA - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'L'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
*********************************************************
PROCEDURE K4
parameters c
select 2
use DSTOV index DSTOV
select 1
use u1dat
goto bsl
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka + unos
  i=i-1
  c=0
 else
  *--- unos + ispravka
  @ 03,45 get SFSTV
  read
 endif
 set relation to SFSTV into DSTOV
 if SFSTV=b->SFSTV .and. SFSTV # 0
  *--- kontrolisani podatak je ispravan
  exit
 else
  *--- kontrolisani podatak nije ispravan
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVNO DRUGO STOVARISTE - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'T'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
*********************************************************
PROCEDURE K44
parameters c
select 2
use DSTOV index DSTOV
select 1
use u1dat
goto bsl
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka + unos
  i=i-1
  c=0
 else
  *--- unos + ispravka
  select 1
  @ 03,45 get SFDOB picture "999"
  read
 endif
 select 2
 seek val(str(A->SFDOB,3))
 if found()
  *--- kontrolisani podatak je ispravan
  exit
 else
  *--- kontrolisani podatak nije ispravan
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVNO DRUGO STOVARISTE - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'T'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
select 1
@ 22,01 clear
RETURN
*********************************************************
PROCEDURE K5
parameters c
select 2
use DDOB index DDOB
select 1
use u1dat
goto bsl
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka + unos
  i=i-1
  c=0
 else
  *--- unos + ispravka
  @ 03,42 get SFDOB
  read
 endif
 set relation to SFDOB into DDOB
 if SFDOB=b->SFDOB .and. SFDOB # 0
  *--- kontrolisani podatak je ispravan
  exit
 else
  *--- kontrolisani podatak nije ispravan
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVNA SIFRA DOBAVLJACA - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'D'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
*********************************************************
PROCEDURE KTABV
select 2
use DMAT index DMAT
select 1
use u1dat
goto bsl
set relation to VK into DMAT
if VK=b->VK .and. VK # 0
 *--- kontrolisani podatak je ispravan
 in='i'
else
 *--- kontrolisani podatak nije ispravan
 ?? chr(7)
 set color to /w
 @ 22,01 say ' NEISPRAVAN VK '
 set color to w
endif
RETURN
*********************************************************
PROCEDURE KUSL
parameters c,a,b,polje,gr1,gr2,kodgr,poruka
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka+unos
  i=i-1
  c=0
 else
  *--- unos+ispravka
  @ a,b get &polje
  read
 endif
 if gr1<= &polje .and. &polje<=gr2
  *--- ispravan podatak
  exit
 else
  *--- neispravan podatak
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAV'+poruka
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+kodgr
   exit
  else
   *--- neka se popravi (3 puta)
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
************************************************
PROCEDURE KUSL35
parameters c,a,b,polje,gr1,gr2,kodgr,poruka
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravka+unos
  i=i-1
  c=0
 else
  *--- unos+ispravka
  @ a,b get &polje
  read
 endif
 for J=1 to 8
  if &POLJE=TAB35[J]  &&...sfour 3-5 je iz tabele
   exit
  endif
 next
 if J<=8  &&...ispravan sfour 3-5
  exit
 else  &&...neispravan sfour 3-5
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAV'+poruka
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+kodgr
   exit
  else
   *--- neka se popravi (3 puta)
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
************************************************
PROCEDURE KPOL
parameters a,b,polje,cond,picc,kodgr,poruka
i=0
do while .t.
 if &cond
  exit
 else
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAV'+ poruka
  set color to w
  i=i+1
  @ a,b get &polje picture picc
  read
  if i=3
   gres=trim(gres)+kodgr
   exit
  else
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
**********************************************************
PROCEDURE KBROJ
PARAMETERS c
select 2
use DOUR index DOUR
select 1
use u1dat
goto bsl
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravke+unos
  i=i-1
  c=0
 else
  *--- unos+ispravke
  @ 03,42 get sfdob
  read
 endif
 pd1=' '
 pd2=' '
 dob=str(sfdob,6)
 dob1a=substr(dob,1,1)
 dob1b=substr(dob,2,2)
 dob22=substr(dob,4,3)
 DOB1=val(substr(DOB,1,3))
 doba=val(dob1a)
 dobb=val(dob1b)
 dob2=val(dob22)
 for J=1 to 14
  if DOB1=TAB911[J]  &&...sfdob 9-12 postoji u tabeli
   exit
  endif
 next
 if J<=14  &&...ispravan prvi deo sfdob
  pd1='    '
 else  &&...neispravan prvi deo sfdob
  pd1='PRVI'
 endif
*set relation to dob2 into dour
 select 2
 seek DOB2
 if found()
*if dob2=b->sfour .and. dob2 # 0
  *--- ispravan drugi deo sfdob
  pd2='     '
 else
  *--- neispravan drugi deo sfdob
  pd2='DRUGI'
 endif
 select 1
 vez=' '
 if pd1 # ' ' .and. pd2 # ' '
  vez=' I '
 endif
 pd=pd1+vez+pd2
 if pd1 = ' ' .and. pd2 = ' '
  *--- ispravan i prvi i drugi deo sfdob
  exit
 else
  *--- postoji neka greska ...
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVAN '+trim(pd)+' DEO BROJA - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'X'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
**********************************************************
PROCEDURE KOSN
PARAMETERS in
if vk # 24
   i24=1
endif
pd1=' '
pd2=' '
osn1=substr(osn,1,1)
osn2=substr(osn,2,1)
do case
   case vk=1.or.vk=2.or.vk=3.or.vk=4.or.vk=5.or.vk=30.or. ;
        (vk=24.and.i24=2)
        if osn1 = '0'
        else
           pd1='PRVI'
        endif
   case vk=10.or.vk=11.or.vk=12.or.vk=13.or.vk=14.or.vk=20.or. ;
        vk=21.or.vk=23.or.(vk=24.and.i24=1)
        if osn1='1'
        else
           pd1='PRVI'
        endif
   case vk=22
        if osn1='0'.or.osn1='1'
        else
           pd1='PRVI'
        endif
   otherwise
endcase
do case
   case vk=10
      if osn2 $ '0123456789'
      else
         pd2='DRUGI'
      endif
   case vk=11
      if osn2 $ '05'
      else
         pd2='DRUGI'
      endif
   otherwise
      if osn2 $ '01345689'
      else
         pd2='DRUGI'
      endif
endcase
if pd1 # ' ' .and. pd2 # ' '
   vez=' I '
else
   vez=' '
endif
if pd1=' ' .and. pd2=' '
   in='i'
else
   pd=pd1+vez+pd2
   ?? chr(7)
   set color to /w
   @ 22,01 say ' NEISPRAVAN '+trim(pd)+' DEO OSNOVA - POTVRDI '
   set color to w
endif
RETURN
*********************************************************************
PROCEDURE MOD10
parameters poll
poll1=str(&poll,10)
sss=0
mno=2
k=9
do while k>0
   p1s=substr(poll1,k,1)
   if mno=2
      p2v=mno*val(p1s)
      if p2v>9
         p2s=str(p2v,2)
         p31=substr(p2s,1,1)
         p32=substr(p2s,2,1)
         sss=sss+val(p31)+val(p32)
      else
         sss=sss+p2v
      endif
      mno=1
   else
      sss=sss+val(p1s)
      mno=2
   endif
   k=k-1
enddo
s4=str(sss,3)
s5=substr(s4,3,1)
if s5='0'
   kb=0
else
   kb=10-val(s5)
endif
RETURN
**********************************************************
PROCEDURE KM10OD
PARAMETERS cc,kodgr
j=0
do while .t.
 j=j+1
 if cc=1
  *--- ispravka+unos
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVAN OUR-SIFRA STOVARISTA '
  set color to w
  j=j-1
  cc=0
 endif
 gres=' '
  do K2   with 0
 if substr(gres,1,1) = '2'
  gres='2'+'  '
 endif
 @ 03,28 get sfstv
 read
 pol1=sfour*1000+sfstv
 pol=str(pol1,10)
 public kb
 do mod10 with pol
 kb1=substr(pol,10,1)
 if val(kb1)=kb .and. sfstv # 0
  *--- ispravan kontrolni broj
  exit
 else
  *--- neispravan kontrolni broj
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVAN OUR-SIFRA STOVARISTA '
  set color to w
  if j=3
   *--- neka ide dalje
   gres=trim(gres)+kodgr
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
**********************************************************
PROCEDURE KM10B
PARAMETERS c,rrr
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravke+unos
  i=i-1
  c=0
 else
  *--- unos+ispravke
  @ rrr,13 get broj
  read
 endif
 if BROJ=0
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVAN BROJ -> MORA BITI VECI OD NULE ! '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'I'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
 pol=str(broj,10)
 public kb
 do mod10 with pol
 kb1=substr(pol,10,1)
 if val(kb1)=kb
  *--- ispravan kontrolni broj
  exit
 else
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAVAN BROJ PO MODULU 10 - POTVRDI '
  set color to w
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'I'
   exit
  else
   *--- neka se popravi
   loop
  endif
 endif
enddo
@ 22,01 clear
RETURN
*********************************************
PROCEDURE KPOL1
PARAMETERS c,red,col,kodgr,pg
i=0
do while .t.
 i=i+1
 if c=1
  *--- ispravke+unos
  i=i-1
  c=0
 else
  *--- unos+ispravke
  @ red,col get pol1 picture '99999999999'
  read
 endif
 if pol1=0
  *--- neispravan pol1
  ?? chr(7)
  set color to /w
  @ 22,01 say ' NEISPRAV'+pg
  set color to w
  if i=3
   *--- neka ide dalje ...
   gres=trim(gres)+kodgr
   exit
  else
   *--- neka se popravi
   loop
  endif
 else
  *--- ispravan pol1
  exit
 endif
enddo
@ 22,01 clear
RETURN
*********************************************
PROCEDURE ISPGR  &&-samo neispravna polja
gres=' '
ost=ostatak
ii=1
sgr=substr(greska,1,1)
if sgr=' '
 *--- ispravan slog --------------------------------------------
 *--- zaglavlje ---
 *--- SFOUR - ne mora da bude ispravna,0-u+i
  *do KUSL with 0,03,16,'sfour',899,899,'1','NA SIFRA OUR-a - POTVRDI '
   do KUSL35 with 0,03,16,'sfour',614,899,'1','NA SIFRA OUR-a - POTVRDI '
 *--- SFSTV - ne mora da bude ispravna,0-u+i
   do K1   with 0
   msfstv=sfstv
 *---
do case
   case vk=2.or.vk=3.or.vk=4.or.vk=9.or.vk=10.or.vk=14
  *--- SFDOB(PRVI I DRUGI DEO BROJA) - ne mora da bude ispravna,0-u+i
    do KBROJ with 0
  *---
   case vk=11
  *--- SFDOB(SERIJA I BR.VUC.VOZILA) - ne mora da bude ispravna,0-u+i
    do K3   with 0
  *---
   case vk=20
  *--- SFSTV(DRUGO STOVARISTE) - ne mora da bude ispravna,0-u+i
    do K44  with 0
    msfdob=sfdob
  *---
   case vk=1
  *--- SFDOB(SIFRA DOBAVLJACA) - ne mora da bude ispravna,0-u+i
    do K5   with 0
  *---
   otherwise
      @ 03,42 get sfdob
      read
endcase
*--- BRDOK - ne mora da bude ispravna,0-u+i
  do KUSL with 0,3,61,'brdok',1,99999,'B', ;
               'AN BROJ DOKUMENTA - POTVRDI '
*--- MESEC - ne mora da bude ispravna,0-u+i
  do KUSL with 0,3,76,'mesec',1,12,'M', ;
               'AN MESEC - POTVRDI '
 *--- stavke ---
i=0
do while .t.
 i=i+1
 @ 10,07 get osn
 read
 in='n'
 do KOSN with in
 if in='n'
  *--- neispravan unos
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'O'
   exit
  else
   *--- neka se popravi
   loop
  endif
 else
  *--- ispravan unos
  exit
 endif
enddo
*---
*--- BROJ - ne mora da bude ispravan,0-u+i
  do KM10B with 0,10
*--- KOL - ne mora da bude ispravan,0-unos
if VK=10
    if substr(str(BROJ,10),1,1)="3"
     do KUSL with 0,10,26,'kol',1,999999,'K',;
                  'NA KOLICINA - MORA BITI 0-999999 - POTVRDI '
    else
     do KUSL with 0,10,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
    endif
else
     do KUSL with 0,10,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
endif
*---
  do case
    case vk=1 .or. vk=30
     pol1=val(substr(ostatak,1,11))
     prevoz=val(substr(ostatak,12,7))
     porez=val(substr(ostatak,19,7))
     carina=val(substr(ostatak,26,8))
    *pol1=0
    *prevoz=0
    *porez=0
    *carina=0
     do KPOL1 with 0,10,37,'F',;
              'NA FAKTURNA VREDNOST - MORA BITI > 0 - POTVRDI '
     if vk=30
 *--- PREVOZ - ne mora da bude ispravan
      i=0
      do while .t.
       i=i+1
       @ 10,49 get prevoz picture '9999999'
       read
       if prevoz <> 0
        *--- neispravan prevoz
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVAN PREVOZ - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'Z'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan prevoz
        exit
       endif
      enddo
      @ 22,01 clear
 *--- POREZ - ne mora da bude ispravan
      i=0
      do while .t.
       i=i+1
       @ 10,59 get porez picture '9999999'
       read
       if porez <> 0
        *--- neispravan porez
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVAN POREZ - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'E'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan porez
        exit
       endif
      enddo
      @ 22,01 clear
 *--- CARINA - ne mora da bude ispravna
      i=0
      do while .t.
       i=i+1
       @ 10,69 get carina picture '99999999'
       read
       if carina <> 0
        *--- neispravna carina
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVNA CARINA - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'C'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravna carina
        exit
       endif
      enddo
      @ 22,01 clear
 *---
     else
      *--- vk=1
      @ 10,49 get prevoz picture '9999999'
      @ 10,59 get porez picture '9999999'
      @ 10,69 get carina picture '99999999'
      read
     endif
    ost=str(pol1,11)+str(prevoz,7)+str(porez,7)+str(carina,8)
    case vk=2 .or. vk=4 .or. vk=10 .or. vk=14
     pol1=val(substr(ostatak,1,11))
    *pol1=0
     do KPOL1 with 0,10,41,'R',;
              'AN KONTO RADA SEME KONTIRANJA TROSKOVA - POTVRDI '
     ost=str(pol1,11)
    case vk=3
     pol1=val(substr(ostatak,1,11))
    *pol1=0
     do KPOL1 with 0,10,43,'P',;
              'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
     ost=str(pol1,11)
    case vk=11
     pol1=val(substr(ostatak,1,11))
     matbr=val(substr(ostatak,12,4))
    *pol1=0
    *matbr=0
     do KPOL1 with 0,10,41,'R',;
              'AN KONTO RADA SEME KONTIRANJA TROSKOVA- POTVRDI '
     @ 10,61 get matbr picture '9999'
     read
     ost=str(pol1,11)+str(matbr,4)
    case vk=12
     pol1=val(substr(ostatak,1,11))
     porez=val(substr(ostatak,12,7))
    *pol1=0
    *porez=0
     do KPOL1 with 0,10,43,'J',;
              'NA PRODAJNA VREDNOST - MORA BITI > 0 - POTVRDI '
     @ 10,63 get porez picture '9999999'
     read
     ost=str(pol1,11)+str(porez,7)
    case vk=21
     pol1=val(substr(ostatak,1,11))
    *pol1=0
     do KPOL1 with 0,10,43,'J',;
              'NA PRODAJNA VREDNOST - MORA BITI > 0 - POTVRDI '
     ost=str(pol1,11)
    case vk=23
     pol1=val(substr(ostatak,1,11))
     prevoz=val(substr(ostatak,12,7))
    *pol1=0
    *prevoz=0
     do KPOL1 with 0,10,43,'P',;
              'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
     @ 10,63 get prevoz picture '9999999'
     read
     ost=str(pol1,11)+str(prevoz,7)
    case vk=24
     if i24=2
      pol1=val(substr(ostatak,1,11))
      prevoz=val(substr(ostatak,12,7))
      vrdor=val(substr(ostatak,19,7))
     *pol1=0
     *prevoz=0
     *vrdor=0
      do KPOL1 with 0,10,43,'P',;
               'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
      @ 10,60 get prevoz picture '9999999'
      read
 *--- VRDOR - ne mora da bude ispravna
      i=0
      do while .t.
       i=i+1
       @ 10,71 get vrdor picture '9999999'
       read
       if vrdor = 0
        *--- neispravan vrdor
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVNA VREDNOST DORADE - MORA BITI > 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'F'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan vrdor
        exit
       endif
      enddo
      @ 22,01 clear
 *---
      ost=str(pol1,11)+str(prevoz,7)+str(vrdor,7)
     else
      pol1=val(substr(ostatak,1,11))
      pol1=0
      do KPOL1 with 0,10,43,'P',;
               'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
      read
      ost=str(pol1,11)
     endif
    otherwise
     ost=' '
 endcase
else
 *--- neispravan slog --------------------------------------------
  do while sgr<>' '
    do case
     case sgr='1'
      *do KUSL with 1,03,16,'sfour',899,899,'1',;
      *             'NA SIFRA OURA - POTVRDI '
       do KUSL35 with 1,03,16,'sfour',614,899,'1',;
                    'NA SIFRA OURA - POTVRDI '
     case sgr='2'
       do K2   with 1
     case sgr='S'
       do K1   with 1
     case sgr='W'
       do KM10OD with 1,'W'
     case sgr='X'
       do KBROJ with 1
     case sgr='L'
       do K3   with 1
     case sgr='T'
       do K44  with 1
     case sgr='D'
       do K5   with 1
     case sgr='B'
       do KUSL with 1,3,61,'brdok',1,99999,'B',;
                    'AN BROJ DOKUMENTA - POTVRDI '
     case sgr='M'
       do KUSL with 1,3,76,'mesec',1,12,'M',;
                    'AN MESEC - POTVRDI '
     case sgr='O'
          i=0
          do while .t.
           i=i+1
           if i=1
            *--- prvi put
            in='n'
            do KOSN with in
           else
            *--- sledeci
            @ 10,07 get osn
            read
            in='n'
            do KOSN with in
           endif
           if in='n'
            *--- neispravan broj
            if i=3
             gres=trim(gres)+'O'
             exit
            else
             loop
            endif
           else
            *--- ispravan broj
            exit
           endif
          enddo
     case sgr='I'
       do KM10B with 1,10
     case sgr='K'
*--- KOL - ne mora da bude ispravan,0-unos
if VK=10
    if substr(str(BROJ,10),1,1)="3"
     do KUSL with 1,10,26,'kol',1,999999,'K',;
                  'NA KOLICINA - MORA BITI 0-999999 - POTVRDI '
    else
     do KUSL with 1,10,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
    endif
else
     do KUSL with 1,10,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
endif
*---
     case sgr='F'
          pol11=substr(ost,1,11)
          pol1=val(pol11)
       do KPOL1 with 1,10,37,'F',;
               'NA FAKTURNA VREDNOST - MORA BITI > 0 - POTVRDI '
          ost=str(pol1,11)+substr(ost,12,30)
     case sgr='Z'
          pol12=substr(ost,12,7)
          prevoz=val(pol12)
       if vk=30
        do KPOL with 10,49,'prevoz','prevoz=0','9999999','Z',;
                'AN PREVOZ - MORA BITI = 0 - POTVRDI '
       else
        do KPOL with 10,49,'prevoz','prevoz>0','9999999','Z',;
                'AN PREVOZ - MORA BITI > 0 - POTVRDI '
       endif
          ost=substr(ost,1,11)+str(prevoz,7)+substr(ost,20,22)
     case sgr='E'
          pol13=substr(ost,19,7)
          porez=val(pol13)
       if vk=30
        do KPOL with 10,59,'porez','porez=0','9999999','E',;
                'AN POREZ - MORA BITI = 0 - POTVRDI '
       else
        do KPOL with 10,59,'porez','porez>0','9999999','E',;
                'AN POREZ - MORA BITI > 0 - POTVRDI '
       endif
          ost=substr(ost,1,18)+str(porez,7)+substr(ost,26,16)
     case sgr='C'
          pol14=substr(ost,26,8)
          carina=val(pol14)
       if vk=30
        do KPOL with 10,69,'carina','carina=0','99999999','C',;
                'NA CARINA - MORA BITI = 0 - POTVRDI '
       else
        do KPOL with 10,69,'carina','carina>0','99999999','C',;
                'NA CARINA - MORA BITI > 0 - POTVRDI '
       endif
          ost=substr(ost,1,25)+str(carina,8)+substr(ost,34,8)
     case sgr='R'
          pol11=substr(ost,1,11)
          pol1=val(pol11)
       do KPOL with 10,41,'pol1','pol1>0','99999999999','R',;
     'AN KONTO RADA SEME KONTIRANJA TROSKOVA - MORA BITI > 0 - POTVRDI '
          ost=str(pol1,11)+substr(ost,12,30)
     case sgr='P'
          pol11=substr(ost,1,11)
          pol1=val(pol11)
       do KPOL with 10,43,'pol1','pol1>0','99999999999','P',;
               'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
          ost=str(pol1,11)+substr(ost,12,30)
     case sgr='J'
          pol11=substr(ost,1,11)
          pol1=val(pol11)
       do KPOL with 10,43,'pol1','pol1>0','99999999999','J',;
               'NA PRODAJNA VREDNOST - MORA BITI > 0 - POTVRDI '
          ost=str(pol1,11)+substr(ost,12,30)
     case sgr='G'
          pol22=substr(ost,19,7)
          pol2=val(pol22)
       do KPOL with 10,71,'pol2','pol2>0','9999999','G', ;
               'NA VREDNOST DORADE - MORA BITI > 0 - POTVRDI '
          ost=substr(ost,1,18)+str(pol2,7)+substr(ost,26,16)
    endcase
    ii=ii+1
    sgr=substr(greska,ii,1)
  enddo
endif
replace greska with gres,ostatak with ost
RETURN
*********************************************
PROCEDURE ISPGR2  &&-sva polja
gres=' '
ost=ostatak
ii=1
*sgr=substr(greska,1,1)
sgr=" "
if sgr=' '
 *--- ispravan slog --------------------------------------------
 *--- zaglavlje ---
 *--- SFOUR - ne mora da bude ispravna,0-u+i
  *do KUSL with 0,03,16,'sfour',899,899,'1','NA SIFRA OUR-a - POTVRDI '
   do KUSL35 with 0,03,16,'sfour',614,899,'1','NA SIFRA OUR-a - POTVRDI '
 *--- SFSTV - ne mora da bude ispravna,0-u+i
   do K1   with 0
   msfstv=sfstv
 *---
do case
   case vk=2.or.vk=3.or.vk=4.or.vk=9.or.vk=10.or.vk=14
  *--- SFDOB(PRVI I DRUGI DEO BROJA) - ne mora da bude ispravna,0-u+i
    do KBROJ with 0
  *---
   case vk=11
  *--- SFDOB(SERIJA I BR.VUC.VOZILA) - ne mora da bude ispravna,0-u+i
    do K3   with 0
  *---
   case vk=20
  *--- SFSTV(DRUGO STOVARISTE) - ne mora da bude ispravna,0-u+i
    do K44  with 0
    msfdob=sfdob
  *---
   case vk=1
  *--- SFDOB(SIFRA DOBAVLJACA) - ne mora da bude ispravna,0-u+i
    do K5   with 0
  *---
   otherwise
      @ 03,42 get sfdob
      read
endcase
*--- BRDOK - ne mora da bude ispravna,0-u+i
  do KUSL with 0,3,61,'brdok',1,99999,'B', ;
               'AN BROJ DOKUMENTA - POTVRDI '
*--- MESEC - ne mora da bude ispravna,0-u+i
  do KUSL with 0,3,76,'mesec',1,12,'M', ;
               'AN MESEC - POTVRDI '
 *--- stavke ---
i=0
do while .t.
 i=i+1
 @ 10,07 get osn
 read
 in='n'
 do KOSN with in
 if in='n'
  *--- neispravan unos
  if i=3
   *--- neka ide dalje
   gres=trim(gres)+'O'
   exit
  else
   *--- neka se popravi
   loop
  endif
 else
  *--- ispravan unos
  exit
 endif
enddo
*---
*--- BROJ - ne mora da bude ispravan,0-u+i
  do KM10B with 0,10
*--- KOL - ne mora da bude ispravan,0-unos
if VK=10
    if substr(str(BROJ,10),1,1)="3"
     do KUSL with 0,10,26,'kol',1,999999,'K',;
                  'NA KOLICINA - MORA BITI 0-999999 - POTVRDI '
    else
     do KUSL with 0,10,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
    endif
else
     do KUSL with 0,10,26,'kol',1,99999999,'K',;
                  'NA KOLICINA - MORA BITI > 0 - POTVRDI '
endif
*---
  do case
    case vk=1 .or. vk=30
     pol1=val(substr(ostatak,1,11))
     prevoz=val(substr(ostatak,12,7))
     porez=val(substr(ostatak,19,7))
     carina=val(substr(ostatak,26,8))
    *pol1=0
    *prevoz=0
    *porez=0
    *carina=0
     do KPOL1 with 0,10,37,'F',;
              'NA FAKTURNA VREDNOST - MORA BITI > 0 - POTVRDI '
     if vk=30
 *--- PREVOZ - ne mora da bude ispravan
      i=0
      do while .t.
       i=i+1
       @ 10,49 get prevoz picture '9999999'
       read
       if prevoz <> 0
        *--- neispravan prevoz
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVAN PREVOZ - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'Z'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan prevoz
        exit
       endif
      enddo
      @ 22,01 clear
 *--- POREZ - ne mora da bude ispravan
      i=0
      do while .t.
       i=i+1
       @ 10,59 get porez picture '9999999'
       read
       if porez <> 0
        *--- neispravan porez
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVAN POREZ - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'E'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan porez
        exit
       endif
      enddo
      @ 22,01 clear
 *--- CARINA - ne mora da bude ispravna
      i=0
      do while .t.
       i=i+1
       @ 10,69 get carina picture '99999999'
       read
       if carina <> 0
        *--- neispravna carina
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVNA CARINA - MORA BITI = 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'C'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravna carina
        exit
       endif
      enddo
      @ 22,01 clear
 *---
     else
      *--- vk=1
      @ 10,49 get prevoz picture '9999999'
      @ 10,59 get porez picture '9999999'
      @ 10,69 get carina picture '99999999'
      read
     endif
    ost=str(pol1,11)+str(prevoz,7)+str(porez,7)+str(carina,8)
    case vk=2 .or. vk=4 .or. vk=10 .or. vk=14
     pol1=val(substr(ostatak,1,11))
    *pol1=0
     do KPOL1 with 0,10,41,'R',;
              'AN KONTO RADA SEME KONTIRANJA TROSKOVA - POTVRDI '
     ost=str(pol1,11)
    case vk=3
     pol1=val(substr(ostatak,1,11))
    *pol1=0
     do KPOL1 with 0,10,43,'P',;
              'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
     ost=str(pol1,11)
    case vk=11
     pol1=val(substr(ostatak,1,11))
     matbr=val(substr(ostatak,12,4))
    *pol1=0
    *matbr=0
     do KPOL1 with 0,10,41,'R',;
              'AN KONTO RADA SEME KONTIRANJA TROSKOVA- POTVRDI '
     @ 10,61 get matbr picture '9999'
     read
     ost=str(pol1,11)+str(matbr,4)
    case vk=12
     pol1=val(substr(ostatak,1,11))
     porez=val(substr(ostatak,12,7))
    *pol1=0
    *porez=0
     do KPOL1 with 0,10,43,'J',;
              'NA PRODAJNA VREDNOST - MORA BITI > 0 - POTVRDI '
     @ 10,63 get porez picture '9999999'
     read
     ost=str(pol1,11)+str(porez,7)
    case vk=21
     pol1=val(substr(ostatak,1,11))
    *pol1=0
     do KPOL1 with 0,10,43,'J',;
              'NA PRODAJNA VREDNOST - MORA BITI > 0 - POTVRDI '
     ost=str(pol1,11)
    case vk=23
     pol1=val(substr(ostatak,1,11))
     prevoz=val(substr(ostatak,12,7))
    *pol1=0
    *prevoz=0
     do KPOL1 with 0,10,43,'P',;
              'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
     @ 10,63 get prevoz picture '9999999'
     read
     ost=str(pol1,11)+str(prevoz,7)
    case vk=24
     if i24=2
      pol1=val(substr(ostatak,1,11))
      prevoz=val(substr(ostatak,12,7))
      vrdor=val(substr(ostatak,19,7))
     *pol1=0
     *prevoz=0
     *vrdor=0
      do KPOL1 with 0,10,43,'P',;
               'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
      @ 10,60 get prevoz picture '9999999'
      read
 *--- VRDOR - ne mora da bude ispravna
      i=0
      do while .t.
       i=i+1
       @ 10,71 get vrdor picture '9999999'
       read
       if vrdor = 0
        *--- neispravan vrdor
        ?? chr(7)
        set color to /w
        @ 22,01 say ' NEISPRAVNA VREDNOST DORADE - MORA BITI > 0 - POTVRDI '
        set color to w
        if i=3
         *--- neka ide dalje
         gres=trim(gres)+'F'
         exit
        else
         *--- neka se popravi
         loop
        endif
       else
        *--- ispravan vrdor
        exit
       endif
      enddo
      @ 22,01 clear
 *---
      ost=str(pol1,11)+str(prevoz,7)+str(vrdor,7)
     else
      pol1=val(substr(ostatak,1,11))
     *pol1=0
      do KPOL1 with 0,10,43,'P',;
               'NA PROSECNA VREDNOST - MORA BITI > 0 - POTVRDI '
      read
      ost=str(pol1,11)
     endif
    otherwise
     ost=' '
 endcase
endif
replace greska with gres,ostatak with ost
RETURN
***********************************************************************
PROCEDURE PROCRBS
@ 0,0 clear
radp=.t.
do while radp
   @ 22,01 say ' DATOTEKA IMA SLOGOVA : ' + str(bsl1,5)+' '
   @ 23,01 say ' UNESI REDNI BROJ TRAZENOG SLOGA : ' ;
           get bsl picture '99999'
   read
   @ 22,01 clear
   if bsl> bsl1
      ? chr(7)
      dane='D'
      @ 20,01 say ' TRAZENI SLOG JE VAN OPSEGA DATOTEKE '
      @ 21,01 say ' DATOTEKA IMA SLOGOVA : ' + str(bsl1,5) + ' '
      do while .t.
       @ 23,01 say ' ZELITE LI DA NASTAVITE ISPRAVKU SLOGOVA (D/N) ?' ;
               get dane
       read
       if dane $ 'DdNn'
        *--- ispravan unos
        exit
       else
        *--- neispravan unos
        loop
       endif
      enddo
      @ 20,01 clear
      if upper(dane)='D'
      else
         radp=.f.
         rad9=.f.
      endif
    else
      radp=.f.
      goto bsl
    endif
enddo radp
RETURN
**********************************************************************
PROCEDURE CFUN1
*** (zaglavlje) izbor kretanja po ekranu (gore,dole)
PARAMETERS red1,col1
   do while .t.
    fun=chr(24)
    @ red1,col1 get fun
    read
    if fun=chr(24) .or. fun=' '
     exit
    else
     ?? chr(7)
     loop
    endif
   enddo
RETURN
**********************************************************************
PROCEDURE CFUN2
*** (stavke) izbor kretanja po ekranu (gore,dole)
PARAMETERS red1,col1
   do while .t.
    fun=chr(26)
    @ red1,col1 get fun
    read
    if fun=chr(26) .or. fun=' '
     exit
    else
     ?? chr(7)
     loop
    endif
   enddo
RETURN
**********************************************************************
