

-- tags table definition
CREATE TABLE IF NOT EXISTS `tags` (
	`id`			INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`name`			TEXT NOT NULL UNIQUE,
	`description`	TEXT,
	`created`		INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- songs table definition
CREATE TABLE IF NOT EXISTS `songs` (
	`id`				INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`song_name`			TEXT NOT NULL UNIQUE,
	`author_name`		TEXT NOT NULL,
	`filesystem_path`	TEXT NOT NULL,
	`created`			INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- songs_has_tags table definition (Vazebni tabulka - M:N relace)
CREATE TABLE IF NOT EXISTS `songs_has_tags` (
	`song_id`	INTEGER NOT NULL,
	`tag_id`	INTEGER NOT NULL,
	`created`	INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY(`song_id`,`tag_id`)
);