#
# $Id: Makefile 18789 2013-01-30 00:05:21Z druzus $
#

ROOT := ../

ifneq ($(HB_BUILD_PARTS),lib)

DIRS := \
   hbmk2 \

ifneq ($(HB_BUILD_PARTS),compiler)

   DIRS := \
      hbtest \
      hbmk2 \
      hbi18n \
      $(__HB_UTIL_ADDONS)

endif

endif

ifneq ($(DIRS),)
   include $(ROOT)config/dir.mk
else
   include $(ROOT)config/none.mk
endif
