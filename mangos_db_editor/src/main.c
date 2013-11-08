/* -*- Mode: C; indent-tabs-mode: t; c-basic-offset: 4; tab-width: 4 -*-  */
/*
 * main.c
 * Copyright (C) 2013 AndriusPC <andriuspc@andriuspc-MS-7529>
 *
 */

#include <config.h>
#include <gtk/gtk.h>
#include "mangos_db_editor.h"


#include <glib/gi18n.h>


int
main (int argc, char *argv[])
{
	Mangos_Db_Editor *app;
	int status;


#ifdef ENABLE_NLS
	bindtextdomain (GETTEXT_PACKAGE, PACKAGE_LOCALE_DIR);
	bind_textdomain_codeset (GETTEXT_PACKAGE, "UTF-8");
	textdomain (GETTEXT_PACKAGE);
#endif

	
	app = mangos_db_editor_new ();
	status = g_application_run (G_APPLICATION (app), argc, argv);
	g_object_unref (app);

	return status;
}

