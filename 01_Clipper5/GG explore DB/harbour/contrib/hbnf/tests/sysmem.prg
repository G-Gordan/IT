/*
 * $Id: sysmem.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   ? "Conventional memory: " + Str( ft_SysMem() ) + "K installed"

   RETURN
