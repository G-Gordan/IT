/*
 * $Id: ftpadv.prg 18477 2012-11-08 15:06:50Z vszakats $
 */

/******************************************
 * TIP test
 * FTP Advanced operations Test
 ******************************************/

#require "hbtip"

PROCEDURE Main( cUrl )

   LOCAL oCon, oUrl

   oUrl := TUrl():New( cUrl )
   IF Empty( oUrl )
      ? "Invalid url " + cUrl
      ?
      QUIT
   ENDIF

   IF oUrl:cProto != "ftp"
      ? "This is a 'DELE' test for ftp."
      ? "Use an ftp address with a file that you can delete."
      ?
      QUIT
   ENDIF

   oCon := TIPClientFTP():New( oUrl )
   oCon:nConnTimeout := 20000
   ? "Connecting with", oUrl:cServer
   IF oCon:Open( cUrl )
      ? "Connection eshtablished"
      ? "Deleting", oUrl:cPath
      IF oCon:CWD( oUrl:cPath )
         ? "CWD success"
         IF oCon:Dele( oUrl:cFile )
            ? "DELE success"
         ELSE
            ? "DELE Faliure (server reply:", oCon:cReply + ")"
         ENDIF
      ELSE
         ? "CWD Faliure (server reply:", oCon:cReply + ")"
      ENDIF

      oCon:Close()
   ELSE
      ? "Can't connect with", oUrl:cServer
      IF oCon:SocketCon == NIL
         ? "Connection not initiated"
      ELSEIF hb_inetErrorCode( oCon:SocketCon ) == 0
         ? "Server sayed:", oCon:cReply
      ELSE
         ? "Error in connection:", hb_inetErrorDesc( oCon:SocketCon )
      ENDIF
   ENDIF

   ? "Done"
   ?

   RETURN
