/*
 * $Id: isshare.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   LOCAL nLoaded := ft_IsShare()

   DO CASE
   CASE nLoaded == 0
      ? "Share not loaded, but ok to load"
   CASE nLoaded == 1
      ? "Share not loaded, but NOT ok to load!"
   CASE nLoaded == 255
      ? "Share is loaded!"
   ENDCASE

   ? "Retcode: " + Str( nLoaded )

   RETURN
