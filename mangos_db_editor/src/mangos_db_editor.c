/* -*- Mode: C; indent-tabs-mode: t; c-basic-offset: 4; tab-width: 4 -*-  */
/*
 * mangos_db_editor.c
 * Copyright (C) 2013 AndriusPC <andriuspc@andriuspc-MS-7529>
 * 
 */
#include "mangos_db_editor.h"

#include <glib/gi18n.h>



/* For testing propose use the local (not installed) ui file */
/* #define UI_FILE PACKAGE_DATA_DIR"/ui/mangos_db_editor.ui" */
#define UI_FILE "src/mangos_db_editor.ui"
#define TOP_WINDOW "window"


G_DEFINE_TYPE (Mangos_Db_Editor, mangos_db_editor, GTK_TYPE_APPLICATION);


/* Define the private structure in the .c file */
#define MANGOS_DB_EDITOR_GET_PRIVATE(obj) (G_TYPE_INSTANCE_GET_PRIVATE((obj), MANGOS_DB_EDITOR_TYPE_APPLICATION, Mangos_Db_EditorPrivate))

struct _Mangos_Db_EditorPrivate
{
	/* ANJUTA: Widgets declaration for mangos_db_editor.ui - DO NOT REMOVE */
};


/* Create a new window loading a file */
static void
mangos_db_editor_new_window (GApplication *app,
                           GFile        *file)
{
	GtkWidget *window;

	GtkBuilder *builder;
	GError* error = NULL;

	Mangos_Db_EditorPrivate *priv = MANGOS_DB_EDITOR_GET_PRIVATE(app);

	/* Load UI from file */
	builder = gtk_builder_new ();
	if (!gtk_builder_add_from_file (builder, UI_FILE, &error))
	{
		g_critical ("Couldn't load builder file: %s", error->message);
		g_error_free (error);
	}

	/* Auto-connect signal handlers */
	gtk_builder_connect_signals (builder, app);

	/* Get the window object from the ui file */
	window = GTK_WIDGET (gtk_builder_get_object (builder, TOP_WINDOW));
        if (!window)
        {
		g_critical ("Widget \"%s\" is missing in file %s.",
				TOP_WINDOW,
				UI_FILE);
        }

	
	/* ANJUTA: Widgets initialization for mangos_db_editor.ui - DO NOT REMOVE */

	g_object_unref (builder);
	
	
	gtk_window_set_application (GTK_WINDOW (window), GTK_APPLICATION (app));
	if (file != NULL)
	{
		/* TODO: Add code here to open the file in the new window */
	}
	gtk_widget_show_all (GTK_WIDGET (window));
}


/* GApplication implementation */
static void
mangos_db_editor_activate (GApplication *application)
{
	mangos_db_editor_new_window (application, NULL);
}

static void
mangos_db_editor_open (GApplication  *application,
                     GFile        **files,
                     gint           n_files,
                     const gchar   *hint)
{
	gint i;

	for (i = 0; i < n_files; i++)
		mangos_db_editor_new_window (application, files[i]);
}

static void
mangos_db_editor_init (Mangos_Db_Editor *object)
{

}

static void
mangos_db_editor_finalize (GObject *object)
{
	G_OBJECT_CLASS (mangos_db_editor_parent_class)->finalize (object);
}

static void
mangos_db_editor_class_init (Mangos_Db_EditorClass *klass)
{
	G_APPLICATION_CLASS (klass)->activate = mangos_db_editor_activate;
	G_APPLICATION_CLASS (klass)->open = mangos_db_editor_open;

	g_type_class_add_private (klass, sizeof (Mangos_Db_EditorPrivate));

	G_OBJECT_CLASS (klass)->finalize = mangos_db_editor_finalize;
}

Mangos_Db_Editor *
mangos_db_editor_new (void)
{
	g_type_init ();

	return g_object_new (mangos_db_editor_get_type (),
	                     "application-id", "org.gnome.mangos_db_editor",
	                     "flags", G_APPLICATION_HANDLES_OPEN,
	                     NULL);
}

