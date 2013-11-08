## Process this file with automake to produce Makefile.in
## Created by Anjuta

SUBDIRS = src po

mangos_db_editordocdir = ${prefix}/doc/mangos_db_editor
mangos_db_editordoc_DATA = \
	README\
	COPYING\
	AUTHORS\
	ChangeLog\
	INSTALL\
	NEWS


INTLTOOL_FILES = intltool-extract.in \
	intltool-merge.in \
	intltool-update.in

EXTRA_DIST = $(mangos_db_editordoc_DATA) \
	$(INTLTOOL_FILES)

DISTCLEANFILES = intltool-extract \
	intltool-merge \
	intltool-update \
	po/.intltool-merge-cache


# Remove doc directory on uninstall
uninstall-local:
	-rm -r $(mangos_db_editordocdir)
