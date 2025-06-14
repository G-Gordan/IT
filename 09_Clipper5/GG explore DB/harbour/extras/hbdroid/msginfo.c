/*
 * $Id: msginfo.c 18523 2012-11-11 19:41:00Z vszakats $
 */

#include "hbapi.h"
#include "hbapistr.h"

#include "hbdroid.h"

HB_FUNC( JNI_MSGINFO )
{
   JNIEnv * jni_env = __hbdroid_jni_env();
   jobject  jni_obj = __hbdroid_jni_obj();

   if( jni_env && jni_obj )
   {
      jclass    cls = ( *jni_env )->GetObjectClass( jni_env, jni_obj );
      jmethodID mid = ( *jni_env )->GetMethodID( jni_env, cls, "MsgInfo", "(Ljava/lang/String;)V" );

      if( cls && mid )
      {
         void * hPar1;

         ( *jni_env )->CallVoidMethod( jni_env, jni_obj, mid, ( *jni_env )->NewStringUTF( jni_env, hb_parstr_utf8( 1, &hPar1, NULL ) ) );

         hb_strfree( hPar1 );
      }
   }
}
