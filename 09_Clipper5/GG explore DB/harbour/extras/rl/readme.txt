/*
 * $Id: readme.txt 17291 2012-02-28 14:47:05Z vszakats $
 */

1.) Copy the full content of /SOURCE/RL from your original
    CA-Cl*pper installation to this directory.

2.) *nix users will need to convert original filenames to lowercase
    and EOLs to native format, using this command:
    hbformat -lFCaseLow=yes -nEol=0 -lIndent=no -lCase=no -lSpaces=no "*.prg"

3.) Apply supplied patch to the source using GNU Patch:
    patch -lNi rl.dif

4.) Build it:
    hbmk2 rl.hbp

5.) You're done.

[vszakats]
