/* -*- Mode: C; indent-tabs-mode: t; c-basic-offset: 4; tab-width: 4 -*-  */
/*
 * mangos_db_editor.h
 * Copyright (C) 2013 AndriusPC <andriuspc@andriuspc-MS-7529>
 * 
 */

#ifndef _MANGOS_DB_EDITOR_
#define _MANGOS_DB_EDITOR_

#include <gtk/gtk.h>

G_BEGIN_DECLS

#define MANGOS_DB_EDITOR_TYPE_APPLICATION             (mangos_db_editor_get_type ())
#define MANGOS_DB_EDITOR_APPLICATION(obj)             (G_TYPE_CHECK_INSTANCE_CAST ((obj), MANGOS_DB_EDITOR_TYPE_APPLICATION, Mangos_Db_Editor))
#define MANGOS_DB_EDITOR_APPLICATION_CLASS(klass)     (G_TYPE_CHECK_CLASS_CAST ((klass), MANGOS_DB_EDITOR_TYPE_APPLICATION, Mangos_Db_EditorClass))
#define MANGOS_DB_EDITOR_IS_APPLICATION(obj)          (G_TYPE_CHECK_INSTANCE_TYPE ((obj), MANGOS_DB_EDITOR_TYPE_APPLICATION))
#define MANGOS_DB_EDITOR_IS_APPLICATION_CLASS(klass)  (G_TYPE_CHECK_CLASS_TYPE ((klass), MANGOS_DB_EDITOR_TYPE_APPLICATION))
#define MANGOS_DB_EDITOR_APPLICATION_GET_CLASS(obj)   (G_TYPE_INSTANCE_GET_CLASS ((obj), MANGOS_DB_EDITOR_TYPE_APPLICATION, Mangos_Db_EditorClass))

typedef struct _Mangos_Db_EditorClass Mangos_Db_EditorClass;
typedef struct _Mangos_Db_Editor Mangos_Db_Editor;
typedef struct _Mangos_Db_EditorPrivate Mangos_Db_EditorPrivate;

struct _Mangos_Db_EditorClass
{
	GtkApplicationClass parent_class;
};

struct _Mangos_Db_Editor
{
	GtkApplication parent_instance;

	Mangos_Db_EditorPrivate *priv;

};

GType mangos_db_editor_get_type (void) G_GNUC_CONST;
Mangos_Db_Editor *mangos_db_editor_new (void);

/* Callbacks */

G_END_DECLS

#endif /* _APPLICATION_H_ */

