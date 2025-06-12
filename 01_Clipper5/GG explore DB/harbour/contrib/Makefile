#
# $Id: Makefile 17464 2012-05-08 16:06:24Z vszakats $
#

ROOT := ../

include $(ROOT)config/global.mk

ifneq ($(HB_NO_HBSCRIPT),yes)

first clean install::
	$(if $(wildcard $(HB_HOST_BIN_DIR)/hbmk2$(HB_HOST_BIN_EXT)),-$(HB_HOST_BIN_DIR)/hbmk2$(HB_HOST_BIN_EXT) $(TOP)$(ROOT)contrib/make.hb $@,@$(ECHO) $(ECHOQUOTE)! Warning: hbmk2 not found, contrib/make.hb skipped.$(ECHOQUOTE))

endif
