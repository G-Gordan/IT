#
# $Id: prg.mk 12148 2009-08-17 17:12:19Z vszakats $
#

PRG_C_SOURCES := $(PRG_SOURCES:.prg=.c)
PRG_OBJS := $(PRG_SOURCES:.prg=$(OBJ_EXT))
PRG_EXES := $(PRG_SOURCES:.prg=$(BIN_EXT))

PRG_MAIN_OBJ := $(PRG_MAIN:.prg=$(OBJ_EXT))

ALL_PRG_OBJS := $(PRG_OBJS) $(PRG_MAIN_OBJ)

$(PRG_OBJS) : %$(OBJ_EXT) : %.c

$(PRG_C_SOURCES) : %.c : $(GRANDP)%.prg
