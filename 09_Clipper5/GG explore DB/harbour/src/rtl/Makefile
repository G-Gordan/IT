#
# $Id: Makefile 18861 2013-02-18 13:50:13Z vszakats $
#

ROOT := ../../

include $(TOP)$(ROOT)config/global.mk

ifneq ($(HB_PLATFORM),wce)
   ifneq ($(HB_COMPILER),pcc)
      HB_PRGFLAGS := -gc3
   endif
endif

C_SOURCES := \
   abs.c \
   accept.c \
   ampm.c \
   arc4.c \
   at.c \
   ati.c \
   base64c.c \
   base64d.c \
   binnum.c \
   box.c \
   cdpapi.c \
   cdpapihb.c \
   cdpbox.c \
   cdpdetc.c \
   chrasc.c \
   chruni.c \
   colorind.c \
   console.c \
   copyfile.c \
   cputime.c \
   datec.c \
   dates.c \
   dateshb.c \
   datesx.c \
   defpath.c \
   defpathu.c \
   descend.c \
   dirdrive.c \
   direct.c \
   diskspac.c \
   disksphb.c \
   do.c \
   empty.c \
   errapi.c \
   errapiu.c \
   errint.c \
   errintlo.c \
   file.c \
   filebuf.c \
   filehb.c \
   filesys.c \
   fkmax.c \
   fmhb.c \
   fnsplit.c \
   fscopy.c \
   fserr.c \
   fslink.c \
   fssize.c \
   fstemp.c \
   gete.c \
   gt.c \
   gtapi.c \
   gtchrmap.c \
   gtclip.c \
   gtfunc.c \
   gtkbstat.c \
   gtkeycod.c \
   gtsys.c \
   gttone.c \
   gx.c \
   hardcr.c \
   hbadler.c \
   hbascii.c \
   hbbffnc.c \
   hbbfish.c \
   hbbit.c \
   hbbyte.c \
   hbcom.c \
   hbcomhb.c \
   hbcrc.c \
   hbdef.c \
   hbdyn.c \
   hbdynhb.c \
   hbfeof.c \
   hbfile.c \
   hbfilehc.c \
   hbgtcore.c \
   hbhex.c \
   hbi18n1.c \
   hbinet.c \
   hbinetz.c \
   hbjson.c \
   hblpp.c \
   hblpphb.c \
   hbmd5.c \
   hbmd5enc.c \
   hbntos.c \
   hbproces.c \
   hbprocfn.c \
   hbrand.c \
   hbrandom.c \
   hbregex.c \
   hbregexc.c \
   hbrunfun.c \
   hbsha1.c \
   hbsha1hm.c \
   hbsha2.c \
   hbsha2hm.c \
   hbsocket.c \
   hbsockhb.c \
   hbstrfmt.c \
   hbstrsh.c \
   hbtoken.c \
   hbzlib.c \
   hbzlibgz.c \
   hbznet.c \
   idle.c \
   inkey.c \
   inkeyapi.c \
   is.c \
   isprint.c \
   itemseri.c \
   lang.c \
   langapi.c \
   left.c \
   len.c \
   lennum.c \
   libnamec.c \
   math.c \
   maxrow.c \
   memofile.c \
   minmax.c \
   mlcfunc.c \
   mod.c \
   mouse53.c \
   mouseapi.c \
   mousehb.c \
   mtran.c \
   natmsg.c \
   natmsgu.c \
   net.c \
   oemansi.c \
   oldbox.c \
   oldclear.c \
   pad.c \
   padc.c \
   padl.c \
   padr.c \
   philes.c \
   philes53.c \
   rat.c \
   replic.c \
   right.c \
   round.c \
   run.c \
   samples.c \
   saverest.c \
   scroll.c \
   scrrow.c \
   seconds.c \
   setcolor.c \
   setcurs.c \
   setkey.c \
   setpos.c \
   setposbs.c \
   sha1.c \
   sha1hmac.c \
   sha2.c \
   sha2hmac.c \
   shadow.c \
   shadowu.c \
   soundex.c \
   space.c \
   spfiles.c \
   str.c \
   strc.c \
   strcase.c \
   strclear.c \
   strmatch.c \
   strrepl.c \
   strtoexp.c \
   strtran.c \
   strxor.c \
   strzero.c \
   stuff.c \
   substr.c \
   tone.c \
   trace.c \
   transfrm.c \
   trim.c \
   tscalara.c \
   tscalarb.c \
   tscalarc.c \
   tscalard.c \
   tscalarh.c \
   tscalarl.c \
   tscalarn.c \
   tscalarp.c \
   tscalars.c \
   tscalart.c \
   tscalaru.c \
   type.c \
   val.c \
   valtostr.c \
   valtype.c \
   version.c \
   word.c \
   xhelp.c \
   xsavescr.c \

