'
' $Id: oletst2.vbs 18716 2012-12-03 13:52:22Z vszakats $
'

' Copyright 2010 Viktor Szakats (harbour syenar.net)
' www - http://harbour-project.org
'
' See COPYING.txt for licensing terms.

Dim tst2 : Set tst2 = WScript.CreateObject("MyOleTimeServer")

WScript.CreateObject("Wscript.Shell").Popup tst2.Time()
