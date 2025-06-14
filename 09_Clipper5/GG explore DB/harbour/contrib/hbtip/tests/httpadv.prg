/*
 * $Id: httpadv.prg 18477 2012-11-08 15:06:50Z vszakats $
 */

/******************************************
 * TIP test
 * HTTP Advanced operations Test
 ******************************************/

#require "hbtip"

PROCEDURE Main( cUrl )

   LOCAL oCon, oUrl, i

   oUrl := TUrl():New( cUrl )
   IF Empty( oUrl )
      ? "Invalid url " + cUrl
      ?
      QUIT
   ENDIF

   IF oUrl:cProto != "http"
      ? "This is a header test for http."
      ? "Use an http address."
      ?
      QUIT
   ENDIF

   oCon := TIPClientHTTP():New( oUrl )
   oCon:nConnTimeout := 20000
   ? "Connecting with", oUrl:cServer
   IF oCon:Open( cUrl )
      ? "Connection eshtablished"
      ? "Retreiving", oUrl:cPath, oUrl:cFile, oUrl:cQuery

      IF oCon:Get( oUrl:cPath )
         ? "Get Sucessful"
         FOR i := 1 TO Len( oCon:hHeaders )
            ? hb_HKeyAt( oCon:hHeaders, i ) + ":", hb_HValueAt( oCon:hHeaders, i )
         NEXT
      ELSE
         ? "Get failure (server reply:", oCon:cReply, ")"
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
