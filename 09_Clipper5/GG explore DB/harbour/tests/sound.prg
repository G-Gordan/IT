/*
 * $Id: sound.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

PROCEDURE Main()

   LOCAL start := Seconds(), stop

   ? "start   ", start
   Tone( 440, 9.1 )
   Tone( 880, 9.1 )
   Tone( 440, 9.1 )
   stop := Seconds()
   ? "stop    ", stop
   ? "duration", ( stop - start ), "(should be close to 1.5)"

   RETURN
