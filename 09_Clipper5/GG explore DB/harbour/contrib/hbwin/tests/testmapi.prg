/*
 * $Id: testmapi.prg 18697 2012-11-29 00:30:07Z vszakats $
 */

#require "hbwin"

#include "simpleio.ch"

PROCEDURE Main()

   LOCAL cSubject := "Test subject"
   LOCAL cBody := "Test body"
   LOCAL lMailConf := .F.
   LOCAL lFromUser := .T.
   LOCAL aSender := { "test from", "from@test.com" }
   LOCAL aDest := { { "test to", "to@test.com", WIN_MAPI_TO } }
   LOCAL aFiles := { { __FILE__, "testmapi" } }

   ? win_MAPISendMail( ;
      cSubject,                        ; // subject
      cBody,                           ; // menssage
      NIL,                             ; // type of message
      DToS( Date() ) + " " + Time(),   ; // send date
      "",                              ; // conversation ID
      lMailConf,                       ; // acknowledgment
      lFromUser,                       ; // user intervention
      aSender,                         ; // sender
      aDest,                           ; // destinators
      aFiles                           ) // attach

   // simple format

   ? win_MAPISendMail( ;
      cSubject,                        ; // subject
      cBody,                           ; // menssage
      NIL,                             ; // type of message
      DToS( Date() ) + " " + Time(),   ; // send date
      "",                              ; // conversation ID
      lMailConf,                       ; // acknowledgment
      lFromUser,                       ; // user intervention
      "from@test.com",                 ; // sender
      { "to@test.com" },               ; // destinators
      { __FILE__ }                     ) // attach

   RETURN