PRG_SOURCES := \
   achoice.prg \
   adir.prg \
   alert.prg \
   altd.prg \
   browdb.prg \
   browse.prg \
   cdpdet.prg \
   checkbox.prg \
   color53.prg \
   dbedit.prg \
   devoutp.prg \
   dircmd.prg \
   dirscan.prg \
   einstv52.prg \
   einstvar.prg \
   einstvau.prg \
   errsys.prg \
   getlist.prg \
   getsys.prg \
   getsys53.prg \
   getsyshb.prg \
   gui.prg \
   hbdoc.prg \
   hbfilehi.prg \
   hbi18n2.prg \
   hbini.prg \
   input.prg \
   langcomp.prg \
   langlgcy.prg \
   libname.prg \
   listbox.prg \
   memoedit.prg \
   memvarbl.prg \
   memvarhb.prg \
   menuto.prg \
   menusys.prg \
   objfunc.prg \
   perfuncs.prg \
   profiler.prg \
   pushbtn.prg \
   radiobhb.prg \
   radiobtn.prg \
   radiogrp.prg \
   readkey.prg \
   readvar.prg \
   savebuff.prg \
   scrollbr.prg \
   setfunc.prg \
   setta.prg \
   tclass.prg \
   tbcolumn.prg \
   tbrowse.prg \
   tbrowsys.prg \
   teditor.prg \
   text.prg \
   tget.prg \
   tgethb.prg \
   tgetint.prg \
   tgetlist.prg \
   tlabel.prg \
   tmenuitm.prg \
   tmenusys.prg \
   tobject.prg \
   tpersist.prg \
   tpopup.prg \
   tpopuphb.prg \
   treport.prg \
   tscalar.prg \
   tsymbol.prg \
   ttextlin.prg \
   ttopbar.prg \
   typefile.prg \
   valtoexp.prg \
   wait.prg \

LIBNAME := hbrtl

DIRS := \
   gtcgi \
   gtcrs \
   gtdos \
   gtgui \
   gtos2 \
   gtpca \
   gtsln \
   gtstd \
   gttrm \
   gtwin \
   gtwvt \
   gtxwc \

ifneq ($(HB_HAS_ZLIB),)

   ifneq ($(HB_HAS_PCRE),)
      HB_CFLAGS += -DHB_HAS_PCRE $(foreach d,$(HB_HAS_PCRE),-I$(d))
      ifneq ($(HB_HAS_PCRE_LOCAL),)
         HB_CFLAGS += -DPCRE_STATIC
      endif
   endif
   ifneq ($(HB_HAS_ZLIB),)
      HB_CFLAGS += -DHB_HAS_ZLIB $(foreach d,$(HB_HAS_ZLIB),-I$(d))
   endif
   ifneq ($(HB_HAS_WATT),)
      HB_CFLAGS += -DHB_HAS_WATT $(foreach d,$(HB_HAS_WATT),-I$(d))
   endif

   include $(TOP)$(ROOT)config/lib.mk
   include $(TOP)$(ROOT)config/dir.mk
else
   $(error ! Error: zlib component required, but not available)
endif
