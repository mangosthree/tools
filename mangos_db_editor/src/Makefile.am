## Process this file with automake to produce Makefile.in

## Created by Anjuta


uidir = $(pkgdatadir)/ui
ui_DATA = mangos_db_editor.ui


AM_CPPFLAGS = \
	-DPACKAGE_LOCALE_DIR=\""$(localedir)"\" \
	-DPACKAGE_SRC_DIR=\""$(srcdir)"\" \
	-DPACKAGE_DATA_DIR=\""$(pkgdatadir)"\" \
	$(MANGOS_DB_EDITOR_CFLAGS)

AM_CFLAGS =\
	 -Wall\
	 -g

bin_PROGRAMS = mangos_db_editor

mangos_db_editor_SOURCES = \
	main.c \
	mangos_db_editor.h \
	mangos_db_editor.c	

mangos_db_editor_LDFLAGS = \
	-Wl,--export-dynamic

mangos_db_editor_LDADD = $(MANGOS_DB_EDITOR_LIBS)


EXTRA_DIST = $(ui_DATA)

# Remove ui directory on uninstall
uninstall-local:
	-rm -r $(uidir)
	-rm -r $(pkgdatadir)

